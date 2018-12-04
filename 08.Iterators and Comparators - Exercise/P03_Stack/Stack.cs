namespace P03_Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable<T>
    {
        private Node<T> top;

        public Stack()
        {
            top = null;
        }

        public void Push(params T[] elements)
        {
            foreach (var element in elements)
            {
                var newNode = new Node<T>(element);
                newNode.Prev = top;
                top = newNode;
            }
        }

        public T Pop()
        {
            if (top == null)
            {
                throw new InvalidOperationException("No elements");
            }

            T currentElement = top.Element;
            top = top.Prev;

            return currentElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = top;

            while (current != null)
            {
                yield return current.Element;

                current = current.Prev;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private class Node<T>
        {
            public Node(T element)
            {
                Element = element;
                Prev = null;
            }

            public T Element { get; set; }
            public Node<T> Prev { get; set; }
        }
    }
}
