using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice3
{
    public static class SafeWriter
    {
        private delegate void SafeTextWriteDelegate(string text, Label label);
        private delegate void SafeControlTextWriteDelegate(string text, Control control);
        private delegate void SafeChangeLocationDelegate(Point location, Control control);
        private delegate void SafeTimerStartDelegate(Timer timer, Control control);

        public static void WriteTextSafe(string text, Label label)
        {
            if (label.InvokeRequired)
            {
                var d = new SafeTextWriteDelegate(WriteTextSafe);
                label.Invoke(d, new object[] { text, label });
            }
            else
            {
                label.Text = text;
            }
        }

        public static void TimerStartSafe(Timer timer, Control control)
        {
            if (control.InvokeRequired)
            {
                var d = new SafeTimerStartDelegate(TimerStartSafe);
                control.Invoke(d, new object[] { timer, control });
            }
            else
            {
                timer.Start();
            }
        }

        public static void WriteControlTextSafe(string text, Control control)
        {
            if (control.InvokeRequired)
            {
                var d = new SafeControlTextWriteDelegate(WriteControlTextSafe);
                control.Invoke(d, new object[] { text, control });
            }
            else
            {
                control.Text = text;
            }
        }

        public static void WriteLocationSafe(Point location, Control control)
        {
            if (control.InvokeRequired)
            {
                var d = new SafeChangeLocationDelegate(WriteLocationSafe);
                control.Invoke(d, new object[] { location, control });
            }
            else
            {
                control.Location = location;
            }
        }
    }
}
