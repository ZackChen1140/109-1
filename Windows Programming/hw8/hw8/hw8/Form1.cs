using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw8
{
    public partial class Form1 : Form
    {
        Bitmap apple = new Bitmap(Properties.Resources.Apple);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'studentsDataSet.Students' 資料表。您可以視需要進行移動或移除。
            this.studentsTableAdapter.Fill(this.studentsDataSet.Students);
            label8.Text = ((int.Parse(textBox3.Text) + int.Parse(textBox4.Text)) / 2).ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((this.studentsBindingSource.Find("StudentID", textBox1.Text)) != -1)
            {
                MessageBox.Show("This ID exists!");
            }
            else if(int.Parse(textBox3.Text)>100|| int.Parse(textBox3.Text)<0)
            {
                MessageBox.Show("Incorrect MidExam Score!");
            }
            else if (int.Parse(textBox4.Text) > 100 || int.Parse(textBox4.Text) < 0)
            {
                MessageBox.Show("Incorrect FinalExam Score!");
            }
            else
            {
                this.studentsTableAdapter.Insert(textBox1.Text, textBox2.Text, comboBox1.Text,int.Parse(textBox3.Text),int.Parse(textBox4.Text));
                this.studentsTableAdapter.Fill(this.studentsDataSet.Students);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.studentsBindingSource.EndEdit();
            this.studentsTableAdapter.Update(this.studentsDataSet);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.studentsTableAdapter.Delete(textBox1.Text, textBox2.Text, comboBox1.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            this.studentsTableAdapter.Fill(this.studentsDataSet.Students);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = -1;
            switch (comboBox2.Text)
            {
                case "ID":
                    i = this.studentsBindingSource.Find("StudentID", textBox5.Text);
                    break;
                case "Name":
                    i = this.studentsBindingSource.Find("StudentName", textBox5.Text);
                    break;
            }
            if (i != -1)
                this.studentsBindingSource.Position = i;
            else
                MessageBox.Show("Not found!");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text!=""&&textBox4.Text!="")
                label8.Text = ((double.Parse(textBox3.Text) + double.Parse(textBox4.Text)) / 2).ToString();
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (double.Parse(label8.Text) >= 60)
                e.Graphics.DrawImage(apple, 550, 40, apple.Width / 2, apple.Height / 2);
            if (double.Parse(label8.Text) >= 70)
                e.Graphics.DrawImage(apple, 550 + apple.Width / 2, 40, apple.Width / 2, apple.Height / 2);
            if (double.Parse(label8.Text) >= 80)
                e.Graphics.DrawImage(apple, 550 + apple.Width, 40, apple.Width / 2, apple.Height / 2);
            if (double.Parse(label8.Text) >= 90)
                e.Graphics.DrawImage(apple, 550 + 3 * apple.Width / 2, 40, apple.Width / 2, apple.Height / 2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "")
                label8.Text = ((double.Parse(textBox3.Text) + double.Parse(textBox4.Text)) / 2).ToString();
            Invalidate();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "")
                label8.Text = ((double.Parse(textBox3.Text) + double.Parse(textBox4.Text)) / 2).ToString();
            Invalidate();
        }
    }
}
