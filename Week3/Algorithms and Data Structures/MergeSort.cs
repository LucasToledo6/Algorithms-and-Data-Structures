namespace MergeSort
{
    public class Program
    {
        static void Main(string[] args)
        {

            int[] array = { 64, 25, 12, 22, 11, 65, 12, 77, 89, 12, 4, 5, 6, 1, 99, 34, 45, 55, 56, 9 };
            Console.WriteLine("Original array:");
            PrintArray(array);

            // Sort the array using Merge Sort
            MergeSort.Sort(array, 0, 19);

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
    public class MergeSort
    {
        // Merges two subarrays of []arr.
        // First subarray is arr[l..m]
        // Second subarray is arr[m+1..r]
        public static void Merge(int[] arr, int lo, int mid, int hi)
        {
            // Find sizes of two subarrays to be merged
            int n1 = mid - lo + 1;
            int n2 = hi - mid;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[lo + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[mid + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged subarray array
            int k = lo;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k++] = L[i++];
                }
                else
                {
                    arr[k++] = R[j++];
                }
            }

            // Copy remaining elements of L[] if any
            while (i < n1)
            {
                arr[k++] = L[i++];
            }

            // Copy remaining elements of R[] if any
            while (j < n2)
            {
                arr[k++] = R[j++];
            }
        }

        // Main function that sorts arr[l..r] using merge()
        public static void Sort(int[] arr, int lo, int hi)
        {
            if (lo < hi)
            {

                // Find the middle point
                int mid = lo + (hi - lo) / 2;

                // Sort first and second halves
                Sort(arr, lo, mid);
                Sort(arr, mid + 1, hi);

                // Merge the sorted halves
                Merge(arr, lo, mid, hi);
            }
        }

        // Time Complexity:
        // Best Case: O(n*log(⁡n))
        // The best-case time complexity occurs when the input array is divided into subarrays of length 1,
        // and then these sorted subarrays are merged back together.Merging n subarrays takes O(n*log(⁡n)) time.

        // Average Case: O(n*log(⁡n))
        // Merge Sort always divides the array into two halves until each subarray has only one element.
        // The merging step takes O(n) time at each level of recursion, resulting in an average-case time complexity of O(n*log(⁡n)).

        // Worst Case: O(n*log(⁡n))
        // Merge Sort has a consistent O(n*log(⁡n)) time complexity, even in the worst-case scenario.
        // This is because it always divides the array into halves and then merges them back in O(n) time per level.

        // Space Complexity:
        // O(n)
        // Merge Sort is not an in-place sorting algorithm; it requires additional space proportional to the input size.
        // During the merging step, it uses an auxiliary array of size n to temporarily store the merged elements.
        // The space complexity is O(n) due to this additional storage requirement.
    }
}