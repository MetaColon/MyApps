using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tron
{
    class Program
    {
        public static int sizex = Console.LargestWindowWidth - 1, sizey = Console.LargestWindowHeight - 1;
        public static int[,] Feld = new int[sizey, sizex];
        public static int[,] possis = new int[2, 2] { { sizex - 10, sizey - 10 }, { 10, 10 } };
        public static decimal Time, Timer, Speed = 5;
        public static ConsoleColor[] colours = new ConsoleColor[2] { ConsoleColor.Blue, ConsoleColor.Red };
        public static byte[] directions = new byte[2] { 0, 2 };
        public static bool end = false;
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            ConsoleKey ck = new ConsoleKey();
            char c = new char();
            Init();
            a:
            Time = Environment.TickCount;

            if (Console.KeyAvailable)
            {
                while (Console.KeyAvailable) cki = Console.ReadKey(true);
                ck = cki.Key;
                c = cki.KeyChar;
                #region verarbeite
                switch (ck)
                {
                    case ConsoleKey.A:
                        if (directions[1] != 1)
                            directions[1] = 3;
                        break;
                    case ConsoleKey.Add:
                        break;
                    case ConsoleKey.Applications:
                        break;
                    case ConsoleKey.Attention:
                        break;
                    case ConsoleKey.B:
                        break;
                    case ConsoleKey.Backspace:
                        break;
                    case ConsoleKey.BrowserBack:
                        break;
                    case ConsoleKey.BrowserFavorites:
                        break;
                    case ConsoleKey.BrowserForward:
                        break;
                    case ConsoleKey.BrowserHome:
                        break;
                    case ConsoleKey.BrowserRefresh:
                        break;
                    case ConsoleKey.BrowserSearch:
                        break;
                    case ConsoleKey.BrowserStop:
                        break;
                    case ConsoleKey.C:
                        break;
                    case ConsoleKey.Clear:
                        break;
                    case ConsoleKey.CrSel:
                        break;
                    case ConsoleKey.D:
                        if (directions[1] != 3)
                            directions[1] = 1;
                        break;
                    case ConsoleKey.D0:
                        break;
                    case ConsoleKey.D1:
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.D4:
                        break;
                    case ConsoleKey.D5:
                        break;
                    case ConsoleKey.D6:
                        break;
                    case ConsoleKey.D7:
                        break;
                    case ConsoleKey.D8:
                        break;
                    case ConsoleKey.D9:
                        break;
                    case ConsoleKey.Decimal:
                        break;
                    case ConsoleKey.Delete:
                        break;
                    case ConsoleKey.Divide:
                        break;
                    case ConsoleKey.DownArrow:
                        if (directions[0] != 0)
                            directions[0] = 2;
                        break;
                    case ConsoleKey.E:
                        break;
                    case ConsoleKey.End:
                        break;
                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.EraseEndOfFile:
                        break;
                    case ConsoleKey.Escape:
                        break;
                    case ConsoleKey.ExSel:
                        break;
                    case ConsoleKey.Execute:
                        break;
                    case ConsoleKey.F:
                        break;
                    case ConsoleKey.F1:
                        break;
                    case ConsoleKey.F10:
                        break;
                    case ConsoleKey.F11:
                        break;
                    case ConsoleKey.F12:
                        break;
                    case ConsoleKey.F13:
                        break;
                    case ConsoleKey.F14:
                        break;
                    case ConsoleKey.F15:
                        break;
                    case ConsoleKey.F16:
                        break;
                    case ConsoleKey.F17:
                        break;
                    case ConsoleKey.F18:
                        break;
                    case ConsoleKey.F19:
                        break;
                    case ConsoleKey.F2:
                        break;
                    case ConsoleKey.F20:
                        break;
                    case ConsoleKey.F21:
                        break;
                    case ConsoleKey.F22:
                        break;
                    case ConsoleKey.F23:
                        break;
                    case ConsoleKey.F24:
                        break;
                    case ConsoleKey.F3:
                        break;
                    case ConsoleKey.F4:
                        break;
                    case ConsoleKey.F5:
                        break;
                    case ConsoleKey.F6:
                        break;
                    case ConsoleKey.F7:
                        break;
                    case ConsoleKey.F8:
                        break;
                    case ConsoleKey.F9:
                        break;
                    case ConsoleKey.G:
                        break;
                    case ConsoleKey.H:
                        break;
                    case ConsoleKey.Help:
                        break;
                    case ConsoleKey.Home:
                        break;
                    case ConsoleKey.I:
                        break;
                    case ConsoleKey.Insert:
                        break;
                    case ConsoleKey.J:
                        break;
                    case ConsoleKey.K:
                        break;
                    case ConsoleKey.L:
                        break;
                    case ConsoleKey.LaunchApp1:
                        break;
                    case ConsoleKey.LaunchApp2:
                        break;
                    case ConsoleKey.LaunchMail:
                        break;
                    case ConsoleKey.LaunchMediaSelect:
                        break;
                    case ConsoleKey.LeftArrow:
                        if (directions[0] != 1)
                            directions[0] = 3;
                        break;
                    case ConsoleKey.LeftWindows:
                        break;
                    case ConsoleKey.M:
                        break;
                    case ConsoleKey.MediaNext:
                        break;
                    case ConsoleKey.MediaPlay:
                        break;
                    case ConsoleKey.MediaPrevious:
                        break;
                    case ConsoleKey.MediaStop:
                        break;
                    case ConsoleKey.Multiply:
                        break;
                    case ConsoleKey.N:
                        break;
                    case ConsoleKey.NoName:
                        break;
                    case ConsoleKey.NumPad0:
                        break;
                    case ConsoleKey.NumPad1:
                        break;
                    case ConsoleKey.NumPad2:
                        break;
                    case ConsoleKey.NumPad3:
                        break;
                    case ConsoleKey.NumPad4:
                        break;
                    case ConsoleKey.NumPad5:
                        break;
                    case ConsoleKey.NumPad6:
                        break;
                    case ConsoleKey.NumPad7:
                        break;
                    case ConsoleKey.NumPad8:
                        break;
                    case ConsoleKey.NumPad9:
                        break;
                    case ConsoleKey.O:
                        break;
                    case ConsoleKey.Oem1:
                        break;
                    case ConsoleKey.Oem102:
                        break;
                    case ConsoleKey.Oem2:
                        break;
                    case ConsoleKey.Oem3:
                        break;
                    case ConsoleKey.Oem4:
                        break;
                    case ConsoleKey.Oem5:
                        break;
                    case ConsoleKey.Oem6:
                        break;
                    case ConsoleKey.Oem7:
                        break;
                    case ConsoleKey.Oem8:
                        break;
                    case ConsoleKey.OemClear:
                        break;
                    case ConsoleKey.OemComma:
                        break;
                    case ConsoleKey.OemMinus:
                        break;
                    case ConsoleKey.OemPeriod:
                        break;
                    case ConsoleKey.OemPlus:
                        break;
                    case ConsoleKey.P:
                        break;
                    case ConsoleKey.Pa1:
                        break;
                    case ConsoleKey.Packet:
                        break;
                    case ConsoleKey.PageDown:
                        break;
                    case ConsoleKey.PageUp:
                        break;
                    case ConsoleKey.Pause:
                        break;
                    case ConsoleKey.Play:
                        break;
                    case ConsoleKey.Print:
                        break;
                    case ConsoleKey.PrintScreen:
                        break;
                    case ConsoleKey.Process:
                        break;
                    case ConsoleKey.Q:
                        break;
                    case ConsoleKey.R:
                        break;
                    case ConsoleKey.RightArrow:
                        if (directions[0] != 3)
                            directions[0] = 1;
                        break;
                    case ConsoleKey.RightWindows:
                        break;
                    case ConsoleKey.S:
                        if (directions[1] != 0)
                            directions[1] = 2;
                        break;
                    case ConsoleKey.Select:
                        break;
                    case ConsoleKey.Separator:
                        break;
                    case ConsoleKey.Sleep:
                        break;
                    case ConsoleKey.Spacebar:
                        break;
                    case ConsoleKey.Subtract:
                        break;
                    case ConsoleKey.T:
                        break;
                    case ConsoleKey.Tab:
                        break;
                    case ConsoleKey.U:
                        break;
                    case ConsoleKey.UpArrow:
                        if (directions[0] != 2)
                            directions[0] = 0;
                        break;
                    case ConsoleKey.V:
                        break;
                    case ConsoleKey.VolumeDown:
                        break;
                    case ConsoleKey.VolumeMute:
                        break;
                    case ConsoleKey.VolumeUp:
                        break;
                    case ConsoleKey.W:
                        if (directions[1] != 2)
                            directions[1] = 0;
                        break;
                    case ConsoleKey.X:
                        break;
                    case ConsoleKey.Y:
                        break;
                    case ConsoleKey.Z:
                        break;
                    case ConsoleKey.Zoom:
                        break;
                    default:
                        break;
                }
                #endregion
            }

            if (Time - Timer > Speed)
                if (CallOnTick())
                    end = false;
                else end = true;
            if (!end) goto a;
            else
                Console.ReadLine();
        }

        public static bool CallOnTick()
        {
            Timer = Time;
            if (directions[0] == 0) possis[0, 1]--;
            else if (directions[0] == 1) possis[0, 0]++;
            else if (directions[0] == 2) possis[0, 1]++;
            else if (directions[0] == 3) possis[0, 0]--;
            if (directions[1] == 0) possis[1, 1]--;
            else if (directions[1] == 1) possis[1, 0]++;
            else if (directions[1] == 2) possis[1, 1]++;
            else if (directions[1] == 3) possis[1, 0]--;
            try
            {
                if (Feld[possis[0, 1], possis[0, 0]] == 0)
                {
                    Feld[possis[0, 1], possis[0, 0]] = 1;
                    Console.SetCursorPosition(possis[0, 0], possis[0, 1]);
                    Console.ForegroundColor = colours[0];
                    Console.Write("█");
                }
                else return false;
                if (Feld[possis[1, 1], possis[1, 0]] == 0)
                {
                    Feld[possis[1, 1], possis[1, 0]] = 2;
                    Console.SetCursorPosition(possis[1, 0], possis[1, 1]);
                    Console.ForegroundColor = colours[1];
                    Console.Write("█");
                }
                else return false;
            }
            catch
            {
                return false;
            }
            //zeichne();
            return true;
        }

        public static void zeichne()
        {
            for (int x = 0; x < sizex; x++)
            {
                for (int y = 0; y < sizey; y++)
                {
                    if (Feld[y, x] > 0)
                    {
                    }
                }
            }
        }

        public static void Init()
        {
            Console.SetBufferSize(sizex, sizey);
            Console.SetWindowSize(sizex, sizey);
            Console.CursorVisible = false;
            Feld[possis[0, 1], possis[0, 0]] = 1;
            Feld[possis[1, 1], possis[1, 0]] = 2;
            zeichne();
        }
    }
}
