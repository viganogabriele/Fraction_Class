using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frazione
{
    class Frazione
    {
        readonly int n;
        readonly int d;
        public Frazione(int n, int d)
        {
            this.n = n;
            this.d = d;
        }
        public int N => n;
        public int D => d;

        static int CalcolaMCD(Frazione f1, Frazione f2)
        {
            int a = f1.D;
            int b = f2.D;   
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public static Frazione operator +(Frazione f1, Frazione f2)
        {
            int MCD = CalcolaMCD(f1, f2);
            int denominatoreComune = (f1.D * f2.D) / MCD;
            int numeratore1 = (f1.N * (denominatoreComune / f1.D));
            int numeratore2 = (f2.N * (denominatoreComune / f2.D));
            int sommaNumeratore = numeratore1 + numeratore2;
            return new Frazione(sommaNumeratore, denominatoreComune);
        }
        public static Frazione operator -(Frazione f1, Frazione f2)
        {
            int MCD = CalcolaMCD(f1, f2);
            int denominatoreComune = (f1.D * f2.D) / MCD;
            int numeratore1 = (f1.N * (denominatoreComune / f1.D));
            int numeratore2 = (f2.N * (denominatoreComune / f2.D));
            int sommaNumeratore = numeratore1 - numeratore2;
            return new Frazione(sommaNumeratore, denominatoreComune);
        }
        public static Frazione operator *(Frazione f1, Frazione f2)
        {
            return new Frazione(f1.N * f2.N, f1.D * f2.D);
        }
        public static Frazione operator /(Frazione f1, Frazione f2)
        {
            return new Frazione(f1.N * f2.D, f1.D * f2.N);
        }
        public static Frazione operator -(Frazione f1)
        {
            return new Frazione(-f1.N, f1.D);
        }
        public Frazione Semplifica()
        {
            int min;
            if (n > d) min = d;
            else min = n;
            int numerator = n;
            int denominator = d;
            for (int i = 2; i <= min; i++)
            {
                if (numerator % i == 0 && denominator % i == 0)
                {
                    numerator = numerator / i;
                    denominator = denominator / i;
                }
            }
            return new Frazione(numerator, denominator);
        }
        public override string ToString()
        {
            return String.Format(n.ToString() + " / " + d.ToString());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List <Frazione> lFrazioni = new List <Frazione>();
            Frazione[] aFrazioni = new Frazione[5];
            for(int i = 0; i < 5; i++)
            {
                Frazione a = new Frazione((i+1) * 2, i + 3);
                aFrazioni[i] = a;
                lFrazioni.Add(a);
            }
            Frazione somma1 = aFrazioni[0];
            Frazione somma2 = lFrazioni[0];
            for(int i = 1; i < 5; i++)
            {
                somma1 = somma1 + aFrazioni[i];
                somma2 = somma2 + lFrazioni[i];
            }
            Frazione c = new Frazione(2, 3);
            Frazione b = new Frazione(3, 2);
            Frazione d = -c;
            Console.WriteLine(somma1.Semplifica().ToString() + " " + somma2.Semplifica().ToString());
            Console.WriteLine((c + b).ToString());
            Console.WriteLine(d);
            Console.ReadLine();
        }
    }
}
