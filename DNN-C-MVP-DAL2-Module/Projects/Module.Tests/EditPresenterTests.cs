using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using $rootnamespace$$solutionname$.Components;
using $rootnamespace$$solutionname$.Models;
using $rootnamespace$$solutionname$.Presenters;
using $rootnamespace$$solutionname$.Views;

namespace $rootnamespace$$solutionname$.Tests
{
    [TestClass]
    public class EditPresenterTests
    {
        [TestMethod]
        public void Save_CreateNewItem_ItemAddedToRepository()
        {
            // Arrange
            var mockStore = _MockStores.ItemRepositoryFake();
            var mockView = ItemViewFake(0);
            var presenter = new EditPresenter(mockView.Object);

            // Act
            presenter.ItemRepository = mockStore.Object;
            presenter.SettingsRepository = _MockStores.ModuleSettingsFake().Object;
            presenter.Save(null, null);

            // Assert
            Assert.IsTrue(mockStore.Object.GetItems(0).Count() == 1); //New item is added to the repository
        }

        public Mock<IItemView> ItemViewFake(int itemId)
        {
            var mock = new Mock<IItemView>();
            mock.Setup(x => x.AssignedUserId).Returns(0);
            mock.Setup(x => x.ItemDescription).Returns(String.Format("Item {0} in Module 1", itemId));
            mock.Setup(x => x.ItemId).Returns(itemId);
            mock.Setup(x => x.ItemName).Returns(String.Format("Item {0}", itemId));
            mock.Setup(x => x.PortalUserList).Returns(new ArrayList() { "User1", "User2" });
            return mock;
        }

    }
}