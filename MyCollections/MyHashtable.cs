using System;
using System.Linq;

namespace MyCollections
{
    public class MyHashtable
    {
        private int _capacity = 10; //Base capacity is hardcoded
        public Bucket[] BacketArray;
        private readonly IHashGenerator _hashGenerator;
        private int _fullnessCounter;

        public int Count {
            get
            {
                return BacketArray.Count(bucket => bucket != null);
            }
        }

        public MyHashtable(IHashGenerator hashGenerator)
        {
            _hashGenerator = hashGenerator;
        }

        private IHashGenerator HashGenerator
        {
            get
            {
                return _hashGenerator;
            }
        }

        public class Bucket
        {
            public Object Key;
            public Object Value;
        }

        public void Add(Object key, Object value)
        {
            _fullnessCounter++;

            if (BacketArray == null)
                BacketArray = new Bucket[_capacity];

            if (_fullnessCounter == _capacity/2)
            {
                Rehash(_capacity);
            }

            try
            {
                int index = HashGenerator.Generate(key, _capacity);

                if (!CheckCollision(key))
                {
                    index = SolveColission(index);
                }
                var bucket = new Bucket { Key = key, Value = value };

                BacketArray[index] = bucket;
            }

            catch(ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public Object GetEntry(Object key)
        {
            return BacketArray[Find(key)].Key;
        }

        private int Find(Object key)
        {
            if (BacketArray == null)
                throw new ArgumentNullException();
            int index = HashGenerator.Generate(key, _capacity);

            if (BacketArray[index].Key == key)
                return index;

            for (int i = (index - 5); i < (index + 5); i++)
            {
                if (BacketArray[i] != null && BacketArray[i].Key == key)
                    return i;
            }
            return index;
        }

        public void Remove(Object key)
        {
            try
            {
                int index = Find(key);
                BacketArray[index] = null;
                _fullnessCounter--;
            }
            catch (ArgumentNullException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private int SolveColission(int index)
        {
            int r;
            do
            {
                if ((index + 1) <= _capacity)
                {
                     index++;
                }
                r = index--;
            } 
         while (BacketArray[r] != null);
            return r;
        }

        private bool CheckCollision(Object key)
        {
            int index = HashGenerator.Generate(key, _capacity);

            if (BacketArray[index] != null)
            {
                var backet = BacketArray[index];

                if (backet != null && key == backet.Key)
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

            foreach (Bucket i in BacketArray)
            {
                int index = HashGenerator.Generate(i.Key, capacity);

                if (CheckCollision(index))
                {
                    index = SolveColission(index);
                }
                extendedArray[index] = i;
            }
            BacketArray = extendedArray;
            _capacity = capacity;
        }
    }
}
