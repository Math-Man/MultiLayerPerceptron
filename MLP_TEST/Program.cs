using MLP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace MLP
{
    /// <summary>
    /// This file is used to test the algorithm and has no real use at this point. Use the MLP_GUI project.
    /// </summary>
    class Program
    {
        static string inputPath = "IRIS.csv";

        static int inputCount = 4;
        static int outputCount = 1;

        // This tuple values are used to normalize the results within a certain limit
        //input_max, input_min, output_max, output_min
        static Tuple<double, double, double, double> Norm = Tuple.Create(10.0, 0.0, 3.0, 0.0);
        static List<double[]> input = new List<double[]>();
        static List<double[]> output = new List<double[]>();


        static void Main(string[] args)
        {
            PerceptronNetwork p;
            var t = Data.ReadData(inputPath, inputCount, outputCount, Norm, false);

            input = t.Item1;
            output = t.Item2;

            p = new PerceptronNetwork(new int[] { inputCount, 5, 5, outputCount });

            while (!p.Learn(input, output, 0.05, 0.01, 3000))
            {
 
                p = new PerceptronNetwork(new int[] { inputCount, 5, 5, outputCount });
                
            }

          
            /*
           MLP.Network_Control control = new MLP.Network_Control(p, output, input, 0.01, false, Norm, inputCount, outputCount);

           for (int i = 0; i < 3000; i++)
           {
               control.Step();
           }

           MLP.NetworkImage.Draw(p, p.Layers.Count);

           var sst = control.TestValues(1,1,1,1);
           Console.WriteLine(sst);

           Console.WriteLine(control.CurrentError);
           */
            while (true)
            {
                double[] val = new double[inputCount];
                for (int i = 0; i < inputCount; i++)
                {
                    Console.WriteLine("Input Test Value " + i + ": ");
                    val[i] = Data.normalize(double.Parse(Console.ReadLine()), Norm.Item2, Norm.Item1);
                }
                double[] sal = p.Activate(val);
                for (int i = 0; i < outputCount; i++)
                {
                    Console.Write("Result: " + i + ": " + Data.inverseNormalize(sal[i], Norm.Item4, Norm.Item3) + " ");
                }
                Console.WriteLine("");
            }

        }

   



    }






}