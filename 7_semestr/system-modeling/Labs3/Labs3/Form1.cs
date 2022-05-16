using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labs3
{
    public partial class Form1 : Form
    {
        private int p;
        private int n;
        private int oldEquipment;
        List<Cell> cells = new List<Cell>();
        public Form1()
        {
            InitializeComponent();
        }

        DataTable table = new DataTable();

        private void button2_Click(object sender, EventArgs e)
        {
            n = int.Parse(textBox1.Text);
            p = int.Parse(textBox2.Text);
            table.Clear();
            table.Columns.Clear();
            drawTable();
        }

        private void drawTable()
        {
            DataTable g_table = new DataTable();
            g_table.Columns.Add("t", typeof(int));
            g_table.Columns.Add("r(t)", typeof(int));
            g_table.Columns.Add("u(t)", typeof(int));

            for (int j = 0; j <= n; j++)
            {
                g_table.Rows.Add(j);
            }

            dataGridView1.DataSource = g_table;
        }

       private void button1_Click(object sender, EventArgs e)
        {
            table.Clear();
            table.Columns.Clear();
            label12.Text = "";
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            oldEquipment = int.Parse(textBox3.Text);
            //условная оптимизация
            int constValue = 0 - p +
                int.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString()) -
                int.Parse(dataGridView1.Rows[0].Cells[2].Value.ToString());

            table.Columns.Add("W(t)|t");
            for (int i = 0; i <= n; i++)
            {
                table.Columns.Add("" + i);
            }
            for (int i = n; i > 0; i--)
            {
                table.Rows.Add("W(" + i + ")");
            }

            for (int i = 0; i <= n; i++)
            {
                int r_i = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                int u_i = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                int result = r_i - u_i;
                if (result >= constValue)
                {
                    cells.Add(new Cell(0, i + 1, result, Color.White));
                } else
                {
                    cells.Add(new Cell(0, i + 1, constValue, Color.Yellow));
                }
            }

            for (int i = 1; i < n; i++)
            {
                bool isEntered = false;
                for (int j = 0; j <= n; j++)
                {
                    int r_i = int.Parse(dataGridView1.Rows[j].Cells[1].Value.ToString());
                    int u_i = int.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());
                    int result;
                    if (j + 2 > n)
                    {
                        result = r_i - u_i;
                    }
                    else
                    {
                        result = r_i - u_i + getValue(i - 1, j + 2);
                    }
                    int save = constValue + getValue(i - 1, 2);
                    if (result == save && !isEntered)
                    {
                        cells.Add(new Cell(i, j + 1, result, Color.White));
                        isEntered = true;
                    }
                    else if (result > save)
                    {
                        cells.Add(new Cell(i, j + 1, result, Color.White));
                    }
                    else
                    {
                        cells.Add(new Cell(i, j + 1, save, Color.Yellow));
                    }
                }

            }

            //Заполнение таблицы
            for (int i = 0; i < cells.Count; i++)
            {
                table.Rows[cells[i].i][cells[i].j] = cells[i].value;
            }
            dataGridView2.DataSource = table;

            for (int i = 0; i < cells.Count; i++)
            {
                dataGridView2.Rows[cells[i].i].Cells[cells[i].j].Style.BackColor = cells[i].color;
            }

            foreach (DataGridViewColumn column in dataGridView2.Columns)
                column.Width = 20;

            // Стратегия
            int k = 0;
            textBox5.Text = GetCell(n - 1, oldEquipment + 1 + k).value.ToString();
            for (int i = n - 1; i >= 0; i--)
            {
                Cell cell = GetCell(i, oldEquipment + 1 + k);
                if (cell.color.Equals(Color.Yellow)) {
                    oldEquipment = 1;
                    k = 0;
                    label12.Text += " З ";
                } else
                {
                    label12.Text += " С ";
                    ++k;
                }
                cell.color = Color.Gray;
                dataGridView2.Rows[cell.i].Cells[cell.j].Style.BackColor = cell.color;
            }
        }

        private Cell GetCell(int i, int j)
        {
            for (int k = 0; k < cells.Count; k++)
            {
                if (cells[k].i == i && cells[k].j == j)
                {
                    return cells[k];
                }
            }
            return null;
        }
        private int getValue(int i, int j)
        {
            for (int k = 0; k < cells.Count; k++)
            {
                if (cells[k].i == i && cells[k].j == j)
                {
                    return cells[k].value;
                }
            }
            return -1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
