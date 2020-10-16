using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    public static class Main
    {

        public static List<TimeStamp> timeStamps = new List<TimeStamp>();


        public static bool waiting = false;
        public static int solve = 0;
        public static int genSolve = -200;
        public static DateTime startTime = DateTime.Now;
        public static DateTime pressTime = DateTime.Now;

    }
}