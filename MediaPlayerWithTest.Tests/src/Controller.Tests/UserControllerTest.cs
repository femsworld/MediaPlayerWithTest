using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerWithTest.Controller.src;
using MediaPlayerWithTest.Service.src.ServiceInterface;
using Moq;
using Xunit;

namespace MediaPlayerWithTest.Tests.src.Controller.Tests
{
    public class UserControllerTest
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
        public static IEnumerable<object[]> ListData =>
            new List<object[]>
            {
                new object[] { "List 1", 1 },
                new object[] { "List 2", 2 },
                new object[] { "List 3", 3 }
            };

        [Fact]
        public void AddNewList_ValidData_CallsAddNewListInUserService()
        {
            var userServiceMock = new Mock<IUserService>();
            var userController = new UserController(userServiceMock.Object);
            var name = "Test List";
            var userId = 1;
            userController.AddNewList(name, userId);
            userServiceMock.Verify(
                service => service.AddNewList(name, userId),
                Times.Once
            );
        }

        [Fact]
        public void EmptyOneList_ValidData_CallsEmptyOneListInUserService()
        {
            var userServiceMock = new Mock<IUserService>();
            var userController = new UserController(userServiceMock.Object);
            var listId = 1;
            var userId = 1;
            userController.EmptyOneList(listId, userId);
            userServiceMock.Verify(
                service => service.EmptyOneList(listId, userId),
                Times.Once
            );
        }

        [Fact]
        public void GetAllList_ValidUserId_CallsGetAllListInUserService()
        {
            var userServiceMock = new Mock<IUserService>();
            var userController = new UserController(userServiceMock.Object);
            var userId = 1;
            userController.GetAllList(userId);
            userServiceMock.Verify(
                service => service.GetAllList(userId),
                Times.Once
            );
        }

        [Fact]
        public void GetListById_ValidListId_CallsGetListByIdInUserService()
        {
            var userServiceMock = new Mock<IUserService>();
            var userController = new UserController(userServiceMock.Object);
            var listId = 1;
            userController.GetListById(listId);
            userServiceMock.Verify(
                service => service.GetListById(listId),
                Times.Once
            );
        }

        [Fact]
        public void RemoveAllLists_ValidUserId_CallsRemoveAllListsInUserService()
        {
            var userServiceMock = new Mock<IUserService>();
            var userController = new UserController(userServiceMock.Object);
            var userId = 1;
            userController.RemoveAllLists(userId);
            userServiceMock.Verify(
                service => service.RemoveAllLists(userId),
                Times.Once
            );
        }

        [Theory]
        [MemberData(nameof(ListData))]
        public void RemoveOneList_ValidData_CallsRemoveOneListInUserService(string name, int userId)
        {
            var userServiceMock = new Mock<IUserService>();
            var userController = new UserController(userServiceMock.Object);
            var listId = 1;
            userController.RemoveOneList(listId, userId);
            userServiceMock.Verify(
                service => service.RemoveOneList(listId, userId),
                Times.Once
            );
        }
    }
}