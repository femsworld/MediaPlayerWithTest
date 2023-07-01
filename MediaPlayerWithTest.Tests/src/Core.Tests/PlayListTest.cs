using System;
using System.Collections;
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

        [Theory]
        [MemberData(nameof(TestUpdatePlayListData))]
        // public void AddNewFile_ValidData_NewFileAdded(string name, int userId, string? updatedName, int? updatedUserId, string newName, int newUserId)
        public void AddNewFile_ValidData_NewFileAdded(string name, int userId, string? updatedName, int? updatedUserId, string newName, int newUserId)
        {
            var playList = new PlayList(name, userId);
            var updatedFile = new MyMediaFile(updatedName, "FilePath", TimeSpan.Zero);

            // playList.AddNewFile(updatedName, updatedUserId);
            playList.AddNewFile(updatedFile, (int)updatedUserId);

            Assert.Equal(playList.ListName, newName);
        }

        public static IEnumerable<object[]> TestUpdatePlayListData
        {
            get
            {
                yield return new object[] { "Fela Kuti", 1, "Fela Kuti", 2, "Fela Kuti", 3 };
                yield return new object[] { "Femi Kuti", 1, "Femi Kuti", 2, "Femi Kuti", 3 };
            }
        }
    }

    public class TestUpdatePlayListData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "Fela Kuti", 1, "Fela Kuti", 2, "Fela Kuti", 3 };
            yield return new object[] { "Femi Kuti", 1, "Femi Kuti", 2, "Femi Kuti", 3 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}