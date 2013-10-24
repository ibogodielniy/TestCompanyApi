using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MyCollections
{
    [TestFixture]
    internal class MyHashtableTests
    {
        private MyHashtable hashtable = new MyHashtable(new HashGenerator());
        private HashGenerator heshGenerator = new HashGenerator();
        private Object TestKey = "fghj";
        private Object TestValue = 2345;


        [Test]
        public void AddEntryTest()
        {
            hashtable.Add(TestKey, TestValue);
            Assert.AreEqual(TestKey, hashtable.GetEntry(TestKey));
        }

        [Test]
        public void GetEntryTest()
        {
            Object entry = hashtable.GetEntry(TestKey);
            Assert.AreEqual(entry, TestKey);
        }

        [Test]
        public void RemoveEntryTest()
        {
            hashtable.Add(TestKey, TestValue);
            hashtable.Remove(TestKey);
            Assert.AreEqual(hashtable.Count, 0);
        }
    }
}
