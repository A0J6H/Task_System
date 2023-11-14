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
        List<Button> tasks = new List<Button>();
        bool x = true;
        public Form1()
        {
            //size 420, 693
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
            pictureBox.BackgroundImage = Image.FromFile("C:\\Users\\Andrew\\source\\repos\\Task_System\\Task_System\\Resources\\GreenTask.png");
            pictureBox.Location = new Point(20, 9);
            pictureBox.Size = new Size(154, 190);
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            Button button = new Button();
            button.Name = name;
            button.Click += Button_Click;
            button.Text = name;
            button.Location = new Point(20,50);
            button.Size = new Size(80,50);
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
                MessageBox.Show("ITS HOMEWORK");
            }
            else if (btn.Name == "Revision")
            {
                MessageBox.Show("ITS REVISION");
            }
            
        }
    }
}
