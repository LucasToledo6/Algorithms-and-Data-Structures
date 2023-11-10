namespace SelectionSort
{
    public class Program
    {
        static void Main(string[] args)
        {

            int[] array = { 64, 25, 12, 22, 11, 65, 12, 77, 89, 12, 4, 5, 6, 1, 99, 34, 45, 55, 56, 9 };
            Console.WriteLine("Original array:");
            PrintArray(array);

            // Sort the array using Selection Sort
            SelectionSort.Sort(array);

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
    public class SelectionSort
    {
        public static void Sort(int[] array)
        {
            int n = array.Length;

            // One by one move boundary of unsorted subarray
            for (int i = 0; i < n - 1; i++)
            {
                // Find the index of the minimum element in the unsorted part of the array
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Swap the found minimum element with the first element
                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
                // You can use tuple to swap values: (array[i], array[minIndex]) = (array[minIndex], array[i]); 
            }
        }

        // TIME COMPLEXITY
        // The time complexity of Selection Sort is O(N²) as there are two nested loops:
        // One loop to select an element of Array one by one = O(N)
        // Another loop to compare that element with every other Array element = O(N)
        // Therefore overall complexity = O(N) * O(N) = O(N*N) = O(N²)

        // AUXILIARY SPACE
        // O(1) as the only extra memory used is for temporary variables while swapping two values in Array.
        // The selection sort never makes more than O(N) swaps and can be useful when memory writing is costly.
    }
}