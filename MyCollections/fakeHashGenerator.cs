using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    internal class FakeHashGenerator : IHashGenerator
    {
        public int Generate(Object key, int capacity)
        {
            return 8;
        }
    }
}

