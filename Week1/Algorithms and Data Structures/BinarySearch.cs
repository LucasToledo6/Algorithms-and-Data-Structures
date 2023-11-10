namespace BinarySearch
{
    public class Program
    {
        static void Main(string[] args)
        {

            int[] sortedArray = { 2, 5, 8, 12, 16, 23, 38, 45, 56, 72, 91 };

            Console.Write("Write your targeted number: ");
            int target = int.Parse(Console.ReadLine());

            int result = BinarySearch.Search(sortedArray, target);

            if (result != -1)
            {
                Console.WriteLine("Element found at index: " + result);
            }
            else
            {
                Console.WriteLine("Element not found in the array.");
            }
        }
    }
    public static class BinarySearch
    {
        public static int Search(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                // Check if the target is present at the middle
                if (array[mid] == target)
                {
                    return mid;
                }

                // If the target is greater, ignore the left half of the array
                if (array[mid] < target)
                {
                    left = mid + 1;
                }
                // If the target is smaller, ignore the right half of the array
                else
                {
                    right = mid - 1;
                }
            }

            // Target was not found in the array
            return -1;
        }
    }
}