using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R_Model
{
    public partial class Form1 : Form
    {
        List<RObject> points = new List<RObject>();
        List<RObject> squares = new List<RObject>();

        Point averagePoint = new Point(0, 0);
        Point averageSquare = new Point(0, 0);

        int w = 400;
        int h = 400;

        int resolution = 4;

        RObject interactionObject = null;

        Random r = new Random();

        int[] layers = new int[] { 2, 64, 64, 64, 2 };

        NeuralNetwork NN;

        public Form1()
        {
            InitializeComponent();
            NN = new NeuralNetwork(0.01, x => 1 / (1 + Math.Exp(-x)), y => y * (1 - y), layers);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        void RefreshForm()
        {
            averagePoint = MathDealer.GetAriphmeticAveragePoint(points);
            averageSquare = MathDealer.GetAriphmeticAveragePoint(squares);

            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = panel1.CreateGraphics();

            foreach(var i in points)
            {
                graphics.DrawEllipse(new Pen(Color.FromArgb(0, 255, 0), 4), new Rectangle(i.Position.X - 2, i.Position.Y - 2, 4, 4));
            }

            foreach (var i in squares)
            {
                graphics.DrawRectangle(new Pen(Color.Blue, 4), new Rectangle(i.Position.X - 2, i.Position.Y - 2, 4, 4));
            }

            graphics.DrawEllipse(new Pen(Color.Violet, 2), new Rectangle(averagePoint.X - 2, averagePoint.Y - 2, 4, 4));
            graphics.DrawRectangle(new Pen(Color.Red, 2), new Rectangle(averageSquare.X - 2, averageSquare.Y - 2, 4, 4));

        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(radioButton1.Checked)
            {
                points.Add(new RObject(new Point(e.X, e.Y), 0));
            }
            else if(radioButton2.Checked)
            {
                squares.Add(new RObject(new Point(e.X, e.Y), 1));
            }

            ReLearn();
            ReDraw();
            RefreshForm();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var x in points)
            {
                if (e.X <= x.Position.X + 7 && e.X >= x.Position.X - 7 && e.Y <= x.Position.Y + 7 && e.Y >= x.Position.Y - 7)
                {
                    interactionObject = x;
                    RefreshForm();
                    return;
                }
            }

            foreach (var x in squares)
            {
                if (e.X <= x.Position.X + 7 && e.X >= x.Position.X - 7 && e.Y <= x.Position.Y + 7 && e.Y >= x.Position.Y - 7)
                {
                    interactionObject = x;
                    RefreshForm();
                    return;
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (interactionObject != null)
            {
                interactionObject.Position = new Point(e.X, e.Y);
                RefreshForm();
            }
        }

        private void ReLearn()
        {
            if (points.Count() > 0 || squares.Count() > 0)
            {
                List<RObject> allObjects = new List<RObject>();
                allObjects.AddRange(points);
                allObjects.AddRange(squares);

                for (int k = 0; k < 50000; k++)
                {
                    RObject p = allObjects[(int)(r.NextDouble() * allObjects.Count())];
                    double nx = (double)((double)p.Position.X / (double)panel1.Width);
                    double ny = (double)((double)p.Position.Y / (double)panel1.Height);

                    NN.feedForward(new double[] { nx, ny });
                    double[] targets = new double[2];

                    if (p.Type == 0)
                        targets[0] = 1;
                    else
                        targets[1] = 1;

                    NN.backpropagation(targets);
                }
            }
        }

        private void ReDraw()
        {
            if (points.Count + squares.Count < 2)
                return;

            Bitmap newBitmap = new Bitmap(h, w);

            for (int i = 0; i < w / resolution; i++)
            {
                for (int j = 0; j < h / resolution; j++)
                {
                    double nx = (double)(i * resolution) / (double)panel1.Width;
                    double ny = (double)(j * resolution) / (double)panel1.Height;
                    double[] outputs = NN.feedForward(new double[] { nx, ny });

                    for (int k = 0; k < resolution; k++)
                    {
                        for (int l = 0; l < resolution; l++)
                            newBitmap.SetPixel(i * resolution + k, j * resolution + l,
                            Color.FromArgb(0, (int)(outputs[1] * 255),
                            (int)(outputs[0] * 255)));
                    }
                }
            }

            panel1.BackgroundImage = newBitmap;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if(interactionObject != null)
            {
                interactionObject = null;
                ReLearn();
                ReDraw();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            points.Clear();
            squares.Clear();

            NN = new NeuralNetwork(0.01, x => 1 / (1 + Math.Exp(-x)), y => y * (1 - y), layers);

            ReDraw();
            RefreshForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            squares.Clear();
            points.Clear();

            NN = new NeuralNetwork(0.01, x => 1 / (1 + Math.Exp(-x)), y => y * (1 - y), layers);

            Random random = new Random();

            int x1 = int.Parse(textBox1.Text);
            int y1 = int.Parse(textBox2.Text);
            int sig1 = int.Parse(textBox3.Text);

            int x2 = int.Parse(textBox8.Text);
            int y2 = int.Parse(textBox7.Text);
            int sig2 = int.Parse(textBox6.Text);

            /*for (int i = 0; i < int.Parse(textBox4.Text); i++)
            {
                points.Add(new RObject(new Point(x1 + random.Next(-sig1, sig1), y1 + random.Next(-sig1, sig1))));
                ReLearn();
            }

            for (int i = 0; i < int.Parse(textBox5.Text); i++)
            {
                squares.Add(new RObject(new Point(x2 + random.Next(-sig2, sig2), y2 + random.Next(-sig2, sig2))));
                ReLearn();
            }*/

            int j = 0;
            int k = 0;

            for (int i = 0; i < int.Parse(textBox4.Text) + int.Parse(textBox5.Text); i++)
            {
                if (j < int.Parse(textBox4.Text))
                {
                    points.Add(new RObject(new Point(x1 + random.Next(-sig1, sig1), y1 + random.Next(-sig1, sig1)), 0));
                    j++;
                }

                ReLearn();

                if (k < int.Parse(textBox5.Text))
                {
                    squares.Add(new RObject(new Point(x2 + random.Next(-sig2, sig2), y2 + random.Next(-sig2, sig2)), 1));
                    k++;
                }

                ReLearn();
            }

            ReDraw();
            RefreshForm();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
