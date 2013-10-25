using System;
using System.Linq;

namespace MyCollections
{
    public class MyHashtable
    {
        private int _capacity = 10; 
        private Bucket[] _bucketArray;
        private readonly IHashGenerator _hashGenerator;
        private int _fullnessCounter;

        public int Count {
            get
            {
                return _fullnessCounter;
            }
        }

        public MyHashtable(IHashGenerator hashGenerator , int defaultCapacity)
        {
            _capacity = defaultCapacity;
            _hashGenerator = hashGenerator;
            _bucketArray = new Bucket[_capacity];
        }

        public MyHashtable(IHashGenerator hashGenerator)
        {
            _hashGenerator = hashGenerator;
            _bucketArray = new Bucket[_capacity];
        }

        private IHashGenerator HashGenerator
        {
            get
            {
                return _hashGenerator;
            }
        }

        private class Bucket
        {
            internal Object Key;
            internal Object Value;
        }
        
        private int IndexOf(Object key)
        {
            int index = _hashGenerator.Generate(key, _capacity);

            if (_bucketArray[index].Key != key)
            {
                for (int i = index; i <= _capacity; i++)
                {
                    if (i == _capacity - 1) i = 0;
                    if (_bucketArray[i] != null && _bucketArray[i].Key == key)
                         return i;
                }
            }
            return index;
        }

        private int SolveColission(int index)
        {
            do
            {
                if ((index + 1) == _capacity)
                {
                     index = 0;
                }
                index++;
            } 
         while (_bucketArray[index] != null);
            return index;
        }

        private bool CheckCollision(Object key)
        {
            int index = HashGenerator.Generate(key, _capacity);

            if (_bucketArray[index] != null)
            {
                var backet = _bucketArray[index];

                if (key == backet.Key)
                {
                    throw new ArgumentException();
                }
                return false;
            }
            return true;
        }

        private void Rehash(int capacity)
        {
            capacity *= 2;
            var extendedArray = new Bucket[capacity];

            foreach (Bucket i in _bucketArray)
            {
                if (i != null)
                {
                    int index = HashGenerator.Generate(i.Key, capacity);


                    if (CheckCollision(index))
                    {
                        index = SolveColission(index);
                    }
                    extendedArray[index] = i;
                }
            }
            _bucketArray = extendedArray;
            _capacity = capacity;
        }

        public void Add(Object key, Object value)
        {
            _fullnessCounter++;

            if (_fullnessCounter == _capacity / 2)
            {
                Rehash(_capacity);
            }

            int index = HashGenerator.Generate(key, _capacity);

            if (!CheckCollision(key))
            {
                index = SolveColission(index);
            }
            var bucket = new Bucket { Key = key, Value = value };

            _bucketArray[index] = bucket;
        }

        public Object GetEntry(Object key)
        {
            return _bucketArray[IndexOf(key)].Value;
        }

        public void Remove(Object key)
        {
            int index = IndexOf(key);
            _bucketArray[index] = null;
            _fullnessCounter--;
        }

    }
}
