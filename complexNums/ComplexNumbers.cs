using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace complexNums
{
    class ComplexNumbers
    {
        double re;
        double im;
        static double precision;
        double r; // модуль компл. числа
        public double R
        {
            get => r;
            set
            {
                r = value;
            }
        }
        public static double Precision
        {
            get => precision;
            set
            {
                precision = Math.Pow(10, value);
            }
        }
        public double Re
        {
            get => re;
            set
            {  
                re = value;
            }
        }
        public double Im { get; set; }
        public ComplexNumbers(double re, double im)
        {
            Re = re;
            Im = im;
            R = Math.Sqrt(Re * Re + Im * Im);
        }

        public static ComplexNumbers operator +(ComplexNumbers c1, ComplexNumbers c2)
        {
            return new ComplexNumbers(c1.Re + c2.Re, c1.Im + c2.Im);
        }
        public ComplexNumbers CalcSin()
        {
            int n = 1;
            ComplexNumbers res = this;
            ComplexNumbers curr = this;
           
            while (res.R > Precision && n < 10)
            {
                res += (Math.Pow(-1, n) * (this ^ (2 * n + 1))) / factorial(2 * n + 1);
                n++;
            }
            return res;
        }
        private long factorial(int num)
        {
            if (num < 0) throw new Exception();
            long fact = (long)num;
            for (int i = num - 1; i >= 1; i--)
            {   
                fact *= i;
            }
            return fact;
        }

        public static ComplexNumbers operator ^(ComplexNumbers c, int deg)
        {
            if (deg == 0) return new ComplexNumbers(1, 0);
            else if (deg == 1) return c;
            else return c * (c ^ (deg - 1));
        }
        public static ComplexNumbers operator *(ComplexNumbers c1, ComplexNumbers c2)
        {
            return new ComplexNumbers(c1.Re * c2.Re - c1.Im * c2.Im, c1.Re * c2.Im + c1.Im * c2.Re);
        }
        public static ComplexNumbers operator /(ComplexNumbers c, long k)
        {
            return new ComplexNumbers(c.Re / k, c.Im / k);
        }
        public static ComplexNumbers operator *(double k, ComplexNumbers c)
        {
            return new ComplexNumbers(c.Re * k, c.Im * k);
        }
        public String toString(int numOfDigits)
        {
            string s = "";
            string reStr = Math.Round(Re, numOfDigits).ToString();
            string imStr = Math.Round(Im, numOfDigits).ToString();
          
            if (Im == 0) s += reStr;
            else if (Re == 0) s += imStr+"• i";
            else s += reStr + " + " + imStr+" • i"; 
            return s;
        }
    }
}
