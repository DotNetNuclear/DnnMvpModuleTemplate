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
using DotNetNuke.Web.Mvp;

namespace $rootnamespace$$solutionname$.Views
{
    /// <summary>
    /// IItemView - interface for the item detail view
    /// </summary>
    public interface IItemView : IModuleView<Models.Item>
    {
        /// <summary>
        /// </summary>
        int ItemId { set; get; }
        /// <summary>
        /// </summary>
        string ItemName { set; get; }
        /// <summary>
        /// </summary>
        string ItemDescription { set; get; }
        /// <summary>
        /// </summary>
        int AssignedUserId { set; get; }
        /// <summary>
        /// </summary>
        System.Collections.ArrayList PortalUserList { set; get; }

        event System.EventHandler<EditLoadEventArgs> ModuleLoad;
        event System.EventHandler<SaveClickEventArgs> SaveClick;
    }

    public class SaveClickEventArgs : System.EventArgs
    {
    }

    public class EditLoadEventArgs : System.EventArgs
    {
        public bool IsPostBack { set; get; }
        public int ItemId { set; get; }
    }  

}
