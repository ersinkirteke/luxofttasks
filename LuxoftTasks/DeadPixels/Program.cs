using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxoftTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Bread First Search Algorithm
             * Big O notation : O(V + E) where V is number of vertices and E is number of edges.
             */

            DeadPixel d = new DeadPixel();

            char[][] test = new char[][] {
                new char[] { '1', '0', '1' },
                new char[] { '0', '1', '0' },
                new char[] { '1', '0', '1' }
            };

            Console.WriteLine(d.CountGroups(test));

            char[][] test2 = new char[][] {
                new char[] { '1', '1', '1' },
                new char[] { '1', '0', '0' },
                new char[] { '1', '0', '1' }
            };

            Console.WriteLine(d.CountGroups(test2));

            Console.ReadLine();
        }
    }

    public class Pair
    {
        public int X { get; }
        public int Y { get; }
        public Pair(int x, int y) => (X, Y) = (x, y);
    }

    public class DeadPixel
    {
        private static readonly int[] row = { -1, 0, 0, 1 };
        private static readonly int[] col = { 0, -1, 1, 0 };

        public static bool IsSafe(char[][] monitor, int x, int y, bool[][] processed) => (x >= 0) && (x < processed.Length) && (y >= 0) && (y < processed[0].Length) && (monitor[x][y] == '1' && !processed[x][y]);

        public static void BFS(char[][] monitor, bool[][] processed, int i, int j)
        {
            Queue<Pair> queue = new Queue<Pair>();
            queue.Enqueue(new Pair(i, j));

            processed[i][j] = true;

            while (queue.Count != 0)
            {
                int x = queue.Peek().X;
                int y = queue.Peek().Y;
                queue.Dequeue();

                for (int k = 0; k < 4; k++)
                {
                    if (IsSafe(monitor, x + row[k], y + col[k], processed))
                    {
                        processed[x + row[k]][y + col[k]] = true;
                        queue.Enqueue(new Pair(x + row[k], y + col[k]));
                    }
                }
            }
        }

        public int CountGroups(char[][] monitor)
        {
            int m = monitor.Length;
            int n = monitor[0].Length;
            bool[][] processed = new bool[m][];

            for (int i = 0; i < processed.Length; i++)
            {
                processed[i] = new bool[n];
            }

            int deadPixelsGroupCount = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (monitor[i][j] == '1' && !processed[i][j])
                    {
                        BFS(monitor, processed, i, j);
                        deadPixelsGroupCount++;
                    }
                }
            }

            return deadPixelsGroupCount;
        }
    }
}
