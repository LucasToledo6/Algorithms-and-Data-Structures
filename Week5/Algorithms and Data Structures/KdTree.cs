namespace KdTree
{
    public class Program
    {
        static void Main(string[] args)
        {

            // Initialize root node as null
            Node root = null;

            // Define an array of points to be inserted into the tree
            int[][] points = {
            new int[] { 3, 6 },
            new int[] { 17, 15 },
            new int[] { 13, 15 },
            new int[] { 6, 12 },
            new int[] { 9, 1 },
            new int[] { 2, 7 },
            new int[] { 10, 19 }
            };

            // Get the length of the points array
            int n = points.Length;

            // Create a new KdTree object with k=2
            KdTree tree = new KdTree(2);

            // Insert all the points into the tree and update the root node
            for (int i = 0; i < n; i++)
            {
                root = tree.insert(root, points[i]);
            }

            // Define a point to search for in the tree
            int[] point1 = { 10, 19 };

            // Search for the point in the tree and print the result
            if (tree.Search(root, point1))
            {
                Console.WriteLine("Found");
            }
            else
            {
                Console.WriteLine("Not Found");
            }

            // Define another point to search for in the tree
            int[] point2 = { 12, 19 };

            // Search for the point in the tree and print the result
            if (tree.Search(root, point2))
            {
                Console.WriteLine("Found");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
    }
    // Defining the Node class with an integer array to hold the point and references to left and right nodes
    public class Node
    {
        public int[] point;
        public Node left;
        public Node right;

        // Defining a constructor to initialize the Node object
        public Node(int[] point)
        {
            this.point = point;
            left = null;
            right = null;
        }

    }

    public class KdTree
    {
        private int k;

        // Defining a constructor to initialize the KdTree object
        public KdTree(int k)
        {
            this.k = k;
        }

        // Defining a method to create a new Node object
        public static Node NewNode(int[] point)
        {
            return new Node(point);
        }

        // Defining a recursive method to insert a point into the K-d tree
        public Node InsertRec(Node root, int[] point, int depth)
        {
            if (root == null)
            {
                return NewNode(point);
            }

            int cd = depth % k;

            if (point[cd] < root.point[cd])
            {
                root.left = InsertRec(root.left, point, depth + 1);
            }
            else
            {
                root.right = InsertRec(root.right, point, depth + 1);
            }

            return root;
        }

        // Defining a method to insert a point into the K-d tree
        public Node insert(Node root, int[] point)
        {
            return InsertRec(root, point, 0);
        }

        // Defining a method to check if two points are the same
        public bool arePointsSame(int[] point1, int[] point2)
        {
            for (int i = 0; i < k; i++)
            {
                if (point1[i] != point2[i])
                {
                    return false;
                }
            }

            return true;
        }

        // Defining a recursive method to search for a point in the K-d tree
        public bool SearchRec(Node root, int[] point, int depth)
        {
            if (root == null)
            {
                return false;
            }

            if (arePointsSame(root.point, point))
            {
                return true;
            }

            int cd = depth % k;

            if (point[cd] < root.point[cd])
            {
                return SearchRec(root.left, point, depth + 1);
            }

            return SearchRec(root.right, point, depth + 1);
        }

        // Defining a method to search for a point in the K-d tree
        public bool Search(Node root, int[] point)
        {
            return SearchRec(root, point, 0);
        }

    }
}