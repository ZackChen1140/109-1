using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Random rd = new Random();
            Brush myBrush1 = new SolidBrush(Color.FromArgb(rd.Next(256), rd.Next(256), rd.Next(256)));
            if (e.Location.Y>1&&e.Location.Y<51)
            {
                if (e.Location.X > 1 && e.Location.X < 51)
                    g.FillRectangle(myBrush1, 1, 1, 50, 50);
                else if (e.Location.X > 51 && e.Location.X < 102)
                    g.FillRectangle(myBrush1, 52, 1, 50, 50);
                else if (e.Location.X > 102)
                    g.FillRectangle(myBrush1, 103, 1, 50, 50);
            }
            else if(e.Location.Y>51&& e.Location.Y<102)
            {
                if (e.Location.X > 1 && e.Location.X < 51)
                    g.FillRectangle(myBrush1, 1, 52, 50, 50);
                else if (e.Location.X > 51 && e.Location.X < 102)
                    g.FillRectangle(myBrush1, 52, 52, 50, 50);
                else if (e.Location.X > 102)
                    g.FillRectangle(myBrush1, 103, 52, 50, 50);
            }
            else if(e.Location.Y>102)
            {
                if (e.Location.X > 1 && e.Location.X < 51)
                    g.FillRectangle(myBrush1, 1, 103, 50, 50);
                else if (e.Location.X > 51 && e.Location.X < 102)
                    g.FillRectangle(myBrush1, 52, 103, 50, 50);
                else if (e.Location.X > 102)
                    g.FillRectangle(myBrush1, 103, 103, 50, 50);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Random rd = new Random();
            Brush myBrush = new SolidBrush(Color.Black);
            Brush myBrush1 = new SolidBrush(Color.FromArgb(rd.Next(256), rd.Next(256), rd.Next(256)));
            Brush myBrush2 = new SolidBrush(Color.FromArgb(rd.Next(256), rd.Next(256), rd.Next(256)));
            Brush myBrush3 = new SolidBrush(Color.FromArgb(rd.Next(256), rd.Next(256), rd.Next(256)));
            Brush myBrush4 = new SolidBrush(Color.FromArgb(rd.Next(256), rd.Next(256), rd.Next(256)));
            Brush myBrush5 = new SolidBrush(Color.FromArgb(rd.Next(256), rd.Next(256), rd.Next(256)));
            Brush myBrush6 = new SolidBrush(Color.FromArgb(rd.Next(256), rd.Next(256), rd.Next(256)));
            Brush myBrush7 = new SolidBrush(Color.FromArgb(rd.Next(256), rd.Next(256), rd.Next(256)));
            Brush myBrush8 = new SolidBrush(Color.FromArgb(rd.Next(256), rd.Next(256), rd.Next(256)));
            Brush myBrush9 = new SolidBrush(Color.FromArgb(rd.Next(256), rd.Next(256), rd.Next(256)));
            e.Graphics.FillRectangle(myBrush, 0, 0, 154, 154);
            e.Graphics.FillRectangle(myBrush1, 1, 1, 50, 50);
            e.Graphics.FillRectangle(myBrush2, 52, 1, 50, 50);
            e.Graphics.FillRectangle(myBrush3, 103, 1, 50, 50);
            e.Graphics.FillRectangle(myBrush4, 1, 52, 50, 50);
            e.Graphics.FillRectangle(myBrush5, 52, 52, 50, 50);
            e.Graphics.FillRectangle(myBrush6, 103, 52, 50, 50);
            e.Graphics.FillRectangle(myBrush7, 1, 103, 50, 50);
            e.Graphics.FillRectangle(myBrush8, 52, 103, 50, 50);
            e.Graphics.FillRectangle(myBrush9, 103, 103, 50, 50);
        }
    }
}
