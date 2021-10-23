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

namespace hw4
{
    public partial class Form1 : Form
    {
        Color ballColor = Color.Red;
        int X = 60;
        int Y = 269;
        int timeMs = 0;
        int Xr = 0;
        int Yr = 0;
        int MouseX=0;
        int speed = 5;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Brush myBrush = new SolidBrush(Color.Black);
            Graphics g1 = this.CreateGraphics();
            g1.DrawRectangle(new Pen(myBrush), 0, 50, 360, 300);

            Brush ballBrush = new SolidBrush(ballColor);
            e.Graphics.FillEllipse(ballBrush, 0 + X, 50 + Y, 30, 30);

            Brush bottomBrush = new SolidBrush(Color.Red);
            e.Graphics.FillRectangle(bottomBrush, MouseX-45, 350, 90, 20);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeMs += 50;
            toolStripStatusLabel1.Text = (timeMs / 1000).ToString();

            if (timeMs % 5000 == 0)
                speed += 2;

            if (X >= 330 || X <= 0)
                Xr = (Xr + 1) % 2;
            if (Y >= 270 || Y <= 0)
                Yr = (Yr + 1) % 2;

            if (Xr == 0)
                X += speed;
            else
                X -= speed;

            if (Yr == 0)
                Y -= speed;
            else
                Y += speed;

            if (X > 330)
                X = 330;
            if (Y > 270)
                Y = 270;

            if (Y >= 270 && ((MouseX - 45) > (X + 15) || (MouseX + 45) < (X + 15)))
            {
                timer1.Stop();
                toolStripStatusLabel2.Text = "Game Over";
            }
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Location.X > 315)
                MouseX = 315;
            else if (e.Location.X < 45)
                MouseX = 45;
            else
                MouseX = e.Location.X;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Playing!";
            X = 60;
            Y = 269;
            timeMs = 0;
            Xr = 0;
            Yr = 0;
            MouseX = 0;
            speed = 5;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ballColor = Color.Red;
            toolStripButton1.Checked = true;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ballColor = Color.Green;
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = true;
            toolStripButton3.Checked = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ballColor = Color.Blue;
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = true;
        }
    }
}
