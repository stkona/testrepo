using NUnit.Framework;
using System.Collections.Generic;
using TDDProject;
using Moq;
using System;
using System.Linq;

namespace Tests
{
    public class TestRoomAssignment
    {
        private RoomAssignment roomAssignment;
        private List<Developer> developers;
        private List<Pair> pairs;

        [SetUp]
        public void Setup()
        {
            var msTestApi = new Mock<IMsTeamsAPI>();
            msTestApi.Setup(x => x.GetRoomID()).Returns(1);
            msTestApi.Setup(x => x.AssignRoom(It.IsAny<int>(), It.IsAny<List<IDeveloper>>())).Returns(true);

            roomAssignment = new RoomAssignment(msTestApi.Object);

            developers = new List<Developer>()
            {
                new Developer("Tom", "Python", "Junior"),
                new Developer("Lily", "Python", "Senior"),
                new Developer("Gosho", "JavaScript", "Junior"),
                new Developer("Penka", "JavaScript", "Senior"),
            };

            var listPairs = new List<Pair>();
            var pyth = new Pair(developers.Find(x => x.Name == "Tom"));
            pyth.AddDeveloper(developers.Find(x => x.Name == "Lily"));
            listPairs.Add(pyth);

            var js = new Pair(developers.Find(x => x.Name == "Gosho"));
            js.AddDeveloper(developers.Find(x => x.Name == "Penka"));
            listPairs.Add(pyth);

            pairs = listPairs;
        }

        [Test]
        public void TestRoomAssignment_ShouldReturnTrue()
        {
            // Act & Assert
            foreach (var pair in pairs)
            {
                Assert.True(roomAssignment.Assign(pair));
            }
        }

        [Test]
        public void TestRoomAssignment_WithOnlyOneDeveloper_ShouldReturnFalse()
        {
            // Arrange
            var dev = new Developer("Tom", "Python", "Junior");
            var pair = new Pair(dev);

            // Act & Assert
            Assert.False(roomAssignment.Assign(pair));
        }

        [Test]
        public void TestRoomAssignment_WithNonAvailableID_ShouldReturnFalse()
        {
            // Arrange
            var dev = new Developer("Tom", "Python", "Junior");
            var secondDev = new Developer("Lily", "Python", "Senior");
            var pair = new Pair(dev);
            pair.AddDeveloper(secondDev);

            var msTestApi = new Mock<IMsTeamsAPI>();
            msTestApi.Setup(x => x.GetRoomID()).Returns(-1);
            msTestApi.Setup(x => x.AssignRoom(It.IsAny<int>(), It.IsAny<List<IDeveloper>>())).Returns(true);

            var roomAssignment = new RoomAssignment(msTestApi.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => roomAssignment.Assign(pair));
        }

        [Test]
        public void TestRoomAssignment_WithAssignReturningFalse_ShouldReturnFalse()
        {
            // Arrange
            var msTestApi = new Mock<IMsTeamsAPI>();
            msTestApi.Setup(x => x.GetRoomID()).Returns(1);
            msTestApi.Setup(x => x.AssignRoom(It.IsAny<int>(), It.IsAny<List<IDeveloper>>())).Returns(false);

            var roomAssignment = new RoomAssignment(msTestApi.Object);

            // Act & Assert
            Assert.False(roomAssignment.Assign(pairs.First()));
        }
    }
}