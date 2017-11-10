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
using System.Collections.Generic;
using DotNetNuke.Web.Mvp;

namespace $rootnamespace$$solutionname$.Views
{
    /// <summary>
    /// IItemListView - interface for the item detail view
    /// </summary>
    public interface IItemListView : IModuleView<Models.Item>
    {
        /// <summary>
        /// </summary>
        bool IsEditable { set; get; }
        /// <summary>
        /// </summary>
        IEnumerable<Models.Item> ItemList { set; get; }

        event System.EventHandler<DeleteClickEventArgs> DeleteClick;
        event System.EventHandler<ViewLoadEventArgs> ModuleLoad;
    }

    public class DeleteClickEventArgs : System.EventArgs
    {
        public int ItemId { get; set; }
        public int ModuleId { get; set; }
    }

    public class ViewLoadEventArgs : System.EventArgs
    {
        public bool IsPostBack { set; get; }
    }    
}
