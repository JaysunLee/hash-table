using System;
using System.Collections.Generic;

namespace HashTable
{
    public class LinkedHashTable<TKey, TValue>
    {
        private List<Node<TKey, TValue>>[] Buckets { get; set; }
        private Node<TKey, TValue> Head { get; set; }
        private Node<TKey, TValue> Tail { get; set; }

        public LinkedHashTable(int size = 10)
        {
            Buckets = new List<Node<TKey, TValue>>[size];
            Head = Tail = null;
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

            // List maintainence
            if (Head == null && Tail == null)
            {
                Head = Tail = node;
            }
            else
            {
                node.Previous = Tail;
                Tail.Next = node;
                Tail = node;
            }
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
            
            // List maintainence
            if (nodeToRemove == Head && Head == Tail)
            {
                Head = Tail = null;
            }
            else if (nodeToRemove == Head)
            {
                Head = Head.Next;
                Head.Previous = null;
            }
            else if (nodeToRemove == Tail)
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            else
            {
                var before = nodeToRemove.Previous;
                var after = nodeToRemove.Next;

                before.Next = after;
                after.Previous = before;
            }
        }

        public void PrintList()
        {
            var cursor = Head;

            while (cursor != null)
            {
                Console.WriteLine(cursor.Value);
                cursor = cursor.Next;
            }
        }

        public void PrintListBackwards()
        {
            var cursor = Tail;

            while (cursor != null)
            {
                Console.WriteLine(cursor.Value);
                cursor = cursor.Previous;
            }
        }
    }
}