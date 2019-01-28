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
        private StreamReader reader;
        private string text;

        public ReadFile()
        {
            Assembly assem = Assembly.GetExecutingAssembly();

            using (Stream stream = assem.GetManifestResourceStream("SkiiResortPathTest.Files.Map.txt"))
            {
                using (var item = new StreamReader(stream))
                {
                    text = item.ReadToEnd();
                }
            }

        }
        public int getSizeMatrix()
        {
            string[] lineSplit;
            // first element of the text is the liength of the matrix            
            lineSplit = text.Split(new char[0]);
            sizeMat = Convert.ToInt32(lineSplit[0]);
            return sizeMat;
        }

        public int[][] getMatrixFromTxt(int n, int m)
        {
            int[][] matrix = new int[n][];
            int count = 0;
            int number = 0;
            string[] splitLine;
            for (int mat = 0; mat < n; mat++)
            {
                matrix[mat] = new int[m];
            }

            splitLine = text.Split(new char[0]);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    //get the value from the txt file

                    if (Int32.TryParse(splitLine[count], out number))
                    {
                        matrix[i][j] = number;
                    }
                    else
                    {
                        matrix[i][j] = 0;
                    }
                    count++;
                }
            }

            return matrix;
        }
    }
}
