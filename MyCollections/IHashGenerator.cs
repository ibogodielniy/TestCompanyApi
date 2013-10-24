using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    public interface IHashGenerator
    {
        int Generate(Object key, int capacity);
    }
}
