using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw5
{
    public partial class Form1 : Form
    {
        Image fruit = Properties.Resources._8_0;
        Image[] fruits = new Image[8];
        Image[] insideImage = new Image[16];
        bool[] open = new bool[16];
        Random rd = new Random();
        int timeS = 0;
        int timeS2 = 0;
        int timeActive = 0;
        int[] compareLocation = new int[2];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fruits[0] = Properties.Resources._8_1;
            fruits[1] = Properties.Resources._8_2;
            fruits[2] = Properties.Resources._8_3;
            fruits[3] = Properties.Resources._8_4;
            fruits[4] = Properties.Resources._8_5;
            fruits[5] = Properties.Resources._8_6;
            fruits[6] = Properties.Resources._8_7;
            fruits[7] = Properties.Resources._8_8;
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    int r = rd.Next(16);
                    while (insideImage[r] != null)
                        r = (r + 1) % 16;
                    insideImage[r] = fruits[i];
                }
            }

            for (int i = 0; i < 16; ++i)
                open[i] = false;
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 4; ++i)
                for (int j = 1; j <= 4; ++j)
                {
                    if (open[4 * (j - 1) + i])
                        e.Graphics.DrawImage(insideImage[4 * (j - 1) + i], i * 80, j * 80, 80, 80);
                    else
                        e.Graphics.DrawImage(fruit, i * 80, j * 80, 80, 80);
                    e.Graphics.DrawRectangle(Pens.Black, i * 80, j * 80, 80, 80);
                }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = timeS.ToString() + " Seconds";
            timeS += 1;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for(int i=0;i<4;++i)
                if (e.Location.X > i * 80 && e.Location.X < (i + 1) * 80)
                    for (int j=1;j<5;++j)
                        if(e.Location.Y>j*80&&e.Location.Y<(j+1)*80)
                        {
                            if(timeActive<2)
                            {
                                compareLocation[timeActive] = 4 * (j - 1) + i;
                                open[4 * (j - 1) + i] = true;
                            }
                            if (compareLocation[0] == compareLocation[1])
                                --timeActive;
                            ++timeActive;
                        }
            bool allOn = true;
            for (int i = 0; i < 16; ++i)
                if (open[i] == false)
                    allOn = false;
            if (allOn)
                timer1.Stop();
            if (timeActive == 2)
            {
                if (insideImage[compareLocation[0]] != insideImage[compareLocation[1]])
                    timer2.Start();
                else
                    timeActive = 0;
            }
            
            Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timeS2 += 1;
            if (timeS2==1)
            {
                open[compareLocation[0]] = false;
                open[compareLocation[1]] = false;
                compareLocation[0] = 16;
                compareLocation[1] = 16;
                timeActive = 0;
                Invalidate();
                timeS2 = 0;
                timer2.Stop();
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timeS = 0;
            timeS2 = 0;
            timeActive = 0;
            timer1.Start();
            for (int i = 0; i < 16; ++i)
                insideImage[i] = null;
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    int r = rd.Next(16);
                    while (insideImage[r] != null)
                        r = (r + 1) % 16;
                    insideImage[r] = fruits[i];
                }
            }

            for (int i = 0; i < 16; ++i)
                open[i] = false;

            Graphics g = this.CreateGraphics();
            for (int i = 0; i < 4; ++i)
                for (int j = 1; j <= 4; ++j)
                {
                    if (open[4 * (j - 1) + i])
                        g.DrawImage(insideImage[4 * (j - 1) + i], i * 80, j * 80, 80, 80);
                    else
                        g.DrawImage(fruit, i * 80, j * 80, 80, 80);
                    g.DrawRectangle(Pens.Black, i * 80, j * 80, 80, 80);
                }
        }
    }
}
