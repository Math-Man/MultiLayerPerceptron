using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLP;
using System.Diagnostics;


namespace MLP
{
    public class Network_Control
    {

        public PerceptronNetwork Network { get; set; }
        public bool Paused { get; set; }

        public int CurrentIteration { get; set; }
        public double CurrentError { get; set; }
        public double BestError { get; set; }
        public double LearningRate { get; set; }



        public List<double> Error_Historian { get; private set; }
        public List<System.TimeSpan> Delay_Historian { get; private set; }

        public List<double[]> Output { get; set; }
        public List<double[]> Input { get; set; }

        Tuple<double, double, double, double> Norm;
        public int InputCount { get; set; }
        public int OutputCount { get; set; }

        public string TextOutput { get; set; }

        /// <summary>
        /// Network controller, static networks are non-interactive but somewhat faster
        /// </summary>
        /// <param name="network"></param>
        /// <param name="isStatic"></param>
        public Network_Control(PerceptronNetwork network, List<double[]> output, List<double[]> input, double learningRate, bool isStatic,  Tuple<double, double, double, double> normalizer, int inputcount, int outputcount)
        {
            Network = network;
            Paused = false;
            CurrentIteration = 0;
            CurrentError = Int32.MaxValue;
            BestError = CurrentError;
            Error_Historian = new List<double>();
            Delay_Historian = new List<System.TimeSpan>();
            LearningRate = learningRate;

            Output = new List<double[]>();
            Input = new List<double[]>();

            InputCount = inputcount;
            OutputCount = outputcount;

            Output.AddRange(output);
            Input.AddRange(input);
            Norm = normalizer;

        }

        /// <summary>
        /// Continous stepping until paused
        /// </summary>
        public void Start()
        {
            while (!Paused)
            {
                Step();
            }
        }

        /// <summary>
        /// Takes a single itteration step
        /// </summary>
        public void Step()
        {

            Stopwatch w = new Stopwatch();
            w.Start();


            CurrentError = Network.LearnStep(Input, Output, CurrentError, LearningRate);
            this.TextOutput = "Error :" + CurrentError + " | Iteration: " + CurrentIteration;
            Error_Historian.Add(CurrentError);
            w.Stop();
            Delay_Historian.Add(w.Elapsed);
            CurrentIteration++;
            


            if (CurrentError < BestError) BestError = CurrentError;

            

        }

        /// <summary>
        /// Test input values on the current network, decrepit
        /// </summary>
        /// <param name="values"></param>
        public double[] TestValues(params double[] values)
        {
            double[] val = new double[InputCount];

            for (int i = 0; i < InputCount; i++)
            {
                val[i] = Data.normalize((values[i]), Norm.Item2, Norm.Item1);
            }

            double[] sal = Network.Activate(val);
            var result = new List<double>();
            for (int i = 0; i < OutputCount; i++)
            {
                result.Add(Data.inverseNormalize(sal[i], Norm.Item4, Norm.Item3));
            }

            return result.ToArray();
        }



    }
}
