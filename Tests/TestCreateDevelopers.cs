using NUnit.Framework;
using System;
using System.Collections.Generic;
using TDDProject;

namespace Tests
{
    public class TestCreateDevelopers
    {
        private List<string[]> list;

        [SetUp]
        public void Setup()
        {
            list = new List<string[]>
            {
                new string[] { "Tom", "Python", "Junior"},
                new string[] { "Tom", "Python", "Junior"},
                new string[] { "Lily", "Python", "Senior" },
                new string[] { "Nathan", "Java", "Senior" },
                new string[] { "Josh", "Java", "Junior" },
                new string[] { "Penka", "JavaScript", "Junior" },
                new string[] { "Gosho", "JavaScript", "Senior" },
            };
        }

        [Test]
        public void TestCreateDevelopers_RunsCorrectly()
        {
            // Arrange & Act
            var result = Builder.CreateDevelopers(list);

            // Assert
            var correctNumberOfDevs = 6;
            Assert.IsNotEmpty(result);
            Assert.AreEqual(correctNumberOfDevs, result.Count);
        }
        
        [TestCase(new object[] { new string[] { "", "Python", "Junior"}, new string[] { "Tom", "Python", "Senior"}})]
        [TestCase(new object[] { new string[] { "Lily", "Python", ""}, new string[] { "Tom", "Python", "Senior"}})]
        [TestCase(new object[] { new string[] { "Lily", "Python", "Junior123123" }, new string[] { "Tom", "Python", "Senior"}})]
        [Test]
        public void TestCreateDevelopers_EmptyKnowledgeParameter_ReturnsError(object[] obj)
        {
            // Arrange
            var wrongList = new List<string[]>();

            foreach (var item in obj)
            {
                wrongList.Add((string[])item);
            }

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Builder.CreateDevelopers(wrongList));
        }
    }
}