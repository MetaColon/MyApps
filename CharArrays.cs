using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Char_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            b:
            mischenAusgeben(Console.ReadLine().ToCharArray(), Console.ReadLine().ToCharArray());
            goto b;
        }

        static void vertikaleAusgabe(char[] a)
        {
            foreach (char b in a)
                Console.WriteLine(b);
        }
        static char zeichenAnStelleI(char[] a, int i)
        {
            if (a.Length - 1 < i) return '\0';
            else return a[i];
        }
        static int countChar(char[] wort, char b)
        {
            int count = 0;
            for (int i = 0; i < wort.Length; i++)
            {
                if (wort[i] == b) count++;
            }
            return count;
        }

        static char[] kuerzen (char[] wort)
        {
            char[] gekuerzt;
            int pos = -1;
            for (int i = 0; i < wort.Length; i++)
            {
                if(wort[i] == ' ')
                {
                    pos = i;
                    break;
                }
            }
            if (pos != -1)
            {
                gekuerzt = new char[pos];
                for (int i = 0; i < pos; i++)
                {
                    gekuerzt[i] = wort[i];
                }
            }
            else gekuerzt = wort;
            return gekuerzt;
        }

        static char[] anhängen(char[] wort1, char[] wort2)
        {
            char[] anhängen = new char[wort1.Length + wort2.Length];
            if(vergleiche(wort1, wort2) == 1)
            {
                for (int i = 0; i < wort1.Length; i++)
                {
                    anhängen[i] = wort1[i];
                }
                for (int i = wort1.Length; i < anhängen.Length; i++)
                {
                    anhängen[i] = wort2[i - wort1.Length];
                }
            }
            else
            {
                for (int i = 0; i < wort2.Length; i++)
                {
                    anhängen[i] = wort2[i];
                }
                for (int i = wort2.Length; i < anhängen.Length; i++)
                {
                    anhängen[i] = wort1[i - wort2.Length];
                }
            }
            return anhängen;
        }

        static char[] switchUpper(char[] wort)
        {
            char[] neu = new char[wort.Length];
            for (int i = 0; i < wort.Length; i++)
            {
                if (wort[i] >= 'a' && wort[i] <= 'z') neu[i] = (char)(wort[i] + 'A' - 'a');
                else if (wort[i] >= 'A' && wort[i] <= 'Z') neu[i] = (char)(wort[i] + 'a' - 'A');
            }
            return neu;
        }

        static char[] ToUpper(char[] wort)
        {
            for (int i = 0; i < wort.Length; i++)
            {
                if (wort[i] >= 'a' && wort[i] <= 'z') wort[i] = (char)(wort[i] + 'A' - 'a');
            }
            return wort;
        }

        static sbyte vergleiche(char[] eins, char[] zwei)
        {
            eins = ToUpper(eins);
            zwei = ToUpper(zwei);
            sbyte vergleich = 0;
            for (int i = 0; i < eins.Length && i < zwei.Length; i++)
            {
                if(eins[i] < zwei[i])
                {
                    vergleich = -1;
                    break;
                }
                else if(zwei[i] < eins[i])
                {
                    vergleich = 1;
                }
            }
            if(vergleich == 0)
            {
                if (eins.Length < zwei.Length) vergleich = -1;
                else if (zwei.Length < eins.Length) vergleich = 1;
            }
            return vergleich;
        }

        static void ausgeben(char[] feld)
        {
            for (int i = 0; i < feld.Length; i++)
            {
                Console.Write(feld[i]);
            }
            Console.WriteLine();
        }

        static char[] rotate(char[] wort, int anzahl)
        {
            char[] neu = new char[wort.Length];
            int verschiebung = 0;
            for (int i = 0; i < wort.Length; i++)
            {
                verschiebung = i + anzahl - 1;
                verschiebung %= wort.Length;
                neu[verschiebung] = wort[i];
            }
            return wort = neu;
        }

        static char[] turn(char[] wort)
        {
            char[] neu = new char[wort.Length];
            for (int i = 0; i < wort.Length; i++)
            {
                neu[wort.Length - i-1] = wort[i];
            }
            return neu;
        }

        static void jedesNteZeichen(char[] a, int n)
        {
            char[] array = new char[a.Length / n+1];
            for (int i = 0; i <= array.Length-1; i++)
            {
                array[i] = zeichenAnStelleI(a, i * n);
            }
            vertikaleAusgabe(array);
        }
        static void jedesNteZeichneAbJAusgeben(char[] a, int n, int j)
        {
            char[] array = new char[(a.Length - j) / n+1];
            for (int i = 0; i <= (a.Length - j) / n; i++)
            {
                array[i] = zeichenAnStelleI(a, i * n + j);
            }
            vertikaleAusgabe(array);
        }

        static void mischenAusgeben(char[] a, char[]b)
        {
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                Console.WriteLine(zeichenAnStelleI(a, i));
                Console.WriteLine(zeichenAnStelleI(b, i));
            }
            if(a.Length < b.Length)
                for (int i = a.Length; i < b.Length; i++)
                {
                    Console.WriteLine(zeichenAnStelleI(b, i));
                }
            else if(b.Length < a.Length)
                for (int i = b.Length; i < a.Length; i++)
                {
                    Console.WriteLine(zeichenAnStelleI(a, i));
                }
        }
    }
}
