using System;
using System.Threading;

namespace NJordanGauss
{
    public class Coefficient
    {
        public double Divident { get; set; }
        public double Divider { get; set; } = 1;

        public Coefficient(double number)
        {
            Divident = number;
        }
        public Coefficient(double _divident, double _divider)
        {
            Divident = _divident;
            Divider = _divider;
        }

        public double GetDouble()
        {
            return Divident / Divider;
        }

        #region operators

        public static Coefficient operator -(Coefficient a, Coefficient b)
        {
            Coefficient result = new Coefficient(1);

            if (a.Divider % b.Divider != 0 && b.Divider % a.Divider != 0)
            {
                double prevAD = a.Divider;
                
                a.Divident *= b.Divider;
                a.Divider *= b.Divider;

                b.Divident *= prevAD;
                b.Divider *= prevAD;

                result = new Coefficient(a.Divident - b.Divident, a.Divider);
            }
            
            else if (a.Divider % b.Divider == 0)
            {
                var coeff = a.Divider / b.Divider;
                
                b.Divident *= coeff;
                b.Divider *= coeff;

                result = new Coefficient(a.Divident - b.Divident, a.Divider);
            }
            
            else if (b.Divider % a.Divider == 0)
            {
                var coeff = b.Divider / a.Divider;
                
                a.Divident *= coeff;
                a.Divider *= coeff;

                result = new Coefficient(a.Divident - b.Divident, a.Divider);
            }
            
            return result;
        }
        
        public static Coefficient operator +(Coefficient a, Coefficient b)
        {
            Coefficient result = new Coefficient(1);

            if (a.Divider % b.Divider != 0 && b.Divider % a.Divider != 0)
            {
                double prevAD = a.Divider;
                
                a.Divident *= b.Divider;
                a.Divider *= b.Divider;

                b.Divident *= prevAD;
                b.Divider *= prevAD;
                
                result = new Coefficient(a.Divident + b.Divident, a.Divider);
            }
            
            else if (a.Divider % b.Divider == 0)
            {
                var coeff = a.Divider / b.Divider;
                
                b.Divident *= coeff;
                b.Divider *= coeff;

                result = new Coefficient(a.Divident + b.Divident, a.Divider);
            }
            
            else if (b.Divider % a.Divider == 0)
            {
                var coeff = b.Divider / a.Divider;
                
                a.Divident *= coeff;
                a.Divider *= coeff;

                result = new Coefficient(a.Divident + b.Divident, a.Divider);
            }
            
            return result;
        }

        public static Coefficient operator *(Coefficient a, Coefficient b)
        {
            Coefficient result = new Coefficient(a.Divident * b.Divident, a.Divider * b.Divider);

            return result;
        }

        public static Coefficient operator *(Coefficient a, double b)
        {
            Coefficient result = new Coefficient(a.Divident * b, a.Divider);

            return result;
        }

        public static Coefficient operator /(Coefficient a, Coefficient b)
        {
            Coefficient result = new Coefficient(a.Divident * b.Divider, a.Divider * b.Divident);

            return result;
        }
        
        public static Coefficient operator /(Coefficient a, double b)
        {
            Coefficient result = new Coefficient(a.Divident, a.Divider * b);

            return result;
        }

        #endregion
        
        public override string ToString()
        {
            MakeEasier();
            
            if (Divider < 0 && Divident >= 0)
            {
                Divider *= -1;
                Divident *= -1;
            }

            if (Divident < 0 && Divider < 0)
            {
                Divider *= -1;
                Divident *= -1;
            }
            
            if (Divident % Divider == 0)
            {
                return String.Format("{0}", Divident / Divider);
            }

            if (Divident == 0)
            {
                return "0";
            }
            
            return String.Format("{0}/{1}", Divident, Divider);
        }
        
        private void MakeEasier()
        {
            double divident = Math.Abs(Divident);
            double divider = Math.Abs(Divider);

            double NOD = 0;
            
            for (int i = 1; i < 50; i++)
            {
                if (divident % i == 0 && divider % i == 0)
                {
                    NOD = i;
                }
            }

            if (NOD == 0)
            {
                return;
            }
            else
            {
                Divident /= NOD;
                Divider /= NOD;
            }
        }
    }
}