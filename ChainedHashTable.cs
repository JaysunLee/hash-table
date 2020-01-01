using System;
using System.Collections.Generic;

namespace HashTable
{
    public class ChainedHashTable<TKey, TValue>
    {
        private List<Tuple<TKey, TValue>>[] Buckets { get; set; }

        public ChainedHashTable(int size = 10)
        {
            Buckets = new List<Tuple<TKey, TValue>>[size];
        }

        private int F(TKey key)
        {
            int hash = key.GetHashCode();
            int index = hash % Buckets.Length;
            return index;
        }

        public void Insert(TKey key, TValue value)
        {
            int index = F(key);

            if (Buckets[index] == null)
            {
                Buckets[index] = new List<Tuple<TKey, TValue>>();
            }

            var pair = new Tuple<TKey, TValue>(key, value);
            Buckets[index].Add(pair);
        }

        public TValue Find(TKey key)
        {
            int index = F(key);

            if (Buckets[index] == null)
            {
                throw new KeyNotFoundException();
            }

            foreach (var pair in Buckets[index])
            {
                if (pair.Item1.Equals(key))
                {
                    return pair.Item2;
                }
            }

            throw new KeyNotFoundException();
        }

        public void Delete(TKey key)
        {
            int index = F(key);

            if (Buckets[index] == null)
            {
                return;
            }
            
            Tuple<TKey, TValue> pairToRemove = null;

            foreach (var pair in Buckets[index])
            {
                if (pair.Item1.Equals(key))
                {
                    pairToRemove = pair;
                    break;
                }
            }

            if (pairToRemove != null)
            {
                Buckets[index].Remove(pairToRemove);

                if (Buckets[index].Count == 0)
                {
                    Buckets[index] = null;
                }
            }
        }
    }
}