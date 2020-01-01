using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new HashTable<int, int>();
            table.Insert(1, 666);
            table.Insert(11, 667);
            Console.WriteLine(table.Find(1));
        }
    }
}
