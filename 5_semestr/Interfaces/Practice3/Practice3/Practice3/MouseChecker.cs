using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice3
{
    class MouseChecker
    {
        Control resulter;
        Cursor cursor;
        
        public MouseChecker() { }
        public MouseChecker(Control _control, Cursor _cursor)
        {
            resulter = _control;
            cursor = _cursor;
        }

        public void StartTracking()
        {
            //SafeWriter.WriteControlTextSafe(string.Format("X:{0}\nY:{1}", cursor.Position));
        }
    }
}
