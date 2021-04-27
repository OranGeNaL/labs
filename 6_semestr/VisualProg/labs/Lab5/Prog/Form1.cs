using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog
{
    public partial class Form1 : Form
    {

        public static string OriginText { get; set; }
        public static int[] Key = new int[] { 5, 4, 3, 7, 1, 2, 6, 0};

        public Form1()
        {
            InitializeComponent();
            OriginText = textBox1.Text;
        }

        private void encriptButton_Click(object sender, EventArgs e)
        {
            string res = EncryptText(OriginText, Key);

            textBox2.Text = res;

            Clipboard.SetText(res);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OriginText = textBox1.Text;
        }

        public static string EncryptText(string src, int[] key)
        {
            string fixedSrc = NormalizeText(src, key.Length);
            string result = "";

            List<string> matrix = new List<string>();
            for(int i = 0; i < fixedSrc.Length / key.Length; i++)
            {
                matrix.Add("");
                for(int j = 0; j < key.Length; j++)
                {
                    matrix[i] += fixedSrc[i * key.Length + j];
                }
                //result += matrix[i] + "\n";
            }

            foreach (var i in matrix)
            {
                string block = i;
                string resBlock = "";
                for(int j = 0; j < key.Length; j++)
                {
                    resBlock += block[key[j]];
                }
                result += resBlock;
            }

            return result;
        }

        public static string DecryptText(string src, int[] key)
        {
            string fixedSrc = src;
            string result = "";

            List<string> matrix = new List<string>();
            for (int i = 0; i < fixedSrc.Length / key.Length; i++)
            {
                matrix.Add("");
                for (int j = 0; j < key.Length; j++)
                {
                    matrix[i] += fixedSrc[i * key.Length + j];
                }
                //result += matrix[i] + "\n";
            }

            foreach (var i in matrix)
            {
                string block = i;
                string resBlock = "";
                char[] resMatr = new char[key.Length];

                for (int j = 0; j < key.Length; j++)
                {
                    resMatr[key[j]] = block[j];
                }

                for (int j = 0; j < key.Length; j++)
                {
                    resBlock += resMatr[j];
                }

                result += resBlock;
            }

            return result;
        }

        public static string NormalizeText(string src, int length)
        {
            int n = length - src.Length % length;

            for (int i = 0; i < n; i++)
                src += "_";

            return src;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void decriptButton_Click(object sender, EventArgs e)
        {
            string res = DecryptText(OriginText, Key);

            textBox2.Text = res;
            Clipboard.SetText(res);
        }
    }
}
