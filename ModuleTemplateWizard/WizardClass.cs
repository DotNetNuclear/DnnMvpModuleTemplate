using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using EnvDTE;
using EnvDTE80;
using EnvDTE90;
using Microsoft.VisualStudio.TemplateWizard;


namespace ModuleTemplateWizard
{
    public class WizardClass : IWizard
    {
        private const int MIN_TIME_FOR_PROJECT_TO_RELEASE_FILE_LOCK = 700;
        private const int MIN_TIME_FOR_DIRECTORY_CREATE_RELEASE = 700;

        private ProjectCustomProps _wizardFrm;
        private Dictionary<string, string> _replacementsDictionary;
        private EnvDTE._DTE dte;
        private WizardRunKind _runKind;

        private static Project _moduleProject;
        private static Project _testProject;
        private static string _solutionName;
        private static string _rootnamespace;
        private static string _ownername;
        private static string _owneremail;
        private static string _ownerwebsite;
        private static string _devenvironmenturl;
        private static string _useiisexpress;
        //private static string _msbuildSrcFolder;

        public void BeforeOpeningFile(ProjectItem projectItem)
        {

        }

        public void ProjectFinishedGenerating(Project project)
        {
            if (project != null && project.Name == "Module")
            {
                _moduleProject = MoveProjectTo("\\Module\\", project, "\\");
            }
            else if (project != null && project.Name == "Tests")
            {
                _testProject = project;
            }
            else if (project == null && _moduleProject != null)
            {
                appendProjectReference(_testProject, _moduleProject);
            }
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        public void RunFinished()
        {
            if (_runKind == WizardRunKind.AsMultiProject)
            {
                DeleteSuoFile();

                MoveSolutionFileToProjectsDirectory();
            }
        }

        public void RunStarted(object automationObject, 
                        Dictionary<string, string> replacementsDictionary, 
                        WizardRunKind runKind, object[] customParams)
        {
            try
            {
                this.dte = automationObject as EnvDTE._DTE;
                this._replacementsDictionary = replacementsDictionary;
                this._runKind = runKind;

                // Store the solution name locally while processing the solution template
                if (_runKind == WizardRunKind.AsMultiProject)
                {
                    _solutionName = replacementsDictionary["$safeprojectname$"];

                    //Call win form created in the project to accept user input
                    _wizardFrm = new ProjectCustomProps();

                    if (replacementsDictionary.ContainsKey("$rootnamespace$")) {
                        _wizardFrm.RootNamespace = replacementsDictionary["$rootnamespace$"];
                    }
                    if (replacementsDictionary.ContainsKey("$ownername$")) {
                        _wizardFrm.OwnerName = replacementsDictionary["$ownername$"];
                    }
                    if (replacementsDictionary.ContainsKey("$owneremail$")) {
                        _wizardFrm.OwnerEmail = replacementsDictionary["$owneremail$"];
                    }
                    if (replacementsDictionary.ContainsKey("$ownerwebsite$")) {
                        _wizardFrm.OwnerWebsite = replacementsDictionary["$ownerwebsite$"];
                    }
                    if (replacementsDictionary.ContainsKey("$devenvironmenturl$")) {
                        _wizardFrm.DevelopmentUrl = replacementsDictionary["$devenvironmenturl$"];
                    }
                    if (replacementsDictionary.ContainsKey("$useiisexpress$")) {
                        _wizardFrm.UseIISExpress = Convert.ToBoolean(replacementsDictionary["$useiisexpress$"]);
                    } 
                    _wizardFrm.RefreshTextValues();
                    _wizardFrm.ShowDialog();

                    if (_wizardFrm.CancelWizard)
                    {
                        throw new WizardCancelledException();
                    }

                    // Add custom parameters.
                    _rootnamespace = _wizardFrm.RootNamespace;
                    _ownername = _wizardFrm.OwnerName;
                    _owneremail = _wizardFrm.OwnerEmail;
                    _ownerwebsite = _wizardFrm.OwnerWebsite;
                    _devenvironmenturl = _wizardFrm.DevelopmentUrl;
                    _useiisexpress = _wizardFrm.UseIISExpress.ToString();
                }
                updateReplacementDictionaryItem("$solutionname$", _solutionName);
                updateReplacementDictionaryItem("$rootnamespace$", _rootnamespace);
                updateReplacementDictionaryItem("$ownername$", _ownername);
                updateReplacementDictionaryItem("$owneremail$", _owneremail);
                updateReplacementDictionaryItem("$ownerwebsite$", _ownerwebsite);
                updateReplacementDictionaryItem("$devenvironmenturl$", _devenvironmenturl);
                updateReplacementDictionaryItem("$useiisexpress$", _useiisexpress);
            }
            catch (Exception ex)
            {
                if (!(ex is WizardCancelledException))
                {
                    MessageBox.Show(ex.ToString());
                }
                else
                {
                    throw new WizardCancelledException("User cancelled template wizard");
                }
            }
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        private void updateReplacementDictionaryItem(string itemKey, string value)
        {
            try
            {
                if (_replacementsDictionary.ContainsKey(itemKey))
                {
                    _replacementsDictionary[itemKey] = value;
                }
                else 
                {
                    _replacementsDictionary.Add(itemKey, value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MoveSolutionFileToProjectsDirectory()
        {
            dte.Solution.SaveAs(
                GetSolutionRootPath() + GetSolutionName() + "\\" + GetSolutionFileName());
        }

        private void DeleteSuoFile()
        {
            string suoFile = GetSolutionRootPath() + GetSolutionName() + ".suo";

            if (File.Exists(suoFile))
            {
                File.Delete(suoFile);
            }
        }

        private Project MoveProjectTo(string targetSubFolder, EnvDTE.Project project, string solutionFolderName)
        {
            string projectName = project.Name;
            string originalLocation = GetSolutionRootPath() + GetSolutionName() + "\\" + projectName;

            if (Directory.Exists(originalLocation))
            {
                Solution2 solution = dte.Solution as Solution2;

                solution.Remove(project);

                // Give the solution time to release the lock on the project file
                System.Threading.Thread.Sleep(MIN_TIME_FOR_PROJECT_TO_RELEASE_FILE_LOCK);

                string targetLocation = GetSolutionRootPath() + GetSolutionName();

                moveFolderContentsToFolder(originalLocation, targetLocation, true);

                return solution.AddFromFile(targetLocation + "\\" + _solutionName + ".csproj", false);
            }
            else
            {
                throw new ApplicationException("Couldn't find " + originalLocation + " to move");
            }
        }

        private void moveFolderContentsToFolder(string srcContentsFolder, string destRootFolder, bool deleteSrcDir)
        {
            try
            {
                //Move all of the source content folder's subdirectories
                foreach (string dirPath in Directory.GetDirectories(srcContentsFolder, "*", SearchOption.TopDirectoryOnly))
                {
                    string sFolderName = dirPath.ToLower().Substring(dirPath.LastIndexOf("\\")+1);
                    if (!("debug|obj".Contains(sFolderName)))
                    {
                        Directory.Move(dirPath, dirPath.Replace(srcContentsFolder, destRootFolder));
                    }
                }

                //Move all of the source content folder's files
                foreach (string newPath in Directory.GetFiles(srcContentsFolder, "*.*", SearchOption.TopDirectoryOnly))
                {
                    string sFileName = newPath.Substring(newPath.LastIndexOf("\\") + 1);
                    if (sFileName.Contains("Module.csproj"))
                    {
                        File.Move(newPath, newPath.Replace(srcContentsFolder, destRootFolder)
                                        .Replace("\\Module.", "\\"+_solutionName+"."));
                    }
                    else
                    {
                        File.Move(newPath, newPath.Replace(srcContentsFolder, destRootFolder));
                    }
                }

                //Delete source content folder
                if (deleteSrcDir)
                {
                    Directory.Delete(srcContentsFolder, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// </summary>
        private VSLangProj.Reference appendProjectReference(Project srcProject, Project refProject)
        {
            // Add project reference
            VSLangProj.VSProject theVSProject = (VSLangProj.VSProject)srcProject.Object;            
            return theVSProject.References.AddProject(refProject);
        }

        private string GetSolutionName()
        {
            return _replacementsDictionary["$solutionname$"];
        }

        private string GetSolutionFileName()
        {
            return GetSolutionName() + ".sln";
        }

        private string GetSolutionFileFullName()
        {
            return dte.Solution.Properties.Item("Path").Value.ToString();
        }

        private string GetSolutionRootPath()
        {
            return GetSolutionFileFullName().Replace(GetSolutionFileName(), "");
        }
    }
}
