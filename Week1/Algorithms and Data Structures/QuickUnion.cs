namespace QuickUnion
{
    public class Program
    {
        static void Main(string[] args)
        {

            // The structure of the tree at the end doesn't matter much
            // What matters is using quick union to connect two points and then checking if they are truly connected
            // When possible, the tree is optimized so it can increase perfomance for future tests

            QuickUnion myObj = new(10);
            Console.WriteLine(myObj.Connected(3, 9));
            myObj.Union(4, 3);
            myObj.Union(3, 8);
            myObj.Union(6, 5);
            myObj.Union(9, 4);
            myObj.Union(2, 1);

            Console.WriteLine(myObj.Connected(3, 9));
            myObj.Union(5, 0);
            myObj.Union(7, 2);
            myObj.Union(6, 1);
            myObj.Union(7, 3);

            foreach (int i in myObj.QUarray) 
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");

            QuickUnion myObj2 = new(10);
            Console.WriteLine(myObj2.Connected(3, 9));
            myObj2.WeightedUnion(4, 3);
            myObj2.WeightedUnion(3, 8);
            myObj2.WeightedUnion(6, 5);
            myObj2.WeightedUnion(9, 4);
            myObj2.WeightedUnion(2, 1);

            Console.WriteLine(myObj2.Connected(3, 9));
            myObj2.WeightedUnion(5, 0);
            myObj2.WeightedUnion(7, 2);
            myObj2.WeightedUnion(6, 1);
            myObj2.WeightedUnion(7, 3);

            foreach (int i in myObj2.QUarray)
            {
                Console.Write(i + " ");
            }
        }
    }
    public class QuickUnion
    {
        public readonly int[] QUarray;
        public readonly int[] Size;  //This is a feature of Weighted Quick Union (performance improvement)

        public QuickUnion(int n) //Constructor
        {
            QUarray = new int[n];
            Size = new int[n];
            for (int i = 0; i < n; i++)
            {
                QUarray[i] = i;
                Size[i] = 1;
            }
        }

        public int GetRoot(int a)
        {
            while (a != QUarray[a]) //Path compression (performance improvement). While we are searching the root, make every node point to its grandparent to flatten the tree even more
            {
                QUarray[a] = QUarray[QUarray[a]]; 
                a = QUarray[a];
            }
            return a;
        }

        public bool Connected(int a, int b)
        {
            return GetRoot(a) == GetRoot(b);
        }

        public void Union(int a, int b)
        {
            int rootA = GetRoot(a);
            int rootB = GetRoot(b);
            QUarray[rootA] = rootB; //In this case, B has "priority", B will become the root of A, but you can easily do this the other way around
        }

        public void WeightedUnion(int a, int b)
        {
            int rootA = GetRoot(a);
            int rootB = GetRoot(b);
            if (rootA == rootB)
            {
                return;
            }
     
            if (Size[rootA] < Size[rootB]) //Always put the smaller tree below the larger one to flatten the trees and speed up getRoot() method 
            {
                QUarray[rootA] = rootB;
                Size[rootB] += Size[rootA];
            }
            else
            {
                QUarray[rootB] = rootA; //If the sizes are equal, it can go either way. In this case, A has "priority", A will become the root of B.
                Size[rootA] += Size[rootB];
            }

        }

        public int GetNodeValue(int n)
        {
            return QUarray[n];
        }

        // PERFORMANCE

        // QUICK UNION
        // Constructor: O(N)
        // Union: O(N) - Worst case, when the tree becomes tall
        // Connected: O(N) - Worst case, when the tree becomes tall

        // WEIGHTED QUICK UNION
        // Constructor: O(N)
        // Union: O(log N) - Because the tree is more balanced
        // Connected: O(log N) - Worst case

        // WEIGHTED QUICK UNION WITH PATH COMPRESSION
        // Constructor: O(N)
        // Union: O(log N) - In practice, this is very close to O(1) for all reasonable problem sizes
        // Connected: O(log N) - Also practically constant time
    }
}