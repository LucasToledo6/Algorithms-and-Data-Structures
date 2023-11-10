namespace InsertionSort
{
    public class Program
    {
        static void Main(string[] args)
        {

            int[] array = { 64, 25, 12, 22, 11, 65, 12, 77, 89, 12, 4, 5, 6, 1, 99, 34, 45, 55, 56, 9 };
            Console.WriteLine("Original array:");
            PrintArray(array);

            // Sort the array using Selection Sort
            InsertionSort.Sort(array);

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
    public class InsertionSort
    {
        public static void Sort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1], that are greater than key, to one position ahead of their current position
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        // TIME COMPLEXITY
        // The worst-case (array in descending order) time complexity of the Insertion sort is O(N^2)
        // The average case time complexity of the Insertion sort is O(N^2)
        // The time complexity of the best case (array in ascending order) is O(N).

        // AUXILIARY SPACE
        // The auxiliary space complexity of Insertion Sort is O(1)
    }
}