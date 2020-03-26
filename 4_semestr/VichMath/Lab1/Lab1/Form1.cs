using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void halfDivide_Click(object sender, EventArgs e)
        {
            HalfDivide(0.2, 1.8, 0.00001);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChordNTangents(0.8, 1.8, 0.00001);
        }

        private void HalfDivide(double a, double b, double accuracy)
        {
            double c, fA, fB, fC;
            string table = "";
            int i = 1;

            while (i < 100)
            {
                c = (a + b) / 2;
                fA = CountFunc(a);
                fB = CountFunc(b);
                fC = CountFunc(c);

                table += "Итерация " + i + " : " + c.ToString() + "\n";
                i++;

                if(Math.Abs(fC) <= accuracy)
                {
                    MessageBox.Show(table);
                    MessageBox.Show("Корень равен: " + c.ToString());
                    return;
                }

                if(fA * fC < 0)
                {
                    b = c;
                    continue;
                }
                else if(fB * fC < 0)
                {
                    a = c;
                    continue;
                }
            }
            MessageBox.Show("На этом промежутке корня нет.");
        }

        private void ChordNTangents(double a, double b, double accuracy)
        {
            double fA, fB, deltaAB, fShA;
            string table = "";
            int i = 1;

            while (i < 100)
            {
                fShA = Derivative(a);
                fA = CountFunc(a);
                fB = CountFunc(b);
                deltaAB = Math.Abs(a - b);

                double prA = a;
                double prB = b;

                a = prA - fA / fShA;
                b = prB - (prA - prB) / (fA - fB) * fB;
                table += "Итерация " + i + " : " + b.ToString() + "\n";
                i++;

                if (deltaAB <= accuracy)
                {
                    MessageBox.Show(table);
                    MessageBox.Show("Корень равен: " + b.ToString());
                    return;
                }
            }
            MessageBox.Show("На этом промежутке корня нет.");
        }

        private double CountFunc(double x)
        {
            double result = Math.Sin(Math.Pow(x + 3, 2) / 2) / 2 + Math.Log(x + 2) / 2 - 1;
            return result;
        }

        private double Derivative(double x)
        {
            double result = (x + 3) / 2 * Math.Cos(Math.Pow(x + 3, 2) / 2) + 1 / (2 * (x + 2));
            return result;
        }
    }
}
