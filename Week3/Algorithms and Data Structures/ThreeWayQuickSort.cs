namespace ThreeWayQuickSort
{
    public class Program
    {
        static void Main(string[] args)
        {

            int[] array = { 10, 4, 4, 4, 1, 5, 4, 3, 4, 9, 8, 12, 2, 4, 6 };
            Console.WriteLine("Original array:");
            PrintArray(array);

            KnuthShuffle.Shuffle(array);
            Console.WriteLine("Shuffled array:");
            PrintArray(array);

            // Sort the array using Shell Sort
            ThreeWayQuickSort.Sort(array, 0, 14);

            Console.WriteLine("Sorted array:");
            PrintArray(array);
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
    public class ThreeWayQuickSort
    {
        // The main function that implements 3-Way QuickSort
        public static void Sort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // lt and gt are the partitions for elements less than and greater than the pivot
                int lt, gt;
                (lt, gt) = Partition(arr, low, high);

                // Recursively sort elements before lt and after gt
                Sort(arr, low, lt - 1);
                Sort(arr, gt + 1, high);
            }
        }

        // This function is used to partition the array into three parts
        public static (int, int) Partition(int[] arr, int low, int high)
        {
            if (high <= low) return (low, high);

            int lt = low, gt = high;
            int pivot = arr[low];
            int i = low;

            while (i <= gt)
            {
                if (arr[i] < pivot)
                {
                    Swap(arr, lt++, i++);
                }
                else if (arr[i] > pivot)
                {
                    Swap(arr, i, gt--);
                }
                else
                {
                    i++;
                }
            }
            // now arr[low..lt-1] < pivot = arr[lt..gt] < arr[gt+1..high]
            return (lt, gt);
        }

        // A utility function to swap two elements
        public static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        // Best Case: O(n*log(n))
        // Average Case: O(n*log(n))
        // Worst Case: O(N²) - Improved with 3-way partitioning for cases with many duplicates
        // Auxiliary space: O(log(n))

        // 3-way QuickSort is particularly effective for arrays with many duplicate keys because it reduces the number of comparisons and swaps.
    }
    public class KnuthShuffle
    {
        private static Random random = new Random();

        public static void Shuffle<T>(T[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; i++)
            {
                int j = random.Next(0, i + 1); //only the elements that have been "seen" are randomized

                // Swap array[i] and array[j]
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}