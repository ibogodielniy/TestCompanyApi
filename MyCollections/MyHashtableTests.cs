using System;
using NUnit.Framework;

namespace MyCollections
{

    [TestFixture]
    internal class MyHashtableCollisionsTests
    {
        #region Only open method testing

        [Test]
        public void AddEntryTest()
        {
            var hashtable = new MyHashtable(new HashGenerator());

            Object testKey = "fghj";
            Object testValue = 2345;

            hashtable.Add(testKey, testValue);
            Assert.AreEqual(testKey, hashtable.GetEntry(testKey));
        }

        [Test]
        public void GetEntryTest()
        {
            var hashtable = new MyHashtable(new HashGenerator());

            Object testKey = "fghj";
            Object testValue = 2345;

            hashtable.Add(testKey, testValue);
            Object entry = hashtable.GetEntry(testKey);
            Assert.AreEqual(entry, testKey);
        }

        [Test]
        public void RemoveEntryTest()
        {
            var hashtable = new MyHashtable(new HashGenerator());

            Object testKey = "fghj";
            Object testValue = 2345;

            hashtable.Add(testKey, testValue);
            hashtable.Remove(testKey);
            Assert.AreEqual(hashtable.Count, 0);
        }

        #endregion
        #region Collision solwing testing.

        [Test]
        public void AddCollisionEntryTest()
        {
            var hashtable = new MyHashtable(new FakeHashGenerator());

            Object testKey = "fghj";
            Object secondTestKey = "fdsa";
            Object testValue = 2345;

            hashtable.Add(testKey, testValue);
            hashtable.Add(secondTestKey, testValue);
            Assert.AreEqual(hashtable.Count, 2);
        }

        [Test]
        public void GetCollisionEntryTest()
        {
            var hashtable = new MyHashtable(new FakeHashGenerator());

            Object testKey = "fghj";
            Object secondTestKey = "fdsa";
            Object testValue = 2345;

            hashtable.Add(testKey, testValue);
            hashtable.Add(secondTestKey, testValue);
            Object entry = hashtable.GetEntry(secondTestKey);
            Assert.AreEqual(entry, secondTestKey);
        }

        #endregion
    }
}
