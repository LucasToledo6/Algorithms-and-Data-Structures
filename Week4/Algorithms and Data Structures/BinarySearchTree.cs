namespace BinarySearchTree
{
    public class Program
    {
        static void Main(string[] args)
        {

            BinarySearchTree<string, int> bst = new BinarySearchTree<string, int>();
            bst.Put("S", 1);
            bst.Put("E", 3);
            bst.Put("R", 2);
            bst.Put("X", 4);
            bst.Put("A", 7);
            bst.Put("C", 2);
            bst.Put("H", 4);
            bst.Put("M", 7);
            Console.WriteLine(bst.Floor("G"));
            Console.WriteLine(bst.Ceiling("G"));
            Console.WriteLine(bst.Get("A"));
            Console.WriteLine(bst.Size());
            Console.WriteLine(bst.Rank("E"));

            foreach (var s in bst.Keys())
            {
                Console.Write(s + " ");
            }
            Console.Write("\n");

            bst.DeleteMin();

            foreach (var s in bst.Keys())
            {
                Console.Write(s + " ");
            }
            Console.Write("\n");

            Console.WriteLine(bst.Floor("G"));
            Console.WriteLine(bst.Ceiling("G"));
            Console.WriteLine(bst.Get("A"));
            Console.WriteLine(bst.Size());
            Console.WriteLine(bst.Rank("E"));

            bst.Delete("E");

            foreach (var s in bst.Keys())
            {
                Console.Write(s + " ");
            }
            Console.Write("\n");

            Console.WriteLine(bst.Floor("G"));
            Console.WriteLine(bst.Ceiling("G"));
            Console.WriteLine(bst.Size());
            Console.WriteLine(bst.Rank("E"));
        }
    }
    public class BinarySearchTree<Key, Value> where Key : IComparable<Key>
    {
        private class Node
        {
            public Key Key;
            public Value Val;
            public Node Left, Right;
            public int Size;

            public Node(Key key, Value val, int size)
            {
                Key = key;
                Val = val;
                Size = size;
            }
        }

        private Node Root;

        public void Put(Key key, Value val)
        {
            Root = Put(Root, key, val); //starting position, it starts checking from the top (root)
                                        //at the end, when an element has been successfully put, the variable is updated
                                        //we could say the variable "root" in this case represents all the BST
        }

        private Node Put(Node node, Key key, Value val)
        {
            if (node == null)
            {
                return new Node(key, val, 1); //when we finally reach an empty space, we create a new node (key, value and size)
            }
            int compare = key.CompareTo(node.Key); //compare the key we are trying to put with the key in question
                                                   //-1 when the new key is smaller, 0 when they are equal, 1 when the new key is larger
            if (compare > 0)
            {
                node.Right = Put(node.Right, key, val); //recursive function so we can keep going down the tree
            }
            else if (compare < 0)
            {
                node.Left = Put(node.Left, key, val); //recursion
            }
            else
            {
                node.Val = val; //when we are trying to put a key that already exists, we just update its value
            }
            node.Size = 1 + Size(node.Left) + Size(node.Right); //how many keys are connected to the key in question
            return node;
        }

        public Value Get(Key key)
        {
            return Get(Root, key); //same logic as the "put" method, but we are just trying to get the value of a key now
                                   //that's why there is no need to update the Root variable, we just return some value
        }

        private Value Get(Node node, Key key)
        {
            if (node == null)
            {
                return default; //if we can't find the key, returns the default value (in the case of "int", the default is 0)
            }

            int compare = key.CompareTo(node.Key);

            if (compare > 0)
            {
                return Get(node.Right, key); //recursion
            }
            else if (compare < 0)
            {
                return Get(node.Left, key); //recursion
            }
            else
            {
                return node.Val; //when we finally find the key, return its value
            }
        }

        public void Delete(Key key)
        {
            Root = Delete(Root, key); //same logic as the Put() method, but we are going to delete a specific key now
        }

        private Node Delete(Node node, Key key)
        {
            if (node == null)
            {
                return null; //if we can't find it, go back
            }

            int compare = key.CompareTo(node.Key);
            if (compare < 0)
            {
                node.Left = Delete(node.Left, key);
            }
            else if (compare > 0)
            {
                node.Right = Delete(node.Right, key);
            }
            else //when we find the key we want to delete
            {
                if (node.Right == null)
                {
                    return node.Left; //if the right element is null, the left element will simply take the place of the key we want to delete
                }
                if (node.Left == null)
                {
                    return node.Right; //if the left element is null, the right element will simply take the place of the key we want to delete
                }

                //In case it has both children, replace by its successor (ceiling)
                Node t = node; //put the key that will be deleted in this variable, so we can handle it safely
                node = Min(t.Right); //find the successor (ceiling) and replace the key we want to delete
                node.Right = DeleteMin(t.Right); //delete the successor from its original position
                node.Left = t.Left; //the left part of the key will stay the same
            }
            node.Size = 1 + Size(node.Left) + Size(node.Right);
            return node;
        }

        public bool Contains(Key key)
        {
            return Get(key) != null; //if the tree cointains the specified key
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public int Size()
        {
            return Size(Root);
        }

        private int Size(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            return node.Size;
        }

        public Key Min()
        {
            if (IsEmpty())
            {
                return default; //if the BST is empty, returns the default value
            }
            return Min(Root).Key;
        }

        private Node Min(Node node)
        {
            if (node.Left == null)
            {
                return node;
            }
            return Min(node.Left); //to get the smallest key of the BST, we just got to go left
        }

        public Key Max()
        {
            if (IsEmpty())
            {
                return default;
            }
            return Max(Root).Key;
        }

        private Node Max(Node node)
        {
            if (node.Right == null)
            {
                return node;
            }
            return Max(node.Right); //to get the largest key of the BST, we just got to go right
        }

        public Key Floor(Key key) //floor is the largest key in the BST less than or equal to the specified key
        {
            Node x = Floor(Root, key);
            if (x == null)
            {
                return default;
            }
            return x.Key;
        }

        private Node Floor(Node node, Key key)
        {
            if (node == null)
            {
                return null; //we reached the end of the path, go back
            }
            int compare = key.CompareTo(node.Key);
            if (compare == 0)
            {
                return node;
            }
            else if (compare < 0)
            {
                return Floor(node.Left, key);
            }
            Node t = Floor(node.Right, key); //when we reach this line, it means the key in question (KEY) is the best candidate to be the ceiling
                                             //now, we are going to go right to see if there is a better candidate                               
            if (t != null)
            {
                return t; //After all the recursion, if t receives a key, this key is the ceiling
            }
            else
            {
                return node; //if t receives "null", that means our key from before (KEY) is the ceiling
            }
        }

        public Key Ceiling(Key key) //ceiling is the smallest key in the BST greater than or equal to the specified key
        {
            Node x = Ceiling(Root, key);
            if (x == null)
            {
                return default;
            }
            return x.Key;
        }

        private Node Ceiling(Node node, Key key)
        {
            if (node == null)
            {
                return null; //we reached the end of the path, go back
            }
            int compare = key.CompareTo(node.Key);
            if (compare == 0)
            {
                return node;
            }
            else if (compare > 0)
            {
                return Ceiling(node.Right, key);
            }
            Node t = Ceiling(node.Left, key); //same logic as the Floor() method, but now we go to the left
            if (t != null)
            {
                return t;
            }
            else
            {
                return node;
            }
        }

        public int Rank(Key key) //number of keys less than the specified key
        {
            return Rank(key, Root);
        }

        private int Rank(Key key, Node node)
        {
            if (node == null)
            {
                return 0;
            }

            int compare = key.CompareTo(node.Key);
            if (compare < 0)
            {
                return Rank(key, node.Left);
            }
            else if (compare > 0)
            {
                return 1 + Size(node.Left) + Rank(key, node.Right);
            }
            else
            {
                return Size(node.Left);
            }
        }

        public void DeleteMin()
        {
            Root = DeleteMin(Root);
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left == null) //when left is null, that means we found our smallest element
            {
                return node.Right; //so now, the element to the right of the smallest element will take its place
                                   //regardless if the right element is null or not
            }
            node.Left = DeleteMin(node.Left);
            node.Size = 1 + Size(node.Left) + Size(node.Right); //update the size, now that the smallest element is gone
            return node;
        }

        public void DeleteMax()
        {
            Root = DeleteMax(Root);
        }

        private Node DeleteMax(Node x)
        {
            if (x.Right == null) //same logic as the DeleteMin() method
                                 //when right is null, that means we found our largest element
            {
                return x.Left; //so now, the element to the left will take its place
            }
            x.Right = DeleteMax(x.Right);
            x.Size = 1 + Size(x.Left) + Size(x.Right);
            return x;
        }

        public IEnumerable<Key> Keys()
        {
            Queue<Key> queue = new Queue<Key>(); //we create a queue to store the keys
            LevelOrderTraversal(Root, queue);
            return queue;
        }

        private void LevelOrderTraversal(Node node, Queue<Key> queue) // Level Order Traversal technique is defined as a method to traverse a Tree such that
                                                                      // all nodes present in the same level are traversed completely before traversing the next level.
        {
            if (node == null)
                return;
            LevelOrderTraversal(node.Left, queue);
            queue.Enqueue(node.Key);
            LevelOrderTraversal(node.Right, queue);
        }

        // TIME COMPLEXITY:

        // GET()
        // The time complexity for GET in a BST is O(h), where h is the height of the tree.
        // In the best case, when the tree is perfectly balanced, h = log⁡(n) and the time complexity is O(log⁡(n)).
        // In the worst case, when the tree is completely unbalanced(e.g., a tree that's degenerated into a linked list), h=n and the time complexity is O(n).

        // PUT()
        // Similar to GET, the time complexity for inserting a new node is O(h), which is O(log⁡(n)) in the best case
        // O(n) in the worst case.

        // DELETE()
        // Deleting a node also has the same time complexity as GET and PUT, i.e., O(h), because you first need to find the node to be deleted.

        // TRAVERSAL()
        // Operations that involve traversing the tree, such as in-order, pre-order, or post-order traversal
        // have a time complexity of O(n) since each node is visited once.

        // SPACE COMPLEXITY:

        // STORAGE SPACE
        // The space complexity for storing a BST with nn nodes is O(n), as you need space for each node.

        // OPERATIONAL SPACE:
        // For recursive operations, the space complexity can be O(h) due to the call stack during the recursion,
        // which in the best case is O(log⁡(n)) and in the worst case is O(n).
        // For non-recursive (iterative) operations, the space complexity can be considered as O(1), constant space.
    }
}