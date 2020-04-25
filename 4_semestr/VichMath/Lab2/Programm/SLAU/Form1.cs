using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLAU
{
    public partial class Form1 : Form
    {
        public double[,] A = new double[3, 3] { {34.35, 2.42, 4.85}, {2.31, 25.49, 5.52}, {3.48, 4.85, 30.04}};
        public double[] b = new double[3] {20.14, 10.24, 12.24};
        public double[,] C = new double[3, 3];
        public double[] d = new double[3];
        public double accuracy = 0.00001;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            { 
                for(int j = 0; j < 3; j++)
                {
                    if (i != j)
                        C[i, j] = Math.Round(A[i, j] / A[i, i] * -1, 5);
                    else
                        C[i, j] = 0;
                }
                d[i] = Math.Round(b[i] / A[i, i], 5);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ans = "Исходная система:\n";
            for (int i = 0; i < 3; i++)
            {
                ans += A[i, 0].ToString() + "x1 + " + A[i, 1].ToString() + "x2 + " + A[i, 2].ToString() + "x3 = " + b[i].ToString() + "\n";
            }
            MessageBox.Show(ans);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ans = "Приведённая система:\n";
            for (int i = 0; i < 3; i++)
            {
                ans += C[i, 0].ToString() + "x1 + " + C[i, 1].ToString() + "x2 + " + C[i, 2].ToString() + "x3 = " + d[i].ToString() + "\n";
            }
            MessageBox.Show(ans);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x1 = d[0], x2 = d[1], x3 = d[2];
            double X1 = 0, X2 = 0, X3 = 0;
            int k = 1;
            string result = "";

            while(true)
            {
                X1 = C[0, 1] * x2 + C[0, 2] * x3 + d[0];
                X2 = C[1, 0] * x1 + C[1, 2] * x3 + d[1];
                X3 = C[2, 0] * x1 + C[2, 1] * x2 + d[2];
                result += "Итерация " + k + ":\n    X1 = " + Math.Round(X1, 5).ToString() + "\n    X2 = " + Math.Round(X2, 5).ToString() + "\n    X3 = " + Math.Round(X3, 5).ToString() + "\n";
                if(Math.Abs(X1 + X2 + X3 - x1 - x2 - x3) <= accuracy)
                {
                    MessageBox.Show(result);
                    MessageBox.Show("Ответ:\n    X1 = " + Math.Round(X1, 5).ToString() + "\n    X2 = " + Math.Round(X2, 5).ToString() + "\n    X3 = " + Math.Round(X3, 5).ToString());
                    break;
                }
                k++;
                x1 = X1;
                x2 = X2;
                x3 = X3;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x1 = d[0], x2 = d[1], x3 = d[2];
            double X1 = 0, X2 = 0, X3 = 0;
            int k = 1;
            string result = "";

            while (true)
            {
                X1 = C[0, 1] * x2 + C[0, 2] * x3 + d[0];
                X2 = C[1, 0] * X1 + C[1, 2] * x3 + d[1];
                X3 = C[2, 0] * X1 + C[2, 1] * X2 + d[2];
                result += "Итерация " + k + ":\n    X1 = " + Math.Round(X1, 5).ToString() + "\n    X2 = " + Math.Round(X2, 5).ToString() + "\n    X3 = " + Math.Round(X3, 5).ToString() + "\n";
                if (Math.Abs(X1 + X2 + X3 - x1 - x2 - x3) <= accuracy)
                {
                    MessageBox.Show(result);
                    MessageBox.Show("Ответ:\n    X1 = " + Math.Round(X1, 5).ToString() + "\n    X2 = " + Math.Round(X2, 5).ToString() + "\n    X3 = " + Math.Round(X3, 5).ToString());
                    break;
                }
                k++;
                x1 = X1;
                x2 = X2;
                x3 = X3;
            }
        }
    }
}
