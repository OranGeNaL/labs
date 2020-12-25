using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice4
{
    public partial class Form1 : Form
    {
        List<CustomPanel> panels = new List<CustomPanel>();
        List<double> times = new List<double>();

        Color[] colors = new Color[4]
        {
            Color.White,
            Color.Black,
            Color.Green,
            Color.Red
        };


        int PanelsNum = 2;
        int MaxPanelsNum = 9;

        Random random = new Random();

        DateTime startTime;
        DateTime clickTime;

        int tryNum = 0;
        int maxTryNum = 5;

        bool isGoing = false;
        bool clicked = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < MaxPanelsNum; i++)
            {
                panels.Add(new CustomPanel(this, new Size(90, 30), i, label1_Click)) ;
            }

            ShowNPanels(panels, PanelsNum);
            MixContent(panels, PanelsNum);
        }


        private void ShowNPanels(List<CustomPanel> panels, int n)
        {
            foreach (var i in panels.GetRange(n, panels.Count - n))
                i.panel.Visible = false;
            foreach (var i in panels.GetRange(0, n))
                i.panel.Visible = true;
        }

        private void NumByOrder(List<CustomPanel> panels)
        {
            for (int i = 0; i < panels.Count; i++)
                panels[i].SetText((i + 1).ToString());
        }

        private void MixContent(List<CustomPanel> panels, int n)
        {
            List<int> values = new List<int>();

            for (int i = 1; i <= n; i++)
                values.Add(i);

            for(int i = 0; i < n; i++)
            {
                int value = random.Next(0, values.Count);
                panels[i].SetText(values[value].ToString());
                values.RemoveAt(value);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ///////////////////////////Обработка события нажатия на панель

            Label panelSender = (Label)sender;

            //panelSender.Text = "clicked";

            if (radioButton1.Checked)
            {
                if (isGoing)
                {
                    if (panelSender.Text == label1.Text)
                    {
                        clickTime = DateTime.Now;
                        clicked = true;
                        label2.Text = "YEP";
                        label2.ForeColor = Color.Green;
                        times.Add(clickTime.Subtract(startTime).TotalMilliseconds);
                    }
                }
                //label1.Text = GetRandomValue().ToString();
            }

            if (radioButton2.Checked)
            {
                if (isGoing)
                {
                    if (panelSender.ForeColor == colors[tryNum])
                    {
                        clickTime = DateTime.Now;
                        clicked = true;
                        label2.Text = "YEP";
                        label2.ForeColor = Color.Green;
                        times.Add(clickTime.Subtract(startTime).TotalMilliseconds);
                    }
                }
                //label1.Text = GetRandomValue().ToString();
            }
        }

        private int GetRandomValue()
        {
            return random.Next(1, PanelsNum + 1);
        }

        private void SetTarget(List<CustomPanel> panels, int n, int targetNum)
        {
            foreach (var i in panels)
                i.SetDefault();

            int target = random.Next(0, n);

            panels[target].label.Font = new Font("Times", 18, FontStyle.Underline);
            panels[target].label.ForeColor = colors[targetNum];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            isGoing = true;

            button3.Enabled = true;
            button2.Enabled = false;

            radioButton1.Enabled = false;
            radioButton2.Enabled = false;

            if (radioButton1.Checked)
            {
                PanelsNum = 2;
                label1.Text = GetRandomValue().ToString();
            }

            if (radioButton2.Checked)
            {
                PanelsNum = 2;
                NumByOrder(panels);
                ShowNPanels(panels, PanelsNum);

                SetTarget(panels, PanelsNum, tryNum);
            }

            times.Clear();

            startTime = DateTime.Now;
            MoveCursorTo(new Point(200, (PanelsNum * 50 + 50) / 2 + 50));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked && isGoing && clicked)
            {
                clicked = false;
                tryNum++;
                if (tryNum == maxTryNum)
                {
                    tryNum = 0;
                    WriteToFile(times, "Панелей: " + PanelsNum.ToString());
                    times.Clear();
                    PanelsNum++;
                    if (PanelsNum > MaxPanelsNum)
                    {
                        isGoing = false;
                        button2.Enabled = true;
                        button3.Enabled = false;

                        radioButton1.Enabled = true;
                        radioButton2.Enabled = true;
                    }
                }
                if(isGoing)
                {
                    label2.Text = "-";
                    label2.ForeColor = Color.Black;

                    ShowNPanels(panels, PanelsNum);
                    MixContent(panels, PanelsNum);
                    startTime = DateTime.Now;
                    label1.Text = GetRandomValue().ToString();
                    MoveCursorTo(new Point(200, (PanelsNum * 50 + 50) / 2 + 50));
                }
            }

            if (radioButton2.Checked && isGoing && clicked)
            {
                clicked = false;
                tryNum++;
                if (tryNum == maxTryNum - 1)
                {
                    tryNum = 0;
                    PanelsNum++;
                    //times.Add(PanelsNum.ToString());
                    WriteToFile(times, "Панелей: " + PanelsNum.ToString());
                    times.Clear();
                    if (PanelsNum > MaxPanelsNum)
                    {
                        isGoing = false;
                        button2.Enabled = true;
                        button3.Enabled = false;

                        radioButton1.Enabled = true;
                        radioButton2.Enabled = true;
                    }
                }
                if (isGoing)
                {
                    label2.Text = "-";
                    label2.ForeColor = Color.Black;

                    ShowNPanels(panels, PanelsNum);
                    SetTarget(panels, PanelsNum, tryNum);
                    startTime = DateTime.Now;
                    //label1.Text = GetRandomValue().ToString();
                    MoveCursorTo(new Point(200, (PanelsNum * 50 + 50) / 2 + 50));
                }
            }
            //label2.Text = times.Last<double>().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isGoing = false;
            button2.Enabled = true;
            button3.Enabled = false;

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            tryNum = 0;
            PanelsNum = 2;
            label1.Text = "-";
        }

        public void MoveCursorTo(Point point)
        {
            point.X += this.Location.X;
            point.Y += this.Location.Y;
            Cursor.Position = point;
        }

        public void WriteToFile(List<double> list, string message)
        {
            StreamWriter streamWriter = new StreamWriter("log.txt", true);
            string text = message + "\n";
            double sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                text += Math.Round((list[i] / 1000), 3).ToString() + "\n";
                sum += list[i];
            }
            text += "Среднее время: " + Math.Round(sum / list.Count / 1000, 3) + "\n";
            text += "---------------------------------------";
            streamWriter.WriteLine(text);
            streamWriter.Close();
        }
    }
}
