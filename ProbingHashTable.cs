using System;
using System.Collections.Generic;

namespace HashTable
{
    public class ProbingHashTable<TKey, TValue>
    {
        private Tuple<TKey, TValue>[] Buckets { get; set; }

        public ProbingHashTable(int size = 10)
        {
            Buckets = new Tuple<TKey, TValue>[size];
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

            while (Buckets[index] != null)
            {
                index++;
                if (index == Buckets.Length)
                {
                    index = 0;
                }
            }

            // TODO: Case when Buckets has no more empty slots

            var pair = new Tuple<TKey, TValue>(key, value);
            Buckets[index] = pair;
        }

        public TValue Find(TKey key)
        {
            int index = F(key);

            while (Buckets[index] != null)
            {
                if (Buckets[index].Item1.Equals(key))
                {
                    return Buckets[index].Item2;
                }

                index++;
                if (index == Buckets.Length)
                {
                    index = 0;
                }
            }
            
            throw new KeyNotFoundException();
        }

        public void Delete(TKey key)
        {
            int index = F(key);

            while (Buckets[index] != null)
            {
                if (Buckets[index].Item1.Equals(key))
                {
                    break;
                }

                index++;
                if (index == Buckets.Length)
                {
                    index = 0;
                }
            }

            Buckets[index] = null;
        }
    }
}