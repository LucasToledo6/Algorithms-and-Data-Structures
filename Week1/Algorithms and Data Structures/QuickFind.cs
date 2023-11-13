namespace QuickFind
{
    public class Program
    {
        static void Main(string[] args)
        {

            QuickFind myObj = new(9);
            Console.WriteLine(myObj.Connected(0, 5));
            myObj.Union(0, 5);
            Console.WriteLine(myObj.Connected(0, 5));
        }
    }
    public class QuickFind
    {
        private readonly int[] UFarray;

        public QuickFind(int n) //Constructor
        {
            UFarray = new int[n];
            for (int i = 0; i < n; i++)
            {
                UFarray[i] = i;
            }
        }

        public bool Connected(int a, int b) //Check if the values are equal, i.e. if they are connected
        {
            return UFarray[a] == UFarray[b];
        }

        public void Union(int a, int b)
        {

            //We need to store these values before because UFarray[a and b] are constantly changing throughout the loop
            int valueofa = UFarray[a];
            int valueofb = UFarray[b];

            for (int i = 0; i < UFarray.Length; i++)    //Check every value in the array
            {
                if (UFarray[i] == valueofa)             //If the value being checked is equal to the value inside index a
                {
                    UFarray[i] = valueofb;              //Swap this value for the value inside index b (b has "priority")
                }
            }

        }

        // PERFORMANCE

        // Initialization: O(N)
        // Union: O(N) (Since it needs to iterate through the entire array to change IDs)
        // Connected/Find: O(1) (Direct array access)
    }
}