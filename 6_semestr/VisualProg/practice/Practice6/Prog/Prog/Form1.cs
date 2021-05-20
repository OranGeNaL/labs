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
        Graphics g;
        Polygon rocket;
        SolidBrush orangeBrush;
        bool mUp = false;
        bool mDown = false;
        bool mLeft = false;
        bool mRight = false;

        public Form1()
        {
            InitializeComponent();

            g = panel1.CreateGraphics();
            orangeBrush = new SolidBrush(Color.Orange);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            rocket = new Polygon(new Point[] {
            new Point(0, 0),
            new Point(15, 15),
            new Point(15, 115),
            new Point(-15, 115),
            new Point(-15, 15),
            new Point(0, 0)}, new Point(50, 50));

            Draw();

            timer1.Start();
        }

        private void Draw()
        {
            /*g.Clear(Color.White);
            //Point[] awe = rocket.FixedPoly();
            g.FillPolygon(orangeBrush, rocket.FixedPoly());
            g.DrawLine(new Pen(Color.Black), 50, 50, 75, 12);*/
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g.Clear(Color.White);
            //Point[] awe = rocket.FixedPoly();
            g.FillPolygon(orangeBrush, rocket.FixedPoly());
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            /*rocket.basePoint = new Point(rocket.basePoint.X, rocket.basePoint.Y - 2);
            panel1.Invalidate();*/
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            /*rocket.basePoint = new Point(rocket.basePoint.X, rocket.basePoint.Y + 2);
            panel1.Invalidate();*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mUp)
                rocket.Move(0, -3);
            if (mDown)
                rocket.Move(0, 3);
            if (mLeft)
                rocket.Move(-3, 0);
            if (mRight)
                rocket.Move(3, 0);
            panel1.Invalidate();
        }

        private void upButton_MouseDown(object sender, MouseEventArgs e)
        {
            mUp = true;
        }

        private void upButton_MouseUp(object sender, MouseEventArgs e)
        {
            mUp = false;
        }

        private void downButton_MouseDown(object sender, MouseEventArgs e)
        {
            mDown = true;
        }

        private void downButton_MouseUp(object sender, MouseEventArgs e)
        {
            mDown = false;
        }

        private void leftButton_MouseDown(object sender, MouseEventArgs e)
        {
            mLeft = true;
        }

        private void leftButton_MouseUp(object sender, MouseEventArgs e)
        {
            mLeft = false;
        }

        private void rightButton_MouseDown(object sender, MouseEventArgs e)
        {
            mRight = true;
        }

        private void rightButton_MouseUp(object sender, MouseEventArgs e)
        {
            mRight = false;
        }
    }
}
