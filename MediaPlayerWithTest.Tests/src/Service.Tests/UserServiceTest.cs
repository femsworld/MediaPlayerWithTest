using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerWithTest.Core.src.RepositoryInterface;
using MediaPlayerWithTest.Service.src.Service;
using Moq;
using Xunit;

namespace MediaPlayerWithTest.Tests.src.Service.Tests
{
    public class UserServiceTest
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

    [Fact]
        public void AddNewList_ValidData_CallsRepositoryAddNewList()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);
            var name = "My List";
            var userId = 1;
            userService.AddNewList(name, userId);
            userRepositoryMock.Verify(x => x.AddNewList(name, userId), Times.Once);
        }

        [Fact]
        public void EmptyOneList_ValidData_CallsRepositoryEmptyOneList()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);
            var listId = 1;
            var userId = 1;
            userService.EmptyOneList(listId, userId);
            userRepositoryMock.Verify(x => x.EmptyOneList(listId, userId), Times.Once);
        }

        [Fact]
        public void GetAllList_ValidData_CallsRepositoryGetAllList()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);
            var userId = 1;
            userService.GetAllList(userId);
            userRepositoryMock.Verify(x => x.GetAllList(userId), Times.Once);
        }

        [Fact]
        public void GetListById_ValidData_CallsRepositoryGetListById()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);
            var listId = 1;
            userService.GetListById(listId);
            userRepositoryMock.Verify(x => x.GetListById(listId), Times.Once);
        }

        [Fact]
        public void RemoveAllLists_ValidData_CallsRepositoryRemoveAllLists()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);
            var userId = 1;
            userService.RemoveAllLists(userId);
            userRepositoryMock.Verify(x => x.RemoveAllLists(userId), Times.Once);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        public void RemoveOneList_ValidData_CallsRepositoryRemoveOneList(int listId, int userId)
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);
            userService.RemoveOneList(listId, userId);
            userRepositoryMock.Verify(x => x.RemoveOneList(listId, userId), Times.Once);
        }

    }
}