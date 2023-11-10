using System.Globalization;
using System.Collections;

namespace ArrayStack
{
    public class Program
    {
        static void Main(string[] args)
        {

            ArrayStack<double> stack = new ArrayStack<double>(10);

            // Push elements onto the stack
            stack.Push(1.27);
            stack.Push(2.56);
            stack.Push(3.67);
            stack.Push(4.71);
            stack.Push(5.78);
            stack.Push(6.82);
            stack.Push(7.89);
            stack.Push(8.93);
            stack.Push(9.96);
            stack.Push(10.0);
            stack.Push(69.69);

            Console.WriteLine("Number of elements in the array: " + stack.Count());
            Console.WriteLine("Size of the array: " + stack.Length);
            Console.WriteLine();

            Console.WriteLine("Popped element: " + stack.Pop().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Popped element: " + stack.Pop().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Popped element: " + stack.Pop().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Popped element: " + stack.Pop().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Popped element: " + stack.Pop().ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Popped element: " + stack.Pop().ToString(CultureInfo.InvariantCulture));

            Console.WriteLine();

            // Use the iterator to iterate and print elements in the stack
            Console.WriteLine("Stack elements:");
            foreach (var item in stack)
            {
                Console.WriteLine(item.ToString(CultureInfo.InvariantCulture));
            }

            Console.WriteLine();
            Console.WriteLine("Number of elements in the array: " + stack.Count());
            Console.WriteLine("Size of the array: " + stack.Length);
        }
    }
    public class ArrayStack<DataType> : IEnumerable<DataType>
    {
        private DataType[] array;
        private int top; //index of the top element in the stack
        public int Length { get; internal set; } //variable so that we can easily read the length of the array in the main program
        public ArrayStack(int capacity)
        {
            array = new DataType[capacity];
            top = -1; //stack is initially empty
            Length = array.Length;
        }

        public void Push(DataType data)
        {
            if (top == array.Length - 1)
            {
                // Stack is full, resize the array or throw an exception
                // For this case, let's resize the array
                Array.Resize(ref array, array.Length * 2); //double the length
                Length = array.Length;
            }

            top++;
            array[top] = data;
        }

        public DataType Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            DataType data = array[top];
            array[top] = default; //used to avoid "loiteiring"
                                  //loiteiring is when we keep references to objects that are no longer needed
            if (top > 0 && top == array.Length / 4) //Resize the array if it's only a quarter full
            {
                Array.Resize(ref array, array.Length / 2); //halve the array
                Length = array.Length;
            }
            top--;
            return data;
        }

        public DataType Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return array[top];
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public int Count()
        {
            return top + 1;
        }

        public IEnumerator<DataType> GetEnumerator()
        {
            for (int i = top; i >= 0; i--)
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