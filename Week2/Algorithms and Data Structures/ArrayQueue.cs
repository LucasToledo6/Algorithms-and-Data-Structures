using System.Globalization;
using System.Collections;

namespace ArrayQueue
{
    public class Program
    {
        static void Main(string[] args)
        {

            ArrayQueue<double> queue = new ArrayQueue<double>(10);

            // Enqueue elements
            Console.WriteLine("Enqueued: " + queue.Enqueue(1.111).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + queue.Enqueue(2.222).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + queue.Enqueue(3.333).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + queue.Enqueue(4.444).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + queue.Enqueue(5.555).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + queue.Enqueue(6.666).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + queue.Enqueue(7.777).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + queue.Enqueue(8.888).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + queue.Enqueue(9.999).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + queue.Enqueue(10.111).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine();

            queue.PrintArray();
            Console.WriteLine();

            // Print the size of the queue
            Console.WriteLine("Number of elements in the array: " + queue.Size());
            Console.WriteLine("Array length: " + queue.Length);
            Console.WriteLine();

            // Dequeue elements
            Console.WriteLine("Dequeued: " + queue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + queue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + queue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine();

            queue.PrintArray();
            Console.WriteLine();

            // Print the updated size of the queue
            Console.WriteLine("Updated number of elements in the array: " + queue.Size());
            Console.WriteLine("Updated array length: " + queue.Length);
            Console.WriteLine();

            // Dequeue more elements
            Console.WriteLine("Dequeued: " + queue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + queue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine();

            queue.PrintArray();
            Console.WriteLine();

            // Print the updated size of the queue
            Console.WriteLine("Updated number of elements in the array: " + queue.Size());
            Console.WriteLine("Updated array length: " + queue.Length);
            Console.WriteLine();

            // Dequeue and enqueue more elements
            Console.WriteLine("Dequeued: " + queue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + queue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + queue.Enqueue(11.222).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + queue.Enqueue(12.333).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + queue.Enqueue(13.444).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + queue.Enqueue(14.555).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + queue.Enqueue(15.666).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine();

            queue.PrintArray();
            Console.WriteLine();

            // Print the updated size of the queue
            Console.WriteLine("Updated number of elements in the array: " + queue.Size());
            Console.WriteLine("Updated array length: " + queue.Length);
            Console.WriteLine();

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
    public class ArrayQueue<DataType> : IEnumerable<DataType>
    {
        private DataType[] array;
        private int head;
        private int tail;
        public int Length { get; internal set; } //variable so that we can easily read the length of the array in the main program
        public ArrayQueue(int capacity)
        {
            array = new DataType[capacity];
            head = 0;
            tail = 0;
            Length = array.Length;
        }

        public DataType Enqueue(DataType data)
        {
            array[tail] = data;
            tail++;

            if (tail == array.Length)
            {
                if (head != 0)
                {
                    ShiftArray();
                }
                else
                {
                    // Queue is full, resize the array or throw an exception
                    // For this case, let's resize the array
                    Array.Resize(ref array, array.Length * 2); //double the length
                    Length = array.Length;
                }
            }
            return data;
        }

        public DataType Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            DataType data = array[head];
            array[head] = default; //used to avoid "loiteiring"
                                   //loiteiring is when we keep references to objects that are no longer needed
            head++;
            if (Size() > 0 && Size() == array.Length / 4) //Resize the array if it's only a quarter full
            {
                // Let's shift the array so when we resize it there is no danger in losing any value
                if (head != 0) //if head is not in the first position of the array
                {
                    ShiftArray();
                }
                Array.Resize(ref array, array.Length / 2); //halve the array
                Length = array.Length;
            }
            return data;
        }

        public DataType Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return array[head];
        }

        public bool IsEmpty()
        {
            return head == tail;
        }

        public int Size()
        {
            return tail - head;
        }

        public void ShiftArray()
        {
            DataType[] copy = new DataType[array.Length]; //each time copy is instantiated, the copy array resets
            for (int i = 0; i < Size(); i++)
            {
                copy[i] = array[head + i];
            }
            array = copy;
            tail = Size();
            head = 0;
        }
        public void PrintArray()
        {
            Console.WriteLine("Array:");
            Console.Write("[ ");
            foreach (DataType data in array)
            {
                Console.Write(data + " ");
            }
            Console.WriteLine("] " + "Head: " + head + " Tail: " + tail);
        }

        public IEnumerator<DataType> GetEnumerator()
        {
            for (int i = head; i < tail; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}