using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace GFS
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)] //Dieses struct ConsoleFont, die class ConsoleHelper und das structLayout dingens hab ich kopiert, ich hab es benutzt, um die Schriftart zu verändern, da es nur auf 8x8 richtig funktioniert
    public struct ConsoleFont
    {
        public uint Index;
        public short SizeX, SizeY;
    }

    #region classes
    public static class ConsoleHelper
    {
        [DllImport("kernel32")]
        public static extern bool SetConsoleIcon(IntPtr hIcon);

        [DllImport("kernel32")]
        private extern static bool SetConsoleFont(IntPtr hOutput, uint index);

        private enum StdHandle
        {
            OutputHandle = -11
        }

        [DllImport("kernel32")]
        private static extern IntPtr GetStdHandle(StdHandle index);

        public static bool SetConsoleFont(uint index)
        {
            return SetConsoleFont(GetStdHandle(StdHandle.OutputHandle), index);
        }

        [DllImport("kernel32")]
        private static extern bool GetConsoleFontInfo(IntPtr hOutput, [MarshalAs(UnmanagedType.Bool)]bool bMaximize,
            uint count, [MarshalAs(UnmanagedType.LPArray), Out] ConsoleFont[] fonts);

        [DllImport("kernel32")]
        private static extern uint GetNumberOfConsoleFonts();

        public static uint ConsoleFontsCount
        {
            get
            {
                return GetNumberOfConsoleFonts();
            }
        }

        public static ConsoleFont[] ConsoleFonts
        {
            get
            {
                ConsoleFont[] fonts = new ConsoleFont[GetNumberOfConsoleFonts()];
                if (fonts.Length > 0)
                    GetConsoleFontInfo(GetStdHandle(StdHandle.OutputHandle), false, (uint)fonts.Length, fonts);
                return fonts;
            }
        }

    }

    class Program
    {
        #region ints und blas
        public static string[,] Playermodel1 = new String[9, 6] { { "", "", "█", "█", "", "" }, { "", "", "█", "█", "", "" }, { "", "█", "█", "█", "█", "" }, { "", "█", "█", "█", "█", "" }, { "█", "", "█", "█", "", "█" }, { "", "", "█", "█", "", "" }, { "", "█", "", "", "█", "" }, { "", "█", "", "", "█", "" }, { "", "█", "", "", "█", "" } }; //Das Aussehen
        public static string[,] Playermodel2 = new String[9, 6] { { "", "", "█", "█", "", "" }, { "", "", "█", "█", "", "" }, { "", "█", "█", "█", "█", "" }, { "", "█", "█", "█", "█", "" }, { "█", "", "█", "█", "", "█" }, { "", "", "█", "█", "", "" }, { "", "█", "", "", "█", "" }, { "", "", "█", "", "", "█" }, { "", "", "█", "", "", "█" } };
        public static string[,] Playermodel3 = new String[9, 6] { { "", "", "█", "█", "", "" }, { "", "", "█", "█", "", "" }, { "", "█", "█", "█", "█", "" }, { "", "█", "█", "█", "█", "" }, { "█", "", "█", "█", "", "█" }, { "", "", "█", "█", "", "" }, { "", "█", "", "", "█", "" }, { "█", "", "", "█", "", "" }, { "█", "", "", "█", "", "" } };
        public static string[,] Mercatormodel1 = new String[5, 3] { { "", "☻", "" }, { "█", "█", "█" }, { "", "█", "" }, { "█", "", "█" }, { "█", "", "█" } };
        public static string[,] Monstermodel1 = new String[3, 3] { { "", "-", "" }, { "", "█", "" }, { "█", "", "█" } };
        public static string[,] Monstermodel2 = new String[3, 3] { { "", "-", "" }, { "█", "", "█" }, { "█", "", "█" } };
        public static string[,] LudusModel1 = new String[5, 3] { { "█", "", "█" }, { "█", "", "█" }, { "", "", "" }, { "█", "", "█" }, { "", "█", "" } };
        public static string[,,,,] winneer = new String[2, 2, 6, 3, 3]
        {
            {
                {
                    {
                        {"W"," ","W"},
                        {" ","W"," "},
                        {"W"," ","W"}
                    },
                    {
                        {"I"," ","I"},
                        {" ","I"," "},
                        {"I"," ","I"}
                    },
                    {
                        {"N"," ","N"},
                        {" ","N"," "},
                        {"N"," ","N"}
                    },
                    {
                        {"N"," ","N"},
                        {" ","N"," "},
                        {"N"," ","N"}
                    },
                    {
                        {"E"," ","E"},
                        {" ","E"," "},
                        {"E"," ","E"}
                    },
                    {
                        {"R"," ","R"},
                        {" ","R"," "},
                        {"R"," ","R"}
                    }
                },
                {
                    {
                        {"w"," ","w"},
                        {" ","w"," "},
                        {"w"," ","w"}
                    },
                    {
                        {"i"," ","i"},
                        {" ","i"," "},
                        {"i"," ","i"}
                    },
                    {
                        {"n"," ","n"},
                        {" ","n"," "},
                        {"n"," ","n"}
                    },
                    {
                        {"n"," ","n"},
                        {" ","n"," "},
                        {"n"," ","n"}
                    },
                    {
                        {"e"," ","e"},
                        {" ","e"," "},
                        {"e"," ","e"}
                    },
                    {
                        {"r"," ","r"},
                        {" ","r"," "},
                        {"r"," ","r"}
                    }
                }
            },
            {
                {
                    {
                        {" ","W"," "},
                        {"W"," ","W"},
                        {" ","W"," "}
                    },
                    {
                        {" ","I"," "},
                        {"I"," ","I"},
                        {" ","I"," "}
                    },
                    {
                        {" ","N"," "},
                        {"N"," ","N"},
                        {" ","N"," "}
                    },
                    {
                        {" ","N"," "},
                        {"N"," ","N"},
                        {" ","N"," "}
                    },
                    {
                        {" ","E"," "},
                        {"E"," ","E"},
                        {" ","E"," "}
                    },
                    {
                        {" ","R"," "},
                        {"R"," ","R"},
                        {" ","R"," "}
                    }
                },
                {
                    {
                        {" ","w"," "},
                        {"w"," ","w"},
                        {" ","w"," "}
                    },
                    {
                        {" ","i"," "},
                        {"i"," ","i"},
                        {" ","i"," "}
                    },
                    {
                        {" ","n"," "},
                        {"n"," ","n"},
                        {" ","n"," "}
                    },
                    {
                        {" ","n"," "},
                        {"n"," ","n"},
                        {" ","n"," "}
                    },
                    {
                        {" ","e"," "},
                        {"e"," ","e"},
                        {" ","e"," "}
                    },
                    {
                        {" ","r"," "},
                        {"r"," ","r"},
                        {" ","r"," "}
                    }
                }
            }
        };
        public static string[,,,] Taste = new String[2, 9, 9, 20] //Das ist ein 4D Array! :) Wird fürs Klavier gebraucht
            {
                {
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }, //Das sind die Tasten, wenn sie noch nicht gedrückt sind
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", "A", "A", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    },
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", "H", "S", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    },
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", "c", "D", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    },
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", "d", "F", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    },
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", "e", "G", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    },
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", "f", "H", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    },
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", "g", "J", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    },
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", "a", "K", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    },
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", "h", "L", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    },
                },
                {
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }, //...Und das, wenn sie gedrückt sind
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "A", "A", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    },
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "H", "S", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    },
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "c", "D", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    },
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "d", "F", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    },
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "e", "G", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    },
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "f", "H", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    },
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "g", "J", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    },
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "a", "K", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    },
                    {
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "h", "L", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" },
                        { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█" }
                    }
                }
        };
        public static string[] spanntext = new string[9] { "Entwickler:", "Timo Borner", "Lehrer:", "Herr Holzer", "Tester:", "Timo und Marvin Borner", "Name:", "TOG", "Danke <3" };
        public static string[] auswahl1 = new string[6] { "Bewegungsanimation", "Farbe", "Waffe", "Rüstung", "Pistole", "Abbrechen" }; //Das Angebot des Händlers
        public static string[] auswahl2 = new String[3] { "Snake", "Jump'n' Run", "Abbrechen" }; //Das Angebot des Lududs
        public static int[] cost1 = new int[6] { 5, 10, 20, 50, 100, 0 }; //Und die Preise
        public static int[] cost2 = new int[3] { 10, 20, 0 }; //Und die Preise des Lududs
        public static bool[] schuss = new bool[10] { false, false, false, false, false, false, false, false, false, false }; //Ist ein Schuss des Players unterwegs?
        public static int[,] schusspos = new int[10, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } }; //Wo ist er?
        public static bool[] schuss2 = new bool[10] { false, false, false, false, false, false, false, false, false, false }; //Ist ein Schuss des Monsters unterwegs?
        public static int[,] schusspos2 = new int[10, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } }; // Wo ist er?
        public static bool[] schuss3 = new bool[20] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }; //Das gleiche für den Schuss in der Schießarena
        public static int[,] schusspos3 = new int[20, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };

        public static long starttime, Monsterstarttime, Monster2starttime, sstarttime, jstarttime, musicstarttime;
        public static int Bufferx = 100; //Die Buffergröße in X-Richtung
        public static int Buffery = 100; //Die Buffergröße in Y-Richtung
        public static int Playerx = 47; //Die Playerposition auf der X-Achse
        public static int Playery = 46; //Die Playerpoisition auf der Y-Richtung
        public static bool Update = true; //Heißt, dass der Spieler neu angezeugt werden soll, wenn true
        public static char input = 'g'; //Später die Taste, die der User gedrückt hat
        public static long time = 0; //Meine persönliche Zeit
        public static long timermoney = 0; //Wird benötigt, damit dass Geld erst nach 2s wieder neu auftaucht
        public static int mercatorx = 0; //Die Position des Händlers auf der X-Achse
        public static int mercatory = 0; //Die Position des Händlers auf der Y-Achse
        public static Random rnd = new Random(); //Meine Random Variable
        public static bool mercatorle = false; //Gibt an, ob sich der Spieler im Händler-Menü befindet
        public static int auswahl = 0; //Gibt an, welches "Produkt" des Händlers der Spieler ausgewählt hat
        public static ConsoleKeyInfo cki; //Wird für die Enter-Funktion beim Händler gebraucht
        public static bool bewegung = false; //Gibt an, ob der Spieler die Bewegungsanimation gekauft hat
        public static bool farbe = false; //Gibt an, ob der Spieler die Farbe gekauft hat
        public static bool mercator = false; //Gibt an, ob der Händler bereits gespawnt ist
        public static int money = 0; //Das Geld des Players
        public static int moneyx = 0; //Die Position des Geldes auf der X-Achse
        public static int moneyy = 0; //Die Position des Geldes auf der X-Achse
        public static bool gesammelt = true; //Gibt an, ob der Player das Geld eingesammelt hat
        public static bool firsttime = true; //Wird dafür gebracuht, dass der Player nicht wenn er den Händler verlässt direkt wieder in das Menü kommt und sich dieser neu aufbauen kann, ohne dass er schon angezeigt wird, wenn er eigentlich noch gar nicht gespawnt ist (Das ist dann der Fall firsttime)
        public static bool firsttime2 = true; //Gleich wie beim Mercator
        public static int bewegungsteil = 0; //Wird für die Bewegungsanimation gebraucht, gibt an, in welchem Stadium sich die Bewegung befindet
        public static long bewegungstimer = 0; //Bewirkt, dass die Bewegung nicht in einer Millisekunde von statten geht
        public static bool waffe = false; //Gibt an, ob der Spieler eine Waffe gekauft hat
        public static long timermonster = 0; //der Timer fürs Monster
        public static bool monster = false; //Gibt an, ob bereits ein Monster vorhanden ist
        public static int monsterx = 0; //Die Position des Monsters auf der X-Achse
        public static int monstery = 0; // Die Position des Monsters auf der Y-Achse
        public static int Monstervariable = 0; //Die Variable für den Balken
        public static long Monstertime = 0; //Die Zeit während des Fights
        public static int moneychange; //Wird nur für die zufällige Geldänderung nach dem Fight gebraucht
        public static int layer = 0; //Das "Feld" auf dem sich der Player befindet
        public static bool besiegt1 = false; //Hat der Player das erste Monster bereits besiegt?
        public static bool besiegt2 = false; //Hat der Player das zweite Monster besiegt?
        public static bool besiegt3 = false; //Hat der Player das Ziel getroffen?
        public static bool besiegt4 = false; //Hat der Player das Musicmonster besiegt?
        public static int ludusx = 10; //Die Position der Spielhalle auf der X-Achse
        public static int ludusy = 10; //Die Position der Spielhalle auf der Y-Achse
        public static bool luder = false; //Ist der Player beim Ludus?
        public static bool ludusler = true; //Gleiche Gründe wie Firsttime bei Mercator
        public static int x = 10; //snake Position auf der X-Achse
        public static int y = 9; //Snake Position auf der Y-Achse
        public static int sx = 0; //Herz bei Snake auf der X-Achse
        public static int sy = 0; //Herz bei Snake auf der Y-Achse
        public static int pos = 0; //Position bei Snake im Array
        public static int direction = 0; //Wohin schaut die Schlange?
        public static long times = 0; //Zeut bei Snake
        public static long timem = 0; //Timer bei Snake
        public static int longer = 3; //Wie lang ist die Schlange?
        public static int nopos = 0; //Die Position im Array, die wieder gelöscht wird
        public static int Score = 0; //Der Score in Snake
        public static bool looser = false; //Hat der Spieler in Snake verloren?
        public static int[,] Highscore = new int[10, 1]; //Der Highscore in Snake
        public static bool sound = true; //Der Sound in Snake
        public static int stop = 70; //Die Geschwindigkeit in Snake
        public static bool monster2 = false; //Ist das 2. Monster shon gespawnt?
        public static int monster2x; //Wo ist es auf der X-Achse?
        public static int monster2y; //Und wo auf der Y-Achse?
        public static long monster2timer = 0; //Die Rspw Zeit des Monster2s
        public static bool armor = false; //Hat der Spieler denn auch eine Rüstung?
        public static int monsterkillerx, monsterkillery; //Die Position des Players
        public static int monstersterberx, monstersterbery; //Die Position des Monsters
        public static long timefight2 = 0; //Die Zeit für diesen zweiten Fight
        public static long timerschuss = 0; //Die Zeit für den Schuss des Players
        public static int schussint = 0; //Die Position im Array für den Schuss des Players
        public static int schussint2 = 0; //Die Position im Array für den SChuss des Monsters
        public static long timerschuss2 = 0; //Die Zeit des Schusses des Monsters
        public static int schussint3 = 0; //Auch hier das gleiche für den Schuss in der Schiessarena
        public static long timerschuss3 = 0;
        public static long timerschiesser3 = 0;
        public static bool ckialt = false; //Gibt an, ob die angegeben Taste (Space) alt ist
        public static long timerschiesser = 0; //Begrenzt die Schüsse / Sekunde (Sozusagen)
        public static long timersterber = 0; //Die Begrenzungszeit des Monsters
        public static int monstersterber = 0; //Die Bewegungsrichtung des Monsters
        public static bool playerkiller = true; //Greift das Monster den Player an?
        public static int vorsichtszahl = 0; //Schön vorsichtig und nicht in die Schussbahn laufen... Bei allen 10 Schüssen des Arrays!
        public static bool pistole = false; //Hat der Spieler sich schon eine Pistole gekauft?
        public static bool directionziel = false; //Wo geht das Ziel hin? Da es nur 2 Richtungen gibt, reicht ein boolean
        public static int zielx = 99, ziely = 50; //Wo ist das Ziel?
        public static long timerziel = 0; //Es soll sich nicht in Lichtgeschwindigkei bewegen.
        public static long directioncounter = 0; //Und die Richtung nicht zu schnell ändern
        public static int musicx = rnd.Next(5, 95); //Die Position des Musikzeichens
        public static int musicy = rnd.Next(5, 95);
        public static int ton = 0; //Welcher Ton gerade gespielt wird
        public static int zuschnell = 0; //Die Konsole ist doof: Die sagt, dass keine Taste gedrückt wird, obwohl eine gedrückt wird! :|
        public static bool playing = false;     //Wird im Moment ein Ton beim Piano abgespielt?
        public static string filePath = "test.wav";     //Der Path für den Ton
        public static bool musicend = false;                //Hat der Gegner schon fertig gespielt?
        public static bool musicendplayer = false;          //Hat der Player fertiggespielt?
        public static int[] enemymelody = new int[100];     //Die Melodie des Gegners...
        public static int[] usermelody = new int[100];      //...Und die des Players
        public static int melodyenemylength = 2;            //Die Länge der Melodie - standardmäßig 4
        public static SoundPlayer player = new SoundPlayer(filePath);     //Die SoundPlayer Klasse wird verwendet
        public static long timemusic = 0;           //Die Töne des Gegners sollen auch ein bisschen anhalten
        public static long musictimer = 0;
        public static int emp = 0;                  //Die Enemy Melody Position - Also die Position im Array der Melodie beim Gegner
        public static int pmp = 0;                  //Und die Player Melody Position
        public static bool gotmelody;               //Hat der User die Melodie nachgespielt?
        public static ConsoleKeyInfo garbage;       //Damit die TAste, die der User gedrückt hat, als er in die Noten gerannt ist, nicht auch als Anschlag zählt
        public static long winnertimer = 0;         //Der Timer für dieses fantastische winnerportal
        public static int[] winnerpos = new int[3] { 0, 0, 0 };     //In welchem Teil ist es denn gerade?
        public static bool ende = false;            //Ist das das ENDE?
        public static long timerabspann = 0;        //Der Timer für den Ab-(und Vor-)spann
        public static int line = -10;               //Die Linie im Ab-/Vorspann
        public static bool mercatorspawned = false; //Ist der Mercator gespawnt? Brauch ich, weil ich das ursprüngliche Boolean dafür missbraucht habe
        #endregion

        #region voids
        static void Main(string[] args)
        {
            PreInit();
            while (!ende)                                             //Meine Loop
            {                                                           //Meine persönliche Zeit soll natürlich auch laufen
                time = Convert.ToInt64(Math.Round(Convert.ToDecimal((DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 60000 + DateTime.Now.Hour * 3600000 + DateTime.Now.DayOfYear * 86400000 - starttime) / 2)));
                //Das mit der Zeit war auch mal einfacher, aber dann lief die Zeit an unterschiedlichen Computern unterschiedlich schnell :D Jetzt hab ich eben die Ursprungszeit genommen, die Startzeit davon abgezogen und halbiert (Weil ich alles mit der vorherigen Zeit programmiert hab und es da ungefähr halb so schnell war), und das auch noch bei jedem Durchlauf. Der Vorteil ist, dass die Systemzeit nicht von der Geschwindigkeit des pCs abhängt.
                Bewegung();                                          //Die Verarbeitung der Taste, die der User gedrückt hat
                Bewegungsupdate();                                   //Er soll sich tatsächlich auch bewegen
                Geld();                                              //Money money money...
                Monster();                                           //Das erste Monster (der ersten Ebene)
                Monster2();                                          //Und das zweite
                Mercator();                                          //Der Händler
                Ludusstart();                                        //Die Spielehalle
                Schiessstand();                                      //Die dritte Ebene
                Musikzeichen();                                      //Der Musikunterricht
                if (besiegt4 && layer == 4)
                    winner();
                end();
                Console.SetWindowPosition(0, 0);
            }
        }

        private static void end()
        {
            if (layer == 4 && Playerx < 52 && Playery < 52 && Playerx > 43 && Playery > 40)
            {
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }
                Console.Clear();
                abspann();
                ende = true;
                logo();
            }
        }

        private static void logo()
        {
            Console.SetCursorPosition(0, 50);
            Console.WriteLine("TTTTTTTTTTTTTTTTTTTTTTT     OOOOOOOOO             GGGGGGGGGGGGG");
            Thread.Sleep(100);
            Console.WriteLine("T:::::::::::::::::::::T   OO:::::::::OO        GGG::::::::::::G");
            Thread.Sleep(100);
            Console.WriteLine("T:::::::::::::::::::::T OO:::::::::::::OO    GG:::::::::::::::G");
            Thread.Sleep(100);
            Console.WriteLine("T:::::TT:::::::TT:::::TO:::::::OOO:::::::O  G:::::GGGGGGGG::::G");
            Thread.Sleep(100);
            Console.WriteLine("TTTTTT  T:::::T  TTTTTTO::::::O   O::::::O G:::::G       GGGGGG");
            Thread.Sleep(100);
            Console.WriteLine("        T:::::T        O:::::O     O:::::OG:::::G");
            Thread.Sleep(100);
            Console.WriteLine("        T:::::T        O:::::O     O:::::OG:::::G");
            Thread.Sleep(100);
            Console.WriteLine("        T:::::T        O:::::O     O:::::OG:::::G    GGGGGGGGGG");
            Thread.Sleep(100);
            Console.WriteLine("        T:::::T        O:::::O     O:::::OG:::::G    G::::::::G");
            Thread.Sleep(100);
            Console.WriteLine("        T:::::T        O:::::O     O:::::OG:::::G    GGGGG::::G");
            Thread.Sleep(100);
            Console.WriteLine("        T:::::T        O:::::O     O:::::OG:::::G        G::::G");
            Thread.Sleep(100);
            Console.WriteLine("        T:::::T        O::::::O   O::::::O G:::::G       G::::G");
            Thread.Sleep(100);
            Console.WriteLine("      TT:::::::TT      O:::::::OOO:::::::O  G:::::GGGGGGGG::::G");
            Thread.Sleep(100);
            Console.WriteLine("      T:::::::::T       OO:::::::::::::OO    GG:::::::::::::::G");
            Thread.Sleep(100);
            Console.WriteLine("      T:::::::::T         OO:::::::::OO        GGG::::::GGG:::G");
            Thread.Sleep(100);
            Console.WriteLine("      TTTTTTTTTTT           OOOOOOOOO             GGGGGG   GGGG");
            Thread.Sleep(1000);
        }

        private static void abspann()
        {
            starttime = DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 60000 + DateTime.Now.Hour * 3600000 + DateTime.Now.DayOfYear * 86400000;
            while (true)
            {
                time = Convert.ToInt64(Math.Round(Convert.ToDecimal((DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 60000 + DateTime.Now.Hour * 3600000 + DateTime.Now.DayOfYear * 86400000 - starttime) / 2)));
                if (time - timerabspann > 100)
                {
                    Console.Clear();
                    timerabspann = time;
                    line++;
                    for (int i = 0; i < 9; i++)
                    {
                        if (line + i > 0 && line + i < Buffery)
                        {
                            Console.SetCursorPosition(20, line + i);
                            Console.WriteLine(spanntext[i]);
                        }
                    }
                    if (line > Buffery + 10)
                        return;
                }
            }
        }

        private static void winner()
        {
            if (farbe)
                Console.ForegroundColor = ConsoleColor.Black;
            if (time - winnertimer > 100)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int u = 0; u < 3; u++)
                    {
                        Console.SetCursorPosition(49 + i, 49 + u);
                        Console.Write(winneer[winnerpos[0], winnerpos[1], winnerpos[2], i, u]);
                    }
                }
                if (winnerpos[0] < 1)
                    winnerpos[0]++;
                else
                {
                    winnerpos[0] = 0;
                    if (winnerpos[1] < 1)
                        winnerpos[1]++;
                    else
                    {
                        winnerpos[1] = 0;
                        if (winnerpos[2] < 5)
                            winnerpos[2]++;
                        else
                            winnerpos[2] = 0;
                    }
                }
                winnertimer = time;
            }
        }

        private static void PreInit()
        {
            Console.CursorSize = 1;
            ConsoleHelper.SetConsoleFont(2);
            if (Console.LargestWindowHeight < 100 || Console.LargestWindowWidth < 100)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("Es tut mir ja sehr leid, aber sie haben einen zu kleinen Monitor :/ Probieren sie die Standardschriftart auf Rasterschriftart umzustellen...");
                ende = true;
                Console.ReadKey(true);
                return;
            }

            if (!ende)
            {
                Console.Title = "TOG";

                for (int i = 0; i < 10; i++)
                {
                    Highscore[i, 0] = 0;
                }
                time = 0;                                               //Alles wird initialisiert
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.CursorVisible = false;
                Console.SetWindowSize(Bufferx, Buffery - 1);
                logo();
                Console.Clear();

                Console.SetBufferSize(Bufferx, Buffery);
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                for (int i = 50; i < 100; i++)
                {
                    for (int u = 50; u < 100; u++)
                    {
                        Console.SetCursorPosition(i, u);
                        Console.Write("░");
                    }
                }
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.SetCursorPosition(0, 0);
                Console.Write("Geld: " + money + "   ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            starttime = DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 60000 + DateTime.Now.Hour * 3600000 + DateTime.Now.DayOfYear * 86400000;
        }

        private static void Mercator()
        {
            if (time >= 1000 && layer == 0 && !mercator && !mercatorspawned)                                     //Da ist ja ein Händler!
            {
                mercator = true;
                mercatorspawned = true;
                mercatorx = rnd.Next(0, 96);
                mercatory = rnd.Next(0, 93);
                position(2);
                time = 1001;
            }
            if (time > 1000 && Playerx > mercatorx - 6 && Playerx < mercatorx + 3 && Playery > mercatory - 9 && Playery < mercatory + 5 && mercator && layer == 0 && mercatorspawned) //Jetzt hat sich der Player auch noch auf den armen Händler gehockt
            {
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;                //immer diese betrunkenen Händler
                }
                Console.Clear();
                Console.SetCursorPosition(20, 20);
                Console.Write("Hallo! Ich bin der Mercator! Möchtest du etwas kaufen?"); //JA!
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.SetCursorPosition(20, 40);                          //Tolle Angebote hat unser Mercator!
                Console.Write("Bewegungsanimation");
                Console.SetCursorPosition(40, 40);
                Console.Write("Kosten: " + cost1[0]);
                Console.SetCursorPosition(20, 41);
                Console.Write("Farbe");
                Console.SetCursorPosition(40, 41);
                Console.Write("Kosten: " + cost1[1]);
                Console.SetCursorPosition(20, 42);
                Console.Write("Waffe");
                Console.SetCursorPosition(40, 42);
                Console.Write("Kosten: " + cost1[2]);
                Console.SetCursorPosition(20, 43);
                Console.Write("Rüstung");
                Console.SetCursorPosition(40, 43);
                Console.Write("Kosten: " + cost1[3]);
                Console.SetCursorPosition(20, 44);
                Console.Write("Pistole");
                Console.SetCursorPosition(40, 44);
                Console.Write("Kosten: " + cost1[4]);
                Console.SetCursorPosition(20, 45);
                Console.Write("Abbrechen");
                mercatorle = true;
                while (mercatorle)
                {
                    Console.SetCursorPosition(20, 40 + auswahl);                //Ist das jetzt eine GUI?
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(auswahl1[auswahl]);
                    cki = Console.ReadKey(true);
                    input = cki.KeyChar;
                    if (input == 's' && auswahl < 5)
                    {
                        Console.SetCursorPosition(20, 40 + auswahl);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(auswahl1[auswahl]);
                        auswahl++;
                    }
                    else if (input == 'w' && auswahl > 0)
                    {
                        Console.SetCursorPosition(20, 40 + auswahl);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(auswahl1[auswahl]);
                        auswahl--;
                    }
                    if (cki.Key == ConsoleKey.Enter && (money >= cost1[auswahl] || auswahl == 5))     //Der kauft ja sogar was ein
                    {
                        if (auswahl == 0)
                        {
                            if (!bewegung)                                              //Die schönste Bewegungsanimation aller ZeiteN!
                            {
                                bewegung = true;
                                money = money - cost1[auswahl];
                            }
                            mercatorle = false;
                            mercator = false;
                        }
                        else if (auswahl == 1)
                        {
                            if (!farbe)                                                 //Colourmatic!
                            {
                                farbe = true;
                                money = money - cost1[auswahl];
                            }
                            mercatorle = false;
                            mercator = false;
                        }
                        else if (auswahl == 2)
                        {
                            if (!waffe)                                              //So eine schöne Waffe
                            {
                                waffe = true;
                                money = money - cost1[auswahl];
                                Playermodel1[5, 5] = "|";
                                Playermodel2[5, 5] = "|";
                                Playermodel3[5, 5] = "|";
                                timermonster = time;
                            }
                            mercatorle = false;
                            mercator = false;
                        }
                        else if (auswahl == 3)                                          //Ich hab noch nie eine schönere Rüstung gesehen.
                        {
                            if (!armor)
                            {
                                armor = true;
                                money = money - cost1[auswahl];
                                Playermodel1[4, 1] = "▓";
                                Playermodel2[4, 1] = "▓";
                                Playermodel3[4, 1] = "▓";
                                Playermodel1[5, 1] = "▓";
                                Playermodel2[5, 1] = "▓";
                                Playermodel3[5, 1] = "▓";
                                Playermodel1[4, 4] = "▓";
                                Playermodel2[4, 4] = "▓";
                                Playermodel3[4, 4] = "▓";
                                Playermodel1[5, 4] = "▓";
                                Playermodel2[5, 4] = "▓";
                                Playermodel3[5, 4] = "▓";
                            }
                            mercatorle = false;
                            mercator = false;
                        }
                        else if (auswahl == 4)
                        {
                            if (!pistole)                                              //So eine böse Pistole
                            {
                                pistole = true;
                                money = money - cost1[auswahl];
                                Playermodel1[3, 5] = "╔";
                                Playermodel2[3, 5] = "╔";
                                Playermodel3[3, 5] = "╔";
                                timermonster = time;
                            }
                            mercatorle = false;
                            mercator = false;
                        }
                        else if (auswahl == 5)
                        {
                            mercatorle = false;                                          //Und alles soll wieder so sein wie vorher...
                            mercator = false;
                        }
                        auswahl = 0;
                        Console.ResetColor();
                        Console.Clear();
                        if (layer == 0)
                        {
                            if (farbe)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }
                            for (int i = 50; i < 100; i++)
                            {
                                for (int u = 50; u < 100; u++)
                                {
                                    Console.SetCursorPosition(i, u);
                                    Console.Write("░");
                                }
                            }
                        }
                        if (!gesammelt)
                        {
                            Console.SetCursorPosition(moneyx, moneyy);
                            if (farbe)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            Console.Write("E");
                        }
                        if (farbe)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        Console.SetCursorPosition(0, 0);
                        Console.Write("Geld: " + money + "   ");
                        firsttime = false;
                        Update = true;
                    }
                }
            }
            else if (!(time > 1000 && Playerx > mercatorx - 6 && Playerx < mercatorx + 3 && Playery > mercatory - 9 && Playery < mercatory + 5) && !mercator && !firsttime && layer == 0) //Und wenn der Player dann mal wieder vom Mercator runter gegangen ist, soll dieser auch wieder auftauchen
            {
                mercator = true;
                position(2);
            }
        }

        private static void Ludusstart()
        {
            if (Playerx > ludusx - 6 && Playerx < ludusx + 3 && Playery > ludusy - 9 && Playery < ludusy + 5 && layer == 1 && ludusler)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                ludus();                                //Spielhallen sind toll
            }
            else if (!(Playerx > ludusx - 6 && Playerx < ludusx + 3 && Playery > ludusy - 9 && Playery < ludusy + 5) && !firsttime2 && layer == 1) //Und wenn der Player dann mal wieder vom Ludus runter gegangen ist, soll dieser auch wieder auftauchen -> Gleich wie beim Mercator
            {
                ludusler = true;
                position(6);
            }
        }

        private static void ludus()
        {
            luder = true;
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.Clear();
            Console.SetCursorPosition(20, 20);
            Console.Write("Willkommen bei Ludus, der ultimativen Spielhalle! Was möchtest du spielen?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(20, 40);                          //Tolle Spiele hat unser Ludus!
            Console.Write("Snake");
            Console.SetCursorPosition(40, 40);
            Console.Write("Kosten: " + cost2[0]);
            Console.SetCursorPosition(20, 41);
            Console.Write("Jump'n' Run");
            Console.SetCursorPosition(40, 41);
            Console.Write("Kosten: " + cost2[1]);
            Console.SetCursorPosition(20, 42);
            Console.Write("Abbrechen");
            while (luder)                                                   //So ein Luder...
            {
                Console.SetCursorPosition(20, 40 + auswahl);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(auswahl2[auswahl]);
                cki = Console.ReadKey(true);
                input = cki.KeyChar;
                if (input == 's' && auswahl < 2)
                {
                    Console.SetCursorPosition(20, 40 + auswahl);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(auswahl2[auswahl]);
                    auswahl++;
                }
                else if (input == 'w' && auswahl > 0)
                {
                    Console.SetCursorPosition(20, 40 + auswahl);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(auswahl2[auswahl]);
                    auswahl--;
                }
                if (cki.Key == ConsoleKey.Enter && (money >= cost2[auswahl] || auswahl == 2))     //Der spielt ja sogar was
                {
                    Console.ResetColor();
                    if (auswahl == 0)
                    {
                        Snake();
                        luder = false;
                    }
                    else if (auswahl == 1)
                    {
                        Jumpy();
                        luder = false;
                    }
                    else if (auswahl == 2)
                    {
                        luder = false;
                    }
                    money = money - cost2[auswahl];                             //RESET! - Fast
                    ludusler = false;
                    Console.ResetColor();
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    Console.Clear();
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Geld: " + money + "   ");
                    firsttime2 = false;
                    auswahl = 0;
                }
            }
        }

        private static void Schiessstand()
        {
            if (time - timerschuss3 > 100 && layer == 2 && pistole) //Der Schuss fliegt... Oder alle :D
            {
                for (int i = 0; i < schuss3.Length; i++)
                {
                    if (schuss3[i] && schusspos3[i, 0] < Bufferx - 1)
                    {
                        Console.SetCursorPosition(schusspos3[i, 0], schusspos3[i, 1]);
                        Console.Write(" ");
                        schusspos3[i, 0]++;
                        Console.SetCursorPosition(schusspos3[i, 0], schusspos3[i, 1]);
                        if (farbe)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Console.Write("o");
                    }
                    else if (schuss3[i]) //Oder verschwindet
                    {
                        Console.SetCursorPosition(schusspos3[i, 0], schusspos3[i, 1]);
                        Console.Write(" ");
                        schuss3[i] = false;
                    }
                    if (schusspos3[i, 0] == zielx && schusspos3[i, 1] == ziely && schuss3[i]) //Oder trifft
                    {
                        Console.SetCursorPosition(schusspos3[i, 0], schusspos3[i, 1]);
                        Console.Write(" ");
                        money += 20;
                        if (farbe)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        Console.SetCursorPosition(0, 0);
                        Console.Write("Geld: " + money + "            ");
                        if (farbe) { Console.ForegroundColor = ConsoleColor.Green; }
                        if (!besiegt3)
                        {
                            Console.SetCursorPosition(20, 0);
                            Console.Write("Du kannst nun zur unteren Ebene gehen!"); //YAY
                            ziely = 50;
                        }
                        besiegt3 = true;
                    }
                }
                timerschuss3 = time;
            }
            if (time - timerziel > 500 && layer == 2) //Das böse Ziel bewegt sich auch ncoh...
            {
                timerziel = time;
                directioncounter++;
                if (directioncounter > 3)
                {
                    directioncounter = 0;
                    directionziel = rnd.Next(1, 3) == 2;
                }
                Console.SetCursorPosition(zielx, ziely);
                Console.Write(" ");
                if (directionziel && ziely > 6)
                {
                    ziely--;
                }
                else if (ziely < 92)
                {
                    ziely++;
                }
                Console.SetCursorPosition(zielx, ziely);
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write("♠");
            }
        }

        private static void Musikzeichen()
        {
            if (Playerx + 5 >= musicx && Playerx <= musicx && Playery + 8 >= musicy && Playery <= musicy && layer == 3) //Er hat das Musikzeichen gefunden!
            {
                musicx = rnd.Next(5, 95);
                musicy = rnd.Next(5, 95);
                music();
                Console.SetCursorPosition(musicx, musicy);
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.Write("♫"); //Und es gibt ein neues....
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.SetCursorPosition(0, 0);
                Console.Write("Geld: " + money);
            }
        }

        private static void Bewegung()
        {
            if (Console.KeyAvailable)                                        //Der Player hat die offizielle Erlaubnis, sich zu bewegen
            {
                input = Console.ReadKey(true).KeyChar;
                if (input == 'd' && Playerx < Bufferx - 6 && (layer != 2 || Playerx < 5))
                {
                    motion();
                    Playerx++;
                    Update = true;
                }
                else if (input == 'd' && Playerx == Bufferx - 6 && layer == 0 && besiegt2) //Der Wechsel auf die Schießbudenebene (Ebene 2)
                {
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    }
                    layer = 2;
                    Console.Clear();
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Geld: " + money);
                    Playerx = 0;
                    Update = true;
                    Console.SetCursorPosition(zielx, ziely);
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write("♠");
                }
                else if (input == 'd' && Playerx == Bufferx - 6 && layer == 4)
                {
                    if (farbe)
                        Console.BackgroundColor = ConsoleColor.Black;
                    layer = 0;
                    Console.Clear();
                    if (farbe)
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    for (int i = 50; i < 100; i++)
                    {
                        for (int u = 50; u < 100; u++)
                        {
                            Console.SetCursorPosition(i, u);
                            Console.Write("░");
                        }
                    }
                    position(2);
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Geld: " + money);
                    if (!gesammelt)
                    {
                        Console.SetCursorPosition(moneyx, moneyy);
                        if (farbe)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        Console.Write("E");
                    }
                    Playerx = 0;
                    Update = true;
                }
                if (input == 'a' && Playerx > 0)
                {
                    motion();
                    Playerx--;
                    Update = true;
                }
                else if (input == 'a' && Playerx == 0 && layer == 0 && besiegt4)
                {
                    if (farbe)
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    layer = 4;
                    Console.Clear();
                    if (farbe)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Geld: " + money);
                    if (farbe)
                        Console.ForegroundColor = ConsoleColor.Black;
                    Playerx = Bufferx - 6;
                    Update = true;
                }
                else if (input == 'a' && Playerx == 0 && layer == 2)  //Und zurück auf die Hauptebene
                {
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    layer = 0;
                    Console.Clear();
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    for (int i = 50; i < 100; i++)
                    {
                        for (int u = 50; u < 100; u++)
                        {
                            Console.SetCursorPosition(i, u);
                            Console.Write("░");
                        }
                    }
                    position(2);
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Geld: " + money);
                    if (!gesammelt)
                    {
                        Console.SetCursorPosition(moneyx, moneyy);
                        if (farbe)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        Console.Write("E");
                    }
                    Playerx = Bufferx - 6;
                    Update = true;
                }
                if (input == 'w' && (Playery > 0 && layer != 2 || Playery > 1 && layer == 2))
                {
                    motion();
                    Playery--;
                    Update = true;
                }
                else if (input == 'w' && Playery == 0 && layer == 0 && besiegt1)                   //Er kommt auf einen höheren layer
                {
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    if (!monster2 && armor)
                    {
                        monster2timer = time;
                    }
                    layer = 1;
                    Console.Clear();
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Geld: " + money);
                    position(6);
                    Playery = 90;
                    Update = true;
                }
                else if (input == 'w' && Playery == 0 && layer == 3) //Hier immer dasselbe...
                {
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    layer = 0;
                    Console.Clear();
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    for (int i = 50; i < 100; i++)
                    {
                        for (int u = 50; u < 100; u++)
                        {
                            Console.SetCursorPosition(i, u);
                            Console.Write("░");
                        }
                    }
                    position(2);
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Geld: " + money);
                    if (!gesammelt)
                    {
                        Console.SetCursorPosition(moneyx, moneyy);
                        if (farbe)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        Console.Write("E");
                    }
                    Playery = Bufferx - 10;
                    Update = true;
                }
                if (input == 's' && (Playery < Buffery - 10 && layer != 2 || Playery < Buffery - 11 && layer == 2))
                {
                    motion();
                    Playery++;
                    Update = true;
                }
                else if (input == 's' && Playery == Buffery - 10 && layer == 1)
                {
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    layer = 0;
                    Console.Clear();
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    for (int i = 50; i < 100; i++)
                    {
                        for (int u = 50; u < 100; u++)
                        {
                            Console.SetCursorPosition(i, u);
                            Console.Write("░");
                        }
                    }
                    position(2);
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Geld: " + money);
                    if (!gesammelt)
                    {
                        Console.SetCursorPosition(moneyx, moneyy);
                        if (farbe)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        Console.Write("E");
                    }
                    Playery = 0;
                    Update = true;
                }
                else if (input == 's' && Playery == Buffery - 10 && layer == 0 && besiegt3)
                {
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    Console.Clear();
                    layer = 3;
                    Playery = 0;
                    Update = true;
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Geld: " + money + "              ");
                    Console.SetCursorPosition(musicx, musicy);
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Console.Write("♫");
                }
                else if (input == 'f' && layer == 2 && pistole)
                {
                    if (time - timerschiesser3 > 500 && !schuss3[schussint3])
                    {
                        schuss3[schussint3] = true;
                        schusspos3[schussint3, 0] = Playerx + 6;
                        schusspos3[schussint3, 1] = Playery + 3;
                        timerschiesser3 = time;
                        if (farbe)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Console.SetCursorPosition(schusspos3[schussint3, 0], schusspos3[schussint3, 1]);
                        Console.Write("o");
                        schussint3++;
                        if (schussint3 > 19) schussint3 = 0;
                    }
                }
                input = 'g';                                                    //g ist ein toller Buchstabe
            }
        }

        private static void Bewegungsupdate()
        {
            if (Update)                                              //Hat der Player sich etwa gerade bewegt?!
            {
                if (!bewegung)
                {
                    position(1);
                }
                Update = false;
                if (bewegung)                                            //Hat er denn schon eine Bewegungsanimation gekauft?
                {
                    bewegungsteil = 1;
                    bewegungstimer = time;
                    position(3);
                }
            }
            if (bewegungsteil == 1 && time - bewegungstimer > 100)       //Hier ist sie auf jeden Fall
            {
                bewegungsteil = 2;
                position(4);
                bewegungstimer = time;
            }
            else if (bewegungsteil == 2 && time - bewegungstimer > 100)
            {
                bewegungsteil = 0;
                position(1);
                bewegungstimer = time;
            }
        }

        private static void Geld()
        {
            if (time - timermoney > 1000 && gesammelt && layer == 0)            //Und immer mal wieder soll Geld spawnen
            {
                moneyx = rnd.Next(1, 100);                       //natürlich random
                moneyy = rnd.Next(1, 99);
                Console.SetCursorPosition(moneyx, moneyy);
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.Write("E");
                gesammelt = false;                                  //Und dann ist es nicht mehr gesammelt
            }
            if (!gesammelt && (Playerx <= moneyx && Playerx + 5 >= moneyx && Playery <= moneyy && Playery + 8 >= moneyy) && layer == 0) //Der Player kann es aber wieder einsammeln :)
            {
                timermoney = time;
                gesammelt = true;
                money++;
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.SetCursorPosition(0, 0);
                Console.Write("Geld: " + money + "   ");
            }
        }

        private static void Monster()
        {
            if (waffe && time - timermonster > 10000 && !monster && layer == 0) //Das Monster SPAWNT
            {
                monsterx = rnd.Next(50, 96);                      //Natürlich random
                monstery = rnd.Next(50, 95);
                position(5);                                     //Und hat schon von Anfang an eine Textur
                monster = true;
            }
            if (monster && time - timermonster > 200 && layer == 0)            //Es soll sich auf den Spieler zu bewegen
            {
                timermonster = time;
                if (Playerx > monsterx)
                {
                    motionMonster();
                    monsterx++;
                }
                else if (Playerx < monsterx && monsterx > 50)
                {
                    motionMonster();
                    monsterx--;
                }
                if (Playery > monstery)
                {
                    motionMonster();
                    monstery++;
                }
                else if (Playery < monstery && monstery >= 50)
                {
                    motionMonster();
                    monstery--;
                }
                position(5);
                if (Playery <= monstery + 2 && Playery + 8 >= monstery && Playerx <= monsterx + 2 && Playerx + 5 >= monsterx)
                {
                    Monsterfight();                             //Und wenn es angekommen ist, geht der Monster Fight los
                }
            }
        }

        private static void Monster2()
        {
            if (armor && time - monster2timer > 5000 && !monster2 && layer == 1) //Das zweite Monster spawnt
            {
                monster2x = rnd.Next(1, 90);
                monster2y = rnd.Next(1, 90);
                position(7);
                monster2 = true;
            }
            if (monster2 && time - monster2timer > 200 && layer == 1)            //Es soll sich auch auf den Spieler zu bewegen
            {
                monster2timer = time;
                if (Playerx > monster2x)
                {
                    motionMonster2();
                    monster2x++;
                }
                else if (Playerx < monster2x)
                {
                    motionMonster2();
                    monster2x--;
                }
                if (Playery > monster2y)
                {
                    motionMonster2();
                    monster2y++;
                }
                else if (Playery < monster2y)
                {
                    motionMonster2();
                    monster2y--;
                }
                position(7);
                if (Playery <= monster2y + 2 && Playery + 8 >= monster2y && Playerx <= monster2x + 2 && Playerx + 5 >= monster2x)
                {
                    Monsterfight2();                             //Und wenn es angekommen ist, geht wieder ein Monster Fight los
                }
            }
        }

        private static void music()
        {
            Console.ResetColor();
            if (farbe)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            Console.Clear();
            Console.SetCursorPosition(10, 10);
            Console.Write("Spiele die Melodie nach! Wenn du fertig bist, schlage eine weitere Taste an!");
            for (int i = 0; i < 9; i++)                         //Alle Tasten (Natürlich unageschalgen)
            {
                for (int u = 0; u < 9; u++)
                {
                    for (int o = 0; o < 20; o++)
                    {
                        Console.SetCursorPosition(u + 9 * i + 10, o + 40);
                        Console.Write(Taste[0, i, u, o]);
                    }
                }
            }
            emp = 0;
            pmp = 0;
            musicend = false;
            musicenemy();
            player.Stop();
            musicendplayer = false;
            while (Console.KeyAvailable)
                garbage = Console.ReadKey(true);
            while (!musicendplayer)
            {
                if (Console.KeyAvailable)
                {
                    input = Console.ReadKey(true).KeyChar;
                    if (input == 'a' && ton != 1)                   //Alle Töne, die angeschlagen werden können
                    {
                        tonechange(1, ton);
                        playTone(220, 1);
                    }
                    else if (input == 's' && ton != 2)              //das gleiche für die anderen Töne
                    {
                        tonechange(2, ton);
                        playTone(246, 2);
                    }
                    else if (input == 'd' && ton != 3)
                    {
                        tonechange(3, ton);
                        playTone(261, 3);
                    }
                    else if (input == 'f' && ton != 4)
                    {
                        tonechange(4, ton);
                        playTone(293, 4);
                    }
                    else if (input == 'g' && ton != 5)
                    {
                        tonechange(5, ton);
                        playTone(329, 5);
                    }
                    else if (input == 'h' && ton != 6)
                    {
                        tonechange(6, ton);
                        playTone(349, 6);
                    }
                    else if (input == 'j' && ton != 7)
                    {
                        tonechange(7, ton);
                        playTone(391, 7);
                    }
                    else if (input == 'k' && ton != 8)
                    {
                        tonechange(8, ton);
                        playTone(440, 8);
                    }
                    else if (input == 'l' && ton != 9)
                    {
                        tonechange(9, ton);
                        playTone(493, 9);
                    }
                    input = 'v';
                }
                zuschnell++;

                if (Console.KeyAvailable) zuschnell = 0;

                Thread.Sleep(5);
                if (Console.KeyAvailable) zuschnell = 0;

                if (!Console.KeyAvailable)
                {

                    if (zuschnell > 50)
                    {
                        stopTone();
                    }
                }
            }
            Console.ResetColor();       //Und wieder alles auf Standards - fast
            if (farbe)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
            }
            Console.Clear();
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.SetCursorPosition(0, 0);
            Console.Write("Geld: " + money);
            Update = true;
            player.Stop();
            ton = 0;
            input = 'v';
        }

        private static void tonechange(int newton, int oldton)
        {
            if (pmp < melodyenemylength)
            {
                usermelody[pmp] = newton;
                pmp++;
            }
            else
            {
                musicendplayer = true;
                gotmelody = true;
                for (int i = 0; i < melodyenemylength; i++)
                {
                    if (enemymelody[i] != usermelody[i])
                        gotmelody = false;
                }
                Console.Clear();
                Console.SetCursorPosition(9, 40);
                if (gotmelody)
                {
                    if (farbe)
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    melodyenemylength++;
                    Console.Write("Du hast die Melodie nachgespielt! Das nächste Mal ist die Melodie " + melodyenemylength + " Töne lang!");
                    if (melodyenemylength > 5 && !besiegt4)
                    {
                        Console.SetCursorPosition(20, 42);
                        Console.Write("Du hast die linke Eben freigeschalten!");
                        besiegt4 = true;
                    }
                    moneychange = rnd.Next(1, melodyenemylength * 10);
                }
                else
                {
                    if (farbe)
                        Console.ForegroundColor = ConsoleColor.Red;
                    melodyenemylength = 2;
                    Console.Write("Du hast die Melodie nicht nachgespielt! Das nächste Mal ist die Melodie wieder 2 Töne lang!");
                    moneychange = rnd.Next(melodyenemylength * (-10), -1);
                }
                Console.SetCursorPosition(40, 41);
                Console.Write(moneychange + " Geld!");
                money += moneychange;
                Thread.Sleep(500);
                Console.ReadKey(true);
                ton = 0;
            }
        }

        private static void musicenemy()
        {
            musicstarttime = DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 60000 + DateTime.Now.Hour * 3600000 + DateTime.Now.DayOfYear * 86400000;
            musictimer = 0;
            if (!musicend)
            {
                for (int i = 0; i < melodyenemylength; i++)
                {
                    enemymelody[i] = rnd.Next(1, 9);
                    if (i > 0)
                    {
                        while (enemymelody[i] == enemymelody[i - 1])
                        {
                            enemymelody[i] = rnd.Next(1, 9);
                        }
                    }
                }
                while (!musicend)
                {
                    timemusic = Convert.ToInt64(Math.Round(Convert.ToDecimal((DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 60000 + DateTime.Now.Hour * 3600000 + DateTime.Now.DayOfYear * 86400000 - musicstarttime) / 2)));
                    if (timemusic - musictimer > 500)
                    {
                        if (enemymelody[emp] == 1)
                            playTone(220, 1);
                        else if (enemymelody[emp] == 2)
                            playTone(246, 2);
                        else if (enemymelody[emp] == 3)
                            playTone(261, 3);
                        else if (enemymelody[emp] == 4)
                            playTone(293, 4);
                        else if (enemymelody[emp] == 5)
                            playTone(329, 5);
                        else if (enemymelody[emp] == 6)
                            playTone(349, 6);
                        else if (enemymelody[emp] == 7)
                            playTone(391, 7);
                        else if (enemymelody[emp] == 8)
                            playTone(440, 8);
                        else if (enemymelody[emp] == 9)
                            playTone(493, 9);
                        musictimer = timemusic;
                        if (emp < melodyenemylength)
                            emp++;
                        else
                        {
                            musicend = true;
                            player.Stop();
                        }
                    }
                }
            }
        }

        private static void playTone(int tone, int toner)
        {
            if (ton != 0)
            {
                for (int u = 0; u < 9; u++)
                {
                    for (int o = 0; o < 20; o++)
                    {
                        Console.SetCursorPosition(u + 9 * ton + 1, o + 40);       //Die alte Taste wird erstmal wieder resettet
                        Console.Write(Taste[0, ton - 1, u, o]);
                    }
                }
            }
            player.Stop();                  //Das alte soll aufhören
            WaveGenerator wave = new WaveGenerator(WaveExampleType.Beeper, tone);        //Der Ton wird erstellt. Ich hätte auch einmal alle Töne speichern können, habe darauf aber keine Lust :p Außerdem spar ich so Speicherplatz :D
            wave.Save(filePath);
            player.PlayLooping();       //Der Ton soll dann die ganze Zeit kommen
            ton = toner;                    //Und es wird angegeben, welcher Ton gespielt wird, wobei 0 kein Ton ist, 1 der a-Ton, 2 der s-Ton, ...
            playing = true;             //Und es wird gespielt
            if (ton > 0)                //Dieses Ton > 0 ist eigentlich unnötig, aber zur Sicherheit... Ich hasse eben Out of Length Exceptions
            {
                for (int u = 0; u < 9; u++)
                {
                    for (int o = 0; o < 20; o++)
                    {
                        Console.SetCursorPosition(u + 9 * ton + 1, o + 40);           //Und hier kommt die angeschlagene Taste
                        Console.Write(Taste[1, ton - 1, u, o]);
                    }
                }
            }
        }

        private static void stopTone()
        {
            breaker:
            if (playing && !Console.KeyAvailable)
            {
                if (!Console.KeyAvailable)
                {
                    Thread.Sleep(30);
                    if (Console.KeyAvailable) goto breaker;             //gotos ;D

                    if (!Console.KeyAvailable)
                    {
                        Thread.Sleep(20);
                        if (Console.KeyAvailable) goto breaker;

                        if (!Console.KeyAvailable)
                        {
                            Thread.Sleep(20);
                            if (Console.KeyAvailable) goto breaker;

                            if (!Console.KeyAvailable)
                            {
                                Thread.Sleep(20);
                                if (Console.KeyAvailable) goto breaker;

                                if (!Console.KeyAvailable)
                                {
                                    Thread.Sleep(20);
                                    if (Console.KeyAvailable) goto breaker;

                                    if (!Console.KeyAvailable)
                                    {
                                        Thread.Sleep(20);
                                        if (Console.KeyAvailable) goto breaker;

                                        if (!Console.KeyAvailable)
                                        {
                                            Thread.Sleep(20);
                                            if (Console.KeyAvailable) goto breaker;

                                            if (!Console.KeyAvailable)
                                            {
                                                Thread.Sleep(20);
                                                if (Console.KeyAvailable) goto breaker;

                                                if (!Console.KeyAvailable)
                                                {
                                                    Thread.Sleep(20);
                                                    if (Console.KeyAvailable) goto breaker;

                                                    if (!Console.KeyAvailable)
                                                    {
                                                        if (ton > 0)
                                                        {
                                                            for (int u = 0; u < 9; u++)
                                                            {
                                                                for (int o = 0; o < 20; o++)
                                                                {
                                                                    Console.SetCursorPosition(u + 9 * ton + 1, o + 40);           //Und dann soll der Ton gestoppt werden. Das bewirkt natürlich auch, dass der Ton länger anhält, aber eine andere Lösung hab ich nicht...
                                                                    Console.Write(Taste[0, ton - 1, u, o]);
                                                                }
                                                            }
                                                        }
                                                        player.Stop();
                                                        ton = 0;
                                                        playing = false;
                                                        zuschnell = 0;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void Monsterfight2() //Der Fight gegen das MEGA Monster
        {
            Console.ResetColor();
            Console.Clear(); //Ertmal alles zurücksetzen
            Console.SetCursorPosition(10, 9);
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            Console.Write("Du hast eine Einweg-Pistole gefunden! ");
            Console.SetCursorPosition(10, 10);
            Console.Write("Benutze W, S und F, um gegen das Monster zu kämpfen!"); //Jaja, Infos für den User sind wichtig
            monsterkillerx = 20; //Alle Positionen festlegen
            monsterkillery = 20;
            monstersterberx = 40;
            monstersterbery = 20;
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.SetCursorPosition(monsterkillerx, monsterkillery); //Und anzeigen
            Console.Write("☺");
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.SetCursorPosition(monstersterberx, monstersterbery);
            Console.Write("☻");
            Monster2starttime = DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 60000 + DateTime.Now.Hour * 3600000 + DateTime.Now.DayOfYear * 86400000;
            timefight2 = Convert.ToInt64(Math.Round(Convert.ToDecimal((DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 60000 + DateTime.Now.Hour * 3600000 + DateTime.Now.DayOfYear * 86400000 - Monster2starttime) / 2)));
            timerschuss = timefight2;
            timersterber = timefight2;
            timerschiesser = timefight2;
            timerschuss2 = timefight2;
            while (true)
            { //Schon wieder diese Zeit...
                timefight2 = Convert.ToInt64(Math.Round(Convert.ToDecimal((DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 60000 + DateTime.Now.Hour * 3600000 + DateTime.Now.DayOfYear * 86400000 - Monster2starttime) / 2)));
                if (Console.KeyAvailable)
                {
                    action(); //ACTION! Da hat der User was gemacht... Das kommt öfters in dem Teil, da der User sonst teilweise kurz nichts machen konnte...
                }
                if (timefight2 - timerschuss > 50) //Der Schuss bewegt sich!
                {
                    timerschuss = timefight2;
                    for (int i = 0; i < 10; i++) //Und zwar alle potentiellen 10
                    {
                        if (Console.KeyAvailable)
                        {
                            action();
                        }
                        if (schuss[i]) //Aber nur die, die auch wirklich da sind
                        {
                            if (schusspos[i, 0] < 40) //Und nur, wenn der Schuss noch nicht angekommen ist
                            {
                                Console.SetCursorPosition(schusspos[i, 0], schusspos[i, 1]);
                                Console.Write(" ");
                                schusspos[i, 0]++;
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.SetCursorPosition(schusspos[i, 0], schusspos[i, 1]);
                                Console.Write("o");
                            }
                            else if (schusspos[i, 0] == 40) //Sonst...
                            {
                                if (schusspos[i, 0] == monstersterberx && schusspos[i, 1] == monstersterbery)
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition(30, 50);
                                    if (farbe)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    }
                                    Console.Write("Du hast gegen das Monster gewonnen!!!"); //Hat man gewonnen...
                                    if (!besiegt2)
                                    {
                                        besiegt2 = true;
                                        Console.SetCursorPosition(30, 52);
                                        Console.Write("Du kanst nun auf die rechte Ebene gehen!");
                                    }
                                    for (int u = 0; u < 10; u++)
                                    {
                                        schuss[u] = false;
                                        schuss2[u] = false;
                                    }
                                    moneychange = rnd.Next(0, 100);
                                    money = money + moneychange;
                                    if (farbe)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                    }
                                    Console.SetCursorPosition(30, 51);
                                    Console.Write(moneychange + " Geld!");
                                    Thread.Sleep(1000);
                                    Console.ReadKey(true);
                                    Console.Clear();
                                    goto fuerherrholzer;
                                }
                                else
                                {
                                    Console.SetCursorPosition(schusspos[i, 0], schusspos[i, 1]); //Oder der Schuss verschwindet
                                    Console.Write(" ");
                                    schuss[i] = false;
                                }
                            }
                        }
                    }
                }
                if (Console.KeyAvailable)
                {
                    action();
                }
                if (timefight2 - timerschuss2 > 50) //Und ziemlich genau das selbe für den Schuss des Monsters - nur umgekehrt
                {
                    timerschuss2 = timefight2;
                    for (int i = 0; i < 10; i++)
                    {
                        if (Console.KeyAvailable)
                        {
                            action();
                        }
                        if (schuss2[i])
                        {
                            if (schusspos2[i, 0] > 20)
                            {
                                Console.SetCursorPosition(schusspos2[i, 0], schusspos2[i, 1]);
                                Console.Write(" ");
                                schusspos2[i, 0]--;
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.SetCursorPosition(schusspos2[i, 0], schusspos2[i, 1]);
                                Console.Write("o");
                            }
                            else if (schusspos2[i, 0] == 20)
                            {
                                if (schusspos2[i, 0] == monsterkillerx && schusspos2[i, 1] == monsterkillery)
                                {
                                    Console.Clear();
                                    if (farbe)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                    }
                                    Console.SetCursorPosition(30, 50);
                                    Console.Write("Du hast gegen das Monster verloren!!!");
                                    moneychange = rnd.Next(-100, 0);
                                    money = money + moneychange;
                                    if (farbe)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                    }
                                    Console.SetCursorPosition(30, 51);
                                    Console.Write(moneychange + " Geld!");
                                    Thread.Sleep(1000);
                                    Console.ReadKey(true);
                                    Console.Clear();
                                    goto fuerherrholzer;
                                }
                                else
                                {
                                    Console.SetCursorPosition(schusspos2[i, 0], schusspos2[i, 1]);
                                    Console.Write(" ");
                                    schuss2[i] = false;
                                }
                            }
                        }
                    }
                }
                if (Console.KeyAvailable)
                {
                    action();
                }
                if (timefight2 - timersterber > 600) //Das Monster darf auch was machen...
                {
                    Console.SetCursorPosition(monstersterberx, monstersterbery);
                    Console.Write(" ");
                    timersterber = timefight2;
                    for (int i = 0; i < 10; i++)
                    {
                        if (Console.KeyAvailable)
                        {
                            action();
                        }
                        if (schusspos[i, 1] == monstersterbery && schuss[i]) //zB dem Schuss ausweichen...
                        {
                            if (monstersterbery > 11)
                            {
                                monstersterber = 1;
                            }
                            else if (monstersterbery < 30)
                            {
                                monstersterber = 2;
                            }
                            for (int u = 0; u < 10; u++)
                            {
                                if (schusspos[u, 1] == monstersterbery - 1 && monstersterbery < 30 && schuss[u] == true)
                                {
                                    monstersterber = 2;
                                    break;
                                }
                            }
                        }
                        else if (monstersterbery > monsterkillery && (schusspos[i, 1] != monstersterbery - 1 || !schuss[i])) //Oder zum Spieler gehen
                        {
                            vorsichtszahl++;
                            if (vorsichtszahl >= 10) //Wenn er in keinen der 10 potentiellen Schüsse läuft
                            {
                                monstersterber = 1;
                                vorsichtszahl = 0;
                                break;
                            }
                        }
                        else if (monstersterbery < monsterkillery && (schusspos[i, 1] != monstersterbery + 1 || !schuss[i])) //Natürlich auch in die andere Richtung
                        {
                            vorsichtszahl++;
                            if (vorsichtszahl >= 10)
                            {
                                monstersterber = 2;
                                vorsichtszahl = 0;
                                break;
                            }
                        }
                        if (monstersterbery == monsterkillery || monstersterbery + 1 == monsterkillery || monstersterbery - 1 == monsterkillery) //Und wenn er da oder nahe dran ist, heißt es Angriff!!
                        {
                            playerkiller = true;
                        }
                    }
                    if (monstersterber == 1) //Das ist die Bewegung nach oben
                    {
                        monstersterbery--;
                    }
                    else if (monstersterber == 2) //Und das nach unten
                    {
                        monstersterbery++;
                    }
                    if (playerkiller && !schuss2[schussint2]) //Und das der Angriff
                    {
                        schuss2[schussint2] = true; //Der Schuss taucht auf
                        schusspos2[schussint2, 1] = monstersterbery; //Auf der Höhe des Monsters
                        schusspos2[schussint2, 0] = 39; //Und vor diesem
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.SetCursorPosition(schusspos2[schussint2, 0], schusspos2[schussint2, 1]);
                        Console.Write("o"); //Das ist er!
                        if (schussint2 < 9)
                        {
                            schussint2++; //Und die Position im Array soll eins weitergehen, damit der nächste Schuss bereit ist
                        }
                        else
                        {
                            schussint2 = 0; //Oder wieder auf 0 gehn
                        }
                    }
                    monstersterber = 0; // Und alle Sachen werden wieder resettet
                    playerkiller = false;
                    vorsichtszahl = 0;
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.SetCursorPosition(monstersterberx, monstersterbery);
                    Console.Write("☻");
                }
                if (Console.KeyAvailable)
                {
                    action();
                }
                for (int i = 0; i < 10; i++) //Und wenn die Schüsse zusammentreffen, sollen sie verschwinden
                {
                    for (int u = 0; u < 10; u++)
                    {
                        if (schuss[i] && schuss2[u] && (schusspos[i, 1] == schusspos2[u, 1] && (schusspos[i, 0] == schusspos2[u, 0] || schusspos[i, 0] == schusspos2[u, 0] + 1 || schusspos[i, 0] == schusspos2[u, 0] - 1))) //Und wenn die Schüsse aufeinander kommen, verschwinden sie beide
                        {
                            Console.SetCursorPosition(schusspos[i, 0] - 1, schusspos[i, 1]);
                            Console.Write("   ");
                            schuss[i] = false;
                            schuss2[u] = false;
                        }
                    }

                }
                if (Console.KeyAvailable)
                {
                    action();
                }
            }
            fuerherrholzer:; //Ecce! Extra pro te!
            if (farbe)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            Console.Clear();
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.Yellow; //Anzeige wird wiederhergestellt...
            }
            Console.SetCursorPosition(0, 0);
            Console.Write("Geld: " + money + "   ");
            monster2 = false;
            position(1);
            position(6);
            for (int i = 0; i < 10; i++)
            {
                schuss[i] = false;
                schuss2[i] = false;
                schusspos[i, 1] = 0;
                schusspos[i, 0] = 0;
                schusspos2[i, 0] = 0;
                schusspos2[i, 1] = 0;
            }
            Update = true;
        }

        private static void action() //Der Spieler darf auch was machen!
        {
            ckialt = false;
            Console.SetCursorPosition(monsterkillerx, monsterkillery);
            Console.Write(" ");
            cki = Console.ReadKey(true);
            input = cki.KeyChar;
            if (input == 'w' && monsterkillery > 11) //zb hoch gehen
            {
                monsterkillery--;
            }
            else if (input == 's' && monsterkillery < 30) //oder runter
            {
                monsterkillery++;
            }
            if (input == 'f' && !schuss[schussint] && !ckialt && timefight2 - timerschiesser > 200) //Oder schießen (s.Monster)
            {
                timerschiesser = timefight2;
                schuss[schussint] = true;
                schusspos[schussint, 1] = monsterkillery;
                schusspos[schussint, 0] = 21;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(schusspos[schussint, 0], schusspos[schussint, 1]);
                Console.Write("o");
                ckialt = true;
                if (schussint < 9)
                {
                    schussint++;
                }
                else
                {
                    schussint = 0;
                }
            }
            input = 'g';
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.SetCursorPosition(monsterkillerx, monsterkillery);
            Console.Write("☺");
        }

        private static void motionMonster2() //Und das Monster darf sich auch bewegen
        {
            for (int i = 0; i < 3; i++) //Das ist selbsterklärend
            {
                for (int u = 0; u < 3; u++)
                {
                    Console.SetCursorPosition(monster2x + u, monster2y + i);
                    Console.Write(" ");
                }
            }
            position(6);
        }

        private static void Jumpy() //Das Jump 'n' Run
        {
            ConsoleKeyInfo cki;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            string wo = "g"; //Das Wort, das eingegeben wurde                                       Ich weiß, ich bin kacke, dass ich hier dann doch eigene Variablen initialisiere.. Aber ich hab das Spiel ja nur von einem früheren Projekt kopiert, und hatte keine Lust, es nochmal neu zu programmieren, oder alle Variablen umzuändern, weil sie evtl. schonmal irgendwo vorkamen
            int Blockx = 20; //Die Position des 1. Blocks auf der X-Achse
            int Blockx2 = 40; //Die Position des 2. Blocks auf der X-Achse
            int Playery = 2; //Die Höhe des Players
            int i = 0; //Sozusagen für eine For-Schleife mit Whiles, die aber immer wieder durch null-setzen initialisiert werden kann
            int colourer = 0; //Für die Farbwechsel
            int wheel = 0; //Der Status des Rades (Players)
            long timej = 0; //die Zeit des Jump 'n' Runs
            long timeup = 0; //Der Timer zum runterfallen
            long timein = 0; //Der Player soll nicht zu schnell klicken können
            long timeblock = 0; //Die Timer für den Block
            long timewheel = 0; //Der Timer für das Rad
            double stop = 200; //Die Zeiteinheit
            int beeper1 = 1000; //Die Pieper
            int beeper2 = 37;
            int score = 0; //der Score
            jstarttime = DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 60000 + DateTime.Now.Hour * 3600000 + DateTime.Now.DayOfYear * 86400000;
            while (0 == 0) //Die Schleife fürs Spiel (Wird später durch break unterbrochen)
            {
                wo = "g";
                timej = Convert.ToInt64(Math.Round(Convert.ToDecimal((DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 60000 + DateTime.Now.Hour * 3600000 + DateTime.Now.DayOfYear * 86400000 - jstarttime) / 2)));
                while (i < 99) //Oben, unten
                {
                    Console.SetCursorPosition(i, 3);
                    Console.Write("O");
                    Console.SetCursorPosition(i, 0);
                    Console.Write("#");
                    i++;
                }
                if (wheel == 0) //Die Animation des Rades
                {
                    Console.SetCursorPosition(4, Playery);
                    Console.Write("/");
                }
                else if (wheel == 1)
                {
                    Console.SetCursorPosition(4, Playery);
                    Console.Write("-");
                }
                else if (wheel == 2)
                {
                    Console.SetCursorPosition(4, Playery);
                    Console.Write("\\");
                }
                else if (wheel == 3)
                {
                    Console.SetCursorPosition(4, Playery);
                    Console.Write("|");
                }
                if (timej - timewheel == 100)
                {
                    wheel = 0;
                }
                else if (timej - timewheel == 200)
                {
                    wheel = 1;
                }
                else if (timej - timewheel == 300)
                {
                    wheel = 2;
                }
                else if (timej - timewheel == 400)
                {
                    wheel = 3;
                    timewheel = timej;
                }
                else if (Console.KeyAvailable == true && timej - timein > stop) //Die Steuerung durch den User
                {
                    cki = Console.ReadKey(true);
                    wo = cki.Key.ToString();
                    timein = timej;
                }
                if (wo == "W" && (Playery > 0 && layer != 2 || Playery > 1 && layer == 2))
                {
                    Console.SetCursorPosition(4, Playery);
                    Console.Write(" ");
                    Playery--;
                    timeup = timej;
                    wo = "g";
                }
                else if (wo == "S")
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Clear();
                    Console.Write("SHUTDOWN");
                    Thread.Sleep(2000);
                    break;
                }
                else if (timej - timeup > stop && Playery < 2) //Der Player soll auch wieder herunterfallen
                {
                    Console.SetCursorPosition(4, Playery);
                    Console.Write(" ");
                    Playery++;
                    timeup = timej;
                }
                if (timej - timeblock > stop / 2 && Blockx > 0 && Blockx2 > 0) //Der Blcok kommt auf den Player zu - oder der Player auf den Block? :D
                {
                    Console.SetCursorPosition(Blockx, 2);
                    Console.Write(" ");
                    Console.SetCursorPosition(Blockx2, 2);
                    Console.Write(" ");
                    Blockx--;
                    Blockx2--;
                    timeblock = timej;
                }
                else if (Blockx == 0) //Jetzt ist der Block am Ende - oder der Player weit genug weg
                {
                    Console.SetCursorPosition(Blockx, 2);
                    Console.Write(" ");
                    Blockx = rnd.Next(10, 50);
                    score++;
                    colourer++;
                    stop = stop - 2;
                    Console.Beep(400, 100);
                }
                else if (Blockx2 == 0)
                {
                    Console.SetCursorPosition(Blockx2, 2);
                    Console.Write(" ");
                    Blockx2 = rnd.Next(10, 50);
                    score++;
                    colourer++;
                    stop = stop - 2;
                    Console.Beep(400, 100);
                }
                if (Blockx + 1 == Blockx2 || Blockx - 1 == Blockx2 || Blockx == Blockx2)
                {
                    Console.SetCursorPosition(Blockx2, 2);
                    Console.Write(" ");
                    Blockx2 = rnd.Next(5, 50);
                }
                if (colourer == 10) //Farbwechsel!
                {
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    Console.Clear();
                    i = 0;
                    colourer++;
                }
                else if (colourer == 21)
                {
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Clear();
                    i = 0;
                    colourer++;
                }
                else if (colourer == 32)
                {
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.Clear();
                    i = 0;
                    colourer++;
                }
                else if (colourer == 43)
                {
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Clear();
                    i = 0;
                    colourer++;
                }
                else if (colourer == 54)
                {
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Clear();
                    i = 0;
                    colourer++;
                }
                else if (colourer == 65)
                {
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    Console.Clear();
                    i = 0;
                    colourer++;
                }
                else if (colourer == 76)
                {
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.Clear();
                    i = 0;
                    colourer++;
                }
                else if (colourer == 87)
                {
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    Console.Clear();
                    i = 0;
                    colourer++;
                }
                else if (colourer == 98)
                {
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    i = 0;
                    colourer++;
                }
                else if (colourer == 109)
                {
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Clear(); //Und wenns keine Farben mehr gibt, hat der Player eben gewonnen :D
                    colourer++;
                    Console.Write("GEWONNEN");
                    while (beeper2 < 1000)
                    {
                        Console.Beep(beeper2, 100);
                        beeper2 = beeper2 + 20;
                    }
                    Thread.Sleep(1000);
                    Console.ReadKey(true);
                    break;
                }
                Console.SetCursorPosition(10, 10);
                Console.Write(score);
                Console.SetCursorPosition(Blockx, 2);
                Console.Write("0");
                Console.SetCursorPosition(Blockx2, 2);
                Console.Write("0");
                if ((Blockx == 4 && Playery == 2) || (Blockx2 == 4 && Playery == 2) || Playery == 0) //Oder wenn er in einen Block läuft, hat er eben verloren
                {
                    if (farbe)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Clear();
                    Console.Write("GAME OVER");
                    while (beeper1 > 57)
                    {
                        Console.Beep(beeper1, 100);
                        beeper1 = beeper1 - 30;
                    }
                    Thread.Sleep(1000);
                    Console.ReadKey(true);
                    break;
                }
            }
            money = money + score;
        }

        private static void Snake() //Snake! Oder das Kinderspiel, whatever
        {
            Console.Clear();
            int[,] snake = new int[10000, 2];
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            for (int i = 5; i < 16; i++) //Die visuelle Beschränkung für den Player
            {
                Console.SetCursorPosition(5, i);
                Console.Write("█");
                Console.SetCursorPosition(15, i);
                Console.Write("█");
                Console.SetCursorPosition(i, 5);
                Console.Write("█");
                Console.SetCursorPosition(i, 15);
                Console.Write("█");
            }
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            Console.SetCursorPosition(x, y); //Die Schlange - oder auch Familie
            Console.Write("☻");
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.SetCursorPosition(20, 5);
            Console.Write("Kids: " + Score); //Der Score - oder die Kinder
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            Console.SetCursorPosition(20, 15);
            Console.Write("Highscore: "); //Der Highscore
            Console.Write(Highscore[0, 0]);
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            Console.SetCursorPosition(5, 20); //Eine unglaublich wichtige Anleitung
            Console.Write("Use WASD");
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            Console.SetCursorPosition(20, 20);
            Console.Write("Difficulty: " + 0);
            Console.ForegroundColor = ConsoleColor.White;
            snake[pos, 0] = x; //Der Position im Array wird die aktuelle Position des Kopfes der "Schlange" zugewiesen
            snake[pos, 1] = y;
            pos++; //Und die Position im Array geht eins weiter
            sx = rnd.Next(6, 14); //Und eine Süßigkeit taucht auf
            sy = rnd.Next(6, 14);
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            Console.SetCursorPosition(sx, sy); //Ok, eigentlich taucht die Süßigkeit erst hier auf :D
            Console.Write("♥");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            Console.ReadKey(true);
            sstarttime = DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 60000 + DateTime.Now.Hour * 3600000 + DateTime.Now.DayOfYear * 86400000;
            while (looser == false)
            {
                if (sound == true) //Die Sound-Toggle-Info
                {
                    Console.SetCursorPosition(20, 10);
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    Console.Write("◄)) Press M for toggle");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (sound == false)
                {
                    Console.SetCursorPosition(20, 10);
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write("◄   Press M for toggle");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                times = Convert.ToInt64(Math.Round(Convert.ToDecimal((DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 60000 + DateTime.Now.Hour * 3600000 + DateTime.Now.DayOfYear * 86400000 - sstarttime) / 2)));
                if (times - timem > stop)
                {
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }
                    Console.SetCursorPosition(5, 20); //Eine unglaublich wichtige Anleitung
                    Console.Write("Use WASD");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (direction == 0 && y > 6 && times - timem > stop) //Die Schlange (Familie) bewegt sich!
                    {
                        y--;
                        timem = times;
                    }
                    else if (direction == 0 && y <= 6 && times - timem > stop) //Oder stirbt
                    {
                        looser = true;
                    }
                    else if (direction == 1 && x > 6 && times - timem > stop)
                    {
                        x--;
                        timem = times;
                    }
                    else if (direction == 1 && x <= 6 && times - timem > stop)
                    {
                        looser = true;
                    }
                    else if (direction == 2 && y < 14 && times - timem > stop)
                    {
                        y++;
                        timem = times;
                    }
                    else if (direction == 2 && y >= 14 && times - timem > stop)
                    {
                        looser = true;
                    }
                    else if (direction == 3 && x < 14 && times - timem > stop)
                    {
                        x++;
                        timem = times;
                    }
                    else if (direction == 3 && x >= 14 && times - timem > stop)
                    {
                        looser = true;
                    }
                    if (pos > 9998)
                    {
                        pos = 0;
                    }
                    snake[pos, 0] = x; //Und der Position im Array wird schon wieder der Wert der Position des Kopfes der Schlange (Oberhaupts der Familie) zugewiesen
                    snake[pos, 1] = y;
                    pos++; //Und die Position im Array geht eins weiter
                    nopos = pos - longer; //Und das ist die letzte Stelle der Schlange, die, wegen der Bewegung wieder gelöscht werden soll
                    if (nopos < 0) //Für den Anfang
                    {
                        nopos = 10000 + (pos - longer);
                    }
                    if (snake[nopos, 0] != sx || snake[nopos, 1] != sy)
                    {
                        Console.SetCursorPosition(snake[nopos, 0], snake[nopos, 1]);
                        Console.Write(" "); //Und weg
                    }
                    timem = times;
                    for (int i = pos - 2; i > pos - longer && i > 0; i--)
                    {
                        if (x == snake[i, 0] && y == snake[i, 1]) //Verreckt
                        {
                            looser = true;
                        }
                    }
                }
                if (Console.KeyAvailable == true) //Der User hat was gemacht!
                {
                    cki = Console.ReadKey(true);
                    input = cki.KeyChar;
                    if (input == 'w') //Wohin?
                    {
                        direction = 0;
                        Console.SetCursorPosition(9, 20);
                        if (farbe)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        Console.Write("W");
                    }
                    else if (input == 'a')
                    {
                        direction = 1;
                        Console.SetCursorPosition(10, 20);
                        if (farbe)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        Console.Write("A");
                    }
                    else if (input == 's')
                    {
                        direction = 2;
                        Console.SetCursorPosition(11, 20);
                        if (farbe)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        Console.Write("S");
                    }
                    else if (input == 'd')
                    {
                        direction = 3;
                        Console.SetCursorPosition(12, 20);
                        if (farbe)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        Console.Write("D");
                    }
                    else if (input == 'm')
                    {
                        if (sound == true)
                        {
                            sound = false;
                        }
                        else if (sound == false)
                        {
                            sound = true;
                        }
                    }
                }
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                Console.SetCursorPosition(x, y);
                Console.Write("☻"); //Da ist der ja schon wieder
                Console.ForegroundColor = ConsoleColor.White;
                if (x == sx && y == sy) //Er hat das Herz eingesammelt
                {
                    longer++;
                    sx = rnd.Next(6, 14);
                    sy = rnd.Next(6, 14);
                    if (pos > 2)
                    {
                        for (int u = 0; u < 10; u++)
                        {
                            for (int i = pos; i > pos - longer; i--)
                            {
                                if (sx == snake[i, 0] && sy == snake[i, 1])
                                {
                                    sx = rnd.Next(6, 14); //Ein Herz im Körper hat zwar Vorteile, wollen wir aber dennoch nicht - also verringern wir die Wahrscheinlichkeit dafür!
                                    sy = rnd.Next(6, 14);
                                }
                            }
                        }
                    }
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    Console.SetCursorPosition(sx, sy); //Da ist ja ein neues Herz!
                    Console.Write("♥");
                    Console.ForegroundColor = ConsoleColor.White;
                    Score++;
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Console.SetCursorPosition(20, 5);
                    Console.Write("Kids: " + Score); //Der Score (Oder die Kinder)
                    if (sound == true)
                    {
                        Console.Beep(1000, 100); //Piep!
                    }
                }
            }
            if (sound == true)
            {
                Console.Beep(100, 1000);
            }
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Clear();
            Console.SetCursorPosition(0, 0); //Looser!
            Console.WriteLine("GAME OVER!");
            if (Score > Highscore[0, 0])
            {
                Console.WriteLine("New Highscore: " + Score);
                Highscore[0, 0] = Score;
            }
            Console.Write("Press a Key"); //Ende
            Thread.Sleep(1000);
            Console.ReadKey();
            snake[pos, 0] = x;
            snake[pos, 1] = y;
            x = 10;
            y = 9;
            sx = 0;
            sy = 0;
            pos = 0;
            direction = 0;
            times = 0;
            timem = 0;
            longer = 3;
            nopos = 0;
            money += Score;
            Score = 0;
            looser = false;
        }

        private static void Monsterfight()                                                          //Oh nein, ein Monster-Kampf!
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(5, 5);
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            Console.Write("Drücke genau dann Enter, wenn der Balken abgelaufen ist");
            Console.SetCursorPosition(10, 10);
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            for (int i = 0; i < 10; i++)
            {
                Console.Write("█");
            }
            Monsterstarttime = DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 60000 + DateTime.Now.Hour * 3600000 + DateTime.Now.DayOfYear * 86400000;
            while (monster)
            {
                Monstertime = Convert.ToInt64(Math.Round(Convert.ToDecimal((DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 60000 + DateTime.Now.Hour * 3600000 + DateTime.Now.DayOfYear * 86400000 - Monsterstarttime) / 2)));
                if (Monstertime == 100)                                          //Alle 0,1 Sekunden soll der Balken um eins kürzer werden
                {
                    Monstervariable++;
                    Monsterstarttime = DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 60000 + DateTime.Now.Hour * 3600000 + DateTime.Now.DayOfYear * 86400000;
                }
                Console.SetCursorPosition(19 - Monstervariable, 10);
                Console.Write(" ");
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter)
                    {
                        if (Monstervariable > 8)                                    //Der Spieler hat im richtigen Moment Enter gedrückt
                        {
                            moneychange = rnd.Next(1, 50);
                            monster = false;
                            money = money + moneychange;
                            Console.Clear();
                            Console.SetCursorPosition(0, 0);
                            if (farbe)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            Console.WriteLine("Gewonnen! +" + moneychange + " Geld!");
                            if (!besiegt1)
                            {
                                besiegt1 = true;
                                Console.Write("Du kannst nun auf die obere Ebene gehen!");
                            }
                        }
                        else                                                                //Oder eben auch nicht
                        {
                            moneychange = rnd.Next(1, 50);
                            monster = false;
                            money = money - moneychange;
                            Console.Clear();
                            Console.SetCursorPosition(0, 0);
                            if (farbe)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            Console.Write("VERLOREN! -" + moneychange + " Geld!");
                        }
                    }
                }
                else if (Monstervariable > 10)                                       //Oder gar nicht - true!
                {
                    moneychange = rnd.Next(1, 50);
                    monster = false;
                    money = money - 20;
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    if (farbe)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write("VERLOREN! -" + moneychange + " Geld!");
                }
            }
            Console.ReadKey(true);                                                  //Und auch hier soll dannach wieder alles sein wie vorher
            timermonster = time;
            Monstertime = 0;
            Monstervariable = 0;
            Console.Clear();
            Console.ResetColor();
            if (layer == 0)
            {
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                for (int i = 50; i < 100; i++)
                {
                    for (int u = 50; u < 100; u++)
                    {
                        Console.SetCursorPosition(i, u);
                        Console.Write("░");
                    }
                }
            }
            if (!gesammelt)
            {
                Console.SetCursorPosition(moneyx, moneyy);
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.Write("E");
            }
            monster = false;
            Console.SetCursorPosition(0, 0);
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.Write("Geld: " + money + "   ");
            position(2);
            Update = true;
        }

        private static void motion()                                                //Der Spieler verschwindet im Grunde nur :D
        {
            Console.SetCursorPosition(0, 0);
            if (farbe)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.Write("Geld: " + money + "   ");
            for (int i = 0; i < 9; i++)
            {
                for (int u = 0; u < 6; u++)
                {
                    if (Playery + i < 99)
                    {
                        Console.SetCursorPosition(Playerx + u, Playery + i);
                        if (layer == 0)
                        {
                            if (Playerx + u >= 50 && Playery + i >= 49)
                            {
                                if (farbe)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                }
                                Console.Write("░");
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
            }
        }

        private static void motionMonster()                                         //Genauso wie das Monster
        {
            if (mercator)       //(Hoffentlich) selbsterklärend
            {
                position(2);
            }
            for (int i = 0; i < 3; i++)
            {
                for (int u = 0; u < 3; u++)
                {
                    Console.SetCursorPosition(monsterx + u, monstery + i);
                    if (layer == 0)
                    {
                        if (monsterx + u >= 50 && monstery + i >= 49)
                        {
                            if (farbe)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }
                            Console.Write("░");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                        if (monsterx + u == moneyx && monstery == moneyy)
                        {
                            if (farbe)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            Console.Write("E");
                        }
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
        }

        private static void position(int v)                                             //Alle möglichen Dinge werden angezeigt
        {
            Console.SetWindowPosition(0, 0);
            if (v == 1)
            {
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                for (int i = 0; i < 9; i++)
                {
                    for (int u = 0; u < 6; u++)
                    {
                        Console.SetCursorPosition(Playerx + u, Playery + i);
                        Console.Write(Playermodel1[i, u]);
                    }
                }
                Console.SetCursorPosition(Playerx, Playery + 7);
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                if (Playerx >= 50 && Playery + 7 >= 49 && layer == 0) //Das Gras soll natürlich auch wieder da sein
                {
                    Console.Write("░");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(Playerx, Playery + 8);
                if (Playerx >= 50 && Playery + 8 >= 49 && layer == 0)
                {
                    Console.Write("░");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(Playerx + 3, Playery + 7);
                if (Playerx + 3 >= 50 && Playery + 7 >= 49 && layer == 0)
                {
                    Console.Write("░");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(Playerx + 3, Playery + 8);
                if (Playerx + 3 >= 50 && Playery + 8 >= 49 && layer == 0)
                {
                    Console.Write("░");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            else if (v == 3)
            {
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                for (int i = 0; i < 9; i++)
                {
                    for (int u = 0; u < 6; u++)
                    {
                        Console.SetCursorPosition(Playerx + u, Playery + i);
                        Console.Write(Playermodel2[i, u]);
                    }
                }
                Console.SetCursorPosition(Playerx + 1, Playery + 7);
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                if (Playerx + 1 >= 50 && Playery + 7 >= 49 && layer == 0)
                {
                    Console.Write("░");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(Playerx + 1, Playery + 8);
                if (Playerx + 1 >= 50 && Playery + 8 >= 49 && layer == 0)
                {
                    Console.Write("░");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(Playerx + 4, Playery + 7);
                if (Playerx + 4 >= 50 && Playery + 7 >= 49 && layer == 0)
                {
                    Console.Write("░");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(Playerx + 4, Playery + 8);
                if (Playerx + 4 >= 50 && Playery + 8 >= 49 && layer == 0)
                {
                    Console.Write("░");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            else if (v == 4)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int u = 0; u < 6; u++)
                    {
                        if (farbe)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                        }
                        Console.SetCursorPosition(Playerx + u, Playery + i);
                        Console.Write(Playermodel3[i, u]);
                    }
                }
                Console.SetCursorPosition(Playerx + 2, Playery + 7);
                if (farbe)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                if (Playerx + 2 >= 50 && Playery + 7 >= 49 && layer == 0)
                {
                    Console.Write("░");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(Playerx + 2, Playery + 8);
                if (Playerx + 2 >= 50 && Playery + 8 >= 49 && layer == 0)
                {
                    Console.Write("░");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(Playerx + 5, Playery + 7);
                if (Playerx + 5 >= 50 && Playery + 7 >= 49 && layer == 0)
                {
                    Console.Write("░");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(Playerx + 5, Playery + 8);
                if (Playerx + 5 >= 50 && Playery + 8 >= 49 && layer == 0)
                {
                    Console.Write("░");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            else if (v == 2)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int u = 0; u < 3; u++)
                    {
                        if (farbe)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.SetCursorPosition(mercatorx + u, mercatory + i);
                        Console.Write(Mercatormodel1[i, u]);
                    }
                }
            }
            else if (v == 5)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int u = 0; u < 3; u++)
                    {
                        if (farbe)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.SetCursorPosition(monsterx + u, monstery + i);
                        Console.Write(Monstermodel1[i, u]);
                    }
                }
            }
            else if (v == 6)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int u = 0; u < 5; u++)
                    {
                        if (farbe)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        Console.SetCursorPosition(ludusx + i, ludusy + u);
                        Console.Write(LudusModel1[u, i]);
                    }
                }
            }
            else if (v == 7)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int u = 0; u < 3; u++)
                    {
                        if (farbe)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.SetCursorPosition(monster2x + i, monster2y + u);
                        Console.Write(Monstermodel2[u, i]);
                    }
                }
            }
            Console.SetWindowPosition(0, 0);
        }
        #endregion
    }
    public class WaveHeader      //Diese Klassen habe ich hauptsächlich kopiert. Aber ich hatte keine Ahnung, wie so etwas funktioniert, mit dem Console.Beep war es nicht asynchron und klang noch abgehackter, und ich wollte unbedingt mein Piano :) Die Kommentare hab ich aber selbst geschrieben :D
    {
        public string sGroupID;         //Was soll man da erklären... ist halt hier RIFF :D
        public uint dwFileLength;       //Das wird später die File Length
        public string sRiffType;        //WAVE - Immer :D
        public WaveHeader()
        {
            dwFileLength = 0;
            sGroupID = "RIFF";
            sRiffType = "WAVE";
        }
    }
    public class WaveFormatChunk
    {
        public string sChunkID;         // Das muss hier fmt sein - für Format
        public uint dwChunkSize;        // Und das 16 - warum auch immer ;D
        public ushort wFormatTag;       // 1 steht hier für PCM - und PCM is immer gut
        public ushort wChannels;        // 2 ist stereo :o :D
        public uint dwSamplesPerSec;    // Das ist die Ausgangsfrequenz - Nehmen wir doch den KAmmerton A (44100Hz)
        public uint dwAvgBytesPerSec;   // Keine Ahnung was das ist :/
        public ushort wBlockAlign;      // Oder das
        public ushort wBitsPerSample;    // Das müssen dann wieder 2 Bytes sein - also 16
        public WaveFormatChunk()
        {                                   //Hier wird dann das angewandt, was ich gerade so toll erklärt hab :D
            sChunkID = "fmt ";
            dwChunkSize = 16;
            wFormatTag = 1;
            wChannels = 2;
            dwSamplesPerSec = 44100;
            wBitsPerSample = 16;
            wBlockAlign = (ushort)(wChannels * (wBitsPerSample / 8));
            dwAvgBytesPerSec = dwSamplesPerSec * wBlockAlign;
        }
    }
    public class WaveDataChunk
    {
        public string sChunkID;     // Das ist der DAta Chunk
        public uint dwChunkSize;    // Die Länge vom Header
        public short[] shortArray;  // 8-bit audio
        public WaveDataChunk()
        {
            shortArray = new short[0];
            dwChunkSize = 0;
            sChunkID = "data";
        }
    }
    public enum WaveExampleType
    {
        Beeper = 0      //Mein toller Beeper :)
    }

    public class WaveGenerator
    {
        // Header, Format, Data chunks
        WaveHeader header;              //hier werden dann die ganzen Klassen verwendet
        WaveFormatChunk format;
        WaveDataChunk data;

        /// <snip>
        public WaveGenerator(WaveExampleType type, double freq)         //Die freq hab ich sogar selber eingebunden, damit ich die Frequenz leichter kontrollieren kann :) Der Type ist dann natürlich mein Beeper
        {
            // Init chunks
            header = new WaveHeader();
            format = new WaveFormatChunk();
            data = new WaveDataChunk();

            // Fill the data array with sample data
            switch (type)
            {
                case WaveExampleType.Beeper:
                    // Number of samples = sample rate * channels * bytes per sample                Das muss halt so sein ;D
                    uint numSamples = format.dwSamplesPerSec * format.wChannels - 1000;
                    // Da ist wieder das shortarray - für 16bit Audio
                    data.shortArray = new short[numSamples];

                    int amplitude = 32760;  // Möglichst kaut natürlich :D
                    double t = (Math.PI * 2 * freq) / (format.dwSamplesPerSec * format.wChannels);      //Irgendein Gedöns zur Erstellung der Sinus Kurve ;)
                    for (uint i = 0; i < numSamples - 1; i++)
                    {
                        for (int channel = 0; channel < format.wChannels; channel++)
                        {
                            data.shortArray[i + channel] = Convert.ToInt16(amplitude * Math.Sin(t * i));        //Hier wird das ShortArray dann mit der Data gefüllt
                        }
                    }

                    // Calculate data chunk size in bytes
                    data.dwChunkSize = (uint)(data.shortArray.Length * (format.wBitsPerSample / 8));                //Und hier wird dann erst die Size angegeben

                    break;
            }
        }
        public void Save(string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Create);      //Es wird entweder eine neue DAtei angelegt, oder die alte überschrieben

            BinaryWriter writer = new BinaryWriter(fileStream);                 //Und hier kommt alles in die Datei rein...

            writer.Write(header.sGroupID.ToCharArray());                    //Erst der Header
            writer.Write(header.dwFileLength);
            writer.Write(header.sRiffType.ToCharArray());

            writer.Write(format.sChunkID.ToCharArray());                                //Dann der Format Chunk
            writer.Write(format.dwChunkSize);
            writer.Write(format.wFormatTag);
            writer.Write(format.wChannels);
            writer.Write(format.dwSamplesPerSec);
            writer.Write(format.dwAvgBytesPerSec);
            writer.Write(format.wBlockAlign);
            writer.Write(format.wBitsPerSample);

            writer.Write(data.sChunkID.ToCharArray());                                      //Und dann der Data Chunk
            writer.Write(data.dwChunkSize);
            foreach (short dataPoint in data.shortArray)
            {
                writer.Write(dataPoint);
            }

            writer.Seek(4, SeekOrigin.Begin);
            uint filesize = (uint)writer.BaseStream.Length;                             //Und hier wird die Filesize berechnet
            writer.Write(filesize - 8);
            writer.Close();
            fileStream.Close();
        }
    }
    #endregion


}
/*Hinweis: Ich hab manche Programmteilen aus anderen Programmen von mir kopiert (Wie zB Snake), 
weshalb es vielleicht so wirkt, als würden diese Teile nicht dazu gehören - Gehörten sie ja auch ursprünglich nicht :D 
Außerdem habe ich mir gewisse Informationen aus dem Internet geholt, jedoch nichts kopiert. Dazu hab ich https://msdn.microsoft.com/de-de/default.aspx benutzt. 
Ich hab übrigens immer "du" verwendet, weil ich etwas anderes in so einem Programm einfach unpassend finde.... 
Ich hoffe, sie finden sich mit Hilfe der Kommentare im Programm zurecht, auch wenn es manchmal ein bisschen Spaghetti ist - Aber hauptsache es funktioniert! 
- 
Timo Borner
*/
