using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Brush myBrush = new SolidBrush(Color.Black);
            Graphics g1 = this.CreateGraphics();
            g1.DrawRectangle(new Pen(myBrush), 0, 30, 60, 60);
            g1.DrawRectangle(new Pen(myBrush), 60, 30, 60, 60);
            g1.DrawRectangle(new Pen(myBrush), 120, 30, 60, 60);
            g1.DrawRectangle(new Pen(myBrush), 0, 90, 60, 60);
            g1.DrawRectangle(new Pen(myBrush), 60, 90, 60, 60);
            g1.DrawRectangle(new Pen(myBrush), 120, 90, 60, 60);
            g1.DrawRectangle(new Pen(myBrush), 0, 150, 60, 60);
            g1.DrawRectangle(new Pen(myBrush), 60, 150, 60, 60);
            g1.DrawRectangle(new Pen(myBrush), 120, 150, 60, 60);
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }
        int I = 0;
        int II = 0;
        int III = 0;
        int IV = 0;
        int V = 0;
        int VI = 0;
        int VII = 0;
        int VIII = 0;
        int IX = 0;
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Brush myBrush = new SolidBrush(Color.Blue), myBrush2 = new SolidBrush(Color.Red);
            Graphics g2 = this.CreateGraphics();
            if (e.Location.Y > 30 && e.Location.Y < 90)
            {
                if (e.Location.X > 0 && e.Location.X < 60)
                {
                    if (I == 0)
                    {
                        g2.DrawEllipse(new Pen(myBrush), 5, 35, 50, 50);
                        I = 1;
                    }
                }
                else if (e.Location.X > 60 && e.Location.X < 120)
                {
                    if (II == 0)
                    {
                        g2.DrawEllipse(new Pen(myBrush), 65, 35, 50, 50);
                        II = 1;
                    }
                }
                else if (e.Location.X > 120 && e.Location.X < 180)
                {
                    if (III == 0)
                    {
                        g2.DrawEllipse(new Pen(myBrush), 125, 35, 50, 50);
                        III = 1;
                    }
                }
            }
            else if (e.Location.Y > 90 && e.Location.Y < 150)
            {
                if (e.Location.X > 0 && e.Location.X < 60)
                {
                    if (IV == 0)
                    {
                        g2.DrawEllipse(new Pen(myBrush), 5, 95, 50, 50);
                        IV = 1;
                    }
                }
                else if (e.Location.X > 60 && e.Location.X < 120)
                {
                    if (V == 0)
                    {
                        g2.DrawEllipse(new Pen(myBrush), 65, 95, 50, 50);
                        V = 1;
                    }
                }
                else if (e.Location.X > 120 && e.Location.X < 180)
                {
                    if (VI == 0)
                    {
                        g2.DrawEllipse(new Pen(myBrush), 125, 95, 50, 50);
                        VI = 1;
                    }
                }
            }
            else if (e.Location.Y > 150 && e.Location.Y < 210)
            {
                if (e.Location.X > 0 && e.Location.X < 60)
                {
                    if (VII == 0)
                    {
                        g2.DrawEllipse(new Pen(myBrush), 5, 155, 50, 50);
                        VII = 1;
                    }
                }
                else if (e.Location.X > 60 && e.Location.X < 120)
                {
                    if (VIII == 0)
                    {
                        g2.DrawEllipse(new Pen(myBrush), 65, 155, 50, 50);
                        VIII = 1;
                    }
                }
                else if (e.Location.X > 120 && e.Location.X < 180)
                {
                    if (IX == 0)
                    {
                        g2.DrawEllipse(new Pen(myBrush), 125, 155, 50, 50);
                        IX = 1;
                    }
                }
            }
            Point[] pt1 = new Point[2];
            if (I == 1 && II == 1 && III == 1)
            {
                pt1[0].X = 5; pt1[0].Y = 60;
                pt1[1].X = 175; pt1[1].Y = 60;
                g2.DrawLine(new Pen(myBrush2), pt1[0], pt1[1]);
                I = 3; II = 3; III = 3; IV = 3; V = 3; VI = 3; VII = 3; VIII = 3; IX = 3;
                label1.Text = "You win!";
            }
            if (IV == 1 && V == 1 && VI == 1)
            {
                pt1[0].X = 5; pt1[0].Y = 120;
                pt1[1].X = 175; pt1[1].Y = 120;
                g2.DrawLine(new Pen(myBrush2), pt1[0], pt1[1]);
                I = 3; II = 3; III = 3; IV = 3; V = 3; VI = 3; VII = 3; VIII = 3; IX = 3;
                label1.Text = "You win!";
            }
            if (VII == 1 && VIII == 1 && IX == 1)
            {
                pt1[0].X = 5; pt1[0].Y = 180;
                pt1[1].X = 175; pt1[1].Y = 180;
                g2.DrawLine(new Pen(myBrush2), pt1[0], pt1[1]);
                I = 3; II = 3; III = 3; IV = 3; V = 3; VI = 3; VII = 3; VIII = 3; IX = 3;
                label1.Text = "You win!";
            }
            if (I == 1&&IV==1&&VII==1)
            {
                pt1[0].X = 30; pt1[0].Y = 35;
                pt1[1].X = 30; pt1[1].Y = 205;
                g2.DrawLine(new Pen(myBrush2), pt1[0], pt1[1]);
                I = 3; II = 3; III = 3; IV = 3; V = 3; VI = 3; VII = 3; VIII = 3; IX = 3;
                label1.Text = "You win!";
            }
            if(II==1&&V==1&&VIII==1)
            {
                pt1[0].X = 90; pt1[0].Y = 35;
                pt1[1].X = 90; pt1[1].Y = 205;
                g2.DrawLine(new Pen(myBrush2), pt1[0], pt1[1]);
                I = 3; II = 3; III = 3; IV = 3; V = 3; VI = 3; VII = 3; VIII = 3; IX = 3;
                label1.Text = "You win!";
            }
            if(III==1&&VI==1&&IX==1)
            {
                pt1[0].X = 150; pt1[0].Y = 35;
                pt1[1].X = 150; pt1[1].Y = 205;
                g2.DrawLine(new Pen(myBrush2), pt1[0], pt1[1]);
                I = 3; II = 3; III = 3; IV = 3; V = 3; VI = 3; VII = 3; VIII = 3; IX = 3;
                label1.Text = "You win!";
            }
            if(I==1&&V==1&&IX==1)
            {
                pt1[0].X = 175; pt1[0].Y = 205;
                pt1[1].X = 5; pt1[1].Y = 35;
                g2.DrawLine(new Pen(myBrush2), pt1[0], pt1[1]);
                I = 3; II = 3; III = 3; IV = 3; V = 3; VI = 3; VII = 3; VIII = 3; IX = 3;
                label1.Text = "You win!";
            }
            if(III==1&&V==1&&VII==1)
            {
                pt1[0].X = 175; pt1[0].Y = 35;
                pt1[1].X = 5; pt1[1].Y = 205;
                g2.DrawLine(new Pen(myBrush2), pt1[0], pt1[1]);
                I = 3; II = 3; III = 3; IV = 3; V = 3; VI = 3; VII = 3; VIII = 3; IX = 3;
                label1.Text = "You win!";
            }
            Point[] pt2 = new Point[2], pt2II = new Point[2];
            if (I==0)
            {
                I = 2;
                pt2[0].X = 5 ;pt2[0].Y = 35; pt2[1].X = 55; pt2[1].Y = 85;
                pt2II[0].X = 5; pt2II[0].Y = 85; pt2II[1].X = 55; pt2II[1].Y = 35;
                g2.DrawLine(new Pen(myBrush), pt2[0], pt2[1]);
                g2.DrawLine(new Pen(myBrush), pt2II[0], pt2II[1]);
            }
            else if(II==0)
            {
                II = 2;
                pt2[0].X = 65; pt2[0].Y = 35; pt2[1].X = 115; pt2[1].Y = 85;
                pt2II[0].X = 65; pt2II[0].Y = 85; pt2II[1].X = 115; pt2II[1].Y = 35;
                g2.DrawLine(new Pen(myBrush), pt2[0], pt2[1]);
                g2.DrawLine(new Pen(myBrush), pt2II[0], pt2II[1]);
            }
            else if (III == 0)
            {
                III = 2;
                pt2[0].X = 125; pt2[0].Y = 35; pt2[1].X = 175; pt2[1].Y = 85;
                pt2II[0].X = 125; pt2II[0].Y = 85; pt2II[1].X = 175; pt2II[1].Y = 35;
                g2.DrawLine(new Pen(myBrush), pt2[0], pt2[1]);
                g2.DrawLine(new Pen(myBrush), pt2II[0], pt2II[1]);
            }
            else if(IV==0)
            {
                IV = 2;
                pt2[0].X = 5; pt2[0].Y = 95; pt2[1].X = 55; pt2[1].Y = 145;
                pt2II[0].X = 5; pt2II[0].Y = 145; pt2II[1].X = 55; pt2II[1].Y = 95;
                g2.DrawLine(new Pen(myBrush), pt2[0], pt2[1]);
                g2.DrawLine(new Pen(myBrush), pt2II[0], pt2II[1]);
            }
            else if (V == 0)
            {
                V = 2;
                pt2[0].X = 65; pt2[0].Y = 95; pt2[1].X = 115; pt2[1].Y = 145;
                pt2II[0].X = 65; pt2II[0].Y = 145; pt2II[1].X = 115; pt2II[1].Y = 95;
                g2.DrawLine(new Pen(myBrush), pt2[0], pt2[1]);
                g2.DrawLine(new Pen(myBrush), pt2II[0], pt2II[1]);
            }
            else if (VI == 0)
            {
                VI = 2;
                pt2[0].X = 125; pt2[0].Y = 95; pt2[1].X = 175; pt2[1].Y = 145;
                pt2II[0].X = 125; pt2II[0].Y = 145; pt2II[1].X = 175; pt2II[1].Y = 95;
                g2.DrawLine(new Pen(myBrush), pt2[0], pt2[1]);
                g2.DrawLine(new Pen(myBrush), pt2II[0], pt2II[1]);
            }
            else if (VII == 0)
            {
                VII = 2;
                pt2[0].X = 5; pt2[0].Y = 155; pt2[1].X = 55; pt2[1].Y = 205;
                pt2II[0].X = 5; pt2II[0].Y = 205; pt2II[1].X = 55; pt2II[1].Y = 155;
                g2.DrawLine(new Pen(myBrush), pt2[0], pt2[1]);
                g2.DrawLine(new Pen(myBrush), pt2II[0], pt2II[1]);
            }
            else if (VIII == 0)
            {
                VIII = 2;
                pt2[0].X = 65; pt2[0].Y = 155; pt2[1].X = 115; pt2[1].Y = 205;
                pt2II[0].X = 65; pt2II[0].Y = 205; pt2II[1].X = 115; pt2II[1].Y = 155;
                g2.DrawLine(new Pen(myBrush), pt2[0], pt2[1]);
                g2.DrawLine(new Pen(myBrush), pt2II[0], pt2II[1]);
            }
            else if (IX == 0)
            {
                IX = 2;
                pt2[0].X = 125; pt2[0].Y = 155; pt2[1].X = 175; pt2[1].Y = 205;
                pt2II[0].X = 125; pt2II[0].Y = 205; pt2II[1].X = 175; pt2II[1].Y = 155;
                g2.DrawLine(new Pen(myBrush), pt2[0], pt2[1]);
                g2.DrawLine(new Pen(myBrush), pt2II[0], pt2II[1]);
            }

            if (I == 2 && II == 2 && III == 2)
            {
                pt1[0].X = 5; pt1[0].Y = 60;
                pt1[1].X = 175; pt1[1].Y = 60;
                g2.DrawLine(new Pen(myBrush2), pt1[0], pt1[1]);
                I = 3; II = 3; III = 3; IV = 3; V = 3; VI = 3; VII = 3; VIII = 3; IX = 3;
                label1.Text = "You lose!";
            }
            if (IV == 2 && V == 2 && VI == 2)
            {
                pt1[0].X = 5; pt1[0].Y = 120;
                pt1[1].X = 175; pt1[1].Y = 120;
                g2.DrawLine(new Pen(myBrush2), pt1[0], pt1[1]);
                I = 3; II = 3; III = 3; IV = 3; V = 3; VI = 3; VII = 3; VIII = 3; IX = 3;
                label1.Text = "You lose!";
            }
            if (VII == 2 && VIII == 2 && IX == 2)
            {
                pt1[0].X = 5; pt1[0].Y = 180;
                pt1[1].X = 175; pt1[1].Y = 180;
                g2.DrawLine(new Pen(myBrush2), pt1[0], pt1[1]);
                I = 3; II = 3; III = 3; IV = 3; V = 3; VI = 3; VII = 3; VIII = 3; IX = 3;
                label1.Text = "You lose!";
            }
            if (I == 2 && IV == 2 && VII == 2)
            {
                pt1[0].X = 30; pt1[0].Y = 35;
                pt1[1].X = 30; pt1[1].Y = 205;
                g2.DrawLine(new Pen(myBrush2), pt1[0], pt1[1]);
                I = 3; II = 3; III = 3; IV = 3; V = 3; VI = 3; VII = 3; VIII = 3; IX = 3;
                label1.Text = "You lose!";
            }
            if (II == 2 && V == 2 && VIII == 2)
            {
                pt1[0].X = 90; pt1[0].Y = 35;
                pt1[1].X = 90; pt1[1].Y = 205;
                g2.DrawLine(new Pen(myBrush2), pt1[0], pt1[1]);
                I = 3; II = 3; III = 3; IV = 3; V = 3; VI = 3; VII = 3; VIII = 3; IX = 3;
                label1.Text = "You lose!";
            }
            if (III == 2 && VI == 2 && IX == 2)
            {
                pt1[0].X = 150; pt1[0].Y = 35;
                pt1[1].X = 150; pt1[1].Y = 205;
                g2.DrawLine(new Pen(myBrush2), pt1[0], pt1[1]);
                I = 3; II = 3; III = 3; IV = 3; V = 3; VI = 3; VII = 3; VIII = 3; IX = 3;
                label1.Text = "You lose!";
            }
            if (I == 2 && V == 2 && IX == 2)
            {
                pt1[0].X = 5; pt1[0].Y = 35;
                pt1[1].X = 175; pt1[1].Y = 205;
                g2.DrawLine(new Pen(myBrush2), pt1[0], pt1[1]);
                I = 3; II = 3; III = 3; IV = 3; V = 3; VI = 3; VII = 3; VIII = 3; IX = 3;
                label1.Text = "You lose!";
            }
            if (III == 2 && V == 2 && VII == 2)
            {
                pt1[0].X = 175; pt1[0].Y = 35;
                pt1[1].X = 5; pt1[1].Y = 205;
                g2.DrawLine(new Pen(myBrush2), pt1[0], pt1[1]);
                I = 3; II = 3; III = 3; IV = 3; V = 3; VI = 3; VII = 3; VIII = 3; IX = 3;
                label1.Text = "You lose!";
            }

            if ((I != 0 && II != 0 && III != 0 && IV != 0 && V != 0 && VI != 0 && VII != 0 && VIII != 0 && IX != 0)
                && (I != 3 && II != 3 && III != 3 && IV != 3 && V != 3 && VI != 3 && VII != 3 && VIII != 3 && IX != 3))
                label1.Text = "Draw!";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            I = 0; II = 0; III = 0; IV = 0; V = 0; VI = 0; VII = 0; VIII = 0; IX = 0;
            Graphics g3 = this.CreateGraphics();
            g3.Clear(this.BackColor);
            Brush myBrush = new SolidBrush(Color.Black);
            g3.DrawRectangle(new Pen(myBrush), 0, 30, 60, 60);
            g3.DrawRectangle(new Pen(myBrush), 60, 30, 60, 60);
            g3.DrawRectangle(new Pen(myBrush), 120, 30, 60, 60);
            g3.DrawRectangle(new Pen(myBrush), 0, 90, 60, 60);
            g3.DrawRectangle(new Pen(myBrush), 60, 90, 60, 60);
            g3.DrawRectangle(new Pen(myBrush), 120, 90, 60, 60);
            g3.DrawRectangle(new Pen(myBrush), 0, 150, 60, 60);
            g3.DrawRectangle(new Pen(myBrush), 60, 150, 60, 60);
            g3.DrawRectangle(new Pen(myBrush), 120, 150, 60, 60);

            label1.Text = "    ";
        }
    }
}
