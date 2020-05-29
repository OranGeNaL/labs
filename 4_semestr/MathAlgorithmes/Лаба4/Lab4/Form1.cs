using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            int n, M;

            string kStr = "k: ";
            string NStr = "N: ";
            string iStr = "i: ";
            string jStr = "j: ";

            try
            {
                n = int.Parse(nTextBox.Text);
                M = int.Parse(mTextBox.Text);

                int[,] matrix = new int[n, n];

                Random r = new Random();

                for(int k = 0; k < M; k++)
                {
                    int N = r.Next(0, n*n);

                    int i = N / n;
                    int j = (N - i * n);

                    if(i == j || matrix[i, j] == 1)
                    {
                        M++;
                        continue;
                    }
                    else
                    {
                        matrix[i, j] = 1;
                        matrix[j, i] = 1;
                    }

                    kStr += "| " + k.ToString();
                    NStr += "| " + N.ToString();
                    iStr += "| " + (i + 1).ToString();
                    jStr += "| " + (j + 1).ToString();
                }

                MessageBox.Show("Матрица смежности:\n" + PrintMatrix(matrix));
                MessageBox.Show("Таблица работы алгоритма:\n" + kStr +
                    "\n" + NStr + "\n" + iStr + "\n" + jStr);
            }
            catch
            {

            }
        }

        public string PrintMatrix(int[,] matrix)
        {
            string result = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    result += matrix[i, j] + " ";
                }
                result += "\n";
            }
            return result;
        }
    }
}
