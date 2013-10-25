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
            public Object Key;
            public Object Value;
        }
        
        private int IndexOf(Object key)
        {
            int index = HashGenerator.Generate(key, _capacity);

            if (_bucketArray[index].Key != key)
            {
                for (int i = 0; i < _capacity; i++)
                {
                    if (_bucketArray[i] != null && _bucketArray[i].Key == key)
                        index = i;
                }
            }
            return index;
        }

        private int SolveColission(int index)
        {
            do
            {
                if ((index ++) <= _capacity)
                {
                     index++;
                }
                index=0;
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
            return _bucketArray[IndexOf(key)].Key;
        }

        public void Remove(Object key)
        {
            int index = IndexOf(key);
            _bucketArray[index] = null;
            _fullnessCounter--;
        }

    }
}
