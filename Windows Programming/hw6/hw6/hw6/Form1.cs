using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace hw6
{
    public partial class Form1 : Form
    {
        Image[] backGround = new Image[3];
        Image[] fruits = new Image[3];
        Image bowl = Properties.Resources.Bowl;

        Bitmap[] img = new Bitmap[3];
        Bitmap[] imgClone = new Bitmap[3];

        int backGroundN = 0;
        int time = 120;
        int point = 0;
        int X_Pos = 0;
        int[] fruitsX = new int[3];
        int[] fruitsY = new int[3];

        Random rd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = "Remaining: " + --time + " Seconnds";

            if (time == 0)
            {
                timer2.Stop();
                timer1.Stop();
            }

            if (time % 10 == 0)
            {
                ++backGroundN;
                if (backGroundN == 3) 
                    backGroundN = 0;
                Invalidate();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fruits[0] = Properties.Resources.Tomato;
            fruits[1] = Properties.Resources.StawBerry;
            fruits[2] = Properties.Resources.Banana;

            backGround[0] = Properties.Resources.picture1;
            img[backGroundN] = (Bitmap)backGround[backGroundN];
            backImageClone();
            ++backGroundN;

            backGround[1] = Properties.Resources.picture2;
            img[backGroundN] = (Bitmap)backGround[backGroundN];
            backImageClone();
            ++backGroundN;

            backGround[2] = Properties.Resources.picture3;
            img[backGroundN] = (Bitmap)backGround[backGroundN];
            backImageClone();
            ++backGroundN;

            if (backGroundN == 3) 
                backGroundN = 0;

            fruitsX[0] = 0;
            fruitsX[1] = -100;
            fruitsX[0] = -200;
            fruitsX[0] = rd.Next(450);
            fruitsX[1] = rd.Next(450);
            fruitsX[2] = rd.Next(450);

            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            X_Pos = e.Location.X;
            if (X_Pos < 0) 
                X_Pos = 0;
            else if (X_Pos > 410) 
                X_Pos = 410;
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backGroundN = 0;
            time = 120;
            point = 0;
            label1.Text = "" + time;
            label2.Text = "" + point;
            for (int i = 0; i < 3; ++i) 
                fruitsY[i] = 0;

            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(imgClone[backGroundN], 0, 30, 500, 300);
            e.Graphics.DrawImage(bowl, X_Pos, 325, 80, bowl.Height);
            e.Graphics.DrawImage(fruits[0], fruitsX[0], fruitsY[0], fruits[0].Width, fruits[0].Height);
            e.Graphics.DrawImage(fruits[1], fruitsX[1], fruitsY[1], fruits[1].Width, fruits[1].Height);
            e.Graphics.DrawImage(fruits[2], fruitsX[2], fruitsY[2], fruits[2].Width, fruits[2].Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; ++i)
            {
                fruitsY[i] += 10;
                if (fruitsY[i] >= 325 && fruitsX[i] >= X_Pos - 3 && fruitsX[i] <= X_Pos + 83)
                {
                    label2.Text = "Recieved: " + ++point;
                    fruitsY[i] = 0;
                    fruitsX[i] = rd.Next(450);
                }
            }
            Invalidate();
        }

        void backImageClone()
        {
            int x, y;
            imgClone[backGroundN] = (Bitmap)img[backGroundN].Clone();
            
            for (x = 0; x < imgClone[backGroundN].Width; x++)
                for (y = 0; y < imgClone[backGroundN].Height; y++)
                {
                    Color pixelColor = imgClone[backGroundN].GetPixel(x, y);
                    Color newColor = pixelColor;
                    newColor = Color.FromArgb(pixelColor.A / 2, pixelColor.R, pixelColor.G, pixelColor.B);
                    imgClone[backGroundN].SetPixel(x, y, newColor);
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
