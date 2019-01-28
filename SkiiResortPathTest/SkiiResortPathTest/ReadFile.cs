using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SkiiResortPathTest
{
    public class ReadFile
    {
        private int sizeMat = 0;
        private StreamReader file;
        private int[][] matrixFromText;
        public ReadFile()
        {
            //Assembly asem = Assembly.GetExecutingAssembly();
            ////reader = new StreamReader(asem.GetManifestResourceStream("SkiiResortPathTest.Files.Map.txt"));
            file = new System.IO.StreamReader(@"C:\Users\PITI\Source\Repos\SkiiResortTest2\SkiiResortPathTest\SkiiResortPathTest\Files\Map.txt");
        }
        public int getSizeMatrix()
        {
            string[] lineSplit;
            lineSplit = file.ReadLine().Split(new char[0]);
            //file.Close();
            sizeMat = Convert.ToInt32(lineSplit[0]);
            return sizeMat;
        }

        public int[][] getMatrixFromTxt(int n, int m)
        {
            string line;
            int counter = 0;
            int[][] matrix = new int[n][];
            string[] splitLine;
            for (int mat = 0; mat < n; mat++)
            {
                matrix[mat] = new int[m];
            }

            while ((line = file.ReadLine()) != null)
            {
                splitLine = line.Split(new char[0]);
                if (counter > 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            //get the value from the txt file
                        }
                    }
                }
                counter++;
            }
            file.Close();
            return matrix;
        }
    }
}
