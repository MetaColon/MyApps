using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            a:
            Console.WriteLine(trim(Console.ReadLine().ToCharArray()));
            goto a;
        }

        static char zeichenAnStelleI(char[] a, int i)                       //1
        {
            if (a.Length > i) return a[i];
            else return (char)0;
        }
        
        static void vertikaleAusgabe (char[] a)                             //2
        {
            Console.WriteLine(a[0]);
            if(a.Length > 1)
                vertikaleAusgabe(Tail(a));
        }

        static char[] Tail (char[] a)
        {
            char[] newc = new char[a.Length - 1];
            for (int i = 1; i < a.Length; i++)
            {
                newc[i - 1] = a[i];
            }
            return newc;
        }

        static char[] zeichenabn(char[] a, int n)
        {
            if (n == 0) return a;
            else return zeichenabn(Tail(a), n - 1);
        }

        static void jedesNteZeichenAusgeben(char[] a, int n)                //3
        {
            if (a.Length > 0)
            {
                Console.WriteLine(a[0]);
                if (a.Length > n) jedesNteZeichenAusgeben(zeichenabn(a, n), n);
            }
        }

        static void jedesNteZeichenAbJAusgeben (char[] a, int n, int j)     //4
        {
            jedesNteZeichenAusgeben(zeichenabn(a, j), n);
        }

        static void mischenAusgeben (char[] a, char[] b)                    //5
        {
            if (a.Length > 0 && b.Length > 0)
            {
                Console.WriteLine(a[0] + "\n" + b[0]);
                mischenAusgeben(Tail(a), Tail(b));
            }
            else if (a.Length > 0) vertikaleAusgabe(a);
            else if (b.Length > 0) vertikaleAusgabe(b);
        }

        static void etwas_Gutes()
        {
            Random rnd = new Random();
            Console.WriteLine((char)rnd.Next(0, 127));
        }

        static char[] clone (char[] a)
        {
            char[] newc = new char[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                newc[i] = a[i];
            }
            return newc;
        }

        static char[] erweitern (char[] a, char[] b)
        {
            char[] newc = new char[a.Length + b.Length];
            if (b.Length > 0)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    newc[i] = a[i];
                }
                for (int i = 0; i < b.Length; i++)
                {
                    newc[i + a.Length] = b[i];
                }
                return newc;
            }
            else return a;
        }

        static char[] erweitern(char[] a, char b)
        {
            return erweitern(a, new char[1] { b });
        }

        static char[] erweitern(char a, char[] b)
        {
            return erweitern(new char[] { a }, b);
        }

        static char[] ersetze(char[] a, char x, char y) //7
        {
            char[] newc = new char[a.Length];
            if (a[0] == x) newc[0] = y;
            else newc[0] = a[0];
            if (a.Length > 1) return erweitern(newc[0], ersetze(Tail(a), x, y));
            else return new char[1] { newc[0] };
        }

        static void komisch() { } //8

        static char[] jedes2teZeichenloeschen (char[] a) //9
        {
            if (a.Length > 1) return erweitern(a[0], jedes2teZeichenloeschen(zeichenabn(a, 2)));
            else if (a.Length > 0) return new char[] { a[0] };
            else return new char[0];
        }

        static char letztesZeichen(char[] a)
        {
            if (a.Length > 1) return letztesZeichen(Tail(a));
            else if (a.Length > 0) return a[0];
            else return (char)0;
        }

        static char[] ohneletztemZeichen(char[] a)
        {
            if (a.Length > 2) return erweitern(a[0], ohneletztemZeichen(Tail(a)));
            else if (a.Length == 2) return new char[1] { a[0] };
            else return new char[0];
        }

        static void umgedrehtausgeben (char[] a)
        {
            if (a.Length > 1)
            {
                Console.Write(letztesZeichen(a));
                umgedrehtausgeben(ohneletztemZeichen(a));
            }
            else if (a.Length == 1) Console.WriteLine(a[0]);
        }

        static bool endetMit(char[]a, char[]ende)
        {
            if (ende.Length > a.Length) return false;
            else if (a == ende) return true;
            else if (ende.Length == 0) return true;
            if (letztesZeichen(ende) != letztesZeichen(a)) return false;
            else
            {
                return endetMit(ohneletztemZeichen(a), ohneletztemZeichen(ende));
            }
        }

        static char[] trim(char[] a)
        {
            if (a.Length > 1)
            {
                bool letzteszeichen = letztesZeichen(a) == ' ', ersteszeichen = a[0] == ' ';
                if (letzteszeichen)
                {
                    if (ersteszeichen) return trim(Tail(ohneletztemZeichen(a)));
                    return trim(ohneletztemZeichen(a));
                }
                else
                {
                    if (ersteszeichen) return trim(Tail(a));
                    else return a;
                }
            }
            else if (a[0] == ' ') return new char[0];
            else return a;
        }
    }
}
