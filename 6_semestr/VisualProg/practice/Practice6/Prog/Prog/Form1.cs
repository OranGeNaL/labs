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
        }

        private void Draw()
        {
            g.Clear(Color.White);
            //Point[] awe = rocket.FixedPoly();
            g.FillPolygon(orangeBrush, rocket.FixedPoly());
            g.DrawLine(new Pen(Color.Black), 50, 50, 75, 12);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
