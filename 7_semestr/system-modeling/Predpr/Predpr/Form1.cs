using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Predpr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int h;
        int n;
        int C_0;
        List<List<string>> solutions = new List<List<string>>();
        DataTable W_table = new DataTable();

        private void button2_Click(object sender, EventArgs e)
        {
            h = int.Parse(textBox1.Text) * 10;
            n = int.Parse(textBox2.Text);
            C_0 = int.Parse(textBox3.Text);
            richTextBox1.Text = "";
            label8.Text = "";
            W_table.Clear();
            W_table.Columns.Clear();
            solutions.Clear();
            drawFuncView();
        }

        private void drawFuncView()
        {
            DataTable g_table = new DataTable();
            g_table.Columns.Add("x", typeof(int));

            for (int i = 0; i < n; i++)
            {
                g_table.Columns.Add("g_" + (i+1) + "(x)", typeof(int));
            }

            for (int x = 0; x <= C_0; x += h)
            {
                g_table.Rows.Add(x);
            }

            for (int j = 1; j < g_table.Columns.Count; j++)
            {
                g_table.Rows[0][j] = 0;
            }

            dataGridView1.DataSource = g_table;
            for (int i = 0; i < dataGridView1.Columns.Count; i++) {
                dataGridView1.Columns[i].Width = 50;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            solutions.Clear();
            drawResultView();
        }

        private void drawResultView()
        {
            W_table.Clear();
            W_table.Columns.Clear();
            W_table.Columns.Add("c", typeof(int));

            for (int i = 0; i < n; i++)
            {
                W_table.Columns.Add("W_" + (i + 1) + "(c)", typeof(int));
                W_table.Columns.Add("x_" + (i+1));
            }

            for (int C = 0; C <= C_0; C += h)
            {
                W_table.Rows.Add(C);
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                W_table.Rows[i][W_table.Columns.Count - 2] = dataGridView1[dataGridView1.Columns.Count - 1, i].Value;
                W_table.Rows[i][W_table.Columns.Count - 1] = dataGridView1[0, i].Value;
            }

            for (int j = 1; j < W_table.Columns.Count; j++)
            {
                W_table.Rows[0][j] = 0;
            }

            dataGridView2.DataSource = W_table;
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].Width = 50;
            }

            calcResult();
            drawSolutionsView();
        }

        private int W_c(int g_i, int n, int W_i)
        {
            int W = int.Parse(dataGridView1[(n-1)/2, g_i].Value.ToString()) + Int32.Parse(dataGridView2[n, W_i].Value.ToString());
            return W;
        }

        private void calcResult()
        {
            for (int n = dataGridView2.Columns.Count - 2; n > 1; n -= 2)
            {
                for (int c_i = 1; c_i <= C_0 / h; c_i++)
                {
                    int max = 0;
                    List<int> min_x = new List<int>();
                    for (int g_i = 0, W_i = c_i; g_i <= c_i; g_i++, W_i--)
                    {
                        int W = W_c(g_i, n, W_i);
                        if (max == W)
                        {
                            min_x.Add(int.Parse(dataGridView1[0, g_i].Value.ToString()));
                        }
                        else if (max < W)
                        {
                            max = W;
                            min_x.Clear();
                            min_x.Add(int.Parse(dataGridView1[0, g_i].Value.ToString()));
                        }
                    }
                    dataGridView2[n - 2, c_i].Value = max;
                    string min_x_s = list_to_string(min_x);
                    dataGridView2[n - 1, c_i].Value = min_x_s;
                }
            }
        }

        private void calcPath(int budget, int column, int lvl)
        {
            int max = int.Parse(dataGridView2[column, 0].Value.ToString());
            List<int> x_max = string_to_list(dataGridView2[column + 1, 0].Value.ToString());
            for (int row = 1; row < dataGridView2.Rows.Count; row++)
            {
                int value = int.Parse(dataGridView2[column, row].Value.ToString());
                List<int> x_cur = new List<int>();
                foreach (int x_elem in string_to_list(dataGridView2[column + 1, row].Value.ToString()))
                {
                    if(budget - x_elem >= 0)
                        x_cur.Add(x_elem);
                }

                if (max < value && x_cur.Count > 0)
                {
                    max = value;
                    x_max = x_cur;
                }
            }
            for (int x_ind = 0; x_ind < x_max.Count; x_ind++)
            {
                if (x_ind > 0)
                {
                    List<string> pred_solution = new List<string>();

                    for (int ind = 0; ind < column / 2; ind++)
                        pred_solution.Add(solutions[solutions.Count - 1][ind]);

                    solutions.Add(pred_solution);
                }
                solutions[solutions.Count - 1].Add("X_" + (column / 2 + 1) + " = " + x_max[x_ind].ToString());

                if (column < dataGridView2.ColumnCount - 2)
                {
                    calcPath(budget - x_max[x_ind], column + 2, lvl + x_ind);
                }
            }
        }

        private void drawSolutionsView()
        {
            solutions.Add(new List<string>());
            calcPath(C_0, 1, 0);
            richTextBox2.Text = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[dataGridView1.Columns.Count - 1].Value.ToString();
            //richTextBox2.Text = 146 + "";
            if (solutions.Count > 1) 
                label8.Text = "Оптимальные стратегии:";
            else if (solutions.Count == 1) label8.Text = "Оптимальная стратегия:";

            foreach (List<string> solution in solutions)
            {
                for (int elem_ind = 0; elem_ind < solution.Count; elem_ind++)
                {
                    if (elem_ind != solution.Count - 1)
                        richTextBox1.Text += solution[elem_ind] + ", ";
                    else
                        richTextBox1.Text += solution[elem_ind];
                }

                richTextBox1.Text += "\n";
            }
        }

        private List<int> string_to_list(string s)
        {
            List<int> l = new List<int>();
            foreach (string element in s.Split(',')) l.Add(Int32.Parse(element));
            return l;
        }

        private string list_to_string(List<int> l)
        {
            string s = "";
            foreach (int element in l)
            {
                s += element.ToString() + ",";
            }
            s = s.Remove(s.Length - 1);
            return s;
        }

    }
}
