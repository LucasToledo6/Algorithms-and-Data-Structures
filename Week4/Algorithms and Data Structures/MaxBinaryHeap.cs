namespace MaxBinaryHeap
{
    public class Program
    {
        static void Main(string[] args)
        {

            MaxBinaryHeap<int> maxHeap = new MaxBinaryHeap<int>(10);
            maxHeap.Insert(3);
            maxHeap.Insert(1);
            maxHeap.Insert(7);
            maxHeap.Insert(5);
            maxHeap.Insert(2);
            maxHeap.Insert(10);
            maxHeap.Insert(4);
            maxHeap.Insert(9);
            maxHeap.Insert(6);
            maxHeap.Insert(8);

            Console.WriteLine("Max Heap:");
            maxHeap.Print();

            Console.WriteLine("Max Element: " + maxHeap.ExtractMax());

            Console.WriteLine("Max Heap after extracting max element:");
            maxHeap.Print();
        }
    }
    public class MaxBinaryHeap<T> where T : IComparable<T>
    {
        private T[] heapArray;
        private int size;

        public MaxBinaryHeap(int capacity)
        {
            heapArray = new T[capacity];
            size = 0;
        }

        public void Insert(T item)
        {
            if (size >= heapArray.Length - 1)
            {
                Array.Resize(ref heapArray, heapArray.Length * 2);
            }

            size++;
            heapArray[size] = item;
            Swim(size);
        }

        public T ExtractMax()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Heap is empty.");
            }

            T max = heapArray[1];
            Swap(1, size);
            heapArray[size] = default;
            size--;
            Sink(1);

            if (size < heapArray.Length / 4)
            {
                Array.Resize(ref heapArray, heapArray.Length / 2);
            }

            return max;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        private void Swim(int k)
        {
            while (k > 1 && Less(k / 2, k))
            {
                Swap(k, k / 2);
                k /= 2;
            }
        }

        private void Sink(int k)
        {
            while (2 * k <= size)
            {
                int j = 2 * k;
                if (j < size && Less(j, j + 1))
                {
                    j++;
                }

                if (!Less(k, j))
                {
                    break;
                }

                Swap(k, j);
                k = j;
            }
        }

        private bool Less(int i, int j)
        {
            return heapArray[i].CompareTo(heapArray[j]) < 0;
        }

        private void Swap(int i, int j)
        {
            T temp = heapArray[i];
            heapArray[i] = heapArray[j];
            heapArray[j] = temp;
        }

        public void Print()
        {
            Console.Write("[ ");
            foreach (T i in heapArray)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("]");
        }
    }
}