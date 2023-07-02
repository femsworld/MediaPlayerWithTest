using MediaPlayerWithTest.Controller.src;
using MediaPlayerWithTest.Service.src.ServiceInterface;
using Moq;

namespace MediaPlayerWithTest.Tests.src.Controller.Tests
{
    public class MediaControllerTest
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
        [Fact]
        public void CreateNewFile_ValidData_CallsCreateNewFileInMediaService()
        {
            var mediaServiceMock = new Mock<IMediaService>();
            var mediaController = new MediaController(mediaServiceMock.Object);
            var fileName = "testFile";
            var filePath = "/path/to/file";
            var duration = TimeSpan.FromMinutes(5);
            mediaController.CreateNewFile(fileName, filePath, duration);
            mediaServiceMock.Verify(
                service => service.CreateNewFile(fileName, filePath, duration),
                Times.Once
            );
        }

        [Fact]
        public void DeleteFileById_ValidId_CallsDeleteFileByIdInMediaService()
        {
            var mediaServiceMock = new Mock<IMediaService>();
            var mediaController = new MediaController(mediaServiceMock.Object);
            var fileId = 1;
            mediaController.DeleteFileById(fileId);
            mediaServiceMock.Verify(
                service => service.DeleteFileById(fileId),
                Times.Once
            );
        }

        [Fact]
        public void GetAllFiles_CallsGetAllFilesInMediaService()
        {
            var mediaServiceMock = new Mock<IMediaService>();
            var mediaController = new MediaController(mediaServiceMock.Object);
            mediaController.GetAllFiles();
            mediaServiceMock.Verify(
                service => service.GetAllFiles(),
                Times.Once
            );
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetFileById_ValidId_CallsGetFileByIdInMediaService(int fileId)
        {
            var mediaServiceMock = new Mock<IMediaService>();
            var mediaController = new MediaController(mediaServiceMock.Object);
            mediaController.GetFileById(fileId);
            mediaServiceMock.Verify(
                service => service.GetFileById(fileId),
                Times.Once
            );
        }
    }
}