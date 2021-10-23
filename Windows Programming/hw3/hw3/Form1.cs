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
using System.IO;

namespace hw3
{
    public partial class Form1 : Form
    {
        Color c = Color.Red;
        List<Point> startPt = new List<Point>();
        List<Point> endPt = new List<Point>();
        List<Color> colorPt = new List<Color>();
        List<bool> lineSolidPt = new List<bool>();
        List<int> lineWidthPt = new List<int>();
        bool lineSolid = true;
        int lineWidth = 3;
        Point p1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            redToolStripMenuItem.Checked = true;
            solidToolStripMenuItem.Checked = true;
            toolStripMenuItem4.Checked = true;
            openFileDialog1.Filter = "線段檔(*.pnt)|*.pnt";
            saveFileDialog1.Filter = "線段檔(*.pnt)|*.pnt";
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c = Color.Red;
            redToolStripMenuItem.Checked = true;
            greenToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c = Color.Green;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = true;
            blueToolStripMenuItem.Checked = false;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c = Color.Blue;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = true;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            startPt.Add(p1);
            endPt.Add(e.Location);
            colorPt.Add(c);
            lineSolidPt.Add(lineSolid);
            lineWidthPt.Add(lineWidth);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            for (int i = 0; i < endPt.Count(); i++)
            {
                Pen p1 = new Pen(colorPt[i], lineWidthPt[i]);
                if (lineSolidPt[i])
                    p1.DashStyle = DashStyle.Solid;
                else
                    p1.DashStyle = DashStyle.Dash;
                e.Graphics.DrawLine(p1, startPt[i], endPt[i]);
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String s = saveFileDialog1.FileName;
                BinaryWriter outFile = new BinaryWriter(File.Open(s, FileMode.Create));
                outFile.Write(endPt.Count());
                for (int i = 0; i < endPt.Count(); i++)
                {
                    outFile.Write(startPt[i].X);
                    outFile.Write(startPt[i].Y);
                    outFile.Write(endPt[i].X);
                    outFile.Write(endPt[i].Y);
                    outFile.Write(colorPt[i].A);
                    outFile.Write(colorPt[i].R);
                    outFile.Write(colorPt[i].G);
                    outFile.Write(colorPt[i].B);
                    outFile.Write(lineSolidPt[i]);
                    outFile.Write(lineWidthPt[i]);
                }
                outFile.Close();
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String s = openFileDialog1.FileName;
                if (!File.Exists(s)) return;
                BinaryReader inFile = new BinaryReader(File.Open(s, FileMode.Open));
                startPt.Clear();
                endPt.Clear();
                int n = inFile.ReadInt32();
                for (int i = 0; i < n; i++)
                {
                    startPt.Add(new Point(inFile.ReadInt32(), inFile.ReadInt32()));
                    endPt.Add(new Point(inFile.ReadInt32(), inFile.ReadInt32()));
                    Color nC = Color.FromArgb(inFile.ReadByte(), inFile.ReadByte(), inFile.ReadByte(), inFile.ReadByte());
                    colorPt.Add(nC);
                    lineSolidPt.Add(inFile.ReadBoolean());
                    lineWidthPt.Add(inFile.ReadInt32());
                }
                Invalidate();
                inFile.Close();
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startPt.Clear();
            endPt.Clear();
            Invalidate();
        }

        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineSolid = true;
            solidToolStripMenuItem.Checked = true;
            dashToolStripMenuItem.Checked = false;
            Invalidate();

        }

        private void dashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineSolid = false;
            solidToolStripMenuItem.Checked = false;
            dashToolStripMenuItem.Checked = true;
            Invalidate();

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            lineWidth = 1;
            toolStripMenuItem2.Checked = true;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            Invalidate();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            lineWidth = 2;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = true;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            Invalidate();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            lineWidth = 3;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = true;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            Invalidate();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            lineWidth = 4;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = true;
            toolStripMenuItem6.Checked = false;
            Invalidate();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            lineWidth = 4;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = true;
            Invalidate();
        }
    }
}
