using MediaPlayerWithTest.Core.src.RepositoryInterface;
using Xunit;
using Moq;
using MediaPlayerWithTest.Service.src.Service;

namespace MediaPlayerWithTest.Tests.src.Service.Tests
{
    public class MediaServiceTest
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
        [Fact]
        public void CreateNewFile_ValidData_CallsRepositoryCreateNewFile()
        {
            var mediaRepositoryMock = new Mock<IMediaRepository>();
            var mediaService = new MediaService(mediaRepositoryMock.Object);
            string fileName = "test1.mp3";
            string filePath = "/path/to/file";
            TimeSpan duration = TimeSpan.FromMinutes(5);

            mediaService.CreateNewFile(fileName, filePath, duration);

            mediaRepositoryMock.Verify(r => r.CreateNewFile(fileName, filePath, duration), Times.Once);
        }
        [Fact]
        public void DeleteFileById_ValidId_CallsRepositoryDeleteFileById()
        {
            var mediaRepositoryMock = new Mock<IMediaRepository>();
            var mediaService = new MediaService(mediaRepositoryMock.Object);
            int fileId = 1;

            mediaService.DeleteFileById(fileId);

            mediaRepositoryMock.Verify(r => r.DeleteFileById(fileId), Times.Once);
        }

        [Fact]
        public void GetAllFiles_CallsRepositoryGetAllFiles()
        {
            var mediaRepositoryMock = new Mock<IMediaRepository>();
            var mediaService = new MediaService(mediaRepositoryMock.Object);

            mediaService.GetAllFiles();

            mediaRepositoryMock.Verify(r => r.GetAllFiles(), Times.Once);
        }

        [Fact]
        public void GetFileById_ValidId_CallsRepositoryGetFileById()
        {
            var mediaRepositoryMock = new Mock<IMediaRepository>();
            var mediaService = new MediaService(mediaRepositoryMock.Object);
            int fileId = 1;

            mediaService.GetFileById(fileId);

            mediaRepositoryMock.Verify(r => r.GetFileById(fileId), Times.Once);
        }
    }
}