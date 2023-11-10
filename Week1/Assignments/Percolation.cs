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

            for (int i = 0; i < obj.N * obj.N + 2; i++)
            {
                Console.Write(obj.percolationSite.GetNodeValue(i) + " ");
                if (i % 4 == 0)
                    Console.Write("\n");
            }

            Console.Write("\n");
            Console.Write("\n");

            for (int i = 0; i < obj.N * obj.N + 2; i++)
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

        // creates n-by-n grid, with all sites initially blocked
        // Index 0 and n*n+1 are only used to check if there's free access to the top or bottom
        public Percolation(int n)
        {
            N = n;
            percolationSite = new QuickUnion(N * N + 2);
            percolationState = new int[N * N + 2];

            for (int i = 1; i < N * N + 1; i++)
            {
                percolationState[i] = 0;
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
            return ((row - 1) * N) + col;   //Transform 2 dimensional coordinates into 1 dimension
        }

        // opens the site (row, col) if it is not open already
        public void Open(int row, int col)
        {

            if (IsOpen(row, col))
            {
                return;
            }

            int index = Convert(row, col);
            percolationState[index] = 1;    //Open Site
            openSites += 1;

            //Connect this node to all adjacent openned nodes
            if (percolationState[index + 1] == 1 && index % N != 0)
            {
                percolationSite.WeightedUnion(index, index + 1);
            }
            if (percolationState[index - 1] == 1 && (index - 1) % N != 0)
            {
                percolationSite.WeightedUnion(index, index - 1);
            }

            try
            {
                if (percolationState[index - N] == 1) //If index is out of bounds here, means it's either in the first or last row,
                {
                    percolationSite.WeightedUnion(index, index - N);   //which means it must be connected to the first or last node (virtual node)
                }
            }
            catch (Exception)
            {
                percolationSite.WeightedUnion(index, 0);
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
                percolationSite.WeightedUnion(index, N * N + 1);
            }
        }

        // is the site (row, col) open?
        public bool IsOpen(int row, int col)
        {
            int index = Convert(row, col);
            return percolationState[index] == 1;
        }

        // is the site (row, col) full (meaning it has access all the way to the top)?
        public bool IsFull(int row, int col)
        {
            int index = Convert(row, col);
            return percolationSite.Connected(0, index);
        }

        // returns the number of open sites
        public int NumberOfOpenSites()
        {
            return openSites;
        }

        // does the system percolate?
        public bool Percolates()
        {
            return percolationSite.Connected(0, N * N + 1);
        }

    }
}