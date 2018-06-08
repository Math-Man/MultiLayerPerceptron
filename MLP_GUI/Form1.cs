using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using MLP;
using System.Threading;


namespace MLP_GUI
{
    public partial class Form1 : Form
    {

        public MLP.Network_Control NetworkController { get; set; }
        public string FilePath { get; set; }
        public bool chartsDisabled { get; set; }

        public Form1()
        {
            FilePath = "IRIS_Train.csv";
            Tuple<double, double, double, double> Norm = Tuple.Create(10.0, 0.0, 3.0, 0.0);
            List<double[]> input = new List<double[]>();
            List<double[]> output = new List<double[]>();
            var t = Data.ReadData("IRIS.csv", 4, 1, Norm, false);
            input = t.Item1;
            output = t.Item2;

            PerceptronNetwork network = new MLP.PerceptronNetwork(new int[] { 4, 5, 5, 1 });
            NetworkController = new MLP.Network_Control(network, output, input, 0.02, false, Norm, 4, 1);
            InitializeComponent();

            //Set image to the starting network's image
            if (!cbdisabledrawing.Checked)
            {
                var Image = NetworkImage.Draw(network, network.Layers.Count);
                IMG_NetworkTopography.Image = Image;
                IMG_NetworkTopography.SizeMode = PictureBoxSizeMode.Zoom;
            }
            rtbConsole.Text = "";
            NetworkController.Paused = true;

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

            //Iterate through groupboxes if more data is needed to set.   
            chartsDisabled = cbDisableCharts.Checked;
            lbiris1.Cursor = Cursors.Hand;
            lbiris2.Cursor = Cursors.Hand;
            lbiris3.Cursor = Cursors.Hand;

            lbmnist1.Cursor = Cursors.Hand;
            lbmnist2.Cursor = Cursors.Hand;
            lbmnist3.Cursor = Cursors.Hand;

            cartesianChart1.Series.Add(new LineSeries
            {
                Values = new ChartValues<double> { },
                StrokeThickness = 4,
                StrokeDashArray = new System.Windows.Media.DoubleCollection(20),
                Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(107, 185, 69)),
                Fill = System.Windows.Media.Brushes.Transparent,
                LineSmoothness = 0,
                PointGeometry = null

            });

            cartesianChart2.Series.Add(new LineSeries
            {
                Values = new ChartValues<double> { },
                StrokeThickness = 4,
                StrokeDashArray = new System.Windows.Media.DoubleCollection(20),
                Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(107, 120, 190)),
                Fill = System.Windows.Media.Brushes.Transparent,
                LineSmoothness = 3,
                PointGeometry = null
            });

