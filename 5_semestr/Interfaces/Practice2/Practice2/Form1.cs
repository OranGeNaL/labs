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
    }
}
