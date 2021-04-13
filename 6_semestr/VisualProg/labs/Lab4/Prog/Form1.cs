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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float x = float.Parse(textBox1.Text);
            float y = float.Parse(textBox2.Text);
            float z = float.Parse(textBox3.Text);

            textBox1.Text = Math.Max(x, Math.Max(y, z)).ToString();
            textBox3.Text = Math.Min(x, Math.Min(y, z)).ToString();
            textBox2.Text = Math.Max(Math.Min(Math.Max(x, y), z), y).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float numb = float.Parse(textBox4.Text);
            double n = 0;

            for (int i = 0; n <= numb; i++)
            {
                n = Math.Pow(2, i);
            }

            label5.Text = n.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox8.Text = Replace(float.Parse(textBox8.Text)).ToString();
            textBox7.Text = Replace(float.Parse(textBox7.Text)).ToString();
            textBox6.Text = Replace(float.Parse(textBox6.Text)).ToString();
        }

        private float Replace(float src)
        {
            if (src < 0)
                return Math.Abs(src);
            if (src == 0)
                return (float)Math.PI;
            else
                return src;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
                listBox1.Items.Add(string.Format("{0}. {1}", i, i*i)); ;
        }
    }
}
