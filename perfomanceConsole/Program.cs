using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MyCollections;

namespace perfomanceConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var myHashtable= new MyHashtable(new HashGenerator());
            var hashtable = new Hashtable();
            Object key = "assdfasdfasdfasdfasdfasdf";
            Object value = "asdfasdfasdfasdfasdfadsfsdf";
           
            hashtable.Add(key, value);
            Stopwatch sw2 = Stopwatch.StartNew();
            hashtable.ContainsKey(value); 
            Console.WriteLine("Ms perfomance is: {0}", sw2.ElapsedTicks);

            myHashtable.Add(key, value);
            Stopwatch sw1 = Stopwatch.StartNew();
            myHashtable.GetEntry(key); // What method of Ms implementation should match this?
            Console.WriteLine("My perfomance: {0}", sw1.ElapsedTicks);
            Console.ReadKey();
        }
    }
}
