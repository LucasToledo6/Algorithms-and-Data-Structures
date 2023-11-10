namespace HeapSort
{
    public class Program
    {
        static void Main(string[] args)
        {

            int[] arr = { 12, 11, 13, 5, 6, 7, 2, 15, 8, 10, 9 };
            Console.WriteLine("Unsorted array:");
            PrintArray(arr);

            HeapSort.Sort(arr);

            Console.WriteLine("\nSorted array:");
            PrintArray(arr);
        }
        public static void PrintArray<T>(T[] array)
        {
            foreach (T element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

        }
    }
    public class HeapSort
    {
        public static void Sort(int[] arr)
        {
            int n = arr.Length;

            // Build a max heap.
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i);

            // Extract elements from heap one by one.
            for (int i = n - 1; i > 0; i--)
            {
                // Move the current root (maximum element) to the end of the sorted section.
                Swap(arr, 0, i);

                // Call heapify on the reduced heap.
                Heapify(arr, i, 0);
            }
        }

        // Utility function to perform the heapify procedure.
        private static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            // If left child is larger than the root.
            if (left < n && arr[left] > arr[largest])
                largest = left;

            // If right child is larger than the largest so far.
            if (right < n && arr[right] > arr[largest])
                largest = right;

            // If the largest is not the root.
            if (largest != i)
            {
                Swap(arr, i, largest);

                // Recursively heapify the affected sub-tree.
                Heapify(arr, n, largest);
            }
        }

        // Utility function to swap two elements in the array.
        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

    }
}