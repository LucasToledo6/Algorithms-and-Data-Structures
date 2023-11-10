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

        public QuickFind(int n)
        {
            this.UFarray = new int[n];
            for (int i = 0; i < n; i++)
            {
                UFarray[i] = i;
            }
        }

        public bool Connected(int a, int b)
        {
            return UFarray[a] == UFarray[b];
        }

        public void Union(int a, int b)
        {

            //It is important to get the values before because UFarray[a and b] are constantly changing throughout the loop, which would result in a bug
            int valueofa = UFarray[a];
            int valueofb = UFarray[b];

            for (int i = 0; i < UFarray.Length; i++)    //Check every value in the array
            {
                if (UFarray[i] == valueofa)             //If the value being checked is equal to the value inside index a
                {
                    UFarray[i] = valueofb;              //Swap the this value for the value inside index b
                }
            }

        }

        /*
        PERFORMANCE
        Array accesses
            Constructor: N
            Union: N
            Connected: 1
        */
    }
}