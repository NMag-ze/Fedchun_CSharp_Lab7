using System;

namespace Lab7_3
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

        //операции над рациональными числами
        public Rational Plus(Rational a)
        {
            int u, v;
            u = m * a.n + n * a.m; v = n * a.n;
            return (new Rational(u, v));
        }//Plus
        public static Rational operator +(Rational r1, Rational r2)
        {
            return (r1.Plus(r2));
        }

        public Rational Minus(Rational a)
        {
            int u, v;
            u = m * a.n - n * a.m; v = n * a.n;
            return (new Rational(u, v));
        }//Minus
        public static Rational operator -(Rational r1, Rational r2)
        {
            return (r1.Minus(r2));
        }

        public Rational Mult(Rational a)
        {
            int u, v;
            u = m * a.m; v = n * a.n;
            return (new Rational(u, v));
        }//Mult
        public static Rational operator *(Rational r1, Rational r2)
        {
            return (r1.Mult(r2));
        }

        public Rational Divide(Rational a)
        {
            int u, v;
            u = m * a.n; v = n * a.m;
            return (new Rational(u, v));
        }//Divide
        public static Rational operator /(Rational r1, Rational r2)
        {
            return (r1.Divide(r2));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rational r1 = new Rational(1, 2), r2 = new Rational(1, 3);
            Rational r3, r4, r5, r6;
            r3 = r1 - r2; r4 = r1 * r2; r5 = r1 / r2; r6 = r3 + r4 * r5;
            r1.PrintRational("r1: (1,2)"); r2.PrintRational("r2: (1,3)");
            r3.PrintRational("r3: (r1-r2)"); r4.PrintRational("r4: (r1*r2)");
            r5.PrintRational("r5: (r1/r2)");
            r6.PrintRational("r6: (r3+r4*r5)");

        }
    }
}
