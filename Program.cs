using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new HashTable<int, int>();
            table.Insert(1, 666);
            Console.WriteLine(table);
        }
    }
}
