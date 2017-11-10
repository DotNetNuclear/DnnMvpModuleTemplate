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
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Web.Client.ClientResourceManagement;
using DotNetNuke.Web.Mvp;
using WebFormsMvp;

using $rootnamespace$$solutionname$.Components;
using $rootnamespace$$solutionname$.Presenters;
using $rootnamespace$$solutionname$.Models;

namespace $rootnamespace$$solutionname$.Views
{
    /// -----------------------------------------------------------------------------
    /// <summary>   
    /// The Edit class is used to manage content
    /// 
    /// Typically your edit control would be used to create new content, or edit existing content within your module.
    /// The ControlKey for this control is "Edit", and is defined in the manifest (.dnn) file.
    /// 
    /// Because the control inherits from DNNModule1ModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    [PresenterBinding(typeof(EditPresenter))]
    public partial class Edit : ModuleView<Item>, IItemView
    {
        /// <summary>
        /// </summary>
        //protected EditPresenter presenter;

        #region IItemView Properties

        public event EventHandler<SaveClickEventArgs> SaveClick;
        public event EventHandler<EditLoadEventArgs> ModuleLoad;

        /// <summary>
        /// </summary>
        public int ItemId
        {
            get
            {
                try { return Convert.ToInt32(ViewState["DNNModule1_ItemID"]); }
                catch { return 0; }
            }
            set
            {
                ViewState["DNNModule1_ItemID"] = value;
            }
        }

        /// <summary>
        /// </summary>
        public string ItemName
        {
            get { return txtName.Text; }
            set { this.txtName.Text = value; }
        }

        /// <summary>
        /// </summary>
        public string ItemDescription
        {
            get { return txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        /// <summary>
        /// </summary>
        public int AssignedUserId
        {
            get { return Convert.ToInt32(ddlAssignedUser.SelectedValue); }
            set
            {
                try { ddlAssignedUser.Items.FindByValue(value.ToString()).Selected = true; }
                catch { }
            }
        }

        /// <summary>
        /// </summary>
        public System.Collections.ArrayList PortalUserList
        {
            get { return (System.Collections.ArrayList)ddlAssignedUser.DataSource; }
            set
            {
                try
                {
                    ddlAssignedUser.DataSource = value;
                    ddlAssignedUser.DataTextField = "Username";
                    ddlAssignedUser.DataValueField = "UserId";
                    ddlAssignedUser.DataBind();
                }
                catch { }
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int itemId = 0;
            try
            {
                this.btnSubmit.Click += SaveButtonClick;

                if (Request.QueryString["itemid"] != null)
                {
                    Int32.TryParse(Request.QueryString["itemid"], out itemId);
                }

                // send to presenter
                var args = new EditLoadEventArgs 
                { 
                    ItemId = itemId,
                    IsPostBack = this.Page.IsPostBack 
                };
                if (ModuleLoad != null) { ModuleLoad(this, args); }

            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        /// <summary>
        /// </summary>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ClientResourceManager.RegisterStyleSheet(this.Page, this.ControlPath + "../Resources/css/edit.css");
        }

        public void SaveButtonClick(object sender, EventArgs e)
        {
            // validate the page
            if (!Page.IsValid)
                return;

            // pluck off the values we need from the form
            var args = new SaveClickEventArgs
            {
            };

            // send over to the presenter
            if (SaveClick != null)
            {
                SaveClick(this, args);
            }
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }

    }
}