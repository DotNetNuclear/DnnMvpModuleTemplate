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
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Users;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Web.Mvp;

using $rootnamespace$$solutionname$.Components;
using $rootnamespace$$solutionname$.Models;
using $rootnamespace$$solutionname$.Views;

namespace $rootnamespace$$solutionname$.Presenters
{
    /// <summary>
    /// ItemPresenter - presenter object for an item
    /// </summary>
    public class EditPresenter : ModulePresenter<IItemView, Item>
    {
        private IItemRepository _repository;
        private ISettingsRepository _settings;

        /// <summary>
        /// </summary>
        public IItemRepository ItemRepository
        {
            get { return _repository; }
            set { _repository = value; }
        }

        /// <summary>
        /// </summary>
        public ISettingsRepository SettingsRepository
        {
            get { return _settings; }
            set { _settings = value; }
        }

        /// <summary>
        /// </summary>
        public EditPresenter(IItemView view)
            : base(view)
        {
            _repository = new ItemRepository();
            if (base.ModuleContext != null)
            {
                _settings = new SettingsRepository(base.ModuleContext.TabModuleId);
            }
            this.View.SaveClick += Save;
            this.View.ModuleLoad += ModuleLoad;
        }

        /// <summary>
        /// </summary>
        public void Save(object sender, SaveClickEventArgs args)
        {
            Item saveItem = new Item();
            try
            {
                //Update Model
                if (base.View.ItemId != 0)
                {
                    saveItem = (Item)_repository.GetItem(base.View.ItemId, base.ModuleId);
                }
                else
                {
                    saveItem.CreatedOnDate = DateTime.Now;
                    saveItem.CreatedByUserId = base.UserId;
                }
                saveItem.ItemName = base.View.ItemName;
                saveItem.ItemDescription = base.View.ItemDescription;
                saveItem.AssignedUserId = base.View.AssignedUserId;
                saveItem.LastModifiedOnDate = DateTime.Now;
                saveItem.LastModifiedByUserId = base.UserId;
                saveItem.ModuleId = base.ModuleId;
                if (base.View.ItemId == 0)
                {
                    _repository.CreateItem(saveItem);
                }
                else
                {
                    _repository.UpdateItem(saveItem);
                }
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex);
            }
        }

        /// <summary>
        /// </summary>
        public void ModuleLoad(object sender, Views.EditLoadEventArgs args)
        {
            if (!args.IsPostBack)
            {
                if (args.ItemId > 0)
                {
                    Item item = _repository.GetItem(args.ItemId, base.ModuleId);

                    // Update view
                    base.View.ItemId = item.ItemId;
                    base.View.ItemName = item.ItemName;
                    base.View.ItemDescription = item.ItemDescription;
                    base.View.AssignedUserId = item.AssignedUserId;
                }
                else
                {
                    base.View.ItemId = 0;
                }
                base.View.PortalUserList = UserController.GetUsers(base.PortalId);
            }
        }

    }
}