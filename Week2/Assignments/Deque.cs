using System.Globalization;
using System.Collections;

namespace Deque
{
    public class Program
    {
        static void Main(string[] args)
        {

            Deque<double> deque = new Deque<double>(5);

            // Adding elements to the back (AddLast)
            Console.WriteLine("Added to the back: " + deque.AddLast(1.111).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Added to the back: " + deque.AddLast(2.222).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Added to the back: " + deque.AddLast(3.333).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Added to the back: " + deque.AddLast(4.444).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine();

            // Adding elements to the front (AddFirst)
            Console.WriteLine("Added to the front: " + deque.AddFirst(0.666).ToString(CultureInfo.InvariantCulture));

            deque.PrintArray();
            Console.WriteLine();

            // Print the size of the queue
            Console.WriteLine("Number of elements in the array: " + deque.Size());
            Console.WriteLine("Array length: " + deque.Length);
            Console.WriteLine();

            // Adding elements to the front (AddFirst)
            Console.WriteLine("Added to the front: " + deque.AddFirst(0.567).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Added to the front: " + deque.AddFirst(0.456).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Added to the front: " + deque.AddFirst(0.345).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Added to the front: " + deque.AddFirst(0.234).ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Added to the front: " + deque.AddFirst(0.123).ToString(CultureInfo.InvariantCulture));

            Console.WriteLine();

            deque.PrintArray();
            Console.WriteLine();

            // Print the updated size of the queue
            Console.WriteLine("Updated number of elements in the array: " + deque.Size());
            Console.WriteLine("Updated array length: " + deque.Length);
            Console.WriteLine();

            // Removing elementos from the back and front
            Console.WriteLine("Removed from the back: " + deque.RemoveLast().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Removed from the front: " + deque.RemoveFirst().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Removed from the back: " + deque.RemoveLast().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Removed from the front: " + deque.RemoveFirst().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Removed from the back: " + deque.RemoveLast().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine();

            deque.PrintArray();
            Console.WriteLine();

            // Print the updated size of the queue
            Console.WriteLine("Updated number of elements in the array: " + deque.Size());
            Console.WriteLine("Updated array length: " + deque.Length);
            Console.WriteLine();

            // Returns true if the queue is empty
            Console.WriteLine("Is queue empty? " + deque.IsEmpty());

            // Use the iterator to iterate and print elements in the queue
            Console.WriteLine("Queue elements:");
            foreach (var item in deque)
            {
                Console.WriteLine(item.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
    public class Deque<DataType> : IEnumerable<DataType>
    {
        private DataType[] array;
        private int head;
        private int tail;
        public int Length { get; internal set; } //variable so that we can easily read the length of the array in the main program
        public Deque(int capacity)
        {
            array = new DataType[capacity];
            head = 0;
            tail = 0;
            Length = array.Length;
        }

        public DataType AddFirst(DataType data)
        {
            if (data == null)
            {
                throw new InvalidOperationException("Data is invalid");
            }

            if (IsEmpty())
            {
                array[head] = data;
                tail++;
            }
            else
            {
                if (head == 0)
                {
                    ShiftArrayAddFirst();
                    array[head] = data;
                }
                else
                {
                    array[--head] = data;
                }
                if (tail == array.Length)
                {
                    // Queue is full, resize the array or throw an exception
                    // For this case, let's resize the array
                    Array.Resize(ref array, array.Length * 2); //double the length
                    Length = array.Length;
                }
            }
            return data;
        }

        public DataType AddLast(DataType data)
        {
            if (data == null)
            {
                throw new InvalidOperationException("Data is invalid");
            }

            if (IsEmpty())
            {
                array[head] = data;
                tail++;
            }
            else
            {
                array[tail++] = data;
                if (tail == array.Length)
                {
                    if (head != 0)
                    {
                        ShiftArrayHeadZero();
                    }
                    else
                    {
                        // Queue is full, resize the array or throw an exception
                        // For this case, let's resize the array
                        Array.Resize(ref array, array.Length * 2); //double the length
                        Length = array.Length;
                    }
                }
            }
            return data;
        }

        public DataType RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            DataType data = array[head];
            array[head++] = default; //to avoid "loiteiring"

            if (Size() > 0 && Size() == array.Length / 4) //Resize the array if it's only a quarter full
            {
                // Let's shift the array so when we resize it there is no danger in losing any value
                if (head != 0) //if head is not in the first position of the array
                {
                    ShiftArrayHeadZero();
                }
                Array.Resize(ref array, array.Length / 2); //halve the array
                Length = array.Length;
            }
            return data;
        }

        public DataType RemoveLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            DataType data = array[--tail];
            array[tail] = default; //to avoid "loiteiring"

            if (Size() > 0 && Size() == array.Length / 4) //Resize the array if it's only a quarter full
            {
                // Let's shift the array so when we resize it there is no danger in losing any value
                if (head != 0) //if head is not in the first position of the array
                {
                    ShiftArrayHeadZero();
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

        public void ShiftArrayHeadZero()
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

        public void ShiftArrayAddFirst()
        {
            DataType[] copy = new DataType[array.Length]; //each time copy is instantiated, the copy array resets
            for (int i = 0; i < Size(); i++)
            {
                copy[i + 1] = array[head + i];
            }
            array = copy;
            tail++;
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