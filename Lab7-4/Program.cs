using System;

namespace Lab7_4
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

        private Rational(int a, int b, string t) //закрытый конструктор
        {
            m = a; n = b;
        }

        public static readonly Rational Zero, One;
        static Rational()
        {
            Console.WriteLine("Статический конструктор Rational");
            Zero = new Rational(0, 1, "private");
            One = new Rational(1, 1, "private");
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

        //булевы операции
        public static bool operator ==(Rational r1, Rational r2)
        {
            return ((r1.m == r2.m) && (r1.n == r2.n));
        }
        public static bool operator !=(Rational r1, Rational r2)
        {
            return ((r1.m != r2.m) || (r1.n != r2.n));
        }
        public static bool operator <(Rational r1, Rational r2)
        {
            return (r1.m * r2.n < r2.m * r1.n);
        }
        public static bool operator >(Rational r1, Rational r2)
        {
            return (r1.m * r2.n > r2.m * r1.n);
        }
        public static bool operator <(Rational r1, double r2)
        {
            return ((double)r1.m / (double)r1.n < r2);
        }
        public static bool operator >(Rational r1, double r2)
        {
            return ((double)r1.m / (double)r1.n > r2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rational r1 = new Rational(2, 8), r2 = new Rational(2, 5);
            Rational r3 = new Rational(4, 10), r4 = new Rational(3, 7);
            Rational r5 = Rational.Zero, r6 = Rational.Zero;
            if ((r1 != Rational.Zero) && (r2 == r3)) r5 =
                 (r3 + Rational.One) * r4;
            r6 = Rational.One + Rational.One;
            r1.PrintRational("r1: (2,8)");
            r2.PrintRational("r2: (2,5)");
            r3.PrintRational("r3: (4,10)");
            r4.PrintRational("r4: (3,7)");
            r5.PrintRational("r5: ((r3 +1)*r4)");
            r6.PrintRational("r6: (1+1)");
        }
    }
}
