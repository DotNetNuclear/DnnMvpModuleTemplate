/*
' Copyright (c) $year$ $ownername$
' $ownerwebsite$
' All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/
using System;
using System.Collections;
using DotNetNuke.Entities.Modules;

namespace $rootnamespace$$solutionname$.Components
{
    /// <summary>
    /// Implementation class for module settings data
    /// </summary>
    public class SettingsRepository : ISettingsRepository
    {
        /// <summary>
        /// </summary>
        public static bool SettingsChanged = false;

        private ModuleController _controller;
        private int _tabModuleId;

        /// <summary>
        /// </summary>
        public SettingsRepository(int tabModuleId)
        {
            _controller = new ModuleController();
            _tabModuleId = tabModuleId;
        }

        #region setting methods

        /// <summary>
        /// </summary>
        protected T ReadSetting<T>(string settingName, T defaultValue)
        {
            Hashtable settings = _controller.GetTabModuleSettings(_tabModuleId);

            T ret = default(T);

            if (settings.ContainsKey(settingName))
            {
                System.ComponentModel.TypeConverter tc = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
                try
                {
                    ret = (T)tc.ConvertFrom(settings[settingName]);
                }
                catch
                {
                    ret = defaultValue;
                }
            }
            else
                ret = defaultValue;

            return ret;
        }

        /// <summary>
        /// </summary>
        protected void WriteSetting(string settingName, string value)
        {
            _controller.UpdateTabModuleSetting(_tabModuleId, settingName, value);
            SettingsChanged = true;
        }

        #endregion

        #region public properties

        /// <summary>
        /// </summary>
        public int MaxItems
        {
            get { return ReadSetting<int>("MaxItems", 5); }
            set { WriteSetting("MaxItems", value.ToString()); }
        }

        #endregion

    }
}