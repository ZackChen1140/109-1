using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WP_12_2
{
    
    public partial class Form1 : Form
    {
        int w, h, x0, y0, pen_width = 1;
        Bitmap img1, img2, BackupImg, BackupImg2;
        Pen p;
        int tools = 0;
        Color c = Color.Black;
        Color c2 = Color.Black;
        bool fillUp = false;
        Brush fillBrush = new SolidBrush(Color.Black);

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            p = new Pen(c, pen_width);
            toolStripStatusLabel1.Text = "Width: " + w.ToString() + ", Height: " + h.ToString();
            toolStripStatusLabel3.Text = "Pen: " + c.ToString();
            toolStripStatusLabel4.Text = "Brush: " + c2.ToString();
            復原ToolStripMenuItem.Enabled = false;
            取消復原ToolStripMenuItem.Enabled = false;
        }
        public Bitmap ConvertCM(Image image, ColorMatrix cm)
        {
            Bitmap dest = new Bitmap(image.Width, image.Height);
            Graphics g = Graphics.FromImage(dest);

            ImageAttributes ia = new ImageAttributes();

            ia.SetColorMatrix(cm);
            g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ia);
            g.Dispose();

            BackupImg = (Bitmap)pictureBox1.Image.Clone();
            復原ToolStripMenuItem.Enabled = true;

            return dest;
        }

        private void 灰階ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                ColorMatrix cm = new ColorMatrix(
                       new float[][]{ new float[]{0.33f, 0.33f, 0.33f, 0, 0},
                                  new float[]{0.33f, 0.33f, 0.33f, 0, 0},
                                  new float[]{0.33f, 0.33f, 0.33f, 0, 0},
                                  new float[]{  0,    0,    0,  1, 0},
                                  new float[]{  0,    0,    0,  0, 1}});
                pictureBox1.Image = ConvertCM(pictureBox1.Image, cm);
            }
        }

        private void 開啟舊檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String input = openFileDialog1.FileName;
                img1 = (Bitmap)Image.FromFile(input);
                w = img1.Width;
                h = img1.Height;
                if ((ClientSize.Width < w) || (ClientSize.Height < h))
                    ClientSize = new Size(w, h + 56);
                pictureBox1.Image = img1;
                pictureBox1.Refresh();
                toolStripStatusLabel1.Text = "Width: " + w.ToString() + ", Height: " + h.ToString();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if ((e.X < w) && (e.Y < h) && (e.X > 0) && (e.Y > 0))
                {
                    toolStripStatusLabel2.Text = e.Location.ToString();
                }
                else
                {
                    toolStripStatusLabel2.Text = "{,}";
                }
                if (e.Button == MouseButtons.Left)
                {
                    if (tools == 0)
                    {
                        Graphics g = Graphics.FromImage(pictureBox1.Image);
                        if ((e.X < w) && (e.Y < h) && (e.X > 0) && (e.Y > 0))
                        {
                            g.DrawLine(p, x0, y0, e.X, e.Y);
                            x0 = e.X;
                            y0 = e.Y;
                            pictureBox1.Refresh();
                        }
                    }
                    else if (tools == 1)
                    {
                        {
                            if ((e.X < w) && (e.Y < h) && (e.X > 0) && (e.Y > 0))
                            {
                                Bitmap tempImg = (Bitmap)img2.Clone();
                                Graphics gg = Graphics.FromImage(tempImg);
                                gg.DrawLine(p, x0, y0, e.X, e.Y);
                                pictureBox1.Image = tempImg;
                                pictureBox1.Refresh();
                            }
                        }
                    }
                    else if(tools==2)
                    {
                        if ((e.X < w) && (e.Y < h) && (e.X > 0) && (e.Y > 0))
                        {
                            Bitmap tempImg = (Bitmap)img2.Clone();
                            Graphics gg = Graphics.FromImage(tempImg);
                            if (fillUp)
                                gg.FillRectangle(fillBrush, x0, y0, e.X - x0, e.Y - y0);
                            gg.DrawRectangle(p, x0, y0, e.X - x0, e.Y - y0);
                            pictureBox1.Image = tempImg;
                            pictureBox1.Refresh();
                        }
                    }
                    else if(tools==3)
                    {
                        if ((e.X < w) && (e.Y < h) && (e.X > 0) && (e.Y > 0))
                        {
                            Bitmap tempImg = (Bitmap)img2.Clone();
                            Graphics gg = Graphics.FromImage(tempImg);
                            if (fillUp)
                                gg.FillEllipse(fillBrush, x0, y0, e.X - x0, e.Y - y0);
                            gg.DrawEllipse(p, x0, y0, e.X - x0, e.Y - y0);
                            pictureBox1.Image = tempImg;
                            pictureBox1.Refresh();
                        }
                    }
                }
            }
        }

        private void 增亮ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                ColorMatrix cm = new ColorMatrix(
                   new float[][]{ new float[]{  1.1f,    0,    0,  0, 0},
                                  new float[]{  0,    1.1f,    0,  0, 0},
                                  new float[]{  0,    0,    1.1f,  0, 0},
                                  new float[]{  0,    0,    0,  1, 0},
                                  new float[]{  0,    0,    0,  0, 1}});
                pictureBox1.Image = ConvertCM(pictureBox1.Image, cm);
            }
        }

        private void 調暗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                ColorMatrix cm = new ColorMatrix(
                   new float[][]{ new float[]{  0.9f,    0,    0,  0, 0},
                                  new float[]{  0,    0.9f,    0,  0, 0},
                                  new float[]{  0,    0,    0.9f,  0, 0},
                                  new float[]{  0,    0,    0,  1, 0},
                                  new float[]{  0,    0,    0,  0, 1}});
                pictureBox1.Image = ConvertCM(pictureBox1.Image, cm);
            }
        }

        private void 顏色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                c = colorDialog1.Color;
                p = new Pen(c, pen_width);
                toolStripStatusLabel3.Text = "Pen:" + c.ToString();
            }
        }

        private void 點ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            點ToolStripMenuItem.Checked = true;
            直線ToolStripMenuItem.Checked = false;
            圓ToolStripMenuItem.Checked = false;
            矩形ToolStripMenuItem.Checked = false;
            tools = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void 直線ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            點ToolStripMenuItem.Checked = false;
            直線ToolStripMenuItem.Checked = true;
            圓ToolStripMenuItem.Checked = false;
            矩形ToolStripMenuItem.Checked = false;
            tools = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            pen_width = 1;
            toolStripMenuItem2.Checked = true;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            p = new Pen(c, pen_width);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pen_width = 2;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = true;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            p = new Pen(c, pen_width);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            pen_width = 3;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = true;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            p = new Pen(c, pen_width);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            pen_width = 4;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = true;
            toolStripMenuItem6.Checked = false;
            p = new Pen(c, pen_width);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            復原ToolStripMenuItem.Enabled = true;
        }

        private void 復原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            復原ToolStripMenuItem.Enabled = false;
            取消復原ToolStripMenuItem.Enabled = true;
            BackupImg2 = (Bitmap)pictureBox1.Image;
            pictureBox1.Image = BackupImg;
            pictureBox1.Refresh();
        }

        private void 取消復原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            復原ToolStripMenuItem.Enabled = true;
            取消復原ToolStripMenuItem.Enabled = false;
            pictureBox1.Image = BackupImg2;
            pictureBox1.Refresh();
        }

        private void 矩形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            點ToolStripMenuItem.Checked = false;
            直線ToolStripMenuItem.Checked = false;
            圓ToolStripMenuItem.Checked = false;
            矩形ToolStripMenuItem.Checked = true;
            tools = 2;
        }

        private void 圓ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            點ToolStripMenuItem.Checked = false;
            直線ToolStripMenuItem.Checked = false;
            圓ToolStripMenuItem.Checked = true;
            矩形ToolStripMenuItem.Checked = false;
            tools = 3;
        }

        private void 填滿ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            填滿ToolStripMenuItem.Checked = true;
            無填滿ToolStripMenuItem.Checked = false;
            fillUp = true;
        }

        private void 無填滿ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            填滿ToolStripMenuItem.Checked = false;
            無填滿ToolStripMenuItem.Checked = true;
            fillUp = false;
        }

        private void 顏色ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                c2 = colorDialog1.Color;
                fillBrush = new SolidBrush(c2);
                toolStripStatusLabel3.Text = c.ToString();
                toolStripStatusLabel4.Text = "Brush: " + c2.ToString();
            }
        }

        private void 自訂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Form3 n = new Form3();
                n.TopMost = true;
                n.Text = "設定畫布的顏色";
                n.ShowDialog();
                if (n.getA() != -1)
                {
                    ColorMatrix cm = new ColorMatrix(
                       new float[][]{ new float[]{n.getR(), 0, 0, 0, 0},
                                  new float[]{0, n.getG(), 0, 0, 0},
                                  new float[]{0, 0, n.getB(), 0, 0},
                                  new float[]{  0,    0, 0, n.getA(), 0},
                                  new float[]{  0,    0,    0,  0, 1}});
                    pictureBox1.Image = ConvertCM(pictureBox1.Image, cm);
                }
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            pen_width = 5;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = true;
            p = new Pen(c, pen_width);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                x0 = e.X;
                y0 = e.Y;
                img2 = (Bitmap)pictureBox1.Image.Clone();
                BackupImg = (Bitmap)pictureBox1.Image.Clone();
            }
        }

        private void 一半ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupImg = (Bitmap)pictureBox1.Image.Clone();
            復原ToolStripMenuItem.Enabled = true;
            w = pictureBox1.Image.Width;
            h = pictureBox1.Image.Height;
            img1 = (Bitmap)pictureBox1.Image;
            Bitmap p = new Bitmap(w / 2, h / 2);
            for (int i = 0; i < w; i += 2)
                for (int j = 0; j < h; j += 2)
                {
                    Color c = img1.GetPixel(i, j);
                    int i2 = i / 2;
                    int j2 = j / 2;
                    p.SetPixel(i2, j2, c);
                }
            pictureBox1.Image = p;
            img1 = p;
            w = p.Width;
            h = p.Height;
            pictureBox1.Refresh();
            toolStripStatusLabel1.Text = "Width: " + w.ToString() + ", Height: " + h.ToString();
        }

        private void 二倍ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupImg = (Bitmap)pictureBox1.Image.Clone();
            復原ToolStripMenuItem.Enabled = true;
            w = pictureBox1.Image.Width;
            h = pictureBox1.Image.Height;
            Bitmap p = new Bitmap(w * 2, h * 2);
            img1 = (Bitmap)pictureBox1.Image;
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    Color c = img1.GetPixel(i, j);
                    for (int ii = 0; ii < 2; ii++)
                        for (int jj = 0; jj < 2; jj++)
                            p.SetPixel(i * 2 + ii, j * 2 + jj, c);
                }
            pictureBox1.Image = p;
            img1 = p;
            w = p.Width;
            h = p.Height;
            pictureBox1.Refresh();
            toolStripStatusLabel1.Text = "Width: " + w.ToString() + ", Height: " + h.ToString();
            if ((ClientSize.Width < w) || (ClientSize.Height < (h + 56)))
                ClientSize = new Size(w, h + 56);
        }

        private void 開啟新檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 x = new Form2();
            x.TopMost = true;
            x.Text = "設定畫布的寬與高";
            x.ShowDialog();
            w = x.getWidth();
            h = x.getHeight();
            if (w != -1)
            {
                img1 = new Bitmap(w, h);
                pictureBox1.Image = img1;
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                g.Clear(Color.White);
                pictureBox1.Refresh();
                if ((ClientSize.Width < w) || (ClientSize.Height < (h + 56)))
                    ClientSize = new Size(w, h + 56);
            }

        }

        private void 儲存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    String output = saveFileDialog1.FileName;
                    pictureBox1.Image.Save(output);
                    img1 = (Bitmap)pictureBox1.Image;
                }
        }

        private void 負片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                ColorMatrix cm = new ColorMatrix(
                   new float[][]{ new float[]{ -1f,    0,    0,  0, 0},
                                  new float[]{  0,   -1f,    0,  0, 0},
                                  new float[]{  0,    0,   -1f,  0, 0},
                                  new float[]{  0,    0,    0,  1, 0},
                                  new float[]{  1,    1,    1,  0, 1}});
                pictureBox1.Image = ConvertCM(pictureBox1.Image, cm);
            }
        }
    }

    

}
