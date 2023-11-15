using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_System
{
    public partial class Form1 : Form
    {
        //List<Button> tasks = new List<Button>();
        List<int> cols = new List<int>();
        bool x = true;
        public Form1()
        {
            //size 420, 693
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cols.Add(103);
            cols.Add(108);
            cols.Add(59);
            cols.Add(208);
            cols.Add(190);
            cols.Add(143);
            cols.Add(244);
            cols.Add(246);
            cols.Add(220);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneVScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int rc = rnd.Next(0, 3);
            string name = "Revision";
            if (x == true)
            {
                name = "Homework";
                x = false;
            }
            
            Panel dynamicPanel = new Panel();
            dynamicPanel.Location = new System.Drawing.Point(26, 12);
            dynamicPanel.Name = "Panel1";
            dynamicPanel.Size = new System.Drawing.Size(175, 202);
            //TextBox textBox1 = new TextBox();
            //textBox1.Location = new Point(10, 10);
            //textBox1.Text = "I am a TextBox5";
            //textBox1.Size = new Size(200, 30);
            PictureBox pictureBox = new PictureBox();
            switch (rc)
            {
                case 0:
                    pictureBox.BackgroundImage = Image.FromFile("C:\\Users\\Andrew\\source\\repos\\Task_System\\Task_System\\Resources\\GreenTask.png");
                    break; 
                case 1:
                    pictureBox.BackgroundImage = Image.FromFile("C:\\Users\\Andrew\\source\\repos\\Task_System\\Task_System\\Resources\\TanTask.png");
                    break;
                case 2:
                    pictureBox.BackgroundImage = Image.FromFile("C:\\Users\\Andrew\\source\\repos\\Task_System\\Task_System\\Resources\\OffWhiteTask.png");
                    break;
            }
            pictureBox.Location = new Point(20, 9);
            pictureBox.Size = new Size(154, 190);
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            Button button = new Button();
            button.BackgroundImage = Image.FromFile("C:\\Users\\Andrew\\source\\repos\\Task_System\\Task_System\\Resources\\Group 2.png");
            button.BackgroundImageLayout = ImageLayout.Stretch | ImageLayout.Center;
            //button.BackColor = Color.Transparent;
            rc *= 3;
            button.BackColor = Color.FromArgb(cols[rc], cols[rc + 1], cols[rc+2]);
            button.FlatAppearance.BorderSize = 0;
            button.Name = name;
            button.Click += Button_Click;
            button.Location = new Point(110,25);
            button.Size = new Size(50,13);
            button.FlatStyle = FlatStyle.Flat;
            //CheckBox checkBox1 = new CheckBox();
            //checkBox1.Location = new Point(10, 50);
            //checkBox1.Text = "Check Me";
            //checkBox1.Size = new Size(200, 30);
            //dynamicPanel.Controls.Add(textBox1);
            dynamicPanel.Controls.Add(button);
            dynamicPanel.Controls.Add(pictureBox);
            
            //dynamicPanel.Controls.Add(checkBox1);
            Controls.Add(dynamicPanel);
            flowLayoutPanel1.Controls.Add(dynamicPanel);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Name == "Homework")
            {
                //MessageBox.Show("ITS HOMEWORK");
            }
            else if (btn.Name == "Revision")
            {
                //MessageBox.Show("ITS REVISION");
            }
            
        }
    }
}
