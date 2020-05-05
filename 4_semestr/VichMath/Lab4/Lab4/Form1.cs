using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Globalization;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void RefreshForm()
        {
            panel1.Invalidate();
        }

        void ClearForm()
        {
            Main.dots.Clear();
            Main.lines.Clear();
            Main.couples = new double[1, 1];
            Main.numOfCouples = 0;
            Graphic.scale = 100;
            label1.Text = "Импортируйте пары значений";
            RefreshForm();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            string fileText = "";
            Form2 importForm = new Form2();
            importForm.Owner = this;
            importForm.ShowDialog();
            if (importForm.DialogResult == DialogResult.OK)
            {
                StreamReader file;
                try
                {
                    file = new StreamReader(Main.sourcePath);
                    fileText = file.ReadToEnd();
                }
                catch
                {
                    MessageBox.Show("Введён неверный путь к файлу!");
                    return;
                }
                file.Close();

                Main.sourcePath = "";

                CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

                try
                {
                    ClearForm();
                    string[] separators = {"\n", " ", "\t"};
                    string[] splittedText = fileText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    //string text = "";

                    Main.numOfCouples = int.Parse(splittedText[0]);
                    Main.couples = new double[Main.numOfCouples, 2];

                    for (int i = 0; i < Main.numOfCouples; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            //MessageBox.Show("+" + splittedText[1 + i * 2 + j] + "+");
                            Main.couples[i, j] = double.Parse(splittedText[1 + i * 2 + j]);
                            //text += Main.couples[i, j].ToString() + " ";
                        }
                        //text += '\n';
                    }

                    //MessageBox.Show(text);
                }
                catch
                {
                    MessageBox.Show("Файл не прочитан");
                }
                Thread.CurrentThread.CurrentCulture = temp_culture;
                RefreshForm();
                Graphic.GetDelta();
                Graphic.ImportCouples();
            }
        }

        private void showCouples_Click(object sender, EventArgs e)
        {
            string text = Main.numOfCouples.ToString() + " пар:\n";
            for (int i = 0; i < Main.numOfCouples; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    text += Main.couples[i, j].ToString() + " ";
                }
                text += '\n';
            }
            MessageBox.Show(text);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = panel1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 1);

            graphics.DrawLine(pen, new Point(0, 250), new Point(500, 250));
            graphics.DrawLine(pen, new Point(250, 0), new Point(250, 500));
            int x = 250;
            int y = 250;
            while(x > 0)
            {
                x -= Graphic.scale;
                graphics.DrawLine(pen, new Point(x, 240), new Point(x, 260));
            }
            x = 250;
            while (x < 500)
            {
                x += Graphic.scale;
                graphics.DrawLine(pen, new Point(x, 240), new Point(x, 260));
            }
            while (y > 0)
            {
                y -= Graphic.scale;
                graphics.DrawLine(pen, new Point(240, y), new Point(260, y));
            }
            y = 250;
            while (y < 500)
            {
                y += Graphic.scale;
                graphics.DrawLine(pen, new Point(240, y), new Point(260, y));
            }

            foreach (Line i in Main.lines) // Отрисовка линий
            {
                graphics.DrawLine(new Pen(Color.Red, 2), new Point(i.firstPoint.x, i.firstPoint.y), new Point(i.secondPoint.x, i.secondPoint.y));
            }

            foreach (Dot i in Main.dots) // Отрисовка точек
            {
                graphics.DrawRectangle(new Pen(Color.Green, 2), i.x - 1, i.y - 1, 3, 3);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void lessQuadsButton_Click(object sender, EventArgs e)
        {
            if(Main.numOfCouples == 0)
            {
                MessageBox.Show("Сначала импортируйте пары значений!");
                return;
            }

            double sumX = 0;
            double sumY = 0;
            double sumXY = 0;
            double sumXX = 0;
            double k, b;

            for(int i = 0; i < Main.numOfCouples; i++)
            {
                sumX += Main.couples[i, 0];
                sumY += Main.couples[i, 1];
                sumXY += Main.couples[i, 0] * Main.couples[i, 1];
                sumXX += Main.couples[i, 0] * Main.couples[i, 0];
            }

            k = (sumXY - sumX * sumY / Main.numOfCouples) / (sumXX - sumX * sumX / Main.numOfCouples);
            b = (sumY - k * sumX) / Main.numOfCouples;

            label1.Text = "k: " + k.ToString() + "\nb: " + b.ToString();

            /*MessageBox.Show(sumX.ToString() + " " 
                + sumY.ToString() + " " 
                + sumXY.ToString() + " "
                + sumXX.ToString() + " k: "
                + k.ToString() + " b: "
                + b.ToString());*/
            Dot dot1 = new Dot(Main.GetMinX() - 1, (Main.GetMinX() - 1) * k + b);
            Dot dot2 = new Dot(Main.GetMaxX() + 1, (Main.GetMaxX() + 1) * k + b);
            Main.lines.Add(new Line(dot1, dot2));

            RefreshForm();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void shouDotsButton_Click(object sender, EventArgs e)
        {
            string result = "";
            int i = 1;
            foreach(Dot x in Main.dots)
            {
                result += i.ToString() + ": " + x.x.ToString() + "/" + x.y.ToString() + "\n";
                i++;
            }
            MessageBox.Show(result);
        }
    }
}
