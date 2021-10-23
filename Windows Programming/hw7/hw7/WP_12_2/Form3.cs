using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WP_12_2
{
    public partial class Form3 : Form
    {
        private float R = -1, G = -1, B = -1, A = -1;
        bool changed = false;
        public Form3()
        {
            InitializeComponent();
        }
        public float getR()
        {
            return R;
        }
        public float getG()
        {
            return G;
        }
        public float getB()
        {
            return B;
        }
        public float getA()
        {
            return A;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = (trackBar1.Value / 10).ToString() + '.' + (trackBar1.Value % 10).ToString();
            changed = true;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label6.Text = (trackBar2.Value / 10).ToString() + '.' + (trackBar2.Value % 10).ToString();
            changed = true;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label7.Text = (trackBar3.Value / 10).ToString() + '.' + (trackBar3.Value % 10).ToString();
            changed = true;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label8.Text = (trackBar4.Value / 10).ToString() + '.' + (trackBar4.Value % 10).ToString();
            changed = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(changed)
            {
                R = trackBar1.Value / 20;
                G = trackBar2.Value / 20;
                B = trackBar3.Value / 20;
                A = trackBar4.Value / 20;
            }
            Close();
        }
    }
}
