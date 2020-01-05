using System;
using System.Collections.Generic;

namespace HashTable
{
    public class LinkedHashTable<TKey, TValue>
    {
        private List<Node<TKey, TValue>>[] Buckets { get; set; }

        public LinkedHashTable(int size = 10)
        {
            Buckets = new List<Node<TKey, TValue>>[size];
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
                Buckets[index] = new List<Node<TKey, TValue>>();
            }

            var node = new Node<TKey, TValue>(key, value);
            Buckets[index].Add(node);
        }

        public TValue Find(TKey key)
        {
            int index = F(key);

            if (Buckets[index] == null)
            {
                throw new KeyNotFoundException();
            }

            foreach (var node in Buckets[index])
            {
                if (node.Key.Equals(key))
                {
                    return node.Value;
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
            
            Node<TKey, TValue> nodeToRemove = null;

            foreach (var node in Buckets[index])
            {
                if (node.Key.Equals(key))
                {
                    nodeToRemove = node;
                    break;
                }
            }

            if (nodeToRemove != null)
            {
                Buckets[index].Remove(nodeToRemove);

                if (Buckets[index].Count == 0)
                {
                    Buckets[index] = null;
                }
            }
        }
    }
}