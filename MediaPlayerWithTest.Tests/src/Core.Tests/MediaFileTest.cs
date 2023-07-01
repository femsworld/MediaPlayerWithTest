using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}