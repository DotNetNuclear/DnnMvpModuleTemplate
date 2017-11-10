using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuleTemplateWizard
{
    public partial class ProjectCustomProps : Form
    {
        private bool _cancelwizard;
        private bool _finishclicked;
        private bool _iisExpress;
        private string _rootnamespace;
        private string _ownername;
        private string _owneremail;
        private string _ownerwebsite;
        private string _devurl;

        public bool CancelWizard
        {
            get { return _cancelwizard; }
            set { _cancelwizard = value; }
        }
        public string RootNamespace 
        {
            get { return _rootnamespace; } 
            set { _rootnamespace = value; } 
        }
        public string OwnerName
        {
            get { return _ownername; }
            set { _ownername = value; }
        }
        public string OwnerEmail
        {
            get { return _owneremail; }
            set { _owneremail = value; }
        }
        public string OwnerWebsite
        {
            get { return _ownerwebsite; }
            set { _ownerwebsite = value; }
        }
        public string DevelopmentUrl
        {
            get { return _devurl; }
            set { _devurl = value; }
        }
        public bool UseIISExpress
        {
            get { return _iisExpress; }
            set { _iisExpress = value; }
        }

        public ProjectCustomProps()
        {
            InitializeComponent();

            _rootnamespace = global::ModuleTemplateWizard.Properties.Resources.Default_RootNamespace;
            _ownername = global::ModuleTemplateWizard.Properties.Resources.Default_OwnerName;
            _owneremail = global::ModuleTemplateWizard.Properties.Resources.Default_OwnerEmail;
            _ownerwebsite = global::ModuleTemplateWizard.Properties.Resources.Default_OwnerWebsite;
            _devurl = global::ModuleTemplateWizard.Properties.Resources.DefaultDevUrl;
            _iisExpress = Convert.ToBoolean(global::ModuleTemplateWizard.Properties.Resources.UseIISExpress);

            RefreshTextValues();
        }

        public void RefreshTextValues()
        {
            this.txtRootNamespace.Text = _rootnamespace;
            this.txtOwnerName.Text = _ownername;
            this.txtOwnerEmail.Text = _owneremail;
            this.txtOwnerWebsite.Text = _ownerwebsite;
            this.txtDevUrl.Text = _devurl;

            rbIISExpress.Checked = _iisExpress;
            rbIIS.Checked = (!_iisExpress);

            refreshUrlExample();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            _rootnamespace = txtRootNamespace.Text;
            _rootnamespace = (_rootnamespace.EndsWith(".") ? _rootnamespace : _rootnamespace + ".");
            _ownername = txtOwnerName.Text;
            _owneremail = txtOwnerEmail.Text;
            _ownerwebsite = txtOwnerWebsite.Text;
            _iisExpress = rbIISExpress.Checked;
            _devurl = validUrl(txtDevUrl.Text);
            if (String.IsNullOrEmpty(_devurl))
            {
                MessageBox.Show("Webserver Url is in incorrect format, see example and correct.", "MVP Template Properties", MessageBoxButtons.OK);
            }
            else
            {
                _finishclicked = true;
                this.Dispose();
            }
        }

        private void ProjectCustomProps_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_finishclicked)
            {
                if (MessageBox.Show("Are you sure you want to cancel?", "DotNetNuclear DNN Template",
                   MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    // Cancel the Closing event from closing the form.
                    e.Cancel = true;
                }
                else { _cancelwizard = true; }
            }
        }

        private void rbIIS_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIIS.Checked)
            {
                txtDevUrl.Text = global::ModuleTemplateWizard.Properties.Resources.DefaultDevUrl;
                refreshUrlExample();
            }
        }

        private void rbIISExpress_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIISExpress.Checked)
            {
                txtDevUrl.Text = global::ModuleTemplateWizard.Properties.Resources.DefaultIISExpressUrl;
                refreshUrlExample();
            }
        }

        private string validUrl(string url)
        {
            try
            {
                string validUrl = "";
                var vUrl = new Uri(url.ToLower());
                if (vUrl.Scheme.Equals("http") || vUrl.Scheme.Equals("https"))
                {
                    validUrl = vUrl.ToString();
                    if (validUrl.EndsWith("/"))
                    {
                        validUrl = validUrl.Substring(0, validUrl.LastIndexOf("/"));
                    }
                }
                return validUrl;
            }
            catch
            {
                return "";
            }
        }

        private void refreshUrlExample()
        {
            lblExampleUrl.Text = String.Format("Example: {0}", txtDevUrl.Text);
        }

    }
}
