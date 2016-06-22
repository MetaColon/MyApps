using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JumpNRun
{
    public partial class Form1 : Form
    {
        float[] posblocks = new float[3];
        float posy = 0;
        bool jumping = false;
        float jumpstate = 0;
        int Score = -3;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (float item in posblocks)
            {
                e.Graphics.FillRectangle(Brushes.Red, item, 500, 10, 10);
            }
            e.Graphics.FillRectangle(Brushes.DarkCyan, 10, posy+490, 10, 20);
            e.Graphics.DrawString("Score: " + Score, new Font(FontFamily.GenericMonospace, 10), Brushes.Green, 0, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Score % 10 == 0 && timer1.Interval > 1) timer1.Interval--;
            for (int i = 0; i < posblocks.Length; i++)
            {
                if (posblocks[i] > 0) posblocks[i] = posblocks[i] - 3;
                else
                {
                    do
                    {
                        posblocks[i] = rnd.Next(10, 100) * 10;
                    } while (checkifexists(posblocks[i], posblocks, i, 100));
                    Score++;
                }
            }
            if(jumping)
            {
                posy = 10*((float)(Math.Pow(jumpstate - Math.Sqrt(5), 2)) - (float)5);
                if (posy > 10 * ((float)(Math.Pow(0 - Math.Sqrt(5), 2)) - (float)5))
                {
                    jumping = false;
                    posy = 0;
                }
                jumpstate+=(float)0.3;
            }
            foreach (float item in posblocks)
            {
                if (posy > -25 && item >= 10 && item <= 20)
                {
                    Score = -3;
                    timer1.Interval = 20;
                    for (int i = 0; i < posblocks.Length; i++)
                    {
                        posblocks[i] = 0;
                    }
                    break;
                }
            }
            Refresh();
        }

        bool checkifexists(float my, float[] others, int index, float toleranz)
        {
            for (int i = 0; i < others.Length; i++)
            {
                if (i != index && (my >= others[i] - toleranz/2 && my <= others[i] + toleranz/2)) return true;
            }
            return false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (posy == 0 && !jumping)
            {
                jumping = true;
                jumpstate = 0;
            }
        }
    }
}
