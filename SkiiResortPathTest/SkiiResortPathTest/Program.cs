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
            Console.WriteLine("Length of the longest path is " + findPathLength(path));
        }

        // returns the lenght of calculated path
        public static int findPathLength(int[][] matrix)
        {
            int result = 0;

            //Initialize path auxiliar with -1 in all positions
            int[][] auxPath = InitializeAuxPath(n, n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    auxPath[i][j] = -1;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (auxPath[i][j] == -1)
                    {
                        findBestPathFromPosition(i, j, matrix, auxPath);
                    }

                    result = Math.Max(result, auxPath[i][j]);
                }
            }

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
            if (i < 0 || i >= n || j < 0 || j >= n)
            {
                return 0;
            }

            if (aux[i][j] != -1)
            {
                return aux[i][j];
            }
            // check east
            if (j < n - 1 && ((mat[i][j] + 1) == mat[i][j + 1]))
            {
                Console.WriteLine("," + (mat[i][j] + 1));
                return aux[i][j] = 1 + findBestPathFromPosition(i, j + 1, mat, aux);
            }
            //check west
            if (j > 0 && (mat[i][j] + 1 == mat[i][j - 1]))
            {
                Console.WriteLine("," + (mat[i][j] + 1));
                return aux[i][j] = 1 + findBestPathFromPosition(i, j - 1, mat, aux);
            }
            // check north
            if (i > 0 && (mat[i][j] + 1 == mat[i - 1][j]))
            {
                Console.WriteLine("," + (mat[i][j] + 1));
                return aux[i][j] = 1 + findBestPathFromPosition(i - 1, j, mat, aux);
            }
            //check south
            if (i < n - 1 && (mat[i][j] + 1 == mat[i + 1][j]))
            {
                Console.WriteLine("," + (mat[i][j] + 1));
                return aux[i][j] = 1 + findBestPathFromPosition(i + 1, j, mat, aux);
            }

            return aux[i][j] = 1;
        }

    }
}
