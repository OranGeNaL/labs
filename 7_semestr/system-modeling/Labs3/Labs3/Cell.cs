using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs3
{
    class Cell
    {
        public int i { get; set; }

        public int j { get; set; }
        public int value { get; set; }
        public Color color { get; set; }

        public Cell(int i, int j, int value, Color color)
        {
            this.i = i;
            this.j = j;
            this.value = value;
            this.color = color;
        }
    }
}
