using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafBuilder
{
    public class Line
    {
        public Dot dot1;
        public Dot dot2;
        public int line_ind;

        public Line(Dot first_dot, Dot second_dot, int ind)
        {
            dot1 = first_dot;
            dot2 = second_dot;
            line_ind = ind;
        }
    }
}
