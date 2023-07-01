using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerWithTest.Core.src.Core;
using Xunit;

namespace MediaPlayerWithTest.Tests.src.Core.Tests
{
    public class PlayListTest
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void CreatePlayList_ValidData_CreateNewPlayList()
        {
            var playList = new PlayList("Fela Kuti", 1);
            Assert.Equal("Fela Kuti", playList.ListName);
        }
    }


}