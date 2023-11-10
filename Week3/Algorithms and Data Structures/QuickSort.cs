namespace QuickSort
{
    public class Program
    {
        static void Main(string[] args)
        {

            int[] array = { 10, 7, 8, 9, 1, 5, 11, 3 };
            Console.WriteLine("Original array:");
            PrintArray(array);

            KnuthShuffle.Shuffle(array);
            Console.WriteLine("Shuffled array:");
            PrintArray(array);

            // Sort the array using Shell Sort
            QuickSort.Sort(array, 0, 7);

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
    public class QuickSort
    {
        // This function takes the first element as pivot, places the pivot element at its correct position in sorted array,
        // and places all smaller to the left of the pivot and all greater elements to the right of the pivot
        public static int Partition(int[] arr, int low, int high)
        {
            // Choosing the pivot
            int pivot = arr[low];

            // Index of higher element and indicates the right position of pivot found so far
            int i = (high + 1);

            for (int j = high; j > low; j--)
            {

                // If current element is higher than the pivot
                if (arr[j] > pivot)
                {

                    // Decrement index of higher element
                    i--;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, low, i - 1);
            return (i - 1);
        }

        // The main function that implements QuickSort
        // arr[] --> Array to be sorted,
        // low --> Starting index,
        // high --> Ending index
        public static void Sort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // pi is partitioning index, arr[p] is now at right place
                int pi = Partition(arr, low, high);

                // Separately sort elements before and after partition index
                Sort(arr, low, pi - 1);
                Sort(arr, pi + 1, high);
            }
        }
        // A utility function to swap two elements
        public static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        // Best Case: O(n*log(n))
        // The best-case scenario for quicksort occur when the pivot chosen at the each step divides the array into roughly equal halves.

        // Average Case: O(n*log(n))
        // Quicksort’s average-case performance is usually very good in practice, making it one of the fastest sorting Algorithm.

        // Worst Case: O(N²)
        // The worst-case Scenario for Quicksort occur when the pivot at each step consistently results in highly unbalanced partitions.
        // ***However, when the array is randomly shuffled before sorting, the likelihood of encountering the worst-case scenario is significantly reduced.

        // Auxiliary space: O(log(n))
        // Quick Sort is an in-place sorting algorithm, meaning it doesn't require additional space proportional to the input size.
        // However, it uses O(log(n)) space for the recursive call stack due to the depth of recursion.
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