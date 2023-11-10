namespace KnuthShuffle
{
    public class Program
    {
        static void Main(string[] args)
        {

            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Original array:");
            PrintArray(array);

            // Shuffle the array
            KnuthShuffle.Shuffle(array);

            Console.WriteLine("Shuffled array:");
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