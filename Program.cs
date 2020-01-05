using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new LinkedHashTable<int, int>();
            table.Insert(1, 666);
            table.Insert(11, 667);
            table.Delete(11);
            table.Insert(4, 66);
            table.Insert(2, 88);
            Console.WriteLine(table.Find(4));

            table.PrintList();
            table.PrintListBackwards();
        }
    }
}
