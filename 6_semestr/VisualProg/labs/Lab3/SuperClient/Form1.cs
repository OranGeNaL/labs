using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            label5.Text = "Никуда";
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label5.Text = "Вверх";
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label5.Text = "Вправо";
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label5.Text = "Влево";
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label5.Text = "Вниз";
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            Reset();
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            Reset();
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Reset();
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
