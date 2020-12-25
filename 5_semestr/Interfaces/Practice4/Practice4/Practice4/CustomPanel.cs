using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Practice4
{
    class CustomPanel
    {
        Control form;
        public Panel panel = new Panel();
        public Label label = new Label();

        public Size size;
        public int num;

        public delegate void Click(object sender, EventArgs e);

        public CustomPanel() { }
        public CustomPanel(Control _form, Size _size, int _num, Click click)
        {
            form = _form;
            size = _size;
            num = _num;
            label.Click += new EventHandler(click);

            Initialize();
        }

        private void Initialize()
        {
            label.AutoSize = false;
            label.Text = "empty";
            label.Size = size;
            label.ForeColor = Color.Blue;
            label.Font = new Font("Times", 12, FontStyle.Underline);
            label.TextAlign = ContentAlignment.MiddleCenter;
            panel.Controls.Add(label);


            panel.Size = size;
            panel.BackColor = Color.Yellow;
            panel.Location = new Point(50, 50 + 50 * num);


            form.Controls.Add(panel);
        }

        public void SetText(string text)
        {
            label.Text = text;
        }
    }
}
