using System;
using System.Collections.Generic;
using System.Text;

namespace Examen
{
    class Complex
    {
        public double a;
        public double b;

        public Complex() { }
        public Complex(double _a, double _b)
        {
            a = _a;
            b = _b;
        }

        public static Complex operator *(Complex first, double d)
        {
            Complex second = new Complex(d, 0);
            return new Complex(first.a * second.a - first.b * second.b, first.b * second.a + first.a * second.b);
        }

        public static Complex operator *(double d, Complex first)
        {
            Complex second = new Complex(d, 0);
            return new Complex(first.a * second.a - first.b * second.b, first.b * second.a + first.a * second.b);
        }

        public static Complex operator /(Complex first, double d)
        {
            Complex second = new Complex(d, 0);

            double a = (first.a * second.a + first.b * second.b) / (second.a * second.a + second.b * second.b);
            double b = (first.b * second.a - first.a * second.b) / (second.a * second.a + second.b * second.b);

            return new Complex(a, b);
        }

        public static Complex operator /(double d, Complex second)
        {
            Complex first = new Complex(d, 0);

            double a = (first.a * second.a + first.b * second.b) / (second.a * second.a + second.b * second.b);
            double b = (first.b * second.a - first.a * second.b) / (second.a * second.a + second.b * second.b);

            return new Complex(a, b);
        }

        public override string ToString()
        {
            if (b >= 0)
                return string.Format("{0} + {1}i", a, b);
            else
                return string.Format("{0} {1}i", a, b);
        }
    }
}
