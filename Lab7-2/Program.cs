using System;

namespace Lab7_2
{
    class Rational
    {
        private int m; //числитель
        private int n; //знаменатель
        public Rational(int a, int b)
        {
            if (b == 0) { m = 0; n = 1; }
            else
            {
                //приведение знака
                if (b < 0) { b = -b; a = -a; }
                //приведение к несократимой дроби
                int d = nod(a, b);
                m = a / d; n = b / d;
            }
        }
        private int nod(int m, int n)
        {
            int p = 0;
            m = Math.Abs(m); n = Math.Abs(n);
            if (n > m) { p = m; m = n; n = p; }
            do
            {
                p = m % n; m = n; n = p;
            } while (n != 0);
            return (m);
        }

        public void PrintRational(string name)
        {
            Console.WriteLine(" {0} = {1}/{2}", name, m, n);
        }

        public override string ToString()
        {
            if (m == 0 || n == 0) return $"0";
            return $"{m}/{n}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rational r1 = new Rational(0, 0), r2 = new Rational(1, 1);
            Rational r3 = new Rational(10, 8), r4 = new Rational(2, 6);
            Rational r5 = new Rational(4, -12), r6 = new Rational(-12, -14);
            r1.PrintRational("r1:(0,0)");
            r2.PrintRational("r2:(1,1)");
            r3.PrintRational("r3:(10,8)");
            r4.PrintRational("r4:(2,6)");
            r5.PrintRational("r5: (4,-12)");
            r6.PrintRational("r6: (-12,-14)");
        }
    }
}
