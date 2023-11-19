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
using System.Xml;
using Task_System.Properties;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;
using System.Diagnostics;

namespace Task_System
{
    public partial class Form1 : Form
    {
        //List<Task> tasks = new List<Task>();
        int Active = 0;   
        List<int> cols = new List<int>();
        int xposr = 184;
        int xposl = 0;
        int yposr = 7;
        int yposl = 211;
        int c = 1;
        string filter = string.Empty;
        string json_filepath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Tasks.json");
        List<Task> tasks = JsonConvert.DeserializeObject<List<Task>>(File.ReadAllText(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Tasks.json")));
        public Form1()
        {
            //size 420, 693
            InitializeComponent();
            
        }

        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Edit.Visible = false;
            Remove.Visible = false;
            comboBox1.Location = new Point(61, 678);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.MouseDown += Panel2_MouseDown;
            panel3.MouseWheel += Panel3_MouseWheel;
            comboBox1.DropDown += ComboBox1_DropDown;
            comboBox1.DropDownClosed += ComboBox1_DropDownClosed;
            xposr = 184;
            xposl = 0;
            yposr = 7;
            yposl = 211;
            c= 1;
            textBox3.MaxLength = 9;
            panel4.Location = new Point(-1,-1);
            
            if (cols.Count() == 0)
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
            //size 569, 768
            // p size 557, 734
            if (tasks == null )
            {
                tasks = new List<Task>();
                Task tutorial = new Task
                {
                    Title = "Tutorial",
                    Description = "Welcome !!!\r\nIn this app you can :\r\nCreate (+),\r\nDelete And Edit (...)\r\nAll of your reminders.\r\nTry Deleting me :)",
                    DateSet = DateTime.Now.Date,
                    DueDate = DateTime.Now.Date
                };
                tasks.Add(tutorial);
            }
            else if (tasks.Count ==0)
            {
                Task tutorial = new Task
                {
                    Title = "Tutorial",
                    Description = "Welcome !!!\r\nIn this app you can :\r\nCreate (+),\r\nDelete And Edit (...)\r\nAll of your reminders.\r\nTry Deleting me :)",
                    DateSet = DateTime.Now.Date,
                    DueDate = DateTime.Now.Date
                };
                tasks.Add(tutorial);
            }
            if (filter == "duedate")
            {
                List<Task> taskss = tasks.OrderBy(obj => obj.DueDate).ToList();
                tasks = taskss;
                label8.Text = "Sorted by Due Date :";
            }
            else if (filter == "duedatedesc")
            {
                List<Task> taskss = tasks.OrderByDescending(obj => obj.DueDate).ToList();
                tasks = taskss;
                label8.Text = "Sorted by Due Date Descending :";
            }
            else if (filter == "name")
            {
                List<Task> taskss = tasks.OrderBy(obj => obj.Title).ToList();
                tasks = taskss;
                label8.Text = "Sorted by Name :";
            }
            else if (filter == "creation")
            {
                List<Task> taskss = tasks.OrderBy(obj => obj.DateSet).ToList();
                tasks = taskss;
                label8.Text = "Sorted by Date Created :";
            }
            for (int i = 0; i < tasks.Count; i++)
            {
                int tc = 0;
                Random rnd = new Random();
                int rc = rnd.Next(0, 3);
                string path = string.Empty;
                string path2 = string.Empty;
                Panel dynamicPanel = new Panel();
                string inputs = tasks[i].Description;

                string target = ("\r");

                int count = 0;
                int index = inputs.IndexOf(target, StringComparison.OrdinalIgnoreCase);

                while (index != -1)
                {
                    count++;
                    index = inputs.IndexOf(target, index + target.Length, StringComparison.OrdinalIgnoreCase);
                }
                count++;

                if (c == 1)
                {
                    if (yposr == 7)
                    {
                        dynamicPanel.Location = new System.Drawing.Point(xposr, yposr);
                        yposr += 110 + 30 + count * 17;
                        c -= 1;
                    }
                    else
                    {
                        dynamicPanel.Location = new System.Drawing.Point(xposr, yposr);
                        yposr += 110 + 30 + count * 17;
                        c -= 1;
                    }

                }
                else
                {
                    dynamicPanel.Location = new System.Drawing.Point(xposl, yposl);
                    yposl += 110 + 30 + count * 17;
                    c += 1;
                }



                dynamicPanel.Name = "Panel1";
                dynamicPanel.Size = new System.Drawing.Size(175, 110 + 30 + count * 17);
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
                roundbot.Location = new Point(20, (110 + 30 + count * 17) - 90);
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
                        roundbot.Location = new Point(19, (110 + 30 + count * 17) - 90);
                        roundbot.Size = new Size(155, 90);
                        roundbot.BackgroundImage = Image.FromFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\orb.png"));
                        pictureBox.BackgroundImage = Image.FromFile(path);
                        break;
                }

                pictureBox.Location = new Point(20, 9);
                pictureBox.Size = new Size(154, 110 + 30 + count * 17);
                pictureBox.BackgroundImageLayout = ImageLayout.Stretch;

                //Creating the EDIT button//
                Button button = new Button();
                button.BackgroundImage = Image.FromFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\Group 2.png"));
                button.BackgroundImageLayout = ImageLayout.Stretch | ImageLayout.Center;
                button.BackColor = Color.FromArgb(cols[rc * 3], cols[rc * 3 + 1], cols[rc * 3 + 2]);
                button.FlatAppearance.BorderSize = 0;
                button.Name = tasks[i].Title;
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
                title.Text = tasks[i].Title;
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
                date.Text = tasks[i].DueDate.Date.ToString();
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
                details.Text = tasks[i].Description;
                details.Size = new Size(152, count * 17);
                details.ForeColor = Color.FromArgb(cols[tc * 3], cols[tc * 3 + 1], cols[tc * 3 + 2]);
                details.BackColor = Color.FromArgb(cols[rc * 3], cols[rc * 3 + 1], cols[rc * 3 + 2]);
                details.Location = new Point(22, 110);
                details.ReadOnly = true;
                /////////////////////////////
                //Creating DATE CREATED label//
                Label cdate = new Label();
                cdate.Text = tasks[i].DateSet.Date.ToString();
                cdate.Font = font;
                cdate.Width = 90;
                cdate.ForeColor = Color.FromArgb(cols[tc * 3], cols[tc * 3 + 1], cols[tc * 3 + 2]);
                cdate.BackColor = Color.FromArgb(cols[rc * 3], cols[rc * 3 + 1], cols[rc * 3 + 2]);
                cdate.Location = new Point(65, 110 + count * 17 + 4);
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
                
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.ResetText();
            panel4.Visible = false;
            panel2.Visible = true;

        }

        private void ComboBox1_DropDownClosed(object sender, EventArgs e)
        {
            
        }

        private void ComboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Location = new Point(61, 651);
        }

