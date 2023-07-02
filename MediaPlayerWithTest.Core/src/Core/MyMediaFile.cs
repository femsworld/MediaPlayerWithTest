using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaPlayerWithTest.Core.src.Core
{
    public class MyMediaFile : MediaFile
    {
        public MyMediaFile(string fileName, string filePath, TimeSpan duration) : base(fileName, filePath, duration)
        {
        }
    }
}