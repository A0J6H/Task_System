using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task_System.Properties;

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
            cols.Add(106);
            cols.Add(93);
            cols.Add(62);
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
            int tc;
            Random rnd = new Random();
            int rc = rnd.Next(0, 3);
            string name = "Revision";
            string path;
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
                    path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\GreenTask.png");
                    //pictureBox.BackgroundImage = Image.FromFile("C:\\Users\\Andrew\\source\\repos\\Task_System\\Task_System\\Resources\\GreenTask.png");
                    pictureBox.BackgroundImage = Image.FromFile(path);
                    break; 
                case 1:
                    path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\TanTask.png");
                    //pictureBox.BackgroundImage = Image.FromFile("C:\\Users\\Andrew\\source\\repos\\Task_System\\Task_System\\Resources\\TanTask.png");
                    pictureBox.BackgroundImage = Image.FromFile(path);
                    break;
                case 2:
                    path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\OffWhiteTask.png");
                    //pictureBox.BackgroundImage = Image.FromFile("C:\\Users\\Andrew\\source\\repos\\Task_System\\Task_System\\Resources\\OffWhiteTask.png");
                    pictureBox.BackgroundImage = Image.FromFile(path);
                    break;
            }
            
            pictureBox.Location = new Point(20, 9);
            pictureBox.Size = new Size(154, 190);
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            //Creating the EDIT button//
            Button button = new Button();
            button.BackgroundImage = Image.FromFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\Group 2.png"));
            button.BackgroundImageLayout = ImageLayout.Stretch | ImageLayout.Center;
            button.BackColor = Color.FromArgb(cols[rc*3], cols[rc*3 + 1], cols[rc*3+2]);
            button.FlatAppearance.BorderSize = 0;
            button.Name = name;
            button.Click += Button_Click;
            button.Location = new Point(110,25);
            button.Size = new Size(50,13);
            button.FlatStyle = FlatStyle.Flat;
            ////////////////////////////
            //Setting color scheme for the Labels//
            if (rc == 0)
            {
                tc = 2;
            }
            else if (rc == 1)
            {
                tc = 0;
            }
            else
            {
                tc = 3;
            }
            ////////////////////////////
            //Creating Fonts + Styles//
            Font large_font = new Font("Comic Sans MS", 11);
            Font font = new Font("Comic Sans MS", 9);
            FontStyle style_ = FontStyle.Underline ;
            /////////////////////////////
            /////Creating the TITLE label//
            Label title = new Label();
            title.Text = "Title :";
            title.Font = new Font(large_font, style_);
            title.ForeColor = Color.FromArgb(cols[tc * 3], cols[tc * 3 + 1], cols[tc * 3 + 2]); 
            title.BackColor = Color.FromArgb(cols[rc * 3], cols[rc * 3 + 1], cols[rc * 3 + 2]);
            title.Location = new Point(40,30);
            ////////////////////////////
            //Creating the DATE DUE label//
            Label date_due = new Label();
            date_due.Text = "Due Date :";
            date_due.Font = new Font(font, style_);
            date_due.ForeColor = Color.FromArgb(cols[tc * 3], cols[tc * 3 + 1], cols[tc * 3 + 2]);
            date_due.BackColor = Color.FromArgb(cols[rc * 3], cols[rc * 3 + 1], cols[rc * 3 + 2]);
            date_due.Location = new Point(35, 65);
            //Creating the DISPLAY DATE label//
            Label date = new Label();
            date.Text = "20/11/2023";
            date.Font = font;
            date.ForeColor = Color.FromArgb(cols[tc * 3], cols[tc * 3 + 1], cols[tc * 3 + 2]);
            date.BackColor = Color.FromArgb(cols[rc * 3], cols[rc * 3 + 1], cols[rc * 3 + 2]);
            date.Location = new Point(65, 65);
            //CheckBox checkBox1 = new CheckBox();
            //checkBox1.Location = new Point(10, 50);
            //checkBox1.Text = "Check Me";
            //checkBox1.Size = new Size(200, 30);
            //dynamicPanel.Controls.Add(textBox1);
            dynamicPanel.Controls.Add(button);
            dynamicPanel.Controls.Add(title);
            dynamicPanel.Controls.Add(date_due);
            dynamicPanel.Controls.Add(date);
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