        private void Panel3_MouseWheel(object sender, MouseEventArgs e)
        {
            Edit.Visible = false;
            Remove.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel2.Visible = false;
            panel6.Visible = false;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var panel = btn.Parent;
            var bigpanel = panel.Parent;
            for (int i = 0; i < tasks.Count(); i++)
            {
                if (tasks[i].Title == btn.Name)
                {
                    int bpxcoor = bigpanel.Location.X;
                    int bpycoor = bigpanel.Location.Y;
                    int pxcoor = panel.Location.X;
                    int pycoor = panel.Location.Y;  
                    int xcoor = btn.Location.X;
                    int ycoor = btn.Location.Y;
                    Edit.Location = new Point(bpxcoor+pxcoor+xcoor,bpycoor+pycoor+ycoor+20);
                    Edit.Visible = true;
                    Remove.Location = new Point(bpxcoor + pxcoor + xcoor, bpycoor + pycoor + ycoor + 44);
                    Remove.Visible = true;
                    Active = i;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel2.Visible = false;
            

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
            DateTime Current_Date = DateTime.Now.Date;
            Task task = new Task
            {
                Title = textBox3.Text,
                Description = textBox2.Text,
                DueDate = dateTimePicker1.Value,
                DateSet = Current_Date
            };
            tasks.Add(task);
            string json = JsonConvert.SerializeObject(tasks, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(json_filepath, json);
            int tc = 0;
            Random rnd = new Random();
            int rc = rnd.Next(0, 3);
            string name = textBox3.Text.ToString();
            string ndate = dateTimePicker1.Value.ToString();
            string desc = textBox2.Text;
            string path = string.Empty;
            string path2 = string.Empty;
            Panel dynamicPanel = new Panel();


            if (c == 1)
            {
                if (yposr == 7)
                {
                    dynamicPanel.Location = new System.Drawing.Point(xposr, yposr);
                    yposr += 110 + 30 + textBox2.Lines.Count() * 17;
                    c -= 1;
                }
                else
                {
                    dynamicPanel.Location = new System.Drawing.Point(xposr, yposr);
                    yposr += 110 +30+ textBox2.Lines.Count() * 17;
                    c -= 1;
                }
                
            }
            else
            {
                dynamicPanel.Location = new System.Drawing.Point(xposl, yposl);
                yposl += 110 + 30 + textBox2.Lines.Count() * 17;
                c += 1;
            }



            dynamicPanel.Name = "Panel1";
            dynamicPanel.Size = new System.Drawing.Size(175, 110 + 30 + textBox2.Lines.Count() * 17);
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
            roundbot.Location = new Point(20, (110 + 30 + textBox2.Lines.Count() * 17) - 90);
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
                    roundbot.Location = new Point(19, (110 + 30 + textBox2.Lines.Count() * 17) - 90 );
                    roundbot.Size = new Size(155, 90);
                    roundbot.BackgroundImage = Image.FromFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\orb.png"));
                    pictureBox.BackgroundImage = Image.FromFile(path);
                    break;
            }

            pictureBox.Location = new Point(20, 9);
            pictureBox.Size = new Size(154, 110 + 30 + textBox2.Lines.Count() * 17);
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;

            //Creating the OPTIONS button//
            Button button = new Button();
            button.BackgroundImage = Image.FromFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources\\Group 2.png"));
            button.BackgroundImageLayout = ImageLayout.Stretch | ImageLayout.Center;
            button.BackColor = Color.FromArgb(cols[rc * 3], cols[rc * 3 + 1], cols[rc * 3 + 2]);
            button.FlatAppearance.BorderSize = 0;
            button.Name = task.Title;
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
            title.Text = task.Title;
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
            date.Text = task.DueDate.Date.ToString();
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
            details.Text = task.Description;
            details.Size = new Size(150, textBox2.Lines.Count() * 17);
            details.ForeColor = Color.FromArgb(cols[tc * 3], cols[tc * 3 + 1], cols[tc * 3 + 2]);
            details.BackColor = Color.FromArgb(cols[rc * 3], cols[rc * 3 + 1], cols[rc * 3 + 2]);
            details.Location = new Point(22, 110);
            details.ReadOnly = true;
            /////////////////////////////
            //Creating DATE CREATED label//
            Label cdate = new Label();
            cdate.Text = task.DateSet.Date.ToString();
            cdate.Font = font;
            cdate.Width = 90;
            cdate.ForeColor = Color.FromArgb(cols[tc * 3], cols[tc * 3 + 1], cols[tc * 3 + 2]);
            cdate.BackColor = Color.FromArgb(cols[rc * 3], cols[rc * 3 + 1], cols[rc * 3 + 2]);
            cdate.Location = new Point(65, 110 + textBox2.Lines.Count() * 17 + 4);
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
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.ResetText();
            panel4.Visible = false;
            panel2.Visible = true;

        }

        private void Edit_Click(object sender, EventArgs e)
        {
            textBox4.Text = tasks[Active].Title;
            textBox1.Text = tasks[Active].Description;
            dateTimePicker2.Value = tasks[Active].DueDate;
            panel4.Visible = true;
            panel6.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Task task = new Task
            {
                Title = textBox4.Text,
                Description = textBox1.Text,
                DueDate = dateTimePicker2.Value,
                DateSet = tasks[Active].DateSet
            };
            panel6.Visible = false;
            textBox1.Clear();
            textBox4.Clear();
            dateTimePicker2.ResetText();
            tasks[Active] = task;
            this.Controls.Clear();
            this.InitializeComponent();
            Form1_Load(this, null);
            panel4.Visible = false;
            string json = JsonConvert.SerializeObject(tasks, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(json_filepath, json);
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Are you sure you want to permenantly remove this task?", "Remove", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                tasks.RemoveAt(Active);
                this.Controls.Clear();
                this.InitializeComponent();
                Form1_Load(this, null);
                string json = JsonConvert.SerializeObject(tasks, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(json_filepath, json);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            filter = comboBox1.Text.ToLower();
            this.Controls.Clear();
            this.InitializeComponent();
            Form1_Load(this, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            this.Controls.Clear();
            this.InitializeComponent();
            Form1_Load(this, null);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/A0J6H/Task_System");
        }
    }
}
