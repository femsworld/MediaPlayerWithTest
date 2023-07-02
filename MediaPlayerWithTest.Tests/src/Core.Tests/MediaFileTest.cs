using MediaPlayerWithTest.Core.src.Core;
using Xunit;

namespace MediaPlayerWithTest.Tests.src.Core.Tests
{
    public class MediaFileTest
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
        [Fact]
        public void CreateMediaFile_ValidData_CreatedNewMediaFile()
        {
            var duration = TimeSpan.FromSeconds(2);
            var mediaFile = new MyMediaFile("fileName", "filePath", duration);
            Assert.Equal("fileName", mediaFile.FileName);
        }

        [Fact]
        public void Play_WhenNotPlaying_ShouldStartPlayback()
        {
            var mediaFile = new MyMediaFile("test.mp3", "path/to/file", TimeSpan.FromMinutes(3));
            mediaFile.Play();
            Assert.True(mediaFile.IsPlaying);
        }

        [Fact]
        public void Pause_WhenPlaying_ShouldPausePlayback()
        {
            var mediaFile = new MyMediaFile("test.mp3", "path/to/file", TimeSpan.FromMinutes(3));
            mediaFile.Play();
            mediaFile.Pause();
            Assert.False(mediaFile.IsPlaying);
        }

        [Fact]
        public void Stop_WhenPlaying_ShouldStopPlayback()
        {
            var mediaFile = new MyMediaFile("test.mp3", "path/to/file", TimeSpan.FromMinutes(3));
            mediaFile.Play();
            mediaFile.Stop();
            Assert.False(mediaFile.IsPlaying);
            Assert.Equal(TimeSpan.Zero, mediaFile.CurrentPosition);
        }

        [Fact]
        public void Speed_WhenSettingValidSpeed_ShouldUpdatePlaybackSpeed()
        {
            var mediaFile = new MyMediaFile("test.mp3", "path/to/file", TimeSpan.FromMinutes(3));
            mediaFile.Speed = 1.5;
            Assert.Equal(1.5, mediaFile.Speed);
        }

        [Fact]
        public void Speed_WhenSettingInvalidSpeed_ShouldThrowArgumentException()
        {
            var mediaFile = new MyMediaFile("test.mp3", "path/to/file", TimeSpan.FromMinutes(3));
            Assert.Throws<ArgumentException>(() => mediaFile.Speed = 0.8);
        }

        [Theory]
        [MemberData(nameof(GetValidPlaybackSpeedData))]
        public void IsValidPlaybackSpeed_ValidSpeed_ShouldReturnTrue(double speed)
        {
            var isValidSpeed = MyMediaFile.IsValidPlaybackSpeed(speed);
            Assert.True(isValidSpeed);
        }

        [Theory]
        [MemberData(nameof(GetInvalidPlaybackSpeedData))]
        public void IsValidPlaybackSpeed_InvalidSpeed_ShouldReturnFalse(double speed)
        {
            var isValidSpeed = MyMediaFile.IsValidPlaybackSpeed(speed);
            Assert.False(isValidSpeed);
        }

        public static IEnumerable<object[]> GetValidPlaybackSpeedData()
        {
            yield return new object[] { 0.25 };
            yield return new object[] { 0.5 };
            yield return new object[] { 1 };
            yield return new object[] { 1.25 };
            yield return new object[] { 1.5 };
            yield return new object[] { 1.75 };
            yield return new object[] { 2 };
        }

        public static IEnumerable<object[]> GetInvalidPlaybackSpeedData()
        {
            yield return new object[] { 0 };
            yield return new object[] { 0.2 };
            yield return new object[] { 0.8 };
            yield return new object[] { 1.3 };
            yield return new object[] { 1.7 };
            yield return new object[] { 2.2 };
            yield return new object[] { 3 };
        } 
    }
}