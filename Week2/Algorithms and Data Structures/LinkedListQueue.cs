using System.Globalization;
using System.Collections;

namespace LinkedListQueue
{
    public class Program
    {
        static void Main(string[] args)
        {

            LinkedListQueue<double> queue = new LinkedListQueue<double>();

            // Enqueue elements
            queue.Enqueue(1.111);
            queue.Enqueue(2.222);
            queue.Enqueue(3.333);
            queue.Enqueue(4.444);
            queue.Enqueue(5.555);
            queue.Enqueue(6.666);

            // Print the size of the queue
            Console.WriteLine("Queue size: " + queue.Size());

            // Dequeue elements
            Console.WriteLine("Dequeued: " + queue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + queue.Dequeue().ToString(CultureInfo.InvariantCulture));

            // Print the updated size of the queue
            Console.WriteLine("Updated queue size: " + queue.Size());

            // Returns true if the queue is empty
            Console.WriteLine("Is queue empty? " + queue.IsEmpty());

            // Use the iterator to iterate and print elements in the queue
            Console.WriteLine("Queue elements:");
            foreach (var item in queue)
            {
                Console.WriteLine(item.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
    public class Node<DataType>
    {
        public DataType Data { get; }
        public Node<DataType> Next { get; set; }

        public Node(DataType data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedListQueue<DataType> : IEnumerable<DataType>
    {
        private Node<DataType> first; // Front of the queue
        private Node<DataType> last; // Rear of the queue
        private int size; // Number of elements in the queue

        public LinkedListQueue()
        {
            first = null;
            last = null;
            size = 0;
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public void Enqueue(DataType data)
        {
            Node<DataType> newNode = new Node<DataType>(data);

            if (IsEmpty())
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.Next = newNode;
                last = newNode;
            }

            size++;
        }

        public DataType Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            DataType data = first.Data;
            first = first.Next;
            size--;

            if (first == null)
            {
                last = null; // If the queue becomes empty, reset the rear as well
            }

            return data;
        }

        public int Size()
        {
            return size;
        }

        // Implementing IEnumerable<T> interface using an iterator
        public IEnumerator<DataType> GetEnumerator()
        {
            Node<DataType> current = first;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        // Implementing the non-generic IEnumerable interface required by C#
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}