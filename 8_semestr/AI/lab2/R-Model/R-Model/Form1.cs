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

        RObject interactionObject = null;

        public Form1()
        {
            InitializeComponent();
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
                graphics.DrawEllipse(new Pen(Color.Green, 4), new Rectangle(i.Position.X - 2, i.Position.Y - 2, 4, 4));
            }

            foreach (var i in squares)
            {
                graphics.DrawRectangle(new Pen(Color.Blue, 4), new Rectangle(i.Position.X - 2, i.Position.Y - 2, 4, 4));
            }

            graphics.DrawEllipse(new Pen(Color.Violet, 2), new Rectangle(averagePoint.X - 2, averagePoint.Y - 2, 4, 4));
            graphics.DrawRectangle(new Pen(Color.Red, 2), new Rectangle(averageSquare.X - 2, averageSquare.Y - 2, 4, 4));


            if (averagePoint != new Point(0, 0) && averageSquare != new Point(0, 0))
            {
                try
                {
                    double pDistance = MathDealer.GetAverageDistance(points);
                    double sqDictance = MathDealer.GetAverageDistance(squares);

                    double lamba = pDistance / (pDistance + sqDictance);

                    Debug.WriteLine(lamba);

                    Point perpendCenter = new Point();

                    if (pDistance < sqDictance)
                        perpendCenter = MathDealer.GetPerpendPoint(averagePoint, averageSquare, lamba);
                    else
                        perpendCenter = MathDealer.GetPerpendPoint(averageSquare, averagePoint, lamba);


                    float tangenc = (float)(averagePoint.Y - averageSquare.Y) / (float)(averagePoint.X - averageSquare.X);


                    Point startPoint = MathDealer.GetPerpendicularLinePoint(perpendCenter, tangenc, 0);
                    Point endPoint = MathDealer.GetPerpendicularLinePoint(perpendCenter, tangenc, 400);
                    graphics.DrawLine(new Pen(Color.Black), startPoint, endPoint);
                }

                catch
                {

                }
            }

        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(radioButton1.Checked)
            {
                points.Add(new RObject(new Point(e.X, e.Y)));
            }
            else if(radioButton2.Checked)
            {
                squares.Add(new RObject(new Point(e.X, e.Y)));
            }
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

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if(interactionObject != null)
            {
                interactionObject = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            points.Clear();
            squares.Clear();

            RefreshForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            squares.Clear();
            points.Clear();

            Random random = new Random();

            int x1 = int.Parse(textBox1.Text);
            int y1 = int.Parse(textBox2.Text);
            int sig1 = int.Parse(textBox3.Text);

            int x2 = int.Parse(textBox8.Text);
            int y2 = int.Parse(textBox7.Text);
            int sig2 = int.Parse(textBox6.Text);

            for (int i = 0; i < int.Parse(textBox4.Text); i++)
            {
                points.Add(new RObject(new Point(x1 + random.Next(-sig1, sig1), y1 + random.Next(-sig1, sig1))));
            }

            for (int i = 0; i < int.Parse(textBox5.Text); i++)
            {
                squares.Add(new RObject(new Point(x2 + random.Next(-sig2, sig2), y2 + random.Next(-sig2, sig2))));
            }

            RefreshForm();
        }
    }
}
