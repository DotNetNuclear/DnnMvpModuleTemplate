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
using DotNetNuke.Web.Mvp;

using $rootnamespace$$solutionname$.Components;

namespace $rootnamespace$$solutionname$.Presenters
{
    /// <summary>
    /// ItemListPresenter - presenter object for a list of items
    /// </summary>
    public class ViewPresenter : ModulePresenter<Views.IItemListView, Models.Item>
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
        public ViewPresenter(Views.IItemListView view)
            : base(view)
        {
            _repository = new ItemRepository();
            if (base.ModuleContext != null)
            {
                _settings = new SettingsRepository(base.ModuleContext.TabModuleId);
            }
            this.View.DeleteClick += Delete;
            this.View.ModuleLoad += ModuleLoad;
        }

        /// <summary>
        /// </summary>
        public void Delete(object sender, Views.DeleteClickEventArgs args)
        {
            int moduleId = (args.ModuleId > 0 ? args.ModuleId : base.ModuleId);

            //Only delete an item belonging to the current module
            Models.Item delItem = _repository.GetItem(args.ItemId, moduleId);

            if (delItem != null && delItem.ModuleId == moduleId)
            {
                //Update Model
                _repository.DeleteItem(args.ItemId, moduleId);
            }
        }

        /// <summary>
        /// </summary>
        public void ModuleLoad(object sender, Views.ViewLoadEventArgs args)
        {
            if (!args.IsPostBack)
            {
                base.View.ItemList = _repository.GetItems(base.ModuleId);
                base.View.IsEditable = base.ModuleContext.IsEditable;
            }
        }

    }
}