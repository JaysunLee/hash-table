using System;
using System.Collections.Generic;

namespace HashTable
{
    public class HashTable<TKey, TValue>
    {
        private List<Tuple<TKey, TValue>>[] Buckets { get; set; }

        public HashTable(int size = 10)
        {
            Buckets = new List<Tuple<TKey, TValue>>[size];
        }

        public void Insert(TKey key, TValue value)
        {
            int hash = key.GetHashCode();
            int index = hash % Buckets.Length;

            if (Buckets[index] == null)
            {
                Buckets[index] = new List<Tuple<TKey, TValue>>();
            }

            var pair = new Tuple<TKey, TValue>(key, value);
            Buckets[index].Add(pair);
        }
    }
}