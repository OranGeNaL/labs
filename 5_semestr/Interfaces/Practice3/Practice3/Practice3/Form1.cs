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

namespace Practice3
{
    public partial class Form1 : Form
    {
        public int ticks = 0;
        public bool mouseMoved = false;
        public bool waitForMove = true;

        public int[] sizes = { 5, 10, 20, 40, 70, 100 };
        public int sizesCount = 0;
        public int[] spaces = { 0, 50, 100, 150, 200, 300};
        public int spacesCount = 0;

        public bool firstIsGoing;
        public int firstCounter = 0;
        public List<float> firstResults = new List<float>();

        public int tabsX = 13;
        public int tabsY = 55;

        Thread task1;

        delegate void TimerHandler(System.Windows.Forms.Timer timer);
        event TimerHandler StartTimer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Focus();
            StartTimer += OnTimerStart;
        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Space")
            {
                firstCounter = 0;
                firstResults.Clear();
                firstIsGoing = true;
                task1 = new Thread(new ThreadStart(StartTracking));
                task1.Start();
                if (!checkBox1.Checked)
                {
                    button1.Size = new Size(int.Parse(textBox3.Text), int.Parse(textBox3.Text));
                    MoveCursorTo(new Point(tabsX + tabControl1.Location.X + button1.Location.X + button1.Size.Width + int.Parse(textBox1.Text), tabsY + tabControl1.Location.Y + button1.Location.Y));
                }
                else
                {
                    firstIsGoing = true;
                    sizesCount = 0;
                    spacesCount = 0;
                    button1.Size = new Size(sizes[sizesCount], sizes[sizesCount]);
                    MoveCursorTo(new Point(tabsX + tabControl1.Location.X + button1.Location.X + button1.Size.Width + spaces[spacesCount], tabsY + tabControl1.Location.Y + button1.Location.Y));
                }
            }
        }

