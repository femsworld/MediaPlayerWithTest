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
            // Arrange
            var user = User.Instance;
            var list = new PlayList("My List", 1);

            // Act
            user.AddNewList(list);

            // Assert
            Assert.Contains(list, user.Lists);
        }

        [Fact]
        public void RemoveOneList_ExistingList_ListRemovedFromLists()
        {
            // Arrange
            var user = User.Instance;
            var list = new PlayList("My List", 1);
            user.AddNewList(list);

            // Act
            user.RemoveOneList(list);

            // Assert
            Assert.DoesNotContain(list, user.Lists);
        }

        // [Fact]
        // public void EmptyOneList_ExistingList_ListEmptied()
        // {
        //     // Arrange
        //     var user = User.Instance;
        //     var list = new PlayList("My List", 1);
        //     user.AddNewList(list);

        //     // Act
        //     user.EmptyOneList(list);

        //     // Assert
        //     Assert.Empty(list.Files);
        // }

        [Fact]
        public void EmptyOneList_NonExistingList_ArgumentNullExceptionThrown()
        {
            // Arrange
            var user = User.Instance;
            var nonExistingList = new PlayList("Non-existing List", 2);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => user.EmptyOneList(nonExistingList));
        }
    }
}