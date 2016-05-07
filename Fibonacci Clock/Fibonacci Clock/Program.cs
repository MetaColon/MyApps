using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_Clock
{
    class Program
    {
        public static int sizex = Console.LargestWindowWidth, sizey = Console.LargestWindowHeight-1;
        public static ConsoleColor[] colours = new ConsoleColor[4] { ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Green };
        static void Main(string[] args)
        {
            DateTime Time = new DateTime();
            int oldminutes = 100;
            Init();
            a:
            Time = DateTime.Now;
            if (Time.Minute/5 != oldminutes / 5)
            {
                oldminutes = Time.Minute;
                byte[] Patterns = getPatterns(Time);
                zeichnePatterns(Patterns);
                Console.SetCursorPosition(0, 0);
            }
            goto a;
        }

        public static void zeichnePatterns(byte [] Patterns)
        {
            int[,] region = new int[2, 2];
            for (int i = 0; i < 5; i++)
            {
                region = getregion(i);
                for (int x = region[0,0]; x < region[1,0]; x++)
                {
                    for (int y = region[0,1]; y < region[1,1]; y++)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = colours[Patterns[i]];
                        Console.Write("█");
                    }
                }
            }
        }

        public static int[,] getregion(int i)
        {
            int[,] region = new int[2,2];
            if (i == 0)
            {
                region[0, 0] = (sizex / 8) * 2;
                region[0, 1] = 0;
                region[1, 0] = (sizex / 8) * 3;
                region[1, 1] = (sizey / 5);
            }
            else if (i == 1)
            {
                region[0, 0] = (sizex / 8) * 2;
                region[0, 1] = (sizey / 5);
                region[1, 0] = (sizex / 8) * 3;
                region[1, 1] = (sizey / 5) * 2;
            }
            else if (i == 2)
            {
                region[0, 0] = 0;
                region[0, 1] = 0;
                region[1, 0] = (sizex / 8) * 2;
                region[1, 1] = (sizey / 5) * 2;
            }
            else if (i == 3)
            {
                region[0, 0] = 0;
                region[0, 1] = (sizey / 5) * 2;
                region[1, 0] = (sizex / 8) * 3;
                region[1, 1] = sizey;
            }
            else if (i == 4)
            {
                region[0, 0] = (sizex / 8) * 3;
                region[0, 1] = 0;
                region[1, 0] = sizex;
                region[1, 1] = sizey;
            }
            return region;
        }

        public static byte[] getPatterns(DateTime Time)
        {
            byte[] Patterns = new byte[5];
            int hours = Time.Hour, minutes = Time.Minute / 5;
            if (hours > 12) hours -= 12;
            int number;
            b:
            if (hours > minutes) number = minutes;
            else number = hours;
            if (number >= 5 && Patterns[4] == 0)
            {
                Patterns[4] = 2;
                hours -= 5;
                minutes -= 5;
                goto b;
            }
            else if (number >= 3 && Patterns[3] == 0)
            {
                Patterns[3] = 2;
                hours -= 3;
                minutes -= 3;
                goto b;
            }
            else if (number >= 2 && Patterns[2] == 0)
            {
                Patterns[2] = 2;
                hours -= 2;
                minutes -= 2;
                goto b;
            }
            else if (number >= 1 && Patterns[1] == 0)
            {
                Patterns[1] = 2;
                hours -= 1;
                minutes -= 1;
                goto b;
            }
            else if (number >= 1 && Patterns[0] == 0)
            {
                Patterns[0] = 2;
                hours -= 1;
                minutes -= 1;
                goto b;
            }
            else if (number == 0)
            {
                while (minutes != 0)
                {
                    if (minutes >= 5 && Patterns[4] == 0)
                    {
                        Patterns[4] = 3;
                        minutes -= 5;
                    }
                    else if (minutes >= 3 && Patterns[3] == 0)
                    {
                        Patterns[3] = 3;
                        minutes -= 3;
                    }
                    else if (minutes >= 2 && Patterns[2] == 0)
                    {
                        Patterns[2] = 3;
                        minutes -= 2;
                    }
                    else if (minutes >= 1 && Patterns[1] == 0)
                    {
                        Patterns[1] = 3;
                        minutes -= 1;
                    }
                    else if (minutes >= 1 && Patterns[0] == 0)
                    {
                        Patterns[0] = 3;
                        minutes -= 1;
                    }
                }
                while (hours != 0)
                {
                    if (hours >= 5 && Patterns[4] == 0)
                    {
                        Patterns[4] = 1;
                        hours -= 5;
                    }
                    else if (hours >= 3 && Patterns[3] == 0)
                    {
                        Patterns[3] = 1;
                        hours -= 3;
                    }
                    else if (hours >= 2 && Patterns[2] == 0)
                    {
                        Patterns[2] = 1;
                        hours -= 2;
                    }
                    else if (hours >= 1 && Patterns[1] == 0)
                    {
                        Patterns[1] = 1;
                        hours -= 1;
                    }
                    else if (hours >= 1 && Patterns[0] == 0)
                    {
                        Patterns[0] = 1;
                        hours -= 1;
                    }
                }
            }
            else
                return null;
            return Patterns;
        }

        public static void Init()
        {
            Console.SetBufferSize(sizex, sizey+1);
            Console.SetWindowSize(sizex, sizey-1);
            Console.CursorVisible = false;
        }
    }
}
