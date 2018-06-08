using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP
{
    public class Perceptron
    {
        public double[] Weights { get; set; }
        public double Output;
        public double Bias;

        /// <summary>
        /// History of weights over iterations
        /// </summary>
        public List<double[]> WeightHistogram { get; set; }

        /// <summary>
        /// History of weight change over iterations
        /// </summary>
        public  List<double[]> WeightChangeHistogram { get; set; }


        /// <summary>
        /// Perceptron Constructor, randomly sets bias and initial weights
        /// </summary>
        /// <param name="numberOfInputs"></param>
        /// <param name="r"></param>
        public Perceptron(int numberOfInputs, Random r)
        {
            WeightHistogram = new List<double[]>();
            WeightChangeHistogram = new List<double[]>();

            Bias = 10 * r.NextDouble() - 5;
            Weights = new double[numberOfInputs];
            for (int i = 0; i < numberOfInputs; i++)
            {
                Weights[i] = 10 * r.NextDouble() - 5;
            }
            WeightHistogram.Add(Weights);
        }

        /// <summary>
        /// General activation function of the individual perceptron. Uses Standard Sigmoid to convert the calculated activation value into a value that can be worked by the network
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public double Activation_Function(double[] inputs)
        {
            double activation = Bias;

            for (int i = 0; i < Weights.Length; i++)
            {
                activation += Weights[i] * inputs[i];
            }

            Output = activation;
            return Sigmoid(activation);
        }

        /// <summary>
        /// Sigmoid function
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double Sigmoid(double input)
        {
            return 1 / (1 + Math.Exp(-input));
        }

        /// <summary>
        /// Derivated Sigmoid function
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double Sigmoid_D(double input)
        {
            double y = Sigmoid(input);
            return y * (1 - y);
        }

        public double[] Simple_Softmax(double[] inputs)
        {

            var z_exp = inputs.Select(Math.Exp);
            var sum_z_exp = z_exp.Sum();
            var softmax = z_exp.Select(i => i/sum_z_exp);

            return softmax.ToArray();

        }

        

    }
}
