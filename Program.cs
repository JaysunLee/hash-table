using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new ProbingHashTable<int, int>();
            table.Insert(1, 666);
            table.Insert(11, 667);
            table.Delete(11);
            Console.WriteLine(table.Find(1));
        }
    }
}
