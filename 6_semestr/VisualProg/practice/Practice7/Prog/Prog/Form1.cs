using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog
{
    public partial class Form1 : Form
    {
        static Pen pen1;
        static Graphics g;
        static Pen pen2;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Draw(int n)
        {

            pen1 = new Pen(Color.Green, 1);
            pen2 = new Pen(Color.Blue, 1);
            g.Clear(Color.Black);

            var point1 = new PointF(200, 200);
            var point2 = new PointF(500, 200);
            var point3 = new PointF(350, 400);

            g.DrawLine(pen1, point1, point2);
            g.DrawLine(pen1, point2, point3);
            g.DrawLine(pen1, point3, point1);


            Fractal(point1, point2, point3, n);
            Fractal(point2, point3, point1, n);
            Fractal(point3, point1, point2, n);
        }



        static int Fractal(PointF p1, PointF p2, PointF p3, int iter)
        {

            if (iter > 0)
            {

                var p4 = new PointF((p2.X + 2 * p1.X) / 3, (p2.Y + 2 * p1.Y) / 3);
                var p5 = new PointF((2 * p2.X + p1.X) / 3, (p1.Y + 2 * p2.Y) / 3);

                var ps = new PointF((p2.X + p1.X) / 2, (p2.Y + p1.Y) / 2);
                var pn = new PointF((4 * ps.X - p3.X) / 3, (4 * ps.Y - p3.Y) / 3);
                
                g.DrawLine(pen1, p4, pn);
                g.DrawLine(pen1, p5, pn);
                g.DrawLine(pen2, p4, p5);


                
                Fractal(p4, pn, p5, iter - 1);
                Fractal(pn, p5, p4, iter - 1);
                Fractal(p1, p4, new PointF((2 * p1.X + p3.X) / 3, (2 * p1.Y + p3.Y) / 3), iter - 1);
                Fractal(p5, p2, new PointF((2 * p2.X + p3.X) / 3, (2 * p2.Y + p3.Y) / 3), iter - 1);

            }
            return iter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Draw((int)numericUpDown1.Value);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);

            Point start = new Point(50, 50);
            Point finish = new Point(200, 200);

            int x1 = 50;
            int y1 = 40;
            int x2 = 230;
            int y2 = 300;

            int k = (int)numericUpDown1.Value;

            //DragonLine(k, start, finish);
            DragonLine(k, x1, y1, x2, y2);
        }

        private void DragonLine(int k, int x1, int y1, int x2, int y2)
        {
            if (k == 0)
                g.DrawLine(new Pen(Color.Black), new Point(x1, y1), new Point(x2, y2));
            else
            {
                int tx = (int)((x1 + x2) / 2.0 + (y2 - y1) / 2.0);
                int ty = (int)((y1 + y2) / 2.0 - (x2 - x1) / 2.0);

                DragonLine(k - 1, x2, y2, tx, ty);
                DragonLine(k - 1, x1, y1, tx, ty);
            }
        }

        private void LeviLine(int k, int x1, int y1, int x2, int y2)
        {
            if (k == 0)
                g.DrawLine(new Pen(Color.Black), new Point(x1, y1), new Point(x2, y2));
            else
            {
                int tx = (int)((x1 + x2) / 2.0 + (y2 - y1) / 2.0);
                int ty = (int)((y1 + y2) / 2.0 - (x2 - x1) / 2.0);

                LeviLine(k - 1, x1, y1, tx, ty);
                LeviLine(k - 1, tx, ty, x2, y2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);

            Point start = new Point(50, 50);
            Point finish = new Point(200, 200);

            int x1 = 50;
            int y1 = 40;
            int x2 = 230;
            int y2 = 300;

            int k = (int)numericUpDown1.Value;

            //DragonLine(k, start, finish);
            LeviLine(k, x1, y1, x2, y2);
        }
    }
}
