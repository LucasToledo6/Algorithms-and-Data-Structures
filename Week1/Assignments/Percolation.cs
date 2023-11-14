namespace Percolation
{
    public class Program
    {
        static void Main(string[] args)
        {

            Percolation obj = new Percolation(4);
            obj.Open(1, 4);
            obj.Open(2, 1);
            obj.Open(2, 4);
            obj.Open(3, 3);

            Console.WriteLine(obj.Percolates());

            obj.Open(2, 2);
            obj.Open(2, 3);
            obj.Open(4, 3);
            obj.Open(4, 4);

            Console.WriteLine(obj.IsFull(3, 3));
            Console.WriteLine(obj.NumberOfOpenSites());
            Console.WriteLine(obj.Percolates());

            Console.Write("\n");

            for (int i = 0; i < obj.N * obj.N + 2; i++) //print percolationSite in a 2D array format
            {
                Console.Write(obj.percolationSite.GetNodeValue(i) + " ");
                if (i % 4 == 0)
                    Console.Write("\n");
            }

            Console.Write("\n");
            Console.Write("\n");

            for (int i = 0; i < obj.N * obj.N + 2; i++) //print percolationState in a 2D array format
            {
                Console.Write(obj.percolationState[i] + " ");
                if (i % 4 == 0)
                    Console.Write("\n");
            }

        }
    }

    public class Percolation
    {
        public QuickUnion percolationSite;
        public int[] percolationState;
        public int N;
        public int openSites;

        // Creates n-by-n grid, with all sites initially blocked
        // Index 0 and n*n+1 are used to easily check if there's free access to the top or bottom (they are virtual nodes)
        public Percolation(int n)
        {
            N = n;
            percolationSite = new QuickUnion(N * N + 2); //percolationSite will be created so we can have an array where we can unify the elements and check if they are connected
                                                         //in other words, we are going to connect the open sites and make a path through this array
            percolationState = new int[N * N + 2];

            for (int i = 1; i < N * N + 1; i++)
            {
                percolationState[i] = 0; //percolationState will be an array made of 0s and 1s
                                         //0 represents a closed site and 1 represents a open site
            }
            percolationState[0] = 1;
            percolationState[N * N + 1] = 1;
        }

        public int Convert(int row, int col)
        {
            if (row > N || col > N)
            {
                throw new ArgumentException("Invalid Matrix Index");
            }
            return ((row - 1) * N) + col;   //transform 2 dimensional coordinates into 1 dimension
                                            //example: [1,1] = 1; [2,3] = 7
        }

        // Opens the site (row, col) if it is not open already
        public void Open(int row, int col)
        {

            if (IsOpen(row, col))
            {
                return;
            }

            int index = Convert(row, col);
            percolationState[index] = 1;    //Open the site
            openSites += 1;

            // Connect this node to all adjacent openned nodes
            // When we open a site in PercolationState, we will check and connect the adjacent open sites to it through the PercolationSite array

            if (percolationState[index + 1] == 1 && index % N != 0) //checks if the site to the right is open
                                                                    //if we are at the last column, this will be ignored 
            {
                percolationSite.WeightedUnion(index, index + 1);
            }
            if (percolationState[index - 1] == 1 && (index - 1) % N != 0) //checks if the site to the left is open
                                                                          //if we are at the first column, this will be ignored 
            {
                percolationSite.WeightedUnion(index, index - 1);
            }

            try
            {
                if (percolationState[index - N] == 1) //if index is out of bounds here, it means it's either in the first or last row
                {
                    percolationSite.WeightedUnion(index, index - N);   
                }
            }
            catch (Exception)
            {
                percolationSite.WeightedUnion(index, 0); //which means it must be connected to the first or last node (virtual nodes)
            }

            try
            {
                if (percolationState[index + N] == 1)
                {
                    percolationSite.WeightedUnion(index, index + N);
                }
            }
            catch (Exception)
            {
                percolationSite.WeightedUnion(index, N * N + 1); //virtual node
            }
        }

        // Is the site (row, col) open?
        public bool IsOpen(int row, int col)
        {
            int index = Convert(row, col);
            return percolationState[index] == 1;
        }

        // Is the site (row, col) full (meaning it has access all the way to the top)?
        public bool IsFull(int row, int col)
        {
            int index = Convert(row, col);
            return percolationSite.Connected(0, index);
        }

        // Returns the number of open sites
        public int NumberOfOpenSites()
        {
            return openSites;
        }

        // Does the system percolate?
        public bool Percolates()
        {
            return percolationSite.Connected(0, N * N + 1); //checks if the virtual nodes are connected
        }

    }
}