        private void tabPage1_MouseMove(object sender, MouseEventArgs e)
        {
            /*if(firstIsGoing)
                timer1.Start();*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks += 1;
            label4.Text = ticks.ToString();
            if(secondIsGoing)
            {
                if (ticks >= 15)
                {
                    secondMistakes++;
                    ticks = 0;
                    MoveCursorTo(new Point(tabsX + tabControl1.Location.X + button4.Location.X + button4.Size.Width + int.Parse(textBox5.Text), tabsY + tabControl1.Location.Y + button4.Location.Y));
                    label10.Text = "Ошибок: " + secondMistakes;
                }
            }
            //SafeWriter.WriteTextSafe(ticks.ToString(), label4);
        }

        public void StartTracking()
        {
            Point prevPosition = Cursor.Position;
            //this.Cursor = new Cursor(Cursor.Current.Handle);
            while (waitForMove)
            {
                if (Cursor.Position != prevPosition)
                {
                    mouseMoved = true;
                    prevPosition = Cursor.Position;
                    waitForMove = false;
                    StartTimer(timer1);
                }
                else
                {
                    mouseMoved = false;
                }
                Thread.Sleep(1);
            }
            
        }

        public void MoveCursorTo(Point point)
        {
            point.X += this.Location.X;
            point.Y += this.Location.Y;
            Cursor.Position = point;
        }

        public void OnTimerStart(System.Windows.Forms.Timer timer)
        {
            SafeWriter.TimerStartSafe(timer, tabControl1);
            //MessageBox.Show("");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            task1?.Abort();
        }

        //Обработка первого опыта
        #region

        private void button1_Click(object sender, EventArgs e)
        {
            if (firstIsGoing && checkBox1.Checked && sizesCount < sizes.Length)
            {
                firstResults.Add(ticks / 10f);
                ticks = 0;
                timer1.Stop();
                waitForMove = true;
                spacesCount++;
                if (spacesCount == spaces.Length)
                {
                    spacesCount = 0;
                    sizesCount++;
                }
                if (sizesCount < sizes.Length)
                {
                    button1.Size = new Size(sizes[sizesCount], sizes[sizesCount]);
                    MoveCursorTo(new Point(tabsX + tabControl1.Location.X + button1.Location.X + button1.Size.Width + spaces[spacesCount], tabsY + tabControl1.Location.Y + button1.Location.Y));
                    label5.Text = "";
                    for (int i = 1; i <= firstResults.Count; i++)
                    {
                        label5.Text += i / spaces.Length + 1 + ". " + firstResults[i - 1] + " ";
                        if (i % spaces.Length == 0)
                            label5.Text += "\n";
                    }
                    task1.Abort();
                    task1 = new Thread(new ThreadStart(StartTracking));
                    task1.Start();
                }
                else
                {
                    task1.Abort();
                    firstIsGoing = false;
                }
            }
            else if (firstIsGoing && firstCounter < int.Parse(textBox2.Text))
            {
                firstResults.Add(ticks / 10f);
                firstCounter++;
                ticks = 0;
                timer1.Stop();
                waitForMove = true;

                MoveCursorTo(new Point(tabsX + tabControl1.Location.X + button1.Location.X + button1.Size.Width + int.Parse(textBox1.Text), tabsY + tabControl1.Location.Y + button1.Location.Y));
                label5.Text = "";
                for (int i = 1; i <= firstResults.Count; i++)
                    label5.Text += i + ". " + firstResults[i - 1] + "\n";

                if (int.Parse(textBox2.Text) - firstCounter != 0)
                {
                    task1.Abort();
                    task1 = new Thread(new ThreadStart(StartTracking));
                    task1.Start();
                }
            }
            else
            {
                firstIsGoing = false;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            if(firstIsGoing && firstCounter < int.Parse(textBox2.Text))
            {
                MoveCursorTo(new Point(tabsX + tabControl1.Location.X + button1.Location.X + button1.Size.Width + int.Parse(textBox1.Text), tabsY + tabControl1.Location.Y + button1.Location.Y));
            }
        }
        #endregion

        //Обработка второго опыта
        #region

        public bool secondIsGoing = false;

        public int secondCounter = 0;
        public int secondMistakes = 0;
        public List<float> secondResults = new List<float>();



        private void button3_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Space")
            {
                secondCounter = 0;
                firstResults.Clear();
                secondIsGoing = true;
                task1 = new Thread(new ThreadStart(StartTracking));
                task1.Start();

                sizesCount = 0;
                spacesCount = 0;
                button4.Size = new Size(int.Parse(textBox6.Text), int.Parse(textBox6.Text));
                MoveCursorTo(new Point(tabsX + tabControl1.Location.X + button4.Location.X + button4.Size.Width + int.Parse(textBox5.Text), tabsY + tabControl1.Location.Y + button4.Location.Y));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (secondIsGoing && secondCounter < int.Parse(textBox4.Text))
            {
                secondResults.Add(ticks / 10f);
                secondCounter++;
                ticks = 0;
                timer1.Stop();
                waitForMove = true;

                MoveCursorTo(new Point(tabsX + tabControl1.Location.X + button4.Location.X + button4.Size.Width + int.Parse(textBox5.Text), tabsY + tabControl1.Location.Y + button4.Location.Y));
                label1.Text = "";
                for (int i = 1; i <= secondResults.Count; i++)
                    label1.Text += i + ". " + secondResults[i - 1] + "\n";

                label10.Text = "Ошибок: " + secondMistakes;

                if (int.Parse(textBox4.Text) - secondCounter != 0)
                {
                    task1.Abort();
                    task1 = new Thread(new ThreadStart(StartTracking));
                    task1.Start();
                }
            }
            else
                secondIsGoing = false;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            if (secondIsGoing && secondCounter < int.Parse(textBox4.Text))
            {
                secondMistakes++;
                label10.Text = "Ошибок: " + secondMistakes;
                MoveCursorTo(new Point(tabsX + tabControl1.Location.X + button4.Location.X + button4.Size.Width + int.Parse(textBox5.Text), tabsY + tabControl1.Location.Y + button4.Location.Y));
            }
        }
        #endregion

        //Обработка третьего опыта
        #region
        public bool thirdIsGoing = false;

        public int thirdCounter = 0;
        public List<float> thirdResults = new List<float>();

        private void button5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Space")
            {
                thirdCounter = 0;
                thirdResults.Clear();
                thirdIsGoing = true;
                task1 = new Thread(new ThreadStart(StartTracking));
                task1.Start();

                button6.Size = new Size(int.Parse(textBox7.Text), int.Parse(textBox7.Text));
                MoveCursorTo(new Point(tabsX + tabControl1.Location.X + button6.Location.X + button6.Size.Width + int.Parse(textBox9.Text), tabsY + tabControl1.Location.Y + button6.Location.Y));
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (thirdIsGoing && thirdCounter < int.Parse(textBox8.Text))
            {
                thirdResults.Add(ticks / 10f);
                thirdCounter++;
                ticks = 0;
                timer1.Stop();
                waitForMove = true;

                MoveCursorTo(new Point(tabsX + tabControl1.Location.X + button6.Location.X + button6.Size.Width + int.Parse(textBox9.Text), tabsY + tabControl1.Location.Y + button6.Location.Y));
                label14.Text = "";
                for (int i = 1; i <= thirdResults.Count; i++)
                    label14.Text += i + ". " + thirdResults[i - 1] + "\n";

                if (int.Parse(textBox8.Text) - thirdCounter != 0)
                {
                    task1.Abort();
                    task1 = new Thread(new ThreadStart(StartTracking));
                    task1.Start();
                }
            }
            else
                thirdIsGoing = false;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            if (thirdIsGoing && thirdCounter < int.Parse(textBox8.Text))
            {
                MoveCursorTo(new Point(tabsX + tabControl1.Location.X + button6.Location.X + button6.Size.Width + int.Parse(textBox9.Text), tabsY + tabControl1.Location.Y + button6.Location.Y));
            }
        }
        #endregion

        //Смена цветов кнопки
        #region

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(0, 255, 255);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(0, 0, 255);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(255, 0, 255);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(128, 128, 128);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(0, 128, 0);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(0, 255, 0);
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(128, 0, 0);
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(0, 0, 128);
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(128, 128, 0);
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(128, 0, 128);
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(255, 0, 0);
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(192, 192, 192);
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(0, 128, 128);
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(255, 255, 0);
        }
        #endregion

        //Смена цветов фона
        #region
        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            tabPage3.BackColor = Color.FromArgb(0, 255, 255);
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            tabPage3.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            tabPage3.BackColor = Color.FromArgb(0, 0, 255);
        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            tabPage3.BackColor = Color.FromArgb(255, 0, 255);
        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {
            tabPage3.BackColor = Color.FromArgb(128, 128, 128);
        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {
            tabPage3.BackColor = Color.FromArgb(0, 128, 0);
        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {
            tabPage3.BackColor = Color.FromArgb(0, 255, 0);
        }

        private void radioButton24_CheckedChanged(object sender, EventArgs e)
        {
            tabPage3.BackColor = Color.FromArgb(128, 0, 0);
        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {
            tabPage3.BackColor = Color.FromArgb(0, 0, 128);
        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {
            tabPage3.BackColor = Color.FromArgb(128, 128, 0);
        }

        private void radioButton27_CheckedChanged(object sender, EventArgs e)
        {
            tabPage3.BackColor = Color.FromArgb(128, 0, 128);
        }

        private void radioButton28_CheckedChanged(object sender, EventArgs e)
        {
            tabPage3.BackColor = Color.FromArgb(255, 0, 0);
        }

        private void radioButton29_CheckedChanged(object sender, EventArgs e)
        {
            tabPage3.BackColor = Color.FromArgb(192, 192, 192);
        }

        private void radioButton30_CheckedChanged(object sender, EventArgs e)
        {
            tabPage3.BackColor = Color.FromArgb(0, 128, 128);
        }

        private void radioButton31_CheckedChanged(object sender, EventArgs e)
        {
            tabPage3.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void radioButton32_CheckedChanged(object sender, EventArgs e)
        {
            tabPage3.BackColor = Color.FromArgb(255, 255, 0);
        }
        #endregion
    }
}
