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
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.Utilities;
using DotNetNuke.Web.Mvp;
using DotNetNuke.Web.Client.ClientResourceManagement;
using WebFormsMvp;

using $rootnamespace$$solutionname$.Components;
using $rootnamespace$$solutionname$.Models;
using $rootnamespace$$solutionname$.Presenters;

namespace $rootnamespace$$solutionname$.Views
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from DNNModule1ModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    [PresenterBinding(typeof(ViewPresenter))]
    public partial class View : ModuleView<Item>, IItemListView, IActionable
    {

        /// <summary>
        /// </summary>
        public event EventHandler<DeleteClickEventArgs> DeleteClick;
        public event EventHandler<ViewLoadEventArgs> ModuleLoad;

        /// <summary>
        /// </summary>
        public bool IsEditable { set; get; }

        /// <summary>
        /// </summary>
        public IEnumerable<Item> ItemList
        {
            get
            {
                return (IEnumerable<Item>)rptItemList.DataSource;
            }
            set
            {
                rptItemList.DataSource = value;
                rptItemList.DataBind();
            }
        }

        /// <summary>
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Send the ModuleLoad event of the Presenter
                var args = new ViewLoadEventArgs { IsPostBack = this.Page.IsPostBack };
                if (ModuleLoad != null) { ModuleLoad(this, args); }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }

            lblNoItems.Visible = (ItemList == null || !ItemList.Any());
        }

        /// <summary>
        /// </summary>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ClientResourceManager.RegisterStyleSheet(this.Page, this.ControlPath + "../Resources/css/view.css");
            ClientResourceManager.RegisterScript(this.Page, this.ControlPath + "../Resources/js/view.js");
        }

        /// <summary>
        /// </summary>
        protected void rptItemListOnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var lnkEdit = e.Item.FindControl("lnkEdit") as HyperLink;
                var lnkDelete = e.Item.FindControl("lnkDelete") as LinkButton;

                var pnlAdminControls = e.Item.FindControl("pnlAdmin") as Panel;

                var t = (Item)e.Item.DataItem;

                if (IsEditable && lnkDelete != null && lnkEdit != null && pnlAdminControls != null)
                {
                    pnlAdminControls.Visible = true;
                    lnkDelete.CommandArgument = t.ItemId.ToString();
                    lnkDelete.Enabled = lnkDelete.Visible = lnkEdit.Enabled = lnkEdit.Visible = true;

                    lnkEdit.NavigateUrl = base.ModuleContext.EditUrl(string.Empty, string.Empty, "Edit", "itemid=" + t.ItemId);

                    ClientAPI.AddButtonConfirm(lnkDelete, Localization.GetString("ConfirmDelete", LocalResourceFile));
                }
                else
                {
                    pnlAdminControls.Visible = false;
                }
            }
        }

        /// <summary>
        /// </summary>
        public void rptItemListOnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect(base.ModuleContext.EditUrl(string.Empty, string.Empty, "Edit", "itemid=" + e.CommandArgument));
            }

            if (e.CommandName == "Delete")
            {
                var args = new DeleteClickEventArgs
                {
                    ItemId = Convert.ToInt32(e.CommandArgument)
                };
                // send over to the presenter
                if (DeleteClick != null) { DeleteClick(this, args); }
            }
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }

        ///// <summary>
        ///// </summary>
        public ModuleActionCollection ModuleActions
        {
            get
            {
                return new ModuleActionCollection
                {
                    // Add the edit action item for people with edit permissions
                    {
                        this.ModuleContext.GetNextActionID(), LocalizeString("EditModule.Text"),
                        string.Empty, string.Empty, string.Empty, this.ModuleContext.EditUrl(), false, SecurityAccessLevel.Edit, true, false
                    }
                };
            }
        }
    }
}