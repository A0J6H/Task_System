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
        int xposr = 184;
        int xposl = 0;
        int yposr = 7;
        int yposl = 211;
        int c = 1;
        public Form1()
        {
            //size 420, 693
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel4.Location = new Point(-1,-1);
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
            //size 569, 768
            // p size 557, 734
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
            panel4.Visible = true;
            panel2.Visible = false;

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

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.Lines.Count().ToString());
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel4.Visible = false;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            int tc = 0;
            Random rnd = new Random();
            int rc = rnd.Next(0, 3);
            string name = textBox3.Text.ToString();
            string ndate = dateTimePicker1.Value.ToString();
            string desc = textBox2.Text;
            string path = string.Empty;
            string path2 = string.Empty;
            if (x == true)
            {
                name = "Homework";
                x = false;
            }

            Panel dynamicPanel = new Panel();


            if (c == 1)
            {
                dynamicPanel.Location = new System.Drawing.Point(xposr, yposr);
                yposr += 110 + 30 + textBox1.Lines.Count() * 17;
                c -= 1;
            }
            else
            {
                dynamicPanel.Location = new System.Drawing.Point(xposl, yposl);
                yposl += 110 + 30 + textBox1.Lines.Count() * 17;
                c += 1;
            }



            dynamicPanel.Name = "Panel1";
            dynamicPanel.Size = new System.Drawing.Size(175, 110 + 30 + textBox1.Lines.Count() * 17);
            //TextBox textBox1 = new TextBox();
            //textBox1.Location = new Point(10, 10);
            //textBox1.Text = "I am a TextBox5";
            //textBox1.Size = new Size(200, 30);
            //Creating ROUND picturebox//
            PictureBox roundtop = new PictureBox();
            roundtop.Location = new Point(20, 9);
            roundtop.Size = new Size(154, 86);
            roundtop.BackColor = Color.Transparent;
            roundtop.BackgroundImageLayout = ImageLayout.Stretch;
            /////////////////////////////
            //Creating ROUND picturebox//
            PictureBox roundbot = new PictureBox();
            roundbot.Location = new Point(20, (110 + 30 + textBox1.Lines.Count() * 17) - 90);
            roundbot.Size = new Size(154, 90);
            roundbot.BackColor = Color.Transparent;
            roundbot.BackgroundImageLayout = ImageLayout.Stretch;
            /////////////////////////////
            PictureBox pictureBox = new PictureBox();
            switch (rc)
            {
                case 0:
                    path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\GreenTask.png");
                    path2 = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\grt.png");
                    roundtop.BackgroundImage = Image.FromFile(path2);
                    roundbot.BackgroundImage = Image.FromFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\grb.png"));
                    pictureBox.BackgroundImage = Image.FromFile(path);
                    break;
                case 1:
                    path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\TanTask.png");
                    path2 = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\trt.png");
                    roundtop.BackgroundImage = Image.FromFile(path2);
                    roundbot.BackgroundImage = Image.FromFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\trb.png"));
                    pictureBox.BackgroundImage = Image.FromFile(path);
                    break;
                case 2:
                    path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\OffWhiteTask.png");
                    path2 = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\ort.png");
                    roundtop.BackgroundImage = Image.FromFile(path2);
                    roundbot.BackgroundImage = Image.FromFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\orb.png"));
                    pictureBox.BackgroundImage = Image.FromFile(path);
                    break;
            }

            pictureBox.Location = new Point(20, 9);
            pictureBox.Size = new Size(154, 110 + 30 + textBox1.Lines.Count() * 17);
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;

            //Creating the EDIT button//
            Button button = new Button();
            button.BackgroundImage = Image.FromFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\Group 2.png"));
            button.BackgroundImageLayout = ImageLayout.Stretch | ImageLayout.Center;
            button.BackColor = Color.FromArgb(cols[rc * 3], cols[rc * 3 + 1], cols[rc * 3 + 2]);
            button.FlatAppearance.BorderSize = 0;
            button.Name = name;
            button.Click += Button_Click;
            button.Location = new Point(110, 25);
            button.Size = new Size(50, 13);
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
            FontStyle style_ = FontStyle.Underline;
            /////////////////////////////
            /////Creating the TITLE label//
            Label title = new Label();
            title.Text = name;
            title.Font = new Font(large_font, style_);
            title.ForeColor = Color.FromArgb(cols[tc * 3], cols[tc * 3 + 1], cols[tc * 3 + 2]);
            title.BackColor = Color.FromArgb(cols[rc * 3], cols[rc * 3 + 1], cols[rc * 3 + 2]);
            title.Location = new Point(23, 30);
            ////////////////////////////
            //Creating the DATE DUE label//
            Label date_due = new Label();
            date_due.Text = "Due Date :";
            date_due.Font = new Font(font, style_);
            date_due.ForeColor = Color.FromArgb(cols[tc * 3], cols[tc * 3 + 1], cols[tc * 3 + 2]);
            date_due.BackColor = Color.FromArgb(cols[rc * 3], cols[rc * 3 + 1], cols[rc * 3 + 2]);
            date_due.Location = new Point(20, 60);
            //Creating the DISPLAY DATE label//
            Label date = new Label();
            date.Text = ndate;
            date.Font = font;
            date.Width = 90;
            date.MaximumSize = new Size(90, 20);
            date.ForeColor = Color.FromArgb(cols[tc * 3], cols[tc * 3 + 1], cols[tc * 3 + 2]);
            date.BackColor = Color.FromArgb(cols[rc * 3], cols[rc * 3 + 1], cols[rc * 3 + 2]);
            date.Location = new Point(80, 60);
            ///////////////////////////////////
            //Creating DETAILS SUB label//
            Label details_sub = new Label();
            details_sub.Text = "Notes :";
            details_sub.Font = new Font(font, style_);
            details_sub.Width = 90;
            details_sub.MaximumSize = new Size(90, 20);
            details_sub.ForeColor = Color.FromArgb(cols[tc * 3], cols[tc * 3 + 1], cols[tc * 3 + 2]);
            details_sub.BackColor = Color.FromArgb(cols[rc * 3], cols[rc * 3 + 1], cols[rc * 3 + 2]);
            details_sub.Location = new Point(20, 90);
            //Creating DETAILS textbox//
            TextBox details = new TextBox();
            details.BorderStyle = BorderStyle.None;
            details.Cursor = DefaultCursor;
            details.Multiline = true;
            details.Font = font;
            details.Text = textBox2.Text.ToString();
            details.Size = new Size(150, textBox2.Lines.Count() * 17);
            details.ForeColor = Color.FromArgb(cols[tc * 3], cols[tc * 3 + 1], cols[tc * 3 + 2]);
            details.BackColor = Color.FromArgb(cols[rc * 3], cols[rc * 3 + 1], cols[rc * 3 + 2]);
            details.Location = new Point(22, 110);
            MessageBox.Show(details.Text.ToString());
            MessageBox.Show(textBox1.Lines.Count().ToString());
            /////////////////////////////
            //Creating DATE CREATED label//
            Label cdate = new Label();
            cdate.Text = "16/11/2023";
            cdate.Font = font;
            cdate.Width = 90;
            cdate.ForeColor = Color.FromArgb(cols[tc * 3], cols[tc * 3 + 1], cols[tc * 3 + 2]);
            cdate.BackColor = Color.FromArgb(cols[rc * 3], cols[rc * 3 + 1], cols[rc * 3 + 2]);
            cdate.Location = new Point(65, 110 + textBox1.Lines.Count() * 17 + 4);
            //CheckBox checkBox1 = new CheckBox();
            //checkBox1.Location = new Point(10, 50);
            //checkBox1.Text = "Check Me";
            //checkBox1.Size = new Size(200, 30);
            //dynamicPanel.Controls.Add(textBox1);
            dynamicPanel.Controls.Add(cdate);
            dynamicPanel.Controls.Add(details);
            dynamicPanel.Controls.Add(button);
            dynamicPanel.Controls.Add(title);
            dynamicPanel.Controls.Add(date);
            dynamicPanel.Controls.Add(date_due);
            dynamicPanel.Controls.Add(details_sub);
            dynamicPanel.Controls.Add(roundtop);
            dynamicPanel.Controls.Add(roundbot);
            dynamicPanel.Controls.Add(pictureBox);
            //dynamicPanel.Controls.Add(checkBox1);
            Controls.Add(dynamicPanel);
            panel3.Controls.Add(dynamicPanel);
        }
    }
}
