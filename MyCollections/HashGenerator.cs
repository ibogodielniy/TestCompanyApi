using System;


namespace MyCollections
{
    public class HashGenerator : IHashGenerator
    {

        public int Generate(Object key, int capacity)
        {
            int hash = key.GetHashCode();
            hash %= capacity;
            return Math.Abs(hash);
        }
    }
}
