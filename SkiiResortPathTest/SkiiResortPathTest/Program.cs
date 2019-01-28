using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiiResortPathTest
{
    class Program
    {
        public static int n = 4;
        public static int m = 4;
        public static int bestJ = 0;
        public static int bestI = 0;
        public static string concatPath = string.Empty;
        static void Main(string[] args)
        {
            // basic scenario
            int[][] path = new int[][]
                          {
                              new int[] {4, 8, 7, 3},
                              new int[] {2, 5, 9, 3},
                              new int[] {6, 3, 2, 5},
                              new int[] {4, 4, 1, 6}
                          };
            ReadFile read = new ReadFile();
            // Read the first line of the txt file an get the size of the matrix
            int nSIze = read.getSizeMatrix();
            int mSize = nSIze;
            //get the path from the txt file
            //path = read.getMatrixFromTxt(nSIze, mSize);
            findBestStartingPoint(path);
            Console.WriteLine("Length of the longest path is " + findPathLength(path));
            Console.WriteLine("Best Path " + concatPath.Substring(1, concatPath.Length - 1));
            Console.WriteLine("Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
        // get the best starting point
        public static void findBestStartingPoint(int[][] mat)
        {
            int great = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (great < mat[i][j])
                    {
                        great = mat[i][j];
                        bestI = i;
                        bestJ = j;
                    }
                }
            }
        }
        // returns the lenght of calculated path
        public static int findPathLength(int[][] matrix)
        {
            int result = 0;

            //Initialize path auxiliar with -1 in all positions
            int[][] auxPath = InitializeAuxPath(n, m);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    auxPath[i][j] = -1;
                }
            }
            result = findBestPathFromPosition(bestI, bestJ, matrix, auxPath);

            return result;
        }

        // initialize auxiliar path and returns a marix
        public static int[][] InitializeAuxPath(int n, int m)
        {
            int[][] matrix = new int[n][];
            for (int mat = 0; mat < n; mat++)
            {
                matrix[mat] = new int[m];
            }
            return matrix;
        }
        // check all possible directions to get the best way
        public static int findBestPathFromPosition(int i, int j, int[][] mat, int[][] aux)
        {
            int east = 0, west = 0, south = 0, north = 0, bigestNum = 0;

            if (concatPath == "")
            {
                concatPath = concatPath + "," + (mat[i][j]);
            }
            if (i < 0 || i >= n || j < 0 || j >= n)
            {
                return 0;
            }

            if (aux[i][j] != -1)
            {
                return aux[i][j];
            }
            if (i >= 0 && j >= 0)
            {
                // check east
                if (j < n - 1 && ((mat[i][j]) > mat[i][j + 1]))
                {
                    east = mat[i][j + 1];
                }
                //check west
                if (j > 0 && (mat[i][j] > mat[i][j - 1]))
                {
                    west = mat[i][j - 1];
                }
                // check north
                if (i > 0 && (mat[i][j] > mat[i - 1][j]))
                {
                    north = mat[i - 1][j];
                }
                //check south
                if (i < n - 1 && (mat[i][j] > mat[i + 1][j]))
                {
                    south = mat[i + 1][j];
                }
                bigestNum = getGreaterNum(east, west, south, north);
                if (bigestNum > 0)
                {
                    if (east == bigestNum)
                    {
                        concatPath = concatPath + "," + east;
                        return aux[i][j] = 1 + findBestPathFromPosition(i, j + 1, mat, aux);
                    }
                    if (west == bigestNum)
                    {
                        concatPath = concatPath + "," + west;
                        return aux[i][j] = 1 + findBestPathFromPosition(i, j - 1, mat, aux);
                    }
                    if (north == bigestNum)
                    {
                        concatPath = concatPath + "," + north;
                        return aux[i][j] = 1 + findBestPathFromPosition(i - 1, j, mat, aux);
                    }
                    if (south == bigestNum)
                    {
                        concatPath = concatPath + "," + south;
                        return aux[i][j] = 1 + findBestPathFromPosition(i + 1, j, mat, aux);
                    }
                }
            }
            return aux[i][j] = 1;
        }

        public static int getGreaterNum(int a, int b, int c, int d)
        {
            int bigNumber = 0;
            if (a > b && a > c && a > d)
            {
                bigNumber = a;
            }
            if (b > a && b > c && b > d)
            {
                bigNumber = b;
            }
            if (c > a && c > b && c > d)
            {
                bigNumber = c;
            }
            if (d > a && d > c && d > b)
            {
                bigNumber = b;
            }
            return bigNumber;
        }

    }
}
