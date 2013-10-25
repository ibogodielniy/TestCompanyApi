using System;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using Moq;

namespace MyCollections
{

    [TestFixture]
    internal class MyHashtableCollisionsTests
    {
        [Test]
        public void AddEntryTest()
        {
            var hashtable = new MyHashtable(new HashGenerator());

            Object testKey = "fghj";
            Object testValue = 2345;

            hashtable.Add(testKey, testValue);
            Assert.AreEqual(testValue, hashtable.GetEntry(testKey));
        }

        [Test]
        public void RemoveEntryTest()
        {
            var hashtable = new MyHashtable(new HashGenerator());

            Object testKey = "fghj";
            Object testValue = 2345;

            hashtable.Add(testKey, testValue);
            Assert.AreEqual(hashtable.Count, 1);
            hashtable.Remove(testKey);
            Assert.AreEqual(hashtable.Count, 0);
        }

        [Test]
        public void RehashingTest()
        {
            var hashtable = new MyHashtable(new HashGenerator(), 10);

            hashtable.Add("qwe", "1");
            hashtable.Add("wer", "2");
            hashtable.Add("ert", "3");
            hashtable.Add("rty", "4");
            hashtable.Add("tyu", "5");
            hashtable.Add("yui", "6");
            hashtable.Add("uio", "7");
            Assert.AreEqual(7, hashtable.Count);
            hashtable.Remove("rty");
            hashtable.Remove("wer");
            Assert.AreEqual(5, hashtable.Count);
        }

        [Test]
        public void AddCollisionEntryTest()
        {
            var stub = new Mock<IHashGenerator>();

            stub.Setup(s => s.Generate(It.IsAny<Object>(), 10)).Returns(9);
            var hashtable = new MyHashtable(stub.Object);

            Object testKey = "fghj";
            Object secondTestKey = "fdsa";
            Object testValue = 2345;
            Object secondTestValue = 1234;

            hashtable.Add(testKey, testValue);
            hashtable.Add(secondTestKey, secondTestValue);
            Assert.AreEqual(hashtable.GetEntry(testKey), testValue);
            Assert.AreEqual(hashtable.GetEntry(secondTestKey), secondTestValue);
        }
    }
}

