using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TDDProject;

namespace Tests
{
    public class TestBuildNickname
    {
        private List<Developer> developers;
        private List<Pair> pairs;

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
        public void TestBuildNickname_ResultsInCorrectNumberOfPairs()
        {
            // Arrange & Act
            var result = Builder.BuildNickname(pairs);
            var expectedResult = "Python_TomJunior_LilySenior";

            // Assert
            Assert.AreEqual(expectedResult, result.First());
        }

        [Test]
        public void TestBuildNickname_ResultsInCorrectDevelopersInPair()
        {
            // Arrange & Act
            var listPairs = new List<Pair>();

            // Assert
            Assert.Throws<ArgumentException>(() => Builder.BuildNickname(listPairs));
        }
    }
}