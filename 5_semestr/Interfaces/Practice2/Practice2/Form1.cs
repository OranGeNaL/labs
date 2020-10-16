using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice2
{
    public partial class Form1 : Form
    {

        private delegate void SafeCallDelegate(string text, Label label);


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(FirstIsp));
            thread.Start();
        }

        private void FirstIsp()
        {
            Main.timeStamps.Clear();
            Random rand = new Random();
            for (int i = 1; i <= int.Parse(textBox1.Text); i++)
            {
                Thread.Sleep(rand.Next(2000, 5000));

                Main.startTime = DateTime.Now;
                panel1.BackColor = Color.Red;

                Thread.Sleep(500);
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if(panel1.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel1.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }

        private void RefreshStats()
        {
            string text = "Время реакции в мс:";
            for (int i = 0; i < Main.timeStamps.Count; i++)
            {
                text += "\n" + (i + 1).ToString() + ". " + Main.timeStamps[i].stamp.ToString();
            }
            label1.Text = text;
        }

        private void RefreshAverage()
        {
            string text = "Среднее время реакции в мс:";
            double sum = 0;
            foreach(var i in Main.timeStamps)
            {
                sum += i.stamp;
            }
            label2.Text = text + (sum / Main.timeStamps.Count).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Focus();
            Thread thread = new Thread(new ThreadStart(ThirdIsp));
            thread.Start();
        }

        private void button3_KeyPress(object sender, KeyPressEventArgs e)
        {
            label3.Text = "Нажата клавиша: " + e.KeyChar;
            if(e.KeyChar.ToString() == label5.Text)
            {
                Main.pressTime = DateTime.Now;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));
                label5.Text = "-";
                RefreshStats();
                RefreshAverage();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(SecondIsp));
            thread.Start();
        }

        private void SecondIsp()
        {
            Main.timeStamps.Clear();
            Random rand = new Random();
            for (int i = 1; i <= int.Parse(textBox2.Text); i++)
            {
                Thread.Sleep(rand.Next(2000, 5000));

                int lamp = rand.Next(1, 7);
                switch (lamp)
                {
                    case 1:
                        panel2.BackColor = Color.Red;
                        break;
                    case 2:
                        panel3.BackColor = Color.Red;
                        break;
                    case 3:
                        panel4.BackColor = Color.Red;
                        break;
                    case 4:
                        panel5.BackColor = Color.Red;
                        break;
                    case 5:
                        panel6.BackColor = Color.Red;
                        break;
                    case 6:
                        panel7.BackColor = Color.Red;
                        break;
                }

                Main.startTime = DateTime.Now;

                Thread.Sleep(1000);
            }
        }

        //Обработка панелей второго испытания
        #region 

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel2.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel2.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel3.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel3.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel4.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel4.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel5.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel5.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }

        private void panel6_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel6.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel6.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }

        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel7.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel7.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }

        #endregion

        private void ThirdIsp()
        {
            Main.timeStamps.Clear();
            Random rand = new Random();
            for (int i = 1; i <= int.Parse(textBox3.Text); i++)
            {
                Thread.Sleep(rand.Next(2000, 5000));

                WriteTextSafe(rand.Next(0, 10).ToString(), label5);

                Main.startTime = DateTime.Now;

                Thread.Sleep(1000);
            }
        }

        private void WriteTextSafe(string text, Label label)
        {
            if (label.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                label.Invoke(d, new object[] { text, label });
            }
            else
            {
                label.Text = text;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button6.Focus();
            Thread thread = new Thread(new ThreadStart(FourthIsp));
            thread.Start();
        }

        private void FourthIsp()
        {
            Main.timeStamps.Clear();
            Random rand = new Random();
            for (int i = 1; i <= int.Parse(textBox4.Text); i++)
            {
                Thread.Sleep(rand.Next(2000, 5000));

                if (rand.Next(0, 2) == 0)
                {
                    int lamp = rand.Next(1, 7);
                    switch (lamp)
                    {
                        case 1:
                            panel8.BackColor = Color.Red;
                            break;
                        case 2:
                            panel9.BackColor = Color.Red;
                            break;
                        case 3:
                            panel10.BackColor = Color.Red;
                            break;
                        case 4:
                            panel11.BackColor = Color.Red;
                            break;
                        case 5:
                            panel12.BackColor = Color.Red;
                            break;
                        case 6:
                            panel13.BackColor = Color.Red;
                            break;
                    }
                }

                else
                {
                    WriteTextSafe(rand.Next(0, 10).ToString(), label6);
                }

                Main.startTime = DateTime.Now;
                
                Thread.Sleep(1000);
            }
        }

        #region

        private void panel8_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel8.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel8.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }

        private void panel9_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel9.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel9.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }

        private void panel10_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel10.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel10.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }

        private void panel11_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel11.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel11.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }

        private void panel12_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel12.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel12.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }

        private void panel13_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel13.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel13.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }
        #endregion

        private void button6_KeyPress(object sender, KeyPressEventArgs e)
        {
            label3.Text = "Нажата клавиша: " + e.KeyChar;
            if (e.KeyChar.ToString() == label6.Text)
            {
                Main.pressTime = DateTime.Now;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));
                label6.Text = "-";
                RefreshStats();
                RefreshAverage();
            }
        }
        
        //Пятое испытание
        private void button8_Click(object sender, EventArgs e)
        {
            button7.Focus();
            Thread thread = new Thread(new ThreadStart(FifthIsp));//TODO
            thread.Start();
        }

        private void FifthIsp()
        {
            Main.timeStamps.Clear();
            Random rand = new Random();
            for (int i = 1; i <= int.Parse(textBox5.Text); i++)
            {
                Thread.Sleep(rand.Next(2000, 5000));
                int k = rand.Next(0, 3);

                if (k == 0)
                {
                    int lamp = rand.Next(1, 7);
                    switch (lamp)
                    {
                        case 1:
                            panel14.BackColor = Color.Red;
                            break;
                        case 2:
                            panel15.BackColor = Color.Red;
                            break;
                        case 3:
                            panel16.BackColor = Color.Red;
                            break;
                        case 4:
                            panel17.BackColor = Color.Red;
                            break;
                        case 5:
                            panel18.BackColor = Color.Red;
                            break;
                        case 6:
                            panel19.BackColor = Color.Red;
                            break;
                    }
                    Main.startTime = DateTime.Now;
                    Thread.Sleep(1000);
                }

                else if(k == 1)
                {
                    WriteTextSafe(rand.Next(0, 10).ToString(), label8);

                    Main.startTime = DateTime.Now;
                    Thread.Sleep(1000);
                }

                else
                {
                    int lNum = rand.Next(0, 10);
                    int rNum = rand.Next(0, 10);

                    int bebs = rand.Next(0, 3);
                    switch(bebs)
                    {
                        case 0:
                            Main.solve = lNum + rNum;
                            Main.genSolve = rand.Next(Main.solve - 2, Main.solve + 2);
                            WriteTextSafe(string.Format("{0} + {1} = {2}", lNum, rNum, Main.genSolve), label11);
                            break;
                        case 1:
                            Main.solve = lNum - rNum;
                            Main.genSolve = rand.Next(Main.solve - 2, Main.solve + 2);
                            WriteTextSafe(string.Format("{0} - {1} = {2}", lNum, rNum, Main.genSolve), label11);
                            break;
                        case 3:
                            Main.solve = lNum * rNum;
                            Main.genSolve = rand.Next(Main.solve - 2, Main.solve + 2);
                            WriteTextSafe(string.Format("{0} * {1} = {2}", lNum, rNum, Main.genSolve), label11);
                            break;
                    }

                    Main.startTime = DateTime.Now;
                    Thread.Sleep(2500);
                }

            }
        }

        //Обработка панелей последнего испытания
        #region
        private void panel14_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel14.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel14.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }

        private void panel15_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel15.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel15.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }

        private void panel16_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel16.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel16.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }

        private void panel17_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel17.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel17.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }

        private void panel18_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel18.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel18.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }

        private void panel19_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel19.BackColor == Color.Red)
            {
                Main.pressTime = DateTime.Now;
                panel19.BackColor = Color.Silver;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));

                RefreshStats();
                RefreshAverage();
            }
        }
        #endregion

        private void button7_KeyPress(object sender, KeyPressEventArgs e)
        {
            label3.Text = "Нажата клавиша: " + e.KeyChar;
            if (e.KeyChar.ToString() == label8.Text)
            {
                Main.pressTime = DateTime.Now;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));
                label8.Text = "-";
                RefreshStats();
                RefreshAverage();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Main.solve == Main.genSolve)
            {
                Main.pressTime = DateTime.Now;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));
                label11.Text = "-";
                RefreshStats();
                RefreshAverage();
            }

            button7.Focus();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (Main.solve != Main.genSolve)
            {
                Main.pressTime = DateTime.Now;

                Main.timeStamps.Add(new TimeStamp(Main.pressTime.Subtract(Main.startTime).TotalMilliseconds));
                label11.Text = "-";
                RefreshStats();
                RefreshAverage();
            }

            button7.Focus();
        }
    }
}
