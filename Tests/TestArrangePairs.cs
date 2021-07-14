using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TDDProject;

namespace Tests
{
    public class TestArrangePairs
    {
        private List<Developer> developers;

        [SetUp]
        public void Setup()
        {
            developers = new List<Developer>()
            {
                new Developer("Tom", "Python", "Junior"),
                new Developer("Lily", "Python", "Senior"),
                new Developer("Gosho", "JavaScript", "Junior"),
                new Developer("Penka", "JavaScript", "Senior"),
            };
        }

        [Test]
        public void TestArrangePairs_ResultsInCorrectNumberOfPairs()
        {
            // Arrange & Act
            var result = Builder.ArrangePairs(developers);

            // Assert
            var correctNumberOfPairs = 2;
            Assert.IsNotEmpty(result);
            Assert.AreEqual(correctNumberOfPairs, result.Count);
        }

        [Test]
        public void TestArrangePairs_ResultsInCorrectDevelopersInPair()
        {
            // Arrange & Act
            var result = Builder.ArrangePairs(developers);
            var listPairs = new List<Pair>();

            var pyth = new Pair(developers.Find(x => x.Name == "Tom"));
            pyth.AddDeveloper(developers.Find(x => x.Name == "Lily"));
            listPairs.Add(pyth);

            // Assert
            var pythResult = result.Find(x => x.Language == "Python");
            Assert.AreEqual(listPairs.First().FirstDeveloper.Name, pythResult.FirstDeveloper.Name);
            Assert.AreEqual(listPairs.First().SecondDeveloper.Name, pythResult.SecondDeveloper.Name);
        }
    }
}