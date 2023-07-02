using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediaPlayerWithTest.Core.src.Core;
using Xunit;

namespace MediaPlayerWithTest.Tests.src.Core.Tests
{
    public class UserTest
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void AddNewList_ValidList_ListAddedToLists()
        {
            var user = User.Instance;
            var list = new PlayList("My List", 1);
            user.AddNewList(list);
            Assert.Contains(list, user.Lists);
        }

        [Fact]
        public void RemoveOneList_ExistingList_ListRemovedFromLists()
        {
            var user = User.Instance;
            var list = new PlayList("My List", 1);
            user.AddNewList(list);
            user.RemoveOneList(list);
            Assert.DoesNotContain(list, user.Lists);
        }

        [Fact]
        public void EmptyOneList_ExistingList_ListEmptied()
        {
            var user = User.Instance;
            var list = new PlayList("My List", 1);
            user.AddNewList(list);
            user.EmptyOneList(list);
            Assert.Empty(list.Files);
        }

        [Fact]
        public void EmptyOneList_NonExistingList_ArgumentNullExceptionThrown()
        {
            var user = User.Instance;
            var nonExistingList = new PlayList("Non-existing List", 2);
            Assert.Throws<ArgumentNullException>(() => user.EmptyOneList(nonExistingList));
        }
    }
}