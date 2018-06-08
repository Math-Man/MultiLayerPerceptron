using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MLP;
using System.Drawing.Imaging;

namespace MLP
{
    /// <summary>
    /// Class contains methods related to drawing network related graphics using bitmaps
    /// </summary>
    public class NetworkImage
    {

        /// <summary>
        /// Draws the given Network structure
        /// </summary>
        /// <param name="Network"></param>
        /// <param name="layerCount"></param>
        /// <returns></returns>
        public static Bitmap Draw(PerceptronNetwork Network, int layerCount)
        {
            Bitmap m = new Bitmap(layerCount * 200, Network.Layers.Max(item => item.Layer_Neurons.Count) * 200);
            Graphics g = Graphics.FromImage(m);

            int row = 0;
            int column = 0;
            int previous_count = 0;

            foreach (Layer l in Network.Layers)
            {
                Font drawFont = new Font("Arial", 10);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                PointF layerPoint = new PointF(200 + column * 150 + 50 / 2 - 10, 180);
                g.DrawString("Layer " + column, drawFont, drawBrush, layerPoint);

                row = 0;
                foreach (Perceptron p in l.Layer_Neurons)
                {
                    int offset = 200;
                    int mult = 150;
                    int lineOffset = 50;

                    int x = offset + column * mult;
                    int y = offset + row * mult;

                    //Going from left to right place ellipses in place of perceptrons and add labels to them
                    g.DrawEllipse(Pens.Black, x, y, 100, 100);

                    PointF drawPoint = new PointF(x + (lineOffset / 2) - 10, y + (lineOffset / 2) + 10);
                    g.DrawString("Bias" + Math.Round(p.Bias, 3) + "\nOutput:" + Math.Round(p.Output, 2), drawFont, drawBrush, drawPoint);

                    //Add lines
                    if (column != 0)
                    {
                        for (int b = 0; b < previous_count; b++)
                        {
                            g.DrawLine(Pens.Black, new Point(x, y + lineOffset), new Point(x - mult + 2 * lineOffset, offset + b * mult + lineOffset));
                        }
                    }

                    row++;
                }
                column++;
                previous_count = l.Layer_Neurons.Count;
            }

            m.Save("Network.png", ImageFormat.Png);
            return m;
        }

        /// <summary>
        /// Draws selection boundry of the two given features, decrepit
        /// </summary>
        /// <param name="p"></param>
        /// <param name="feature1"></param>
        /// <param name="feature2"></param>
        /// <param name="otherInputsStatic"></param>
        /// <param name="possibleOutputCount"></param>
        /// <param name="minOutputValue"></param>
        /// <param name="maxOutputValue"></param>
        public static void DrawBoundryMap_IRIS(Network_Control p, double[] feature1, double[] feature2, double[] otherInputsStatic, int possibleOutputCount, double minOutputValue, double maxOutputValue)
        {
            int sizeMod = 20;
            int width = feature1.Length * sizeMod;
            int height = feature2.Length * sizeMod;

            Bitmap m = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(m);


            Random rnd = new Random();
            /*var a = NetworkController.Network.Activate(input[i]);
                    var bbb = Data.inverseNormalize(a[0], 0.0, 3.0);*/

            List<int[]> GradientColors = new List<int[]>();
            for (int i = 0; i < possibleOutputCount; i++)
            {
                GradientColors.Add(new int[] { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) });
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var sx = (int)Math.Floor( (double)(y / sizeMod));
                    var sy = (int)Math.Floor((double)(x / sizeMod));

                    var a = p.Network.Activate(new double[] { feature1[sx], feature2[sy] }.Concat(otherInputsStatic).ToArray());
                    var bbb = Data.inverseNormalize(a[0], minOutputValue, maxOutputValue);

                    for (int k = 0; k < GradientColors.Count; k++)
                    {
                        if (Math.Round(bbb) == k)
                        {
                            //var c = Color.FromArgb((int)Math.Abs(Math.Floor(GradientColors[k][0] * multiplier)), Math.Abs((int)Math.Floor(GradientColors[k][1] * multiplier)), Math.Abs((int)Math.Floor(GradientColors[k][2] * multiplier)));
                            Pen pen = new Pen(Color.FromArgb(GradientColors[k][0], GradientColors[k][1], GradientColors[k][2]), 1);
                            g.DrawEllipse(pen, x, y, 1, 1);
                        }
                    }
                }
            }

            m.Save("bound.png", ImageFormat.Png);

        }
        /*
        //https://stackoverflow.com/questions/3722307/is-there-an-easy-way-to-blend-two-system-drawing-color-values
        public Color Blend(this Color color, Color backColor, double amount)
        {
            byte r = (byte)((color.R * amount) + backColor.R * (1 - amount));
            byte g = (byte)((color.G * amount) + backColor.G * (1 - amount));
            byte b = (byte)((color.B * amount) + backColor.B * (1 - amount));
            return Color.FromArgb(r, g, b);
        }*/








    }
}
