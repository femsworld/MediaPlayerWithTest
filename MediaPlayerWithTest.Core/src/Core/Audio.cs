
namespace MediaPlayerWithTest.Core.src.Core
{
    public class Audio : MediaFile
    {
        public Audio(string fileName, string filePath, TimeSpan duration, double speed) : base(fileName, filePath, duration, speed)
        {
            FileName = fileName;
            FilePath = filePath;
            Duration = duration;
            Speed = speed;
        }
    }
}