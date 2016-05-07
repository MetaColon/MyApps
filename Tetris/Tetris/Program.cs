using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Program
    {
        public static int[,] Feld = new int[20, 10];
        public static bool[,,,] Objekte = new bool[4, 7, 4, 4]
        {
            {
                {
                    {false,false,false,false },
                    {false,false,false,false },
                    {false,false,false,false },
                    {true,true,true,true }
                },
                {
                    {false,false,false,false },
                    {false,false,false,false },
                    {true,true,true,false },
                    {false,false,true,false }
                },
                {
                    {false,false,false,false },
                    {false,false,false,false },
                    {true,true,true,false },
                    {true,false,false,false }
                },
                {
                    {false,false,false,false },
                    {false,false,false,false },
                    {true,true,false,false },
                    {true,true,false,false }
                },
                {
                    {false,false,false,false },
                    {false,false,false,false },
                    {false,true,true,false },
                    {true,true,false,false }
                },
                {
                    {false,false,false,false },
                    {false,false,false,false },
                    {true,true,true,false },
                    {false,true,false,false }
                },
                {
                    {false,false,false,false },
                    {false,false,false,false },
                    {true,true,false,false },
                    {false,true,true,false }
                }
            },
            {
                {
                    {true,false,false,false },
                    {true,false,false,false },
                    {true,false,false,false },
                    {true,false,false,false }
                },
                {
                    {false,false,false,false },
                    {false,true,false,false },
                    {false,true,false,false },
                    {true,true,false,false }
                },
                {
                    {false,false,false,false },
                    {true,true,false,false },
                    {false,true,false,false },
                    {false,true,false,false }
                },
                {
                    {false,false,false,false },
                    {false,false,false,false },
                    {true,true,false,false },
                    {true,true,false,false }
                },
                {
                    {false,false,false,false },
                    {true,false,false,false },
                    {true,true,false,false },
                    {false,true,false,false }
                },
                {
                    {false,false,false,false },
                    {false,true,false,false },
                    {true,true,false,false },
                    {false,true,false,false }
                },
                {
                    {false,false,false,false },
                    {false,true,false,false },
                    {true,true,false,false },
                    {true,false,false,false }
                }
            },
            {
                {
                    {false,false,false,false },
                    {false,false,false,false },
                    {false,false,false,false },
                    {true,true,true,true }
                },
                {
                    {false,false,false,false },
                    {false,false,false,false },
                    {true,false,false,false },
                    {true,true,true,false }
                },
                {
                    {false,false,false,false },
                    {false,false,false,false },
                    {false,false,true,false },
                    {true,true,true,false }
                },
                {
                    {false,false,false,false },
                    {false,false,false,false },
                    {true,true,false,false },
                    {true,true,false,false }
                },
                {
                    {false,false,false,false },
                    {false,false,false,false },
                    {false,true,true,false },
                    {true,true,false,false }
                },
                {
                    {false,false,false,false },
                    {false,false,false,false },
                    {false,true,false,false },
                    {true,true,true,false }
                },
                {
                    {false,false,false,false },
                    {false,false,false,false },
                    {true,true,false,false },
                    {false,true,true,false }
                }
            },
            {
                {
                    {true,false,false,false },
                    {true,false,false,false },
                    {true,false,false,false },
                    {true,false,false,false }
                },
                {
                    {false,false,false,false },
                    {true,true,false,false },
                    {true,false,false,false },
                    {true,false,false,false }
                },
                {
                    {false,false,false,false },
                    {true,false,false,false },
                    {true,false,false,false },
                    {true,true,false,false }
                },
                {
                    {false,false,false,false },
                    {false,false,false,false },
                    {true,true,false,false },
                    {true,true,false,false }
                },
                {
                    {false,false,false,false },
                    {true,false,false,false },
                    {true,true,false,false },
                    {false,true,false,false }
                },
                {
                    {false,false,false,false },
                    {true,false,false,false },
                    {true,true,false,false },
                    {true,false,false,false }
                },
                {
                    {false,false,false,false },
                    {false,true,false,false },
                    {true,true,false,false },
                    {true,false,false,false }
                }
            }
        };
        public static byte[,] sizes = new byte[8, 2] { { 0, 0 }, { 4, 1 }, { 3, 2 }, { 3, 2 }, { 2, 2 }, { 3, 2 }, { 3, 2 }, { 3, 2 } };
        public static decimal Time = 0, timer = Time;
        public static int[,] current = new int[4, 4];
        public static bool objectexists = false;
        public static Random rnd = new Random();
        public static int posx, posy;
        public static int objectnumber = 0;
        public static int rotation = 0;
        public static bool speed = false;
        public static ConsoleColor[] colours = new ConsoleColor[8] { ConsoleColor.Cyan, ConsoleColor.Blue, ConsoleColor.DarkBlue, ConsoleColor.White, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.DarkMagenta, ConsoleColor.Red };
        public static int Score = 0;
        public static int Speed = 500;
        static void Main(string[] args)
        {
            Spiel();
            Console.ReadLine();
        }

        public static void Spiel()
        {
            Init();
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            ConsoleKey ck = new ConsoleKey();
            char c = new char();
            a:
            Time = Environment.TickCount;
            if (Time - timer > Speed || speed)
            {
                Speed = Convert.ToInt32(Speed * (double)0.9999);
                zeichne();
                if (!objectexists)
                {
                    for (int x = 0; x < Feld.GetLength(1); x++)
                    {
                        if (Feld[3, x] != 0) return;
                    }
                    int r = rnd.Next(0, 7);
                    posx = Feld.GetLength(1) / 2 - current.GetLength(1) / 2;
                    posy = 0;
                    objectnumber = r;
                    for (int x = 0; x < current.GetLength(1); x++)
                    {
                        for (int y = 0; y < current.GetLength(0); y++)
                        {
                            if (Objekte[0, r, y, x])
                                current[y, x] = r + 1;
                            else current[y, x] = 0;
                            Feld[y, x + Feld.GetLength(1) / 2 - current.GetLength(1) / 2] = current[y, x];
                        }
                    }
                    objectexists = true;
                    speed = false;
                    rotation = 0;
                    timer = Time;
                    zeichne();
                    goto a;
                }
                else
                {
                    if (movepossible(Feld, current) && posy < Feld.GetLength(0))
                    {
                        for (int x = 0; x < current.GetLength(1); x++)
                        {
                            for (int y = 0; y < current.GetLength(0); y++)
                            {
                                if (current[y, x] > 0)
                                {
                                    if (posy + current.GetLength(0) + 1 < Feld.GetLength(0))
                                    {
                                        if (y != 0)
                                        {
                                            if (current[y - 1, x] == 0)
                                                Feld[y + posy, x + posx] = 0;
                                        }
                                        else
                                            Feld[y + posy, x + posx] = 0;
                                        Feld[y + posy + 1, x + posx] = objectnumber + 1;
                                    }
                                    else
                                    {
                                        posy = 0;
                                        posx = 0;
                                        objectexists = false;
                                        speed = false;
                                        objectnumber = 0;
                                        rotation = 0;
                                        zeichne();
                                        for (int i = 0; i < 4; i++)
                                            linestuff();
                                        goto a;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        posy = 0;
                        posx = 0;
                        objectexists = false;
                        linestuff();
                        speed = false;
                        objectnumber = 0;
                        rotation = 0;
                        zeichne();
                        goto a;
                    }
                    posy++;
                    timer = Time;
                    zeichne();
                    goto a;
                }
            }
            if (Console.KeyAvailable && objectexists)
            {
                while(Console.KeyAvailable)cki = Console.ReadKey(true);
                ck = cki.Key;
                c = cki.KeyChar;
                int oldx = posx;
                int[,] oldcurrent = new int[current.GetLength(0), current.GetLength(1)];
                int oldrotation = rotation;
                for (int x = 0; x < current.GetLength(1); x++)
                {
                    for (int y = 0; y < current.GetLength(0); y++)
                    {
                        oldcurrent[y, x] = current[y, x];
                    }
                }
                if (ck == ConsoleKey.RightArrow)
                    posx++;
                else if (ck == ConsoleKey.LeftArrow)
                    posx--;
                else if (ck == ConsoleKey.DownArrow) speed = true;
                else if (ck == ConsoleKey.UpArrow)
                {
                    rotation++;
                    rotation %= 4;
                    for (int x = 0; x < current.GetLength(1); x++)
                    {
                        for (int y = 0; y < current.GetLength(0); y++)
                        {
                            if (Objekte[rotation, objectnumber, y, x])
                                current[y, x] = objectnumber + 1;
                            else current[y, x] = 0;
                        }
                    }
                }
                if (posx + sizes[objectnumber + 1, rotation % 2] >= Feld.GetLength(1) || posx < 0 || !seitallowed(oldx))
                {
                    posx = oldx;
                    current = oldcurrent;
                    rotation = oldrotation;
                }
                else
                {
                    for (int x = 0; x < current.GetLength(1); x++)
                    {
                        for (int y = 0; y < current.GetLength(0); y++)
                        {
                            if (oldcurrent[y, x] > 0)
                            {
                                Feld[y + posy, x + oldx] = 0;
                            }
                        }
                    }
                    for (int x = 0; x < current.GetLength(1); x++)
                    {
                        for (int y = 0; y < current.GetLength(0); y++)
                        {
                            if (current[y, x] > 0)
                            {
                                Feld[y + posy, x + posx] = objectnumber + 1;
                            }
                        }
                    }
                    zeichne();
                }
            }
            goto a;
        }

        public static bool seitallowed(int oldx)
        {
            for (int i = 0; i < current.GetLength(0); i++)
            {
                if (current[i, 0] > 0 && Feld[i + posy, posx] > 0 && oldx > posx || current[i, sizes[objectnumber + 1, rotation % 2] - 1] > 0 && Feld[i + posy, posx + sizes[objectnumber + 1, rotation % 2]-1] > 0 && oldx < posx) return false;
            }
            return true;
        }

        public static void linestuff()
        {
            int[,] oldfeld = new int[Feld.GetLength(0), Feld.GetLength(1)];
            for (int x = 0; x < Feld.GetLength(1); x++)
            {
                for (int y = 0; y < Feld.GetLength(0); y++)
                {
                    oldfeld[y, x] = Feld[y, x];
                }
            }
            bool[] lines = new bool[Feld.GetLength(0)];
            for (int y = 0; y < Feld.GetLength(0); y++)
            {
                lines[y] = true;
                for (int x = 0; x < Feld.GetLength(1) - 1; x++)
                {
                    if (Feld[y, x] == 0)
                    {
                        lines[y] = false;
                        break;
                    }
                }
            }
            for (int l = 0; l < lines.Length; l++)
            {
                if(lines[l])
                {
                    Score++;
                    for (int x = 0; x < Feld.GetLength(1); x++)
                    {
                        Feld[l, x] = 0;
                        for (int i = l-1; i > 1; i--)
                        {
                            Feld[i, x] = oldfeld[i - 1, x];
                        }
                    }
                }
            }
        }

        public static bool movepossible(int[,] Feld, int[,] current)
        {
            bool possible = true;
            for (int x = 0; x < current.GetLength(1) && posx + x < Feld.GetLength(1); x++)
            {
                for (int y = 0; y < current.GetLength(0) && y + posy + 1 < Feld.GetLength(0); y++)
                {
                    if (y < current.GetLength(0) - 1)
                    {
                        if (current[y + 1, x] == 0 && Feld[y + posy + 1, posx + x] > 0 && current[y, x] > 0)
                            return false;
                    }
                    else if (Feld[y + posy + 1, posx + x] > 0 && current[y, x] > 0)
                        return false;
                }
            }
            return possible;
        }

        public static void zeichne()
        {
            for (int x = 0; x < Feld.GetLength(1); x++)
            {
                for (int y = 0; y < Feld.GetLength(0) - 1; y++)
                {
                    if (x % 2 == 0) Console.BackgroundColor = ConsoleColor.DarkGray;
                    else Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = colours[Feld[y, x]];
                    Console.SetCursorPosition(2 * x, 2 * y);
                    if (Feld[y, x] > 0) Console.Write("█");
                    else Console.Write(" ");
                    Console.SetCursorPosition(2 * x+1, 2 * y+1);
                    if (Feld[y, x] > 0) Console.Write("█");
                    else Console.Write(" ");
                    Console.SetCursorPosition(2 * x+1, 2 * y);
                    if (Feld[y, x] > 0) Console.Write("█");
                    else Console.Write(" ");
                    Console.SetCursorPosition(2 * x, 2 * y+1);
                    if (Feld[y, x] > 0) Console.Write("█");
                    else Console.Write(" ");
                }
            }
            Console.SetCursorPosition(2 * Feld.GetLength(1) + 1, 2 * Feld.GetLength(0) + 1);
            Console.Write(Score + "     ");
        }

        public static void Init()
        {
            Console.CursorVisible = false;
            Time = Environment.TickCount;
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowSize(Console.BufferWidth, Console.BufferHeight);
        }
    }
}
