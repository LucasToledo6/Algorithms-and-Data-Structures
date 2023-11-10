namespace PercolationStats
{
    public class Program
    {
        static void Main(string[] args)
        {

            PercolationStats test = new PercolationStats(4, 50);
            Console.WriteLine(test.Mean());
            Console.WriteLine(test.Stddev());
            Console.WriteLine(test.ConfidenceLo());
            Console.WriteLine(test.ConfidenceHi());
        }
    }
    public class PercolationStats
    {
        public Percolation[] percolationObject; //create an array of percolation objects
        public double[] percolationThreshold; //create an array to store the threshold for each test
        public int numberOfTrials;
        public int N;

        public PercolationStats(int n, int trials)
        {
            N = n * n;
            numberOfTrials = trials;
            percolationObject = new Percolation[numberOfTrials]; //number of trials will define how many percolation objects will be created
            percolationThreshold = new double[numberOfTrials]; //same thing with the threshold array

            Random rand = new Random();
            for (int i = 0; i < trials; i++)
            {
                percolationObject[i] = new Percolation(n); //add a percolation object to the array
                while (!percolationObject[i].Percolates()) //until this object percolates, keep opening the sites
                {
                    int[] index = new int[2];
                    index[0] = rand.Next(1, n + 1); //generates a random number from 1 to 4
                    index[1] = rand.Next(1, n + 1);
                    percolationObject[i].Open(index[0], index[1]); //since this is an experiment to obtain estimates, you can use random numbers
                                                                   //let the program do all the work
                }
                percolationThreshold[i] = (double)percolationObject[i].NumberOfOpenSites() / N; //number of sites that were necessary to open so that the system percolated
                Console.WriteLine("i: " + i + ", Open Sites: " + percolationObject[i].NumberOfOpenSites() + ", Threshold: " + percolationThreshold[i]);
            }
        }

        public double Mean()
        {
            double sum = 0;
            for (int i = 0; i < numberOfTrials; i++)
            {
                sum += percolationThreshold[i];
            }

            return sum / numberOfTrials;
        }

        public double Stddev()
        {
            double sum = 0;

            for (int i = 0; i < numberOfTrials; i++)
            {
                sum += Math.Pow(percolationThreshold[i] - Mean(), 2);
            }

            return Math.Sqrt(sum / (numberOfTrials - 1));
        }

        public double ConfidenceLo()
        {
            return Mean() - (1.96 * Stddev()) / (Math.Sqrt(numberOfTrials));
        }

        public double ConfidenceHi()
        {
            return Mean() + (1.96 * Stddev()) / (Math.Sqrt(numberOfTrials));
        }
    }
}