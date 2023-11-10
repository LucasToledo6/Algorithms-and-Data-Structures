using System.Globalization;
using System.Collections;

namespace RandomizedQueue
{
    public class Program
    {
        static void Main(string[] args)
        {

            RandomizedQueue<double> randomizedQueue = new RandomizedQueue<double>(20);

            // Enqueue elements
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(1.111).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(2.222).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(3.333).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(4.444).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(5.555).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(6.666).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(7.777).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(8.888).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(9.999).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(10.111).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(11.222).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(12.333).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(13.444).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(14.555).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(15.666).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(16.777).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(17.888).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(18.999).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(19.111).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(20.222).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine();

            randomizedQueue.PrintArray();
            Console.WriteLine();

            // Print the size of the queue
            Console.WriteLine("Number of elements in the array: " + randomizedQueue.Size());
            Console.WriteLine("Array length: " + randomizedQueue.Length);
            Console.WriteLine();

            // Dequeue elements
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine();

            randomizedQueue.PrintArray();
            Console.WriteLine();

            // Print the updated size of the queue
            Console.WriteLine("Updated number of elements in the array: " + randomizedQueue.Size());
            Console.WriteLine("Updated array length: " + randomizedQueue.Length);
            Console.WriteLine();

            // Dequeue more elements
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine();

            randomizedQueue.PrintArray();
            Console.WriteLine();

            // Print the updated size of the queue
            Console.WriteLine("Updated number of elements in the array: " + randomizedQueue.Size());
            Console.WriteLine("Updated array length: " + randomizedQueue.Length);
            Console.WriteLine();

            // Dequeue and enqueue more elements
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(1234).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(2345).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(3456).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Enqueued: " + randomizedQueue.Enqueue(5678).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine();

            randomizedQueue.PrintArray();
            Console.WriteLine();

            // Print the updated size of the queue
            Console.WriteLine("Updated number of elements in the array: " + randomizedQueue.Size());
            Console.WriteLine("Updated array length: " + randomizedQueue.Length);
            Console.WriteLine();

            // Dequeue more elements
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Dequeued: " + randomizedQueue.Dequeue().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine();

            randomizedQueue.PrintArray();
            Console.WriteLine();

            // Print the updated size of the queue
            Console.WriteLine("Updated number of elements in the array: " + randomizedQueue.Size());
            Console.WriteLine("Updated array length: " + randomizedQueue.Length);
            Console.WriteLine();

            // Returns true if the queue is empty
            Console.WriteLine("Is queue empty? " + randomizedQueue.IsEmpty());

            // Use the iterator to iterate and print elements in the queue
            Console.WriteLine("Queue elements:");
            foreach (var item in randomizedQueue)
            {
                Console.WriteLine(item.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
    public class RandomizedQueue<DataType> : IEnumerable<DataType>
    {
        private DataType[] array;
        private int head;
        private int tail;
        private Random rand = new Random();
        public int Length { get; internal set; } //variable so that we can easily read the length of the array in the main program
        public RandomizedQueue(int capacity)
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

            int index = rand.Next(head, tail);
            DataType data = array[index];
            array[index] = default; //used to avoid "loiteiring"
                                    //loiteiring is when we keep references to objects that are no longer needed
            if (index == head)
            {
                head++;
            }
            else if (index == tail - 1)
            {
                tail--;
            }
            else
            {
                tail--;
                for (int i = 0; i < tail - index; i++)
                {
                    array[index + i] = array[index + 1 + i];
                }
                array[tail] = default;
            }
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

        public DataType Sample()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            int index = rand.Next(head, tail);

            return array[index];
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