            cartesianChart3.Series.Add(new LineSeries
            {
                Values = new ChartValues<double> { },
                StrokeThickness = 1,
                StrokeDashArray = new System.Windows.Media.DoubleCollection(20),
                Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(250, 120, 120)),
                Fill = System.Windows.Media.Brushes.Transparent,
                LineSmoothness = 3,
                PointGeometry = null
            });


            cartesianChart1.AxisX.Add(new Axis
            {
                LabelFormatter = value => value + "th Iteration",
                Separator = new Separator()
            });

            cartesianChart2.AxisX.Add(new Axis
            {
                LabelFormatter = value => value + "th Iteration",
                Separator = new Separator()
            });
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //cartesianChart1.Series[0].Values.Add(3.0);

            NetworkController.LearningRate = double.Parse(tbLearningRate.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bToggleController_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < nudIterations.Value; i++)
            {
                NetworkController.Step();

                if (!chartsDisabled) cartesianChart1.Series[0].Values.Add(NetworkController.CurrentError);

                rtbConsole.Text += "Error: " + NetworkController.CurrentError + " | Iteration: " + NetworkController.CurrentIteration + "\n";
                if (!chartsDisabled) cartesianChart2.Series[0].Values.Add(NetworkController.Delay_Historian[NetworkController.Delay_Historian.Count - 1].TotalMilliseconds);

                rtbConsole.SelectionStart = rtbConsole.Text.Length;
                rtbConsole.ScrollToCaret();

                lbElapsed.Text = "" + (NetworkController.Delay_Historian.Sum(item => item.Milliseconds)) + "ms";
                lbBestError.Text = "" + Math.Round(NetworkController.BestError, 4);
                lbIterationNumber.Text = "" + NetworkController.CurrentIteration;

                if (NetworkController.Error_Historian.Count > 2)
                {
                    if (!chartsDisabled) cartesianChart3.Series[0].Values.Add(NetworkController.Error_Historian[NetworkController.Error_Historian.Count - 2] - NetworkController.Error_Historian[NetworkController.Error_Historian.Count - 1]);
                }
            }
            if (!cbdisabledrawing.Checked)
            {
                var Image = NetworkImage.Draw(NetworkController.Network, NetworkController.Network.Layers.Count);
                IMG_NetworkTopography.Image = Image;
            }
        }

        private void consoleUpdater_Tick(object sender, EventArgs e)
        {

        }

        private void bControllerStep_Click(object sender, EventArgs e)
        {

            NetworkController.Step();
            if (!chartsDisabled) cartesianChart1.Series[0].Values.Add(NetworkController.CurrentError);
            rtbConsole.Text += "Error: " + NetworkController.CurrentError + " | Iteration: " + NetworkController.CurrentIteration + "\n";
            if (!chartsDisabled) cartesianChart2.Series[0].Values.Add(NetworkController.Delay_Historian[NetworkController.Delay_Historian.Count - 1].TotalMilliseconds);
            rtbConsole.SelectionStart = rtbConsole.Text.Length;
            rtbConsole.ScrollToCaret();
            lbElapsed.Text = "" + (NetworkController.Delay_Historian.Sum(item => item.Milliseconds)) + "ms";
            lbBestError.Text = "" + Math.Round(NetworkController.BestError, 4);
            lbIterationNumber.Text = "" + NetworkController.CurrentIteration;
            if (!cbdisabledrawing.Checked)
            {
                var Image = NetworkImage.Draw(NetworkController.Network, NetworkController.Network.Layers.Count);
                IMG_NetworkTopography.Image = Image;
            }
            if (NetworkController.Error_Historian.Count > 2)
            {
                if (!chartsDisabled) cartesianChart3.Series[0].Values.Add(NetworkController.Error_Historian[NetworkController.Error_Historian.Count - 2] - NetworkController.Error_Historian[NetworkController.Error_Historian.Count - 1]);
            }

        }

        private void bControllerReset_Click(object sender, EventArgs e)
        {
            int inputCount;
            int outputCount;
            var structure = ParseStructureBox(out inputCount, out outputCount);

            Tuple<double, double, double, double> Norm = Tuple.Create(10.0, 0.0, 3.0, 0.0);
            List<double[]> input = new List<double[]>();
            List<double[]> output = new List<double[]>();
            var t = Data.ReadData(FilePath, inputCount, outputCount, Norm, rbMNIST.Checked);

            input = t.Item1;
            output = t.Item2;

            PerceptronNetwork network = new MLP.PerceptronNetwork(structure);
            NetworkController = new MLP.Network_Control(network, output, input, Double.Parse(tbLearningRate.Text), false, Norm, inputCount, outputCount);

            cartesianChart1.Series[0].Values.Clear();
            cartesianChart2.Series[0].Values.Clear();
            cartesianChart3.Series[0].Values.Clear();
            if (!cbdisabledrawing.Checked)
            {
                var Image = NetworkImage.Draw(NetworkController.Network, NetworkController.Network.Layers.Count);
                IMG_NetworkTopography.Image = Image;
            }
        }

        private void bClearLog_Click(object sender, EventArgs e)
        {
            rtbConsole.Text = "";
        }

        private void bConstruct_Click(object sender, EventArgs e)
        {
            if (!cbdisabledrawing.Checked)
            {
                var Image = NetworkImage.Draw(NetworkController.Network, NetworkController.Network.Layers.Count);
                IMG_NetworkTopography.Image = Image;
            }
            bControllerReset_Click(sender, e);
        }
        private void bTestValues_Click(object sender, EventArgs e)
        {

            if (rbIris.Checked)
            {
                Tuple<double, double, double, double> Norm = Tuple.Create(10.0, 0.0, 3.0, 0.0);

                double[] values = ParseValueTest();

                double[] inputs = values.Take(values.Length - 1).ToArray();
                double expectedress = values[values.Length - 1];


                var a = NetworkController.Network.Activate(inputs);
                var bbb = Data.inverseNormalize(a[0], 0.0, 3.0);

                var res_r = Math.Round(bbb);

                rtbConsole.Text += "Expected: " + expectedress + " Got :" + Math.Round(bbb) + "\n";
                rtbConsole.SelectionStart = rtbConsole.Text.Length;
                rtbConsole.ScrollToCaret();


                double errors = (expectedress - bbb);

                lbErrorResult.Text = Math.Round(errors, 4) + "";
                lbTestResult.Text = Math.Round(res_r, 4) + "";
                lbNumericResult.Text = Math.Round(bbb, 4) + "";
            }
            else if (rbMNIST.Checked)
            {
                Tuple<double, double, double, double> Norm = Tuple.Create(255.0, 0.0, 9.0, 0.0);

                double[] values = ParseValueTest();

                double[] inputs = values.Take(values.Length - 1).ToArray();
                double expectedress = values[values.Length - 1];


                var a = NetworkController.Network.Activate(inputs);
                var bbb = Data.inverseNormalize(a[0], 0.0, 9.0);

                var res_r = Math.Round(bbb);

                rtbConsole.Text += "Expected: " + expectedress + " Got :" + Math.Round(bbb) + "\n";
                rtbConsole.SelectionStart = rtbConsole.Text.Length;
                rtbConsole.ScrollToCaret();


                double errors = (expectedress - bbb);

                lbErrorResult.Text = Math.Round(errors, 4) + "";
                lbTestResult.Text = Math.Round(res_r, 4) + "";
                lbNumericResult.Text = Math.Round(bbb, 4) + "";

            }
        }

        /// <summary>
        /// Parses the structure box to create the inputed network structure
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        private int[] ParseStructureBox(out int input, out int output)
        {
            string t = tbStructure.Text;

            string[] words = t.Split(' ');


            input = int.Parse(words[0]);
            output = int.Parse(words[words.Length - 1]);

            List<int> d = new List<int>();
            for (int i = 0; i < words.Length; i++)
            {
                d.Add(int.Parse(words[i]));
            }

            return d.ToArray();


        }

        /// <summary>
        /// Parses the value test intput to get a meaningful input and output value for testing
        /// </summary>
        /// <returns></returns>
        private double[] ParseValueTest()
        {
            string inp = tbValueTest.Text;

            string[] words = inp.Split(' ');

            List<double> lst = new List<double>();
            foreach (var s in words) { lst.Add(double.Parse(s)); }
            var ou = lst.ToArray();

            return ou;
        }


        private void btnWeightCharts_Click(object sender, EventArgs e)
        {

            var copy = new List<Layer>();
            copy.AddRange(NetworkController.Network.Layers);
            WeightChart wc = new WeightChart();

            int row = 0;
            int col = 0;
            Random rnd = new Random();

            foreach (Layer l in copy)
            {
                row = 0;
                foreach (Perceptron p in l.Layer_Neurons)
                {

                    LiveCharts.WinForms.CartesianChart chart = new LiveCharts.WinForms.CartesianChart();

                    chart.Location = new Point(50 + 170 * col, 50 + 100 * row);
                    chart.Size = new Size(150, 75);
                    chart.BackColor = Color.LightGray;

                    for (int i = 0; i < p.Weights.Length; i++)  //Go through different weights by index (weight#1, weight#2...) in the same perceptron, weight is the number of connections
                    {
                        //Create a new series, representing the current weight that is being looked at
                        chart.Series.Add(new LineSeries
                        {
                            Values = new ChartValues<double> { },
                            StrokeThickness = 1,
                            StrokeDashArray = new System.Windows.Media.DoubleCollection(20),
                            Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)(rnd.Next(0, 255)), (byte)(rnd.Next(0, 255)), (byte)(rnd.Next(0, 255)))),
                            Fill = System.Windows.Media.Brushes.Transparent,
                            LineSmoothness = 1,
                            PointGeometry = null,
                        });

                        foreach (double[] w in p.WeightChangeHistogram.Skip(p.WeightHistogram.Count - 50).Take(50))   //Go through weight changes over time of the current perceptron
                        {
                            //var currentweight = w[i];
                            //add the weight of the current connection from the histogram
                            chart.Series[i].Values.Add((double)(w[i])); //Goes through every registered weight in the histogram, pulls out the given index
                        }
                    }

                    wc.Controls.Add(chart);
                    row++;
                }
                col++;
            }

            wc.Show();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void rbIris_CheckedChanged(object sender, EventArgs e)
        {
            //btnbatch.Enabled = true;


            Tuple<double, double, double, double> Norm = Tuple.Create(10.0, 0.0, 3.0, 0.0);
            List<double[]> input = new List<double[]>();
            List<double[]> output = new List<double[]>();
            var t = Data.ReadData("IRIS_Train.csv", 4, 1, Norm, false);
            input = t.Item1;
            output = t.Item2;

            PerceptronNetwork network = new MLP.PerceptronNetwork(new int[] { 4, 5, 5, 1 });
            NetworkController = new MLP.Network_Control(network, output, input, double.Parse(tbLearningRate.Text), false, Norm, 4, 1);
            tbStructure.Text = "4 5 5 1";
        }

        private void rbMNIST_CheckedChanged(object sender, EventArgs e)
        {
            //btnbatch.Enabled = false;


            Tuple<double, double, double, double> Norm = Tuple.Create(255.0, 0.0, 9.0, 0.0);
            List<double[]> input = new List<double[]>();
            List<double[]> output = new List<double[]>();
            var t = Data.ReadData("mnist_test.csv", 785, 1, Norm, true);
            input = t.Item1;
            output = t.Item2;
            //https://www.kaggle.com/donfuzius/vectordigits
            PerceptronNetwork network = new MLP.PerceptronNetwork(new int[] { 784, 784, 1 });
            NetworkController = new MLP.Network_Control(network, output, input, double.Parse(tbLearningRate.Text), false, Norm, 784, 1);
            tbStructure.Text = "784 784 1";

            /*
             Tuple<double, double, double, double> Norm = Tuple.Create(255.0, 0.0, 9.0, 0.0);
                List<double[]> input = new List<double[]>();
                List<double[]> output = new List<double[]>();
                var t = Data.ReadData(path, 784, 1, Norm);
                input = t.Item1;
                output = t.Item2;

                int errors = 0;
                for (int i = 0; i < input.Count; i++)
                {
                    for (int j = 0; j < output[i].Length; j++)
                    {
                        var expected = Data.inverseNormalize(output[i][j], Norm.Item4, Norm.Item3);

                        var a = NetworkController.Network.Activate(input[i]);   //Get the result from the given outputs
                        var bbb = Data.inverseNormalize(a[j], Norm.Item4, Norm.Item3);  //Inverse normalize the result to fit it between output values

                        if (Math.Round(bbb) != expected) { errors++; }//Error?
                        rtbConsole.Text += "Expected: " + expected + " Got :" + Math.Round(bbb) + "\n";
                        rtbConsole.SelectionStart = rtbConsole.Text.Length;
                        rtbConsole.ScrollToCaret();

                    }
                    

                }
                rtbConsole.Text += "Total Number of Errors: " + errors + "/" + input.Count*output.Count + "\n";
             
             */


        }

        private void lbiris1_Click(object sender, EventArgs e)
        {

            tbValueTest.Text = lbiris1.Text;
        }

        private void lbiris2_Click(object sender, EventArgs e)
        {
            tbValueTest.Text = lbiris2.Text;
        }

        private void lbiris3_Click(object sender, EventArgs e)
        {
            tbValueTest.Text = lbiris3.Text;
        }

        private void lbmnist1_Click(object sender, EventArgs e)
        {
            tbValueTest.Text = "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 84 185 159 151 60 36 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 222 254 254 254 254 241 198 198 198 198 198 198 198 198 170 52 0 0 0 0 0 0 0 0 0 0 0 0 67 114 72 114 163 227 254 225 254 254 254 250 229 254 254 140 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 17 66 14 67 67 67 59 21 236 254 106 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 83 253 209 18 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 22 233 255 83 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 129 254 238 44 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 59 249 254 62 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 133 254 187 5 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 9 205 248 58 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 126 254 182 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 75 251 240 57 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 19 221 254 166 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 3 203 254 219 35 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 38 254 254 77 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 31 224 254 115 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 133 254 254 52 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 61 242 254 254 52 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 121 254 254 219 40 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 121 254 207 18 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 7";
        }

        private void lbmnist2_Click(object sender, EventArgs e)
        {
            tbValueTest.Text = "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 116 125 171 255 255 150 93 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 169 253 253 253 253 253 253 218 30 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 169 253 253 253 213 142 176 253 253 122 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 52 250 253 210 32 12 0 6 206 253 140 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 77 251 210 25 0 0 0 122 248 253 65 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 31 18 0 0 0 0 209 253 253 65 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 117 247 253 198 10 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 76 247 253 231 63 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 128 253 253 144 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 176 246 253 159 12 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 25 234 253 233 35 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 198 253 253 141 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 78 248 253 189 12 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 19 200 253 253 141 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 134 253 253 173 12 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 248 253 253 25 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 248 253 253 43 20 20 20 20 5 0 5 20 20 37 150 150 150 147 10 0 0 0 0 0 0 0 0 0 248 253 253 253 253 253 253 253 168 143 166 253 253 253 253 253 253 253 123 0 0 0 0 0 0 0 0 0 174 253 253 253 253 253 253 253 253 253 253 253 249 247 247 169 117 117 57 0 0 0 0 0 0 0 0 0 0 118 123 123 123 166 253 253 253 155 123 123 41 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 2";
        }

        private void lbmnist3_Click(object sender, EventArgs e)
        {
            tbValueTest.Text = "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 11 150 253 202 31 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 37 251 251 253 107 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 21 197 251 251 253 107 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 110 190 251 251 251 253 169 109 62 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 253 251 251 251 251 253 251 251 220 51 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 182 255 253 253 253 253 234 222 253 253 253 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 63 221 253 251 251 251 147 77 62 128 251 251 105 0 0 0 0 0 0 0 0 0 0 0 0 0 0 32 231 251 253 251 220 137 10 0 0 31 230 251 243 113 5 0 0 0 0 0 0 0 0 0 0 0 0 37 251 251 253 188 20 0 0 0 0 0 109 251 253 251 35 0 0 0 0 0 0 0 0 0 0 0 0 37 251 251 201 30 0 0 0 0 0 0 31 200 253 251 35 0 0 0 0 0 0 0 0 0 0 0 0 37 253 253 0 0 0 0 0 0 0 0 32 202 255 253 164 0 0 0 0 0 0 0 0 0 0 0 0 140 251 251 0 0 0 0 0 0 0 0 109 251 253 251 35 0 0 0 0 0 0 0 0 0 0 0 0 217 251 251 0 0 0 0 0 0 21 63 231 251 253 230 30 0 0 0 0 0 0 0 0 0 0 0 0 217 251 251 0 0 0 0 0 0 144 251 251 251 221 61 0 0 0 0 0 0 0 0 0 0 0 0 0 217 251 251 0 0 0 0 0 182 221 251 251 251 180 0 0 0 0 0 0 0 0 0 0 0 0 0 0 218 253 253 73 73 228 253 253 255 253 253 253 253 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 113 251 251 253 251 251 251 251 253 251 251 251 147 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 31 230 251 253 251 251 251 251 253 230 189 35 10 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 62 142 253 251 251 251 251 253 107 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 72 174 251 173 71 72 30 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0";
        }

        private void btnbatch_Click(object sender, EventArgs e)
        {
            string path = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                path = file;
            }

            if (rbIris.Checked)
            {
                Tuple<double, double, double, double> Norm = Tuple.Create(10.0, 0.0, 3.0, 0.0);
                List<double[]> input = new List<double[]>();
                List<double[]> output = new List<double[]>();
                var t = Data.ReadData(path, 4, 1, Norm, rbMNIST.Checked);
                input = t.Item1;
                output = t.Item2;


                int errors = 0;
                for (int i = 0; i < input.Count; i++)
                {

                    var expected = Data.inverseNormalize(output[i][0], Norm.Item4, Norm.Item3);

                    var a = NetworkController.Network.Activate(input[i]);
                    var bbb = Data.inverseNormalize(a[0], 0.0, 3.0);

                    if (Math.Round(bbb) != expected) { errors++; }
                    rtbConsole.Text += "Expected: " + expected + " Got :" + Math.Round(bbb) + "\n";
                    rtbConsole.SelectionStart = rtbConsole.Text.Length;
                    rtbConsole.ScrollToCaret();

                }
                rtbConsole.Text += "Total Number of Errors: " + errors + "/" + input.Count + "\n";


                //var others = input[3].Concat(input[4]).ToArray();
                //NetworkImage.DrawBoundryMap_IRIS(NetworkController, input[0], input[1], others, 3, 0.0, 3.0);
            }
            else if (rbMNIST.Checked)
            {
                Tuple<double, double, double, double> Norm = Tuple.Create(255.0, 0.0, 9.0, 0.0);
                List<double[]> input = new List<double[]>();
                List<double[]> output = new List<double[]>();
                var t = Data.ReadData(path, 785, 1, Norm, true);
                input = t.Item1;
                output = t.Item2;

                int errors = 0;
                for (int i = 0; i < input.Count; i++)
                {
                    for (int j = 0; j < output[i].Length; j++)
                    {
                        var expected = Data.inverseNormalize(output[i][j], Norm.Item4, Norm.Item3);

                        var a = NetworkController.Network.Activate(input[i]);   //Get the result from the given outputs
                        var bbb = Data.inverseNormalize(a[j], Norm.Item4, Norm.Item3);  //Inverse normalize the result to fit it between output values

                        if (Math.Round(bbb) != expected) { errors++; }//Error?
                        rtbConsole.Text += "Expected: " + expected + " Got :" + Math.Round(bbb) + "\n";
                        rtbConsole.SelectionStart = rtbConsole.Text.Length;
                        rtbConsole.ScrollToCaret();

                    }


                }
                rtbConsole.Text += "Total Number of Errors: " + errors + "/" + input.Count * output.Count + "\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                FilePath = file;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string output = "";
            for (double i = 0; i < 5; i += 0.1)
            {
                double res = NetworkController.Network.Activate(new double[] { Data.normalize(i, 0.0, 10.0) })[0];


                output += i + ";" + Data.inverseNormalize(res, 0, 3.0) + "\n";
                // Console.WriteLine(i + ";" + res + "\n");
            }
            rtbConsole.Text += "\n" + output;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cartesianChart1.Series[0].Values.Clear();
            cartesianChart2.Series[0].Values.Clear();
            cartesianChart3.Series[0].Values.Clear();
        }

        private void cbDisableCharts_CheckedChanged(object sender, EventArgs e)
        {
            chartsDisabled = cbDisableCharts.Checked;
        }

        private void cbdisabledrawing_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
