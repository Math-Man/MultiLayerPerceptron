using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP
{
    public class PerceptronNetwork
    {
        public List<Layer> Layers { get; private set; }
        List<double[]> Sigmas;
        List<double[,]> Delta;

        /// <summary>
        /// Multi-Layer Perceptron object, Contains Layers that manages perceptrons
        /// </summary>
        /// <param name="neuronsPerlayer">Structure of the network</param>
        public PerceptronNetwork(int[] neuronsPerlayer)
        {
            Layers = new List<Layer>();
            Random r = new Random();

            for (int i = 0; i < neuronsPerlayer.Length; i++)
            {
                Layers.Add(new Layer(neuronsPerlayer[i], i == 0 ? neuronsPerlayer[i] : neuronsPerlayer[i - 1], r));
            }
        }
        /// <summary>
        /// Process the inputs through the network
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public double[] Activate(double[] inputs)
        {
            double[] outputs = new double[0];
            for (int i = 1; i < Layers.Count; i++)
            {
                outputs = Layers[i].Layer_Activation(inputs);
                inputs = outputs;
            }
            return outputs;
        }

        /// <summary>
        /// Standard SSE Error, used when calculating the backpropogation error
        /// </summary>
        /// <param name="realOutput"></param>
        /// <param name="desiredOutput"></param>
        /// <returns></returns>
        private double Sum_Squared_Error(double[] realOutput, double[] desiredOutput)
        {
            double currentError = 0;
            for (int i = 0; i < realOutput.Length; i++)
            {
                currentError += Math.Pow(realOutput[i] - desiredOutput[i], 2);
            }
            return currentError;
        }

        /// <summary>
        /// Backpropogation error, acts as the general error of the network
        /// </summary>
        /// <param name="input"></param>
        /// <param name="desiredOutput"></param>
        /// <returns></returns>
        private double BackPropogationError(List<double[]> input, List<double[]> desiredOutput)
        {
            double err = 0;
            for (int i = 0; i < input.Count; i++)
            {
                err += Sum_Squared_Error(Activate(input[i]), desiredOutput[i]);
            }
            return err;
        }

        /// <summary>
        /// Training function of the network. Uses backpropogation to learn.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="desiredOutput"></param>
        /// <param name="alpha"></param>
        /// <param name="maxError"></param>
        /// <param name="maxIterations"></param>
        /// <returns></returns>
        public bool Learn(List<double[]> input, List<double[]> desiredOutput, double alpha, double maxError, int maxIterations)
        {
            double error_r = Int32.MaxValue;
            int it = maxIterations;
            while (error_r > maxError)
            {
                Apply_BackPropagation(input, desiredOutput, alpha);
                error_r = BackPropogationError(input, desiredOutput);

                Console.WriteLine("Current Error: " + error_r + " | Iteration: " + (it - maxIterations));
                maxIterations--;

                if (maxIterations <= 0)
                {
                    return true;
                }

            }
            return true;
        }

        /// <summary>
        /// Used in Network_Controller, single learning step
        /// </summary>
        /// <returns></returns>
        public double LearnStep(List<double[]> input, List<double[]> desiredOutput, double LastError, double alpha)
        {
            Apply_BackPropagation(input, desiredOutput, alpha);
            var NewError = BackPropogationError(input, desiredOutput);
            
            return NewError;
        }

        /// <summary>
        /// Updates the sigma units depending on the current error by backpropogation, weights and the expected outputs
        /// Makes use of sigmoid function and the derivated version of the sigmoid function
        /// </summary>
        /// <param name="desiredOutput"></param>
        void Adjust_Sigmas(double[] desiredOutput)
        {
            Sigmas = new List<double[]>();
            for (int i = 0; i < Layers.Count; i++)
            {
                Sigmas.Add(new double[Layers[i].PerceptronCount]);
            }
            for (int i = Layers.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < Layers[i].PerceptronCount; j++)
                {
                    if (i == Layers.Count - 1)
                    {
                        double y = Layers[i].Layer_Neurons[j].Output;
                        Sigmas[i][j] = (Perceptron.Sigmoid(y) - desiredOutput[j]) * Perceptron.Sigmoid_D(y);
                    }
                    else
                    {
                        double sum = 0;
                        for (int k = 0; k < Layers[i + 1].PerceptronCount; k++)
                        {
                            sum += Layers[i + 1].Layer_Neurons[k].Weights[j] * Sigmas[i + 1][k];
                        }
                        Sigmas[i][j] = Perceptron.Sigmoid_D(Layers[i].Layer_Neurons[j].Output) * sum;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the delta values for the initiation of the weight updating
        /// </summary>
        void SetDeltas()
        {
            Delta = new List<double[,]>();
            for (int i = 0; i < Layers.Count; i++)
            {
                Delta.Add(new double[Layers[i].PerceptronCount, Layers[i].Layer_Neurons[0].Weights.Length]);
            }
        }

        /// <summary>
        /// Updates delta values depending on the sigma values
        /// </summary>
        private void Update_Delta()
        {
            for (int i = 1; i < Layers.Count; i++)
            {
                for (int j = 0; j < Layers[i].PerceptronCount; j++)
                {
                    for (int k = 0; k < Layers[i].Layer_Neurons[j].Weights.Length; k++)
                    {
                        Delta[i][j, k] += Sigmas[i][j] * Perceptron.Sigmoid(Layers[i - 1].Layer_Neurons[k].Output);
                    }
                }
            }
        }

        /// <summary>
        /// Updates bias depending on the sigma values
        /// </summary>
        /// <param name="alpha"></param>
        private void UpdateBias(double alpha)
        {
            for (int i = 0; i < Layers.Count; i++)
            {
                for (int j = 0; j < Layers[i].PerceptronCount; j++)
                {
                    Layers[i].Layer_Neurons[j].Bias -= alpha * Sigmas[i][j];
                }
            }
        }

        /// <summary>
        /// Updates weights, this is the final step of applying backpropogation
        /// </summary>
        /// <param name="alpha"></param>
        private void Update_Weights(double alpha)
        {
            for (int i = 0; i < Layers.Count; i++)
            {
                for (int j = 0; j < Layers[i].PerceptronCount; j++)
                {

                    List<double> weightChanges = new List<double>();
                    for (int k = 0; k < Layers[i].Layer_Neurons[j].Weights.Length; k++)
                    {
                        var tfe = Delta[i][j, k];
                        var tff = tfe * alpha;
                        weightChanges.Add(tff);

                        Layers[i].Layer_Neurons[j].Weights[k] -= alpha * Delta[i][j, k];
                    }
                    Layers[i].Layer_Neurons[j].WeightHistogram.Add(Layers[i].Layer_Neurons[j].Weights); //Add the changed weight to histogram

                    Layers[i].Layer_Neurons[j].WeightChangeHistogram.Add(weightChanges.ToArray());

                }
            }
        }

        /// <summary>
        /// Apply backpropogation to change the weights, called when processing an iteration
        /// </summary>
        /// <param name="input"></param>
        /// <param name="desiredOutput"></param>
        /// <param name="alpha"></param>
        private void Apply_BackPropagation(List<double[]> input, List<double[]> desiredOutput, double alpha)
        {
            SetDeltas();

            for (int i = 0; i < input.Count; i++)
            {
                Activate(input[i]);
                Adjust_Sigmas(desiredOutput[i]);
                UpdateBias(alpha);
                Update_Delta();
            }
            Update_Weights(alpha);

        }
    }
}
