namespace P09_Linked_List_Traversal
{
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        private Node head;
        private Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public int Count { get; private set; }



        public void Add(T element)
        {
            Node node = new Node(element);

            if (Count == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }

            Count++;
        }

        public bool Remove(T element)
        {
            // no elements
            if (Count == 0)
            {
                return false;
            }

            // the first element is the seeker
            if (head.Element.Equals(element))
            {
                head = head.Next;
                // the first element is the only one
                if (head == null)
                {
                    tail = null;
                }
                Count--;
                return true;
            }

            // the first element is the only one
            if (Count == 1)
            {
                return false;
            }

            Node current = head;

            do
            {
                if (current.Next.Element.Equals(element))
                {
                    //the last one
                    if (current.Next.Next == null)
                    {
                        tail = current;
                    }
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }

                current = current.Next;
            } while (current.Next != null);

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Element;

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private class Node
        {
            public Node(T element)
            {
                Element = element;
                Next = null;
            }

            public T Element { get; set; }
            public Node Next { get; set; }
        }
    }
}
