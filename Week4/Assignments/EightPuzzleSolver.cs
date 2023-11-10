namespace EightPuzzleSolver
{
    public class Program
    {
        static void Main(string[] args)
        {

            // Create a sample 3x3 board
            int[][] initialTiles =
            {
            new int[] {0, 1, 3},
            new int[] {4, 2, 5},
            new int[] {7, 8, 6}
            };

            Board board = new Board(initialTiles);

            // Display the board
            Console.WriteLine("Initial Board:");
            Console.WriteLine(board);
            Console.WriteLine($"Is this the goal board? {board.IsGoal()}");
            Console.WriteLine($"Number of inversions: {board.Inversions()}");

            // Display neighbors
            Console.WriteLine("\nNeighbors:");
            foreach (Board neighbor in board.Neighbors())
            {
                Console.WriteLine(neighbor);
            }

            // Check equality
            Board anotherBoard = board.CreateCopy();
            Console.WriteLine($"\nIs the initial board equal to its copy? {board.Equals(anotherBoard)}");

            // Solve the board
            Solver solver = new Solver(board, new Board.ByManhattanComparer());

            // Check if it's solvable and display the solution
            if (solver.IsSolvable())
            {
                Console.WriteLine($"\nMinimum number of moves to solve the puzzle: {solver.Moves()}");
                Console.WriteLine("\nSolution sequence:");
                foreach (Board step in solver.Solution())
                {
                    Console.WriteLine(step);
                }
            }
            else
            {
                Console.WriteLine("\nThe puzzle is not solvable.");
            }

            //It's normal to run out of memory.
            //The A* algorithm (with the Manhattan priority function) will struggle to solve some 4-by-4 and even 3-by-3 puzzles
        }
    }
    public class Board
    {
        private readonly int[][] tiles;
        private readonly int lines;
        private readonly int columns;

        private readonly List<Board> neighbors = new List<Board>();

        public int manhattan { get; }
        public int hamming { get; }

        public static readonly IComparer<Board> ByManhattan = new ByManhattanComparer();
        public static readonly IComparer<Board> ByHamming = new ByHammingComparer();

        public Board(int[][] tiles)
        {
            this.tiles = tiles;
            lines = tiles.Length;
            columns = tiles[0].Length;

            if (lines != columns)
                throw new ArgumentException("The board is not symmetrical");

            for (int i = 1; i < lines; i++)
            {
                if (tiles[i].Length != columns)
                    throw new ArgumentException("A line of the board is not complete");
            }

            hamming = -1 * Hamming();
            manhattan = -1 * Manhattan();
        }

        public override string ToString()
        {
            var result = lines + "\n";
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result += tiles[i][j] + " ";
                }
                result += "\n";
            }
            return result;
        }

        public int Dimension()
        {
            return lines;
        }

        private int Hamming()
        {
            int counter = 0;
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (tiles[i][j] != CoordinatesToPosition(i, j))
                        counter++;
                }
            }

            counter--; //we have to desconsider the 0
            return counter;
        }

        private int Manhattan()
        {
            int result = 0;
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (tiles[i][j] == 0)
                        continue;

                    var goalPos = PositionToCoordinates(tiles[i][j]);
                    result += Math.Abs(goalPos[0] - i) + Math.Abs(goalPos[1] - j);
                }
            }
            return result;
        }

        public bool IsGoal()
        {
            return Hamming() == 0;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Board tempBoard)
            {
                if (tempBoard.Dimension() != Dimension())
                    return false;

                for (int i = 0; i < lines; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (tiles[i][j] != tempBoard.tiles[i][j])
                            return false;
                    }
                }
                return true;
            }
            return false;
        }

        public IEnumerable<Board> Neighbors()
        {
            GetNeighbors();
            return neighbors;
        }

        private void GetNeighbors()
        {
            neighbors.Clear();
            int[] coord = new int[2];
            int[][][] placeholderTile = new int[4][][];
            for (int k = 0; k < 4; k++)
            {
                placeholderTile[k] = new int[lines][];
                for (int i = 0; i < lines; i++)
                {
                    placeholderTile[k][i] = new int[columns];
                }
            }

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (tiles[i][j] == 0)
                    {
                        coord[0] = i;
                        coord[1] = j;
                    }

                    for (int k = 0; k < 4; k++)
                    {
                        placeholderTile[k][i][j] = tiles[i][j];
                    }
                }
            }

            int[] dx = { 1, 0, -1, 0 };
            int[] dy = { 0, 1, 0, -1 };
            for (int i = 0; i < 4; i++)
            {
                int newX = coord[0] + dx[i];
                int newY = coord[1] + dy[i];
                if (newX >= 0 && newX < lines && newY >= 0 && newY < columns)
                {
                    placeholderTile[i][coord[0]][coord[1]] = placeholderTile[i][newX][newY];
                    placeholderTile[i][newX][newY] = 0;
                    neighbors.Add(new Board(placeholderTile[i]));
                }
            }
        }

        public Board Twin()
        {
            int[][] placeholderTile = new int[lines][];
            for (int i = 0; i < lines; i++)
            {
                placeholderTile[i] = new int[columns];
                Array.Copy(tiles[i], placeholderTile[i], columns);
            }

            if (placeholderTile[0][0] == 0 || placeholderTile[0][1] == 0)
            {
                int swap = placeholderTile[lines - 1][columns - 1];
                placeholderTile[lines - 1][columns - 1] = placeholderTile[lines - 1][columns - 2];
                placeholderTile[lines - 1][columns - 2] = swap;
            }
            else
            {
                int swap = placeholderTile[0][0];
                placeholderTile[0][0] = placeholderTile[0][1];
                placeholderTile[0][1] = swap;
            }
            return new Board(placeholderTile);
        }

        public int Inversions()
        {
            int counter = 0;
            int[] copy = new int[lines * columns];
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    copy[i * lines + j] = tiles[i][j];
                }
            }

            for (int i = 0; i < copy.Length; i++)
            {
                if (copy[i] == 0) continue;
                for (int j = i + 1; j < copy.Length; j++)
                {
                    if (copy[j] == 0) continue;
                    if (copy[i] > copy[j]) counter++;
                }
            }
            return counter;
        }

        public Board CreateCopy()
        {
            int[][] copy = new int[lines][];
            for (int i = 0; i < lines; i++)
            {
                copy[i] = new int[columns];
                Array.Copy(tiles[i], copy[i], columns);
            }
            return new Board(copy);
        }

        private int CoordinatesToPosition(int x, int y)
        {
            if (x >= lines || y >= columns) throw new ArgumentException("Position out of bounds");
            return x * columns + y + 1;
        }

        private int[] PositionToCoordinates(int pos)
        {
            if (pos > lines * columns) throw new ArgumentException("Position out of bounds");
            return new[] { (pos - 1) / columns, (pos - 1) % columns };
        }

        public class ByManhattanComparer : IComparer<Board>
        {
            public int Compare(Board a, Board b)
            {
                if (a.manhattan == b.manhattan)
                    return 0;
                else if (a.manhattan < b.manhattan)
                    return -1;
                else
                    return 1;
            }
        }

        public class ByHammingComparer : IComparer<Board>
        {
            public int Compare(Board a, Board b)
            {
                if (a.hamming == b.hamming)
                    return 0;
                else if (a.hamming < b.hamming)
                    return -1;
                else
                    return 1;
            }
        }
    }
    public class Solver
    {
        private Board initialBoard;
        private List<Board> result = new List<Board>();

        public Solver(Board initial, IComparer<Board> comp)
        {
            if (initial == null)
                throw new ArgumentNullException("Board is null");

            initialBoard = initial;

            if (!IsSolvable())
                return;

            if (initialBoard.IsGoal())
            {
                result.Add(initialBoard);
                return;
            }

            SortedSet<Board> priorityQueue = new SortedSet<Board>(comp)
            {
                initialBoard
            };

            Board placeholder = initialBoard;

            while (!placeholder.IsGoal())
            {
                placeholder = priorityQueue.Max;
                priorityQueue.Remove(placeholder);
                result.Add(placeholder);

                foreach (var b in placeholder.Neighbors())
                {
                    if (result.Count < 2)
                        priorityQueue.Add(b);
                    else if (!b.Equals(result[result.Count - 2]))
                        priorityQueue.Add(b);
                }
            }
        }

        public bool IsSolvable()
        {
            return initialBoard.Inversions() % 2 == 0;
        }

        public int Moves()
        {
            if (!IsSolvable())
                return -1;

            return result.Count - 1;
        }

        public IEnumerable<Board> Solution()
        {
            if (!IsSolvable())
                return null;

            return result;
        }
    }
}