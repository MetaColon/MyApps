using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gitarre
{
    class Program
    {
        public static bool record = false;
        public static int[] song = new int[100];
        public static int songpos = 0;
        static void Main(string[] args)
        {
            Init();
            int posx = 1;
            int posy = 0;
            ConsoleKey ck = new ConsoleKey();
            char key;
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            Console.SetCursorPosition(posx - 1, posy + Console.LargestWindowHeight / 2 - 3);

            while (true)
            {
                cki = Console.ReadKey(true);
                ck = cki.Key;
                key = cki.KeyChar;
                if (ck == ConsoleKey.UpArrow && posy > 0) posy--;
                else if (ck == ConsoleKey.DownArrow && posy < 5) posy++;
                else if (ck == ConsoleKey.LeftArrow && posx > 1) posx--;
                else if (ck == ConsoleKey.RightArrow && posx < Console.LargestWindowWidth) posx++;
                else if (key >= '0' && key <= '9') posx = key - '0' + 1;
                else if (ck == ConsoleKey.F1) posy = 0;
                else if (ck == ConsoleKey.F2) posy = 1;
                else if (ck == ConsoleKey.F3) posy = 2;
                else if (ck == ConsoleKey.F4) posy = 3;
                else if (ck == ConsoleKey.F5) posy = 4;
                else if (ck == ConsoleKey.F6) posy = 5;
                else if (ck == ConsoleKey.R && !record) record = true;
                else if (ck == ConsoleKey.R && record) record = false;
                else if (ck == ConsoleKey.P) Play();
                else if (ck == ConsoleKey.Enter || ck == ConsoleKey.Spacebar)
                {
                    Console.Beep(Convert.ToInt32(gettone(posx, 5 - posy)), 500);
                    if (record && songpos < song.Length)
                    {
                        song[songpos] = Convert.ToInt32(gettone(posx, 5 - posy));
                        songpos++;
                    }
                    else record = false;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                if (record) Console.Write("♦");
                else Console.Write(" ");
                Console.CursorVisible = true;
                Console.SetCursorPosition(posx -1 , posy + Console.LargestWindowHeight / 2 - 3);
                while (Console.KeyAvailable) Console.ReadKey(true);
            }
        }

        public static void Play()
        {
            record = false;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("►");
            for (int i = 0; i < songpos; i++)
            {
                Console.Beep(song[i], 500);
            }
            songpos = 0;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Write(" ");
        }

        public static double gettone(int posx, int posy)
        {
            double tone = 0;
            double n = 19 + posx + 5* posy;
            if (posy > 3) n--;
            tone = (Math.Pow(2, (n-49)/12)) * 440;
            return tone;
        }

        public static void Init()
        {
            Console.CursorSize = 100;
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            for (int i = 0; i < 6; i++)
            {
                for (int u = 0; u < Console.LargestWindowWidth; u++)
                {
                    Console.SetCursorPosition(u, i + Console.LargestWindowHeight / 2 - 3);
                    if (u % 5 != 0) Console.Write("-");
                    else Console.Write("|");
                    
                }
            }
        }
    }
}
