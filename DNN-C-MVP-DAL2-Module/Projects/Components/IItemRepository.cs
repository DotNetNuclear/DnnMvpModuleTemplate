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

using $rootnamespace$$solutionname$.Models;

namespace $rootnamespace$$solutionname$.Components
{
    public interface IItemRepository
    {
        ///<summary>
        /// CreateItem
        ///</summary>
        void CreateItem(Item t);

        ///<summary>
        /// DeleteItem
        ///</summary>
        void DeleteItem(int itemId, int moduleId);

        ///<summary>
        /// DeleteItem
        ///</summary>
        void DeleteItem(Item t);

        ///<summary>
        /// GetItems
        ///</summary>
        IEnumerable<Item> GetItems(int moduleId);

        ///<summary>
        /// GetItems
        ///</summary>
        Item GetItem(int itemId, int moduleId);

        ///<summary>
        /// GetItemCount
        ///</summary>
        int GetItemCount(int moduleId);

        ///<summary>
        /// UpdateItem
        ///</summary>
        void UpdateItem(Item t);

    }
}
