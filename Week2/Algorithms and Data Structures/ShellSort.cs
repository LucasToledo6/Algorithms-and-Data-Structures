namespace ShellSort
{
    public class Program
    {
        static void Main(string[] args)
        {

            int[] array = { 64, 25, 12, 22, 11, 65, 12, 77, 89, 12, 4, 5, 6, 1, 99, 34, 45, 55, 56, 9 };
            Console.WriteLine("Original array:");
            PrintArray(array);

            // Sort the array using Shell Sort
            ShellSort.Sort(array);

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
    public class ShellSort
    {
        public static void Sort(int[] array)
        {
            int n = array.Length;
            int gap = 1;

            // Calculate initial gap using the 3x + 1 sequence (it's an okay solution, easy to compute)
            while (gap < n / 3)
            {
                gap = 3 * gap + 1;
            }

            // Start with the largest gap and reduce the gap using 3x + 1 sequence
            while (gap >= 1)
            {
                // Do an insertion sort for elements at gap positions
                for (int i = gap; i < n; i++)
                {
                    int temp = array[i];
                    int j;

                    // Shift elements until the correct location for temp is found
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }

                    array[j] = temp;
                }

                // Reduce the gap using 3x + 1 sequence
                gap /= 3;
            }

            // Shell Sort has a time complexity that depends on the gap sequence used.
            // The worst-case time complexity is O(n^2) for the traditional Shell Sort.
            // However, the performance can be significantly improved with certain gap sequences,
            // leading to an average-case time complexity of O(n^(3/2)) or even O(n log n) for the best cases.

            // The space complexity of the shell sort is O(1).
        }
    }
}