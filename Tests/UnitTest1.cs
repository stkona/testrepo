using NUnit.Framework;
using System;
using System.Collections.Generic;
using TDDProject;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new object[] { new string[] { "Tom", "Python" }, new string[] { "Lily", "Python" } }, new string[] { "Python_Tom_Lily" })]
        [TestCase(new object[] { new string[] { "Tom", "Python" }, new string[] { "Lily", "Java" } }, new string[] { "Python_Tom", "Java_Lily" })]
        [TestCase(new object[] { new string[] { "Tom", "Java" }, new string[] { "Lily", "Java" }, new string[] { "Nathan", "Python" } }, new string[] { "Java_Tom_Lily", "Python_Nathan" })]
        [Test]
        public void TestRegisteredNames_RunsCorrectly(object[] obj, string[] expectedResult)
        {
            // Arrange
            var testList = new List<string[]>();
            foreach (var item in obj)
            {
                testList.Add((string[])item);
            }

            // Act
            var result = Unit.RegisteredNames(testList);

            // Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(result[i], expectedResult[i]);
            }
        }

        [TestCase(new object[] { new string[] { "Tom", "Python", "wrong" }, new string[] { "Lily", "Python" } })]
        [TestCase(new object[] { new string[] { "Tom" }, new string[] { "Lily", "Python" } })]
        [TestCase(new object[] { new string[] { "Tom", "Lily" }, new string[] { "Lily", "Python" } })]
        [Test]
        public void TestRegisteredNames_ReturnsError_WithIncorrectValues(object[] obj)
        {
            // Arrange
            var testList = new List<string[]>();
            foreach (var item in obj)
            {
                testList.Add((string[])item);
            }

            // Act & Assert
            Assert.Throws<Exception>(() => Unit.RegisteredNames(testList));
        }
    }
}