using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaPlayerWithTest.Core.src.Core
{
    public class MyMediaFile : MediaFile
    {
        public bool IsPlaying { get; private set; }
        public TimeSpan CurrentPosition { get; private set; }
        public MyMediaFile(string fileName, string filePath, TimeSpan duration) : base(fileName, filePath, duration)
        {
            IsPlaying = false;
            CurrentPosition = TimeSpan.Zero; 
        }

        public override void Play()
        {
            base.Play();
            IsPlaying = true;
        }

        public override void Pause()
        {
            base.Pause();
            IsPlaying = false;
        }

        public override void Stop()
        {
            base.Stop();
            IsPlaying = false;
        }
        public static bool IsValidPlaybackSpeed(double speed)
        {
            double[] validSpeeds = { 0.25, 0.5, 1, 1.25, 1.5, 1.75, 2 };
            return validSpeeds.Contains(speed);
        }
    }
}