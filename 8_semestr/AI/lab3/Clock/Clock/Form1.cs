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

namespace Clock
{
    public partial class Form1 : Form
    {
        List<char[,]> basedNumbers = new List<char[,]>();
        List<char[,]> readedNumbers = new List<char[,]>();

        List<double[]> basedVectors = new List<double[]>();

        int[] layers = new int[] { 48, 24, 12, 10 };
        double learningRate = 0.01;

        NeuralNetwork NN;

        Random r = new Random();


        public Form1()
        {
            InitializeComponent();
            NN = new NeuralNetwork(learningRate, x => 1 / (1 + Math.Exp(-x)), y => y * (1 - y), layers);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string baseFilePath = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    baseFilePath = openFileDialog.FileName;
                    textBox1.Text = baseFilePath;

                    using (StreamReader sr = new StreamReader(baseFilePath))
                    {
                        InitializeBasedNumbers(sr);

                        basedVectors = BasedToBased(basedNumbers);
                        LearnNN();
                    }

                    GetAnswer(basedVectors[8]);
                    MessageBox.Show("OK");

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string readingFilePath = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    readingFilePath = openFileDialog.FileName;
                    textBox2.Text = readingFilePath;

                    using (StreamReader sr = new StreamReader(readingFilePath))
                    {
                        ReadNumbers(sr);
                    }

                    string stringRepresentation = "";

                    for(int i = 0; i < 8; i++)
                    {
                        foreach(var j in readedNumbers)
                        {
                            for(int k = 0; k < 6; k++)
                            {
                                stringRepresentation += j[i, k];
                            }
                        }

                        stringRepresentation += "\n";
                    }

                    

                    MessageBox.Show("OK");
                }
            }
        }

        private void InitializeBasedNumbers(StreamReader fileStream)
        {
            basedNumbers.Clear();
            for(int i = 0; i <= 9; i++)
            {
                basedNumbers.Add(new char[8, 6]);

                for (int j = 0; j < 8; j++)
                {
                    string line = fileStream.ReadLine();
                    for(int k = 0; k < 6; k++)
                    {
                        basedNumbers[i][j, k] = line[k];
                    }
                }
            }
        }

        private void ReadNumbers(StreamReader fileStream)
        {
            readedNumbers.Clear();
            for (int i = 0; i <= 3; i++)
            {
                readedNumbers.Add(new char[8, 6]);

                for (int j = 0; j < 8; j++)
                {
                    string line = fileStream.ReadLine();
                    for (int k = 0; k < 6; k++)
                    {
                        readedNumbers[i][j, k] = line[k];
                    }
                }
            }
        }

        private int CompareNumbers(char[,] comparing, char[,] based)
        {
            int weigth = 0;
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    if (comparing[i, j] == based[i, j])
                        weigth++;
                }
            }
            return weigth;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            string resultStr = "";


            var basedReadedNumbers = BasedToBased(readedNumbers);

            foreach (var i in basedReadedNumbers)
            {
                resultStr += GetAnswer(i).ToString();
            }

            string hours = string.Format("{0}{1}", resultStr[0], resultStr[1]);
            string minutes = string.Format("{0}{1}", resultStr[2], resultStr[3]);

            if (int.Parse(hours) >= 0 && int.Parse(hours) <= 23 && int.Parse(minutes) >= 0 && int.Parse(minutes) <= 59)
            {
                MessageBox.Show(string.Format("Текущее время: {0}:{1}", hours, minutes));
            }
            else
            {
                MessageBox.Show("Часы показывают неверное время!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private List<double[]> BasedToBased(List<char[,]> chars)
        {
            List<double[]> result = new List<double[]>();

            for (int i = 0; i < chars.Count; i++)
            {
                result.Add(new double[48]);
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        result[i][j * 6 + k] = chars[i][j, k] == '*' ? 1 : 0;
                    }
                }
            }

            return result;
        }

        private void LearnNN()
        {
            for (int k = 0; k < 50000; k++)
            {
                int index = r.Next(0, 10);
                double[] vs = basedVectors[index];

                NN.feedForward(vs);
                double[] targets = new double[10];

                targets[index] = 1;

                NN.backpropagation(targets);
            }
        }

        private int GetAnswer(double[] source)
        {
            NN.feedForward(source);

            string finalLayer = "";

            int maxInd = 0;

            for (int i = 0; i < 10; i++)
            {
                finalLayer += string.Format("{0}: {1}\n", i + 1, NN.layers[3].neurons[i]);

                if(NN.layers[3].neurons[i] > NN.layers[3].neurons[maxInd])
                    maxInd = i;
            }

            label1.Text = finalLayer;

            return maxInd;
        }
    }
}
