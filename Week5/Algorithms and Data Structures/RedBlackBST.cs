namespace RedBlackBST
{
    public class Program
    {
        static void Main(string[] args)
        {

            RedBlackBST<string, int> bst = new RedBlackBST<string, int>();
            bst.Put("S", 1);
            bst.Put("E", 3);
            bst.Put("R", 2);
            bst.Put("X", 4);
            bst.Put("A", 7);
            bst.Put("C", 2);
            bst.Put("H", 4);
            bst.Put("M", 7);

            foreach (string s in bst.Keys())
            {
                Console.Write(s + " ");
            }
            Console.Write("\n");
        }
    }
    public class RedBlackBST<Key, Value> where Key : IComparable<Key>
    {
        private Node Root;
        private bool RED = true;
        private bool BLACK = false;

        private class Node
        {
            public Key Key;
            public Value Value;
            public Node Left, Right;
            public bool Color; // Color of parent link

            public Node(Key key, Value value, bool color)
            {
                Key = key;
                Value = value;
                Color = color;
            }
        }

        public Value Get(Key key)
        {
            Node node = Root;
            while (node != null)
            {
                int comp = key.CompareTo(node.Key);
                if (comp < 0)
                {
                    node = node.Left;
                }
                else if (comp > 0)
                {
                    node = node.Right;
                }
                else
                {
                    return node.Value;
                }
            }
            return default;
        }

        public void Put(Key key, Value value)
        {
            Root = Put(Root, key, value);
            Root.Color = BLACK;
        }

        private Node Put(Node node, Key key, Value value)
        {
            if (node == null)
            {
                return new Node(key, value, RED);
            }

            int comp = key.CompareTo(node.Key);

            if (comp < 0)
            {
                node.Left = Put(node.Left, key, value);
            }
            else if (comp > 0)
            {
                node.Right = Put(node.Right, key, value);
            }
            else
            {
                node.Value = value;
            }

            if (IsRed(node.Right) && !IsRed(node.Left))
            {
                node = RotateLeft(node);
            }
            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RotateRight(node);
            }
            if (IsRed(node.Left) && IsRed(node.Right))
            {
                FlipColors(node);
            }

            return node;
        }

        private Node RotateLeft(Node node)
        {
            if (!IsRed(node.Right))
            {
                throw new InvalidOperationException("Right child is not red.");
            }
            Node x = node.Right;
            node.Right = x.Left;
            x.Left = node;
            x.Color = node.Color;
            node.Color = RED;
            return x;
        }

        private Node RotateRight(Node node)
        {
            if (!IsRed(node.Left))
            {
                throw new InvalidOperationException("Left child is not red.");
            }
            Node x = node.Left;
            node.Left = x.Right;
            x.Right = node;
            x.Color = node.Color;
            node.Color = RED;
            return x;
        }

        private void FlipColors(Node node)
        {
            if (IsRed(node))
            {
                throw new InvalidOperationException("Node is red.");
            }
            if (!IsRed(node.Left) || !IsRed(node.Right))
            {
                throw new InvalidOperationException("Both children are not red.");
            }

            node.Left.Color = BLACK;
            node.Right.Color = BLACK;
            node.Color = RED;
        }

        private bool IsRed(Node node)
        {
            if (node == null)
            {
                return false;
            }
            return node.Color == RED;
        }

        public IEnumerable<Key> Keys()
        {
            Queue<Key> queue = new Queue<Key>();
            LevelOrderTraversal(Root, queue);
            return queue;
        }

        private void LevelOrderTraversal(Node node, Queue<Key> queue)
        {
            if (node == null)
            {
                return;
            }
            LevelOrderTraversal(node.Left, queue);
            queue.Enqueue(node.Key);
            LevelOrderTraversal(node.Right, queue);
        }
    }
}