using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP
{
    public class Layer
    {
        public List<Perceptron> Layer_Neurons { get; private set; }
        public int PerceptronCount;
        public double[] Outputs;

        public Layer(int neuronCount, int numberOfInputs, Random r)
        {
            PerceptronCount = neuronCount;
            Layer_Neurons = new List<Perceptron>();
            for (int i = 0; i < PerceptronCount; i++)
            {
                Layer_Neurons.Add(new Perceptron(numberOfInputs, r));
            }
        }

        /// <summary>
        /// Activates all neurons in the layer and returns an output value array
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public double[] Layer_Activation(double[] inputs)
        {
            List<double> outputs = new List<double>();
            for (int i = 0; i < PerceptronCount; i++)
            {
                outputs.Add(Layer_Neurons[i].Activation_Function(inputs));
            }
            Outputs = outputs.ToArray();
            return outputs.ToArray();
        }

        /// <summary>
        /// Softmax function, currently decrepit
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public List<double[]> Output_Softmax_Activation(double[] inputs)
        {
            List<double[]> outputs = new List<double[]>();
            for (int i = 0; i < PerceptronCount; i++)
            {
                outputs.Add(Layer_Neurons[i].Simple_Softmax(inputs));
            }
            
            return outputs;
        }

    }
}
