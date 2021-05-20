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
        Polygon rocket_bot;
        Polygon air_ball;

        SolidBrush orangeBrush;
        SolidBrush grayBrush;
        SolidBrush greenBrush;

        bool autoMod = false;
        string autoDirection = "r";

        bool mUp = false;
        bool mDown = false;
        bool mLeft = false;
        bool mRight = false;

        public Form1()
        {
            InitializeComponent();

            g = panel1.CreateGraphics();
            orangeBrush = new SolidBrush(Color.Orange);
            grayBrush = new SolidBrush(Color.Gray);
            greenBrush = new SolidBrush(Color.Green);
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

            rocket_bot = new Polygon(new Point[]
            {
                new Point(0, 0),
                new Point(50, 0),
                new Point(55, 30),
                new Point(-5, 30),
                new Point(0, 0)
            }, new Point(25, 165));

            air_ball = new Polygon(new Point[]
            {
                new Point(0, 0),
                new Point(20, -20),
                new Point(10, -40),
                new Point(-10, -40),
                new Point(-20, -20),
                new Point(0, 0)
            }, new Point(40, 200));

            Draw();

            timer1.Start();
        }

        private void Draw()
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g.Clear(Color.White);

            g.FillPolygon(greenBrush, air_ball.FixedPoly());
            g.FillRectangle(new SolidBrush(Color.Brown), new Rectangle(new Point(30, 200), new Size(20, 20)));

            g.FillPolygon(orangeBrush, rocket.FixedPoly());
            g.FillPolygon(grayBrush, rocket_bot.FixedPoly());

            g.FillEllipse(new SolidBrush(Color.Yellow), new Rectangle(new Point(150, 40), new Size(50, 50)));
        }

        private void upButton_Click(object sender, EventArgs e)
        {
        }

        private void downButton_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!autoMod)
            {
                if (mUp)
                {
                    rocket.Move(0, -3);
                    rocket_bot.Move(0, -3);
                }
                if (mDown)
                {
                    rocket.Move(0, 3);
                    rocket_bot.Move(0, 3);
                }
                if (mLeft)
                {
                    rocket.Move(-3, 0);
                    rocket_bot.Move(-3, 0);
                }
                if (mRight)
                {
                    rocket.Move(3, 0);
                    rocket_bot.Move(3, 0);
                }
            }
            else
            {
                if (autoDirection == "r")
                {
                    if (rocket.basePoint.X < 150)
                    {
                        rocket.Move(4, 0);
                        rocket_bot.Move(4, 0);
                    }
                    else
                        autoDirection = "l";
                }
                else if (autoDirection == "l")
                {
                    if (rocket.basePoint.X > 20)
                    {
                        rocket.Move(-4, 0);
                        rocket_bot.Move(-4, 0);
                    }
                    else
                        autoDirection = "r";
                }
            }

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

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = false;
            rightButton.Enabled = false;
            leftButton.Enabled = false;
            upButton.Enabled = false;
            downButton.Enabled = false;
            autoMod = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = true;
            rightButton.Enabled = true;
            leftButton.Enabled = true;
            upButton.Enabled = true;
            downButton.Enabled = true;
            autoMod = false;
        }
    }
}
