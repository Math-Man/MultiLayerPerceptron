using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP
{
    public static class Data
    {
        /// <summary>
        /// Reads data, since MNIST behaves differently uses a special boo flag for reading mnist data
        /// </summary>
        /// <param name="inputPath"></param>
        /// <param name="inputCount"></param>
        /// <param name="outputCount"></param>
        /// <param name="norm"></param>
        /// <param name="mnist"></param>
        /// <returns></returns>
        public static Tuple<List<double[]>, List<double[]>> ReadData(string inputPath, int inputCount, int outputCount, Tuple<double, double, double, double> norm, bool mnist)
        {
            string data = System.IO.File.ReadAllText(inputPath).Replace("\r", "");
            string[] row = data.Split(Environment.NewLine.ToCharArray());

            List<double[]> ins = new List<double[]>();
            List<double[]> ous = new List<double[]>();

            for (int i = 0; i < row.Length; i++)
            {
                string[] rowData = null;
                if (!mnist) { rowData = row[i].Split(';'); }
                else { rowData = row[i].Split(','); }

                double[] inputs = new double[inputCount];
                double[] outputs = new double[outputCount];

                for (int j = 0; j < rowData.Length; j++)
                {

                    if (j < inputCount)
                    {
                        if (rowData[j] != "")
                        {
                            inputs[j] = normalize(double.Parse(rowData[j]), norm.Item2, norm.Item1);
                        }
                    }
                    else
                    {
                        if (rowData[j] != "")
                        {
                            outputs[j - inputCount] = normalize(double.Parse(rowData[j]), norm.Item4, norm.Item3);
                        }
                    }
                }

                ins.Add(inputs);
                ous.Add(outputs);
            }
            return Tuple.Create(ins, ous);
        }

        /// <summary>
        /// Maps the given value between the given max and min
        /// </summary>
        /// <param name="val"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double normalize(double val, double min, double max)
        {
            return (val - min) / (max - min);
        }

        /// <summary>
        /// Un-Maps the given value that was bound with normalize
        /// </summary>
        /// <param name="val"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double inverseNormalize(double val, double min, double max)
        {
            return val * (max - min) + min;
        }



    }
}
