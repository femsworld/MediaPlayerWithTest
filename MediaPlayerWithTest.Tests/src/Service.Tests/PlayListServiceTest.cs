using Moq;
using MediaPlayerWithTest.Core.src.RepositoryInterface;
using MediaPlayerWithTest.Service.src.Service;

namespace MediaPlayerWithTest.Tests.src.Service.Tests
{
    public class PlayListServiceTest
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
        [Fact]
        public void AddNewFile_ValidInput_CallsAddNewFileMethodOnRepository()
        {
            var mockPlayListRepository = new Mock<IPlayListRepository>();
            var playListService = new PlayListService(mockPlayListRepository.Object);
            int playListId = 1;
            int fileId = 2;
            int userId = 3;

            playListService.AddNewFile(playListId, fileId, userId);

            mockPlayListRepository.Verify(
                repo => repo.AddNewFile(playListId, fileId, userId),
                Times.Once
            );
        }

        [Fact]
        public void EmptyList_ValidInput_CallsEmptyListMethodOnRepository()
        {
            var mockPlayListRepository = new Mock<IPlayListRepository>();
            var playListService = new PlayListService(mockPlayListRepository.Object);
            int playListId = 1;
            int userId = 3;
            playListService.EmptyList(playListId, userId);
            mockPlayListRepository.Verify(
                repo => repo.EmptyList(playListId, userId),
                Times.Once
            );
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 6)]
        [InlineData(7, 8, 9)]
        public void RemoveFile_ValidInput_CallsRemoveFileMethodOnRepository(int playListId, int fileId, int userId)
        {
            var mockPlayListRepository = new Mock<IPlayListRepository>();
            var playListService = new PlayListService(mockPlayListRepository.Object);
            playListService.RemoveFile(playListId, fileId, userId);
            mockPlayListRepository.Verify(
                repo => repo.RemoveFile(playListId, fileId, userId),
                Times.Once
            );

        }
    }
}