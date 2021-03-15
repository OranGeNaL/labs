using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UchebProg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b, c, p;
            a = Convert.ToInt32(textBox1.Text);
            b = Convert.ToInt32(textBox2.Text);
            c = Convert.ToInt32(textBox3.Text);
            p = a + b + c;
            if (a > 0 && b > 0 && c > 0)
                if (a + b > c && a + c > b && b + c > a)
                    textBox4.Text = "Периметр треугольника = " + p.ToString();
                else
                {
                    textBox4.Text = "Одна из сторон треугольника больше суммы двух других Повторите ввод ";
                }
            else
            {
                textBox4.Text = "Одна из сторон треугольника меньше или равно 0! Повторите ввод ";
            }
        }
    }
}
