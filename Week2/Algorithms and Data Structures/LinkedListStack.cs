using System.Collections;
using System.Globalization;

namespace LinkedListStack
{
    public class Program
    {
        static void Main(string[] args)
        {

            LinkedListStack<double> stack = new LinkedListStack<double>();

            stack.Push(3.14);
            stack.Push(1.618);
            stack.Push(299792458);
            stack.Push(2.718);
            stack.Push(6.626);

            // Iterate through the stack using foreach loop
            // This is possible due to the application of the IEnumerable interface in the LinkedListStack class
            Console.WriteLine("Stack elements:");
            foreach (var item in stack)
            {
                Console.WriteLine(item.ToString(CultureInfo.InvariantCulture));
            }

            Console.WriteLine();

            Console.WriteLine("Popped element: " + stack.Pop().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Popped element: " + stack.Pop().ToString(CultureInfo.InvariantCulture));

            Console.WriteLine("Top element: " + stack.Peek().ToString(CultureInfo.InvariantCulture));

            Console.WriteLine("Is stack empty? " + stack.IsEmpty());

            Console.WriteLine();

            Console.WriteLine("Popped element: " + stack.Pop().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Popped element: " + stack.Pop().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Popped element: " + stack.Pop().ToString(CultureInfo.InvariantCulture));

            Console.WriteLine("Is the stack empty now? " + stack.IsEmpty());
        }
    }
    // Node class represents each node in the linked list
    public class Node<DataType>
    {
        public DataType Data { get; set; }
        public Node<DataType> Next { get; set; }

        public Node(DataType data)
        {
            Data = data;
            Next = null;
        }
    }

    // Stack implemented using a linked list with iterator
    public class LinkedListStack<DataType> : IEnumerable<DataType>
    {
        private Node<DataType> first = null; // first of the stack
        private int size;

        // Push operation to add an element to the stack
        public void Push(DataType data)
        {
            Node<DataType> newNode = new Node<DataType>(data);
            if (IsEmpty())
            {
                first = newNode;
            }
            else
            {
                newNode.Next = first;
                first = newNode;
            }
            size++;
        }

        // Pop operation to remove and return the top element from the stack
        public DataType Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            DataType data = first.Data;
            first = first.Next;
            size--;
            return data;
        }

        // Peek operation to return the top element without removing it
        public DataType Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return first.Data;
        }

        // Check if the stack is empty
        public bool IsEmpty()
        {
            return first == null;
        }

        // Returns the size of the stack
        public int Size()
        {
            return size;
        }

        // Implementing iterator using IEnumerable interface
        public IEnumerator<DataType> GetEnumerator()
        {
            Node<DataType> current = first;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        // Explicit implementation for non-generic IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}