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
    public class PlayListControllerTest
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        public PlayListControllerTest()
        {
        }

        public static IEnumerable<object[]> FileData =>
            new List<object[]>
            {
                new object[] { 1, 1, 1 },
                new object[] { 2, 2, 2 },
                new object[] { 3, 3, 3 }
            };

        [Fact]
        public void AddNewFile_ValidData_CallsAddNewFileInPlayListService()
        {
            var playListServiceMock = new Mock<IPlayListService>();
            var playListController = new PlayListController(playListServiceMock.Object);
            var playListId = 1;
            var fileId = 1;
            var userId = 1;
            playListController.AddNewFile(playListId, fileId, userId);
            playListServiceMock.Verify(
                service => service.AddNewFile(playListId, fileId, userId),
                Times.Once
            );
        }

        [Fact]
        public void AddNewFile_InvalidData_DoesNotCallAddNewFileInPlayListService()
        {
            var playListServiceMock = new Mock<IPlayListService>();
            var playListController = new PlayListController(playListServiceMock.Object);
            var playListId = 0;
            var fileId = 0;
            var userId = 0;
            playListController.AddNewFile(playListId, fileId, userId);
            playListServiceMock.Verify(
                service => service.AddNewFile(playListId, fileId, userId),
                Times.Never
                 );
        }

        [Fact]
        public void EmptyList_ValidData_CallsEmptyListInPlayListService()
        {
            var playListServiceMock = new Mock<IPlayListService>();
            var playListController = new PlayListController(playListServiceMock.Object);
            var playListId = 1;
            var userId = 1;
            playListController.EmptyList(playListId, userId);
            playListServiceMock.Verify(
                service => service.EmptyList(playListId, userId),
                Times.Once
            );
        }

        [Fact]
        public void EmptyList_InvalidData_DoesNotCallEmptyListInPlayListService()
        {
            var playListServiceMock = new Mock<IPlayListService>();
            var playListController = new PlayListController(playListServiceMock.Object);
            var playListId = 0;
            var userId = 0;
            playListController.EmptyList(playListId, userId);
            playListServiceMock.Verify(
                service => service.EmptyList(playListId, userId),
                Times.Never
            );
        }

        [Theory]
        [MemberData(nameof(FileData))]
        public void RemoveFile_ValidData_CallsRemoveFileInPlayListService(int playListId, int fileId, int userId)
        {
            var playListServiceMock = new Mock<IPlayListService>();
            var playListController = new PlayListController(playListServiceMock.Object);
            playListController.RemoveFile(playListId, fileId, userId);
            playListServiceMock.Verify(
                service => service.RemoveFile(playListId, fileId, userId),
                Times.Once
            );
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 0)]
        public void RemoveFile_InvalidData_DoesNotCallRemoveFileInPlayListService(int playListId, int fileId, int userId)
        {
            var playListServiceMock = new Mock<IPlayListService>();
            var playListController = new PlayListController(playListServiceMock.Object);
            playListController.RemoveFile(playListId, fileId, userId);
            playListServiceMock.Verify(
                service => service.RemoveFile(playListId, fileId, userId),
                Times.Never
            );
        }
    }
}