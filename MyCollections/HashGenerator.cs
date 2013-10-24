using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
     class HashGenerator : IHashGenerator
    {

        public int Generate(Object key, int capacity)
        {
            int hash = key.GetHashCode();
            hash %= capacity;
            return hash;
        }
    }
}
