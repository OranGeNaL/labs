using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafBuilder
{
    public class Dot
    {
        public Dot(int x, int y, int n)
        {
            DotX = x;
            DotY = y;
            DotInd = n;
        }

        public string ShowCoords()
        {
            return DotX.ToString() + DotY.ToString();
        }

        private int dotInd;
        public int DotInd
        {
            get { return dotInd; }
            set { dotInd = value; }
        }

        private int dotX;
        public int DotX
        {
            get { return dotX; }

            set { dotX = value; }
        }

        private int dotY;
        public int DotY
        {
            get { return dotY; }
            set { dotY = value; }
        }
    }
}
