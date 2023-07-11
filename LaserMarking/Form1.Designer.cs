namespace LaserMarking
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            picBoxPrew = new PictureBox();
            label6 = new Label();
            groupBox3 = new GroupBox();
            trackBar3 = new TrackBar();
            label1 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            tb_tagID = new TextBox();
            tb_jobNo = new TextBox();
            tb_requestNo = new TextBox();
            button6 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox1 = new GroupBox();
            checkBox5 = new CheckBox();
            checkBox4 = new CheckBox();
            label2 = new Label();
            checkBox2 = new CheckBox();
            label3 = new Label();
            checkBox1 = new CheckBox();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            button1 = new Button();
            button2 = new Button();
            checkBox3 = new CheckBox();
            groupBox2 = new GroupBox();
            button5 = new Button();
            button3 = new Button();
            button4 = new Button();
            groupBox5 = new GroupBox();
            comboBox1 = new ComboBox();
            button10 = new Button();
            button8 = new Button();
            button9 = new Button();
            button7 = new Button();
            groupBox6 = new GroupBox();
            textBox1 = new TextBox();
            label11 = new Label();
            textBox2 = new TextBox();
            label7 = new Label();
            textBox3 = new TextBox();
            label5 = new Label();
            comboBox2 = new ComboBox();
            label4 = new Label();
            groupBox4 = new GroupBox();
            radioButton2 = new RadioButton();
            button11 = new Button();
            ((System.ComponentModel.ISupportInitialize)picBoxPrew).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            groupBox2.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // picBoxPrew
            // 
            picBoxPrew.BackColor = SystemColors.ControlLightLight;
            picBoxPrew.BorderStyle = BorderStyle.Fixed3D;
            picBoxPrew.Location = new Point(0, 0);
            picBoxPrew.Margin = new Padding(3, 4, 3, 4);
            picBoxPrew.Name = "picBoxPrew";
            picBoxPrew.Size = new Size(817, 713);
            picBoxPrew.TabIndex = 1;
            picBoxPrew.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.Window;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(9, 8);
            label6.Name = "label6";
            label6.Size = new Size(49, 23);
            label6.TabIndex = 16;
            label6.Text = "View";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(trackBar3);
            groupBox3.Controls.Add(picBoxPrew);
            groupBox3.Location = new Point(3, 1);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(827, 713);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            // 
            // trackBar3
            // 
            trackBar3.AllowDrop = true;
            trackBar3.AutoSize = false;
            trackBar3.BackColor = SystemColors.Window;
            trackBar3.Location = new Point(775, 27);
            trackBar3.Maximum = 30;
            trackBar3.Name = "trackBar3";
            trackBar3.Orientation = Orientation.Vertical;
            trackBar3.RightToLeft = RightToLeft.No;
            trackBar3.Size = new Size(26, 690);
            trackBar3.TabIndex = 29;
            trackBar3.TickStyle = TickStyle.TopLeft;
            trackBar3.Scroll += trackBar3_Scroll;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.Window;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.InfoText;
            label1.Location = new Point(578, 718);
            label1.Name = "label1";
            label1.Size = new Size(177, 31);
            label1.TabIndex = 26;
            label1.Text = "Total Marked:";
            label1.Click += label1_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(8, 807);
            label8.Name = "label8";
            label8.Size = new Size(52, 20);
            label8.TabIndex = 24;
            label8.Text = "TagID:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(7, 765);
            label9.Name = "label9";
            label9.Size = new Size(58, 20);
            label9.TabIndex = 23;
            label9.Text = "JobNo:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(8, 726);
            label10.Name = "label10";
            label10.Size = new Size(88, 20);
            label10.TabIndex = 22;
            label10.Text = "RequestNo:";
            // 
            // tb_tagID
            // 
            tb_tagID.BackColor = SystemColors.Window;
            tb_tagID.Location = new Point(101, 804);
            tb_tagID.Margin = new Padding(3, 4, 3, 4);
            tb_tagID.Name = "tb_tagID";
            tb_tagID.Size = new Size(181, 27);
            tb_tagID.TabIndex = 21;
            tb_tagID.TextChanged += tb_tagID_TextChanged;
            // 
            // tb_jobNo
            // 
            tb_jobNo.BackColor = SystemColors.Window;
            tb_jobNo.Location = new Point(101, 763);
            tb_jobNo.Margin = new Padding(3, 4, 3, 4);
            tb_jobNo.Name = "tb_jobNo";
            tb_jobNo.Size = new Size(181, 27);
            tb_jobNo.TabIndex = 20;
            tb_jobNo.TextChanged += tb_jobNo_TextChanged;
            // 
            // tb_requestNo
            // 
            tb_requestNo.BackColor = SystemColors.Window;
            tb_requestNo.Location = new Point(101, 724);
            tb_requestNo.Margin = new Padding(3, 4, 3, 4);
            tb_requestNo.Name = "tb_requestNo";
            tb_requestNo.Size = new Size(181, 27);
            tb_requestNo.TabIndex = 19;
            tb_requestNo.TextChanged += tb_requestNo_TextChanged;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.Window;
            button6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(357, 755);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(156, 81);
            button6.TabIndex = 25;
            button6.Text = "GET";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 200;
            timer1.Tick += timer1_Tick;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.DarkGray;
            groupBox1.Controls.Add(checkBox5);
            groupBox1.Controls.Add(checkBox4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(trackBar1);
            groupBox1.Controls.Add(trackBar2);
            groupBox1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(11, 141);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(323, 167);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Change Text Size";
            groupBox1.Visible = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox5.Location = new Point(19, 25);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(72, 24);
            checkBox5.TabIndex = 22;
            checkBox5.Text = "String";
            checkBox5.UseVisualStyleBackColor = true;
            checkBox5.CheckedChanged += checkBox5_CheckedChanged;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox4.Location = new Point(210, 25);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(65, 24);
            checkBox4.TabIndex = 21;
            checkBox4.Text = "Logo";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.DarkGray;
            label2.Font = new Font("Britannic Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(34, 81);
            label2.Name = "label2";
            label2.Size = new Size(27, 22);
            label2.TabIndex = 9;
            label2.Text = "X:";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox2.Location = new Point(19, 48);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(68, 24);
            checkBox2.TabIndex = 20;
            checkBox2.Text = "HUID";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.Visible = false;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.DarkGray;
            label3.Font = new Font("Britannic Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(34, 118);
            label3.Name = "label3";
            label3.Size = new Size(26, 22);
            label3.TabIndex = 11;
            label3.Text = "Y:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox1.Location = new Point(210, 49);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(72, 24);
            checkBox1.TabIndex = 18;
            checkBox1.Text = "Purity";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Visible = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // trackBar1
            // 
            trackBar1.AutoSize = false;
            trackBar1.BackColor = Color.DarkGray;
            trackBar1.Location = new Point(80, 80);
            trackBar1.Maximum = 5000;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(202, 29);
            trackBar1.TabIndex = 18;
            trackBar1.TickStyle = TickStyle.None;
            trackBar1.Scroll += trackBar1_Scroll;
            trackBar1.MouseUp += trackBar1_MouseUp;
            // 
            // trackBar2
            // 
            trackBar2.AutoSize = false;
            trackBar2.BackColor = Color.DarkGray;
            trackBar2.Location = new Point(80, 116);
            trackBar2.Maximum = 5000;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(202, 29);
            trackBar2.TabIndex = 19;
            trackBar2.TickStyle = TickStyle.None;
            trackBar2.Scroll += trackBar2_Scroll;
            trackBar2.MouseUp += trackBar2_MouseUp;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Window;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(19, 16);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(298, 44);
            button1.TabIndex = 0;
            button1.Text = "Connect Device";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Window;
            button2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(19, 89);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(298, 44);
            button2.TabIndex = 2;
            button2.Text = "Show Pic";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox3.Location = new Point(19, 62);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(102, 24);
            checkBox3.TabIndex = 21;
            checkBox3.Text = "Break Line";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.DarkGray;
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(button4);
            groupBox2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.Black;
            groupBox2.Location = new Point(13, 665);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(321, 172);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Laser Control";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.Window;
            button5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(21, 125);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(283, 40);
            button5.TabIndex = 7;
            button5.Text = "Stop Laser/Aiming";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.Window;
            button3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(21, 81);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(283, 40);
            button3.TabIndex = 5;
            button3.Text = "LaserMarking";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.Window;
            button4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(21, 35);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(283, 40);
            button4.TabIndex = 6;
            button4.Text = "Aiming";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.DarkGray;
            groupBox5.Controls.Add(comboBox1);
            groupBox5.Controls.Add(button10);
            groupBox5.Controls.Add(button8);
            groupBox5.Controls.Add(button9);
            groupBox5.Controls.Add(button7);
            groupBox5.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox5.Location = new Point(11, 311);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(323, 173);
            groupBox5.TabIndex = 30;
            groupBox5.TabStop = false;
            groupBox5.Text = "Move String";
            groupBox5.Enter += groupBox5_Enter;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.DimGray;
            comboBox1.ForeColor = Color.DarkGray;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "2mm", "1mm", "0.5mm", "0.1mm", "0.05mm" });
            comboBox1.Location = new Point(235, 16);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(82, 29);
            comboBox1.TabIndex = 26;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button10
            // 
            button10.BackColor = SystemColors.Window;
            button10.Font = new Font("Webdings", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            button10.Location = new Point(128, 117);
            button10.Name = "button10";
            button10.Size = new Size(50, 50);
            button10.TabIndex = 29;
            button10.Text = "6";
            button10.TextAlign = ContentAlignment.TopCenter;
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // button8
            // 
            button8.BackColor = SystemColors.Window;
            button8.Font = new Font("Webdings", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            button8.Location = new Point(184, 71);
            button8.Name = "button8";
            button8.Size = new Size(50, 50);
            button8.TabIndex = 27;
            button8.Text = "4";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.BackColor = SystemColors.Window;
            button9.Font = new Font("Webdings", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            button9.Location = new Point(128, 28);
            button9.Name = "button9";
            button9.Size = new Size(50, 50);
            button9.TabIndex = 28;
            button9.Text = "5";
            button9.TextAlign = ContentAlignment.TopCenter;
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // button7
            // 
            button7.BackColor = SystemColors.Window;
            button7.Font = new Font("Webdings", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            button7.Location = new Point(72, 71);
            button7.Name = "button7";
            button7.Size = new Size(50, 50);
            button7.TabIndex = 26;
            button7.Text = "3";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // groupBox6
            // 
            groupBox6.BackColor = Color.DarkGray;
            groupBox6.Controls.Add(textBox1);
            groupBox6.Controls.Add(label11);
            groupBox6.Controls.Add(textBox2);
            groupBox6.Controls.Add(label7);
            groupBox6.Controls.Add(textBox3);
            groupBox6.Controls.Add(label5);
            groupBox6.Controls.Add(comboBox2);
            groupBox6.Controls.Add(label4);
            groupBox6.ImeMode = ImeMode.NoControl;
            groupBox6.Location = new Point(13, 490);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(321, 168);
            groupBox6.TabIndex = 39;
            groupBox6.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Window;
            textBox1.Location = new Point(93, 23);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(211, 30);
            textBox1.TabIndex = 31;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(6, 128);
            label11.Name = "label11";
            label11.Size = new Size(59, 20);
            label11.TabIndex = 38;
            label11.Text = "Filling :";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Window;
            textBox2.Location = new Point(93, 59);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(211, 30);
            textBox2.TabIndex = 32;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(6, 95);
            label7.Name = "label7";
            label7.Size = new Size(59, 20);
            label7.TabIndex = 37;
            label7.Text = "Speed :";
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Window;
            textBox3.Location = new Point(93, 93);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(211, 30);
            textBox3.TabIndex = 33;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(4, 62);
            label5.Name = "label5";
            label5.Size = new Size(61, 20);
            label5.TabIndex = 36;
            label5.Text = "Power :";
            // 
            // comboBox2
            // 
            comboBox2.BackColor = SystemColors.Window;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "FILL_NONE", "FILL_SIMPLE_LINE", "FILL_CROSS_LINES", "FILL_TRIPLE_LINES", "FILL_OFFSET", "FILL_SPYRAL_LINE", "FILL_DOT", "FILL_RASTER", "MASK_ENUM_PART", "FILL_UNIDIRECTIONAL", "FILL_SINGLE_POLY", "FILL_UNKNOWN" });
            comboBox2.Location = new Point(93, 128);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(211, 28);
            comboBox2.TabIndex = 34;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(4, 26);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 35;
            label4.Text = "Frequency :";
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.DarkGray;
            groupBox4.Controls.Add(groupBox6);
            groupBox4.Controls.Add(groupBox5);
            groupBox4.Controls.Add(checkBox3);
            groupBox4.Controls.Add(button2);
            groupBox4.Controls.Add(button1);
            groupBox4.Controls.Add(groupBox2);
            groupBox4.Controls.Add(groupBox1);
            groupBox4.Location = new Point(826, 1);
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(340, 845);
            groupBox4.TabIndex = 18;
            groupBox4.TabStop = false;
            groupBox4.Enter += groupBox4_Enter;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(474, 719);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(77, 24);
            radioButton2.TabIndex = 27;
            radioButton2.TabStop = true;
            radioButton2.Text = "Trigger";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button11.Location = new Point(571, 755);
            button11.Name = "button11";
            button11.Size = new Size(133, 81);
            button11.TabIndex = 28;
            button11.Text = "IO";
            button11.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1178, 849);
            Controls.Add(button11);
            Controls.Add(radioButton2);
            Controls.Add(label1);
            Controls.Add(button6);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(tb_tagID);
            Controls.Add(tb_jobNo);
            Controls.Add(tb_requestNo);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Laservall_Marking_0.1";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picBoxPrew).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.PictureBox picBoxPrew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_tagID;
        private System.Windows.Forms.TextBox tb_jobNo;
        private System.Windows.Forms.TextBox tb_requestNo;
        private System.Windows.Forms.Button button6;
        private Label label1;
        private TrackBar trackBar3;
        private System.Windows.Forms.Timer timer1;
        private GroupBox groupBox1;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private Label label2;
        private CheckBox checkBox2;
        private Label label3;
        private CheckBox checkBox1;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private Button button1;
        private Button button2;
        private CheckBox checkBox3;
        private GroupBox groupBox2;
        private Button button5;
        private Button button3;
        private Button button4;
        private GroupBox groupBox5;
        private ComboBox comboBox1;
        private Button button10;
        private Button button8;
        private Button button9;
        private Button button7;
        private GroupBox groupBox6;
        private TextBox textBox1;
        private Label label11;
        private TextBox textBox2;
        private Label label7;
        private TextBox textBox3;
        private Label label5;
        private ComboBox comboBox2;
        private Label label4;
        private GroupBox groupBox4;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Button button11;
    }
}

