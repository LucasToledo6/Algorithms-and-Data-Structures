namespace MinBinaryHeap
{
    public class Program
    {
        static void Main(string[] args)
        {

            MinBinaryHeap<int> minHeap = new MinBinaryHeap<int>(10);
            minHeap.Insert(3);
            minHeap.Insert(1);
            minHeap.Insert(7);
            minHeap.Insert(5);
            minHeap.Insert(2);
            minHeap.Insert(10);
            minHeap.Insert(4);
            minHeap.Insert(9);
            minHeap.Insert(6);
            minHeap.Insert(8);

            Console.WriteLine("Min Heap:");
            minHeap.Print();

            Console.WriteLine("Min Element: " + minHeap.ExtractMin());

            Console.WriteLine("Min Heap after extracting min element:");
            minHeap.Print();
        }
    }
    public class MinBinaryHeap<T> where T : IComparable<T>
    {
        private T[] heapArray;
        private int size;

        public MinBinaryHeap(int capacity)
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

        public T ExtractMin()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Heap is empty.");
            }

            T min = heapArray[1];
            Swap(1, size);
            heapArray[size] = default;
            size--;
            Sink(1);

            if (size < heapArray.Length / 4)
            {
                Array.Resize(ref heapArray, heapArray.Length / 2);
            }

            return min;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        private void Swim(int k)
        {
            while (k > 1 && More(k / 2, k))
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
                if (j < size && More(j, j + 1))
                {
                    j++;
                }

                if (!More(k, j))
                {
                    break;
                }

                Swap(k, j);
                k = j;
            }
        }

        private bool More(int i, int j)
        {
            return heapArray[i].CompareTo(heapArray[j]) > 0;
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