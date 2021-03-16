using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Practice3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddPolygon(new Point[]
            {
                new Point(0, 0),
                new Point(0, this.Height),
                new Point(this.Width, 0)
            });
            Region myRegion = new Region(myPath);
            this.Region = myRegion;
        }
    }
}