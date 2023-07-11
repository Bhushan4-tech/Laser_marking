class LaserMarking: #this class replaces the original namespace 'LaserMarking'
    class Form1:

        def __init__(self):
            #instance fields found by C# to Python Converter:
            self._components = None

      
        def Dispose(self, disposing):
            if disposing and (self._components is not None):
                self._components.Dispose()
            super().Dispose(disposing)


        def _InitializeComponent(self):
            components = System.ComponentModel.Container()
            resources = System.ComponentModel.ComponentResourceManager(typeof(Form1))
            picBoxPrew = PictureBox()
            label6 = Label()
            groupBox3 = GroupBox()
            trackBar3 = TrackBar()
            label1 = Label()
            label8 = Label()
            label9 = Label()
            label10 = Label()
            tb_tagID = TextBox()
            tb_jobNo = TextBox()
            tb_requestNo = TextBox()
            button6 = Button()
            timer1 = System.Windows.Forms.Timer(components)
            groupBox1 = GroupBox()
            checkBox5 = CheckBox()
            checkBox4 = CheckBox()
            label2 = Label()
            checkBox2 = CheckBox()
            label3 = Label()
            checkBox1 = CheckBox()
            trackBar1 = TrackBar()
            trackBar2 = TrackBar()
            button1 = Button()
            button2 = Button()
            checkBox3 = CheckBox()
            groupBox2 = GroupBox()
            button5 = Button()
            button3 = Button()
            button4 = Button()
            groupBox5 = GroupBox()
            comboBox1 = ComboBox()
            button10 = Button()
            button8 = Button()
            button9 = Button()
            button7 = Button()
            groupBox6 = GroupBox()
            textBox1 = TextBox()
            label11 = Label()
            textBox2 = TextBox()
            label7 = Label()
            textBox3 = TextBox()
            label5 = Label()
            comboBox2 = ComboBox()
            label4 = Label()
            groupBox4 = GroupBox()
            radioButton2 = RadioButton()
            button11 = Button()
            (picBoxPrew).BeginInit()
            groupBox3.SuspendLayout()
            (trackBar3).BeginInit()
            groupBox1.SuspendLayout()
            (trackBar1).BeginInit()
            (trackBar2).BeginInit()
            groupBox2.SuspendLayout()
            groupBox5.SuspendLayout()
            groupBox6.SuspendLayout()
            groupBox4.SuspendLayout()
            SuspendLayout()
            # 
            # picBoxPrew
            # 
            picBoxPrew.BackColor = SystemColors.ControlLightLight
            picBoxPrew.BorderStyle = BorderStyle.Fixed3D
            picBoxPrew.Location = Point(0, 0)
            picBoxPrew.Margin = Padding(3, 4, 3, 4)
            picBoxPrew.Name = "picBoxPrew"
            picBoxPrew.Size = Size(817, 713)
            picBoxPrew.TabIndex = 1
            picBoxPrew.TabStop = False
            # 
            # label6
            # 
            label6.AutoSize = True
            label6.BackColor = SystemColors.Window
            label6.Font = Font("Segoe UI", 10, FontStyle.Bold, GraphicsUnit.Point)
            label6.Location = Point(9, 8)
            label6.Name = "label6"
            label6.Size = Size(49, 23)
            label6.TabIndex = 16
            label6.Text = "View"
            # 
            # groupBox3
            # 
            groupBox3.Controls.Add(label6)
            groupBox3.Controls.Add(trackBar3)
            groupBox3.Controls.Add(picBoxPrew)
            groupBox3.Location = Point(3, 1)
            groupBox3.Margin = Padding(3, 4, 3, 4)
            groupBox3.Name = "groupBox3"
            groupBox3.Padding = Padding(3, 4, 3, 4)
            groupBox3.Size = Size(827, 713)
            groupBox3.TabIndex = 17
            groupBox3.TabStop = False
            # 
            # trackBar3
            # 
            trackBar3.AllowDrop = True
            trackBar3.AutoSize = False
            trackBar3.BackColor = SystemColors.Window
            trackBar3.Location = Point(775, 27)
            trackBar3.Maximum = 30
            trackBar3.Name = "trackBar3"
            trackBar3.Orientation = Orientation.Vertical
            trackBar3.RightToLeft = RightToLeft.No
            trackBar3.Size = Size(26, 690)
            trackBar3.TabIndex = 29
            trackBar3.TickStyle = TickStyle.TopLeft
            trackBar3.Scroll += trackBar3_Scroll
        
            # label1
            # 
            label1.BackColor = SystemColors.Window
            label1.BorderStyle = BorderStyle.Fixed3D
            label1.Font = Font("Segoe UI Semibold", 10.5, FontStyle.Bold, GraphicsUnit.Point)
            label1.ForeColor = SystemColors.InfoText
            label1.Location = Point(578, 718)
            label1.Name = "label1"
            label1.Size = Size(177, 31)
            label1.TabIndex = 26
            label1.Text = "Total Marked:"
            label1.Click += label1_Click
            # 
            # label8
            # 
            label8.AutoSize = True
            label8.Font = Font("Segoe UI Semibold", 9, FontStyle.Bold, GraphicsUnit.Point)
            label8.Location = Point(8, 807)
            label8.Name = "label8"
            label8.Size = Size(52, 20)
            label8.TabIndex = 24
            label8.Text = "TagID:"
            # 
            # label9
            # 
            label9.AutoSize = True
            label9.Font = Font("Segoe UI Semibold", 9, FontStyle.Bold, GraphicsUnit.Point)
            label9.Location = Point(7, 765)
            label9.Name = "label9"
            label9.Size = Size(58, 20)
            label9.TabIndex = 23
            label9.Text = "JobNo:"
            # 
            # label10
            # 
            label10.AutoSize = True
            label10.Font = Font("Segoe UI Semibold", 9, FontStyle.Bold, GraphicsUnit.Point)
            label10.Location = Point(8, 726)
            label10.Name = "label10"
            label10.Size = Size(88, 20)
            label10.TabIndex = 22
            label10.Text = "RequestNo:"
            # 
            # tb_tagID
            # 
            tb_tagID.BackColor = SystemColors.Window
            tb_tagID.Location = Point(101, 804)
            tb_tagID.Margin = Padding(3, 4, 3, 4)
            tb_tagID.Name = "tb_tagID"
            tb_tagID.Size = Size(181, 27)
            tb_tagID.TabIndex = 21
            tb_tagID.TextChanged += tb_tagID_TextChanged
            # 
            # tb_jobNo
            # 
            tb_jobNo.BackColor = SystemColors.Window
            tb_jobNo.Location = Point(101, 763)
            tb_jobNo.Margin = Padding(3, 4, 3, 4)
            tb_jobNo.Name = "tb_jobNo"
            tb_jobNo.Size = Size(181, 27)
            tb_jobNo.TabIndex = 20
            tb_jobNo.TextChanged += tb_jobNo_TextChanged
            # 
            # tb_requestNo
            # 
            tb_requestNo.BackColor = SystemColors.Window
            tb_requestNo.Location = Point(101, 724)
            tb_requestNo.Margin = Padding(3, 4, 3, 4)
            tb_requestNo.Name = "tb_requestNo"
            tb_requestNo.Size = Size(181, 27)
            tb_requestNo.TabIndex = 19
            tb_requestNo.TextChanged += tb_requestNo_TextChanged
            # 
            # button6
            # 
            button6.BackColor = SystemColors.Window
            button6.Font = Font("Segoe UI Semibold", 9, FontStyle.Bold, GraphicsUnit.Point)
            button6.Location = Point(357, 755)
            button6.Margin = Padding(3, 4, 3, 4)
            button6.Name = "button6"
            button6.Size = Size(156, 81)
            button6.TabIndex = 25
            button6.Text = "GET"
            button6.UseVisualStyleBackColor = False
            button6.Click += button6_Click
            # 
            # timer1
            # 
            timer1.Enabled = True
            timer1.Interval = 200
            timer1.Tick += timer1_Tick
            # 
            # groupBox1
            # 
            groupBox1.BackColor = Color.DarkGray
            groupBox1.Controls.Add(checkBox5)
            groupBox1.Controls.Add(checkBox4)
            groupBox1.Controls.Add(label2)
            groupBox1.Controls.Add(checkBox2)
            groupBox1.Controls.Add(label3)
            groupBox1.Controls.Add(checkBox1)
            groupBox1.Controls.Add(trackBar1)
            groupBox1.Controls.Add(trackBar2)
            groupBox1.Font = Font("Segoe UI", 9.5, FontStyle.Bold, GraphicsUnit.Point)
            groupBox1.ForeColor = Color.Black
            groupBox1.Location = Point(11, 141)
            groupBox1.Margin = Padding(3, 4, 3, 4)
            groupBox1.Name = "groupBox1"
            groupBox1.Padding = Padding(3, 4, 3, 4)
            groupBox1.Size = Size(323, 167)
            groupBox1.TabIndex = 14
            groupBox1.TabStop = False
            groupBox1.Text = "Change Text Size"
            groupBox1.Visible = False
            groupBox1.Enter += groupBox1_Enter
            # 
            # checkBox5
            # 
            checkBox5.AutoSize = True
            checkBox5.Font = Font("Segoe UI Semibold", 9, FontStyle.Bold, GraphicsUnit.Point)
            checkBox5.Location = Point(19, 25)
            checkBox5.Name = "checkBox5"
            checkBox5.Size = Size(72, 24)
            checkBox5.TabIndex = 22
            checkBox5.Text = "String"
            checkBox5.UseVisualStyleBackColor = True
            checkBox5.CheckedChanged += checkBox5_CheckedChanged
            
            
            # checkBox4
            # 
            checkBox4.AutoSize = True
            checkBox4.Font = Font("Segoe UI Semibold", 9, FontStyle.Bold, GraphicsUnit.Point)
            checkBox4.Location = Point(210, 25)
            checkBox4.Name = "checkBox4"
            checkBox4.Size = Size(65, 24)
            checkBox4.TabIndex = 21
            checkBox4.Text = "Logo"
            checkBox4.UseVisualStyleBackColor = True
            checkBox4.CheckedChanged += checkBox4_CheckedChanged
            # 
            # label2
            # 
            label2.AutoSize = True
            label2.BackColor = Color.DarkGray
            label2.Font = Font("Britannic Bold", 12, FontStyle.Regular, GraphicsUnit.Point)
            label2.Location = Point(34, 81)
            label2.Name = "label2"
            label2.Size = Size(27, 22)
            label2.TabIndex = 9
            label2.Text = "X:"
            # 
            # checkBox2
            # 
            checkBox2.AutoSize = True
            checkBox2.Font = Font("Segoe UI Semibold", 9, FontStyle.Bold, GraphicsUnit.Point)
            checkBox2.Location = Point(19, 48)
            checkBox2.Name = "checkBox2"
            checkBox2.Size = Size(68, 24)
            checkBox2.TabIndex = 20
            checkBox2.Text = "HUID"
            checkBox2.UseVisualStyleBackColor = True
            checkBox2.Visible = False
            checkBox2.CheckedChanged += checkBox2_CheckedChanged
            # 
            # label3
            # 
            label3.AutoSize = True
            label3.BackColor = Color.DarkGray
            label3.Font = Font("Britannic Bold", 12, FontStyle.Regular, GraphicsUnit.Point)
            label3.Location = Point(34, 118)
            label3.Name = "label3"
            label3.Size = Size(26, 22)
            label3.TabIndex = 11
            label3.Text = "Y:"
            # 
            # checkBox1
            # 
            checkBox1.AutoSize = True
            checkBox1.Font = Font("Segoe UI Semibold", 9, FontStyle.Bold, GraphicsUnit.Point)
            checkBox1.Location = Point(210, 49)
            checkBox1.Name = "checkBox1"
            checkBox1.Size = Size(72, 24)
            checkBox1.TabIndex = 18
            checkBox1.Text = "Purity"
            checkBox1.UseVisualStyleBackColor = True
            checkBox1.Visible = False
            checkBox1.CheckedChanged += checkBox1_CheckedChanged
            # 
            # trackBar1
            # 
            trackBar1.AutoSize = False
            trackBar1.BackColor = Color.DarkGray
            trackBar1.Location = Point(80, 80)
            trackBar1.Maximum = 5000
            trackBar1.Name = "trackBar1"
            trackBar1.Size = Size(202, 29)
            trackBar1.TabIndex = 18
            trackBar1.TickStyle = TickStyle.None_
            trackBar1.Scroll += trackBar1_Scroll
            trackBar1.MouseUp += trackBar1_MouseUp
            # 
            # trackBar2
            # 
            trackBar2.AutoSize = False
            trackBar2.BackColor = Color.DarkGray
            trackBar2.Location = Point(80, 116)
            trackBar2.Maximum = 5000
            trackBar2.Name = "trackBar2"
            trackBar2.Size = Size(202, 29)
            trackBar2.TabIndex = 19
            trackBar2.TickStyle = TickStyle.None_
            trackBar2.Scroll += trackBar2_Scroll
            trackBar2.MouseUp += trackBar2_MouseUp
            # 
            # button1
            # 
            button1.BackColor = SystemColors.Window
            button1.Font = Font("Segoe UI Semibold", 9, FontStyle.Bold, GraphicsUnit.Point)
            button1.Location = Point(19, 16)
            button1.Margin = Padding(3, 4, 3, 4)
            button1.Name = "button1"
            button1.Size = Size(298, 44)
            button1.TabIndex = 0
            button1.Text = "Connect Device"
            button1.UseVisualStyleBackColor = False
            button1.Click += button1_Click
            # 
            # button2
            # 
            button2.BackColor = SystemColors.Window
            button2.Font = Font("Segoe UI Semibold", 9, FontStyle.Bold, GraphicsUnit.Point)
            button2.Location = Point(19, 89)
            button2.Margin = Padding(3, 4, 3, 4)
            button2.Name = "button2"
            button2.Size = Size(298, 44)
            button2.TabIndex = 2
            button2.Text = "Show Pic"
            button2.UseVisualStyleBackColor = False
            button2.Click += button2_Click
            # 
            # checkBox3
            # 
            checkBox3.AutoSize = True
            checkBox3.Font = Font("Segoe UI Semibold", 9, FontStyle.Bold, GraphicsUnit.Point)
            checkBox3.Location = Point(19, 62)
            checkBox3.Name = "checkBox3"
            checkBox3.Size = Size(102, 24)
            checkBox3.TabIndex = 21
            checkBox3.Text = "Break Line"
            checkBox3.UseVisualStyleBackColor = True
            checkBox3.CheckedChanged += checkBox3_CheckedChanged
            
            
            # 
            # groupBox2
            # 
            groupBox2.BackColor = Color.DarkGray
            groupBox2.Controls.Add(button5)
            groupBox2.Controls.Add(button3)
            groupBox2.Controls.Add(button4)
            groupBox2.Font = Font("Segoe UI", 9.5, FontStyle.Bold, GraphicsUnit.Point)
            groupBox2.ForeColor = Color.Black
            groupBox2.Location = Point(13, 665)
            groupBox2.Margin = Padding(3, 4, 3, 4)
            groupBox2.Name = "groupBox2"
            groupBox2.Padding = Padding(3, 4, 3, 4)
            groupBox2.Size = Size(321, 172)
            groupBox2.TabIndex = 15
            groupBox2.TabStop = False
            groupBox2.Text = "Laser Control"
            groupBox2.Enter += groupBox2_Enter
            # 
            # button5
            # 
            button5.BackColor = SystemColors.Window
            button5.Font = Font("Segoe UI Semibold", 9, FontStyle.Bold, GraphicsUnit.Point)
            button5.Location = Point(21, 125)
            button5.Margin = Padding(3, 4, 3, 4)
            button5.Name = "button5"
            button5.Size = Size(283, 40)
            button5.TabIndex = 7
            button5.Text = "Stop Laser/Aiming"
            button5.UseVisualStyleBackColor = False
            button5.Click += button5_Click
            # 
            # button3
            # 
            button3.BackColor = SystemColors.Window
            button3.Font = Font("Segoe UI Semibold", 9, FontStyle.Bold, GraphicsUnit.Point)
            button3.Location = Point(21, 81)
            button3.Margin = Padding(3, 4, 3, 4)
            button3.Name = "button3"
            button3.Size = Size(283, 40)
            button3.TabIndex = 5
            button3.Text = "LaserMarking"
            button3.UseVisualStyleBackColor = False
            button3.Click += button3_Click
            # 
            # button4
            # 
            button4.BackColor = SystemColors.Window
            button4.Font = Font("Segoe UI Semibold", 9, FontStyle.Bold, GraphicsUnit.Point)
            button4.Location = Point(21, 35)
            button4.Margin = Padding(3, 4, 3, 4)
            button4.Name = "button4"
            button4.Size = Size(283, 40)
            button4.TabIndex = 6
            button4.Text = "Aiming"
            button4.UseVisualStyleBackColor = False
            button4.Click += button4_Click
            # 
            # groupBox5
            # 
            groupBox5.BackColor = Color.DarkGray
            groupBox5.Controls.Add(comboBox1)
            groupBox5.Controls.Add(button10)
            groupBox5.Controls.Add(button8)
            groupBox5.Controls.Add(button9)
            groupBox5.Controls.Add(button7)
            groupBox5.Font = Font("Segoe UI", 9.5, FontStyle.Bold, GraphicsUnit.Point)
            groupBox5.Location = Point(11, 311)
            groupBox5.Name = "groupBox5"
            groupBox5.Size = Size(323, 173)
            groupBox5.TabIndex = 30
            groupBox5.TabStop = False
            groupBox5.Text = "Move String"
            groupBox5.Enter += groupBox5_Enter
            # 
            # comboBox1
            # 
            comboBox1.BackColor = Color.DimGray
            comboBox1.ForeColor = Color.DarkGray
            comboBox1.FormattingEnabled = True
            comboBox1.Items.AddRange(["2mm", "1mm", "0.5mm", "0.1mm", "0.05mm"])
            comboBox1.Location = Point(235, 16)
            comboBox1.Name = "comboBox1"
            comboBox1.Size = Size(82, 29)
            comboBox1.TabIndex = 26
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged
            # 
            # button10
            # 
            button10.BackColor = SystemColors.Window
            button10.Font = Font("Webdings", 22.2, FontStyle.Regular, GraphicsUnit.Point)
            button10.Location = Point(128, 117)
            button10.Name = "button10"
            button10.Size = Size(50, 50)
            button10.TabIndex = 29
            button10.Text = "6"
            button10.TextAlign = ContentAlignment.TopCenter
            button10.UseVisualStyleBackColor = False
            button10.Click += button10_Click
            # 
            # button8
            # 
            button8.BackColor = SystemColors.Window
            button8.Font = Font("Webdings", 22.2, FontStyle.Regular, GraphicsUnit.Point)
            button8.Location = Point(184, 71)
            button8.Name = "button8"
            button8.Size = Size(50, 50)
            button8.TabIndex = 27
            button8.Text = "4"
            button8.UseVisualStyleBackColor = False
            button8.Click += button8_Click
            # 
            # button9
            # 
            button9.BackColor = SystemColors.Window
            button9.Font = Font("Webdings", 22.2, FontStyle.Regular, GraphicsUnit.Point)
            button9.Location = Point(128, 28)
            button9.Name = "button9"
            button9.Size = Size(50, 50)
            button9.TabIndex = 28
            button9.Text = "5"
            button9.TextAlign = ContentAlignment.TopCenter
            button9.UseVisualStyleBackColor = False
            button9.Click += button9_Click
            # 
            # button7
            # 
            button7.BackColor = SystemColors.Window
            button7.Font = Font("Webdings", 22.2, FontStyle.Regular, GraphicsUnit.Point)
            button7.Location = Point(72, 71)
            button7.Name = "button7"
            button7.Size = Size(50, 50)
            button7.TabIndex = 26
            button7.Text = "3"
            button7.UseVisualStyleBackColor = False
            button7.Click += button7_Click
            # 
            # groupBox6
            # 
            groupBox6.BackColor = Color.DarkGray
            groupBox6.Controls.Add(textBox1)
            groupBox6.Controls.Add(label11)
            groupBox6.Controls.Add(textBox2)
            groupBox6.Controls.Add(label7)
            groupBox6.Controls.Add(textBox3)
            groupBox6.Controls.Add(label5)
            groupBox6.Controls.Add(comboBox2)
            groupBox6.Controls.Add(label4)
            groupBox6.ImeMode = ImeMode.NoControl
            groupBox6.Location = Point(13, 490)
            groupBox6.Name = "groupBox6"
            groupBox6.Size = Size(321, 168)
            groupBox6.TabIndex = 39
            groupBox6.TabStop = False
            # 
            # textBox1
            # 
            textBox1.BackColor = SystemColors.Window
            textBox1.Location = Point(93, 23)
            textBox1.Multiline = True
            textBox1.Name = "textBox1"
            textBox1.Size = Size(211, 30)
            textBox1.TabIndex = 31
            textBox1.TextChanged += textBox1_TextChanged
            # 
            # label11
            # 
            label11.AutoSize = True
            label11.Font = Font("Segoe UI", 9, FontStyle.Bold, GraphicsUnit.Point)
            label11.Location = Point(6, 128)
            label11.Name = "label11"
            label11.Size = Size(59, 20)
            label11.TabIndex = 38
            label11.Text = "Filling :"
            # 
            # textBox2
            # 
            textBox2.BackColor = SystemColors.Window
            textBox2.Location = Point(93, 59)
            textBox2.Multiline = True
            textBox2.Name = "textBox2"
            textBox2.Size = Size(211, 30)
            textBox2.TabIndex = 32
            textBox2.TextChanged += textBox2_TextChanged
            # 
            # label7
            # 
            label7.AutoSize = True
            label7.Font = Font("Segoe UI", 9, FontStyle.Bold, GraphicsUnit.Point)
            label7.Location = Point(6, 95)
            label7.Name = "label7"
            label7.Size = Size(59, 20)
            label7.TabIndex = 37
            label7.Text = "Speed :"
            # 
            # textBox3
            # 
            textBox3.BackColor = SystemColors.Window
            textBox3.Location = Point(93, 93)
            textBox3.Multiline = True
            textBox3.Name = "textBox3"
            textBox3.Size = Size(211, 30)
            textBox3.TabIndex = 33
            textBox3.TextChanged += textBox3_TextChanged
            # 
            # label5
            # 
            label5.AutoSize = True
            label5.Font = Font("Segoe UI", 9, FontStyle.Bold, GraphicsUnit.Point)
            label5.Location = Point(4, 62)
            label5.Name = "label5"
            label5.Size = Size(61, 20)
            label5.TabIndex = 36
            label5.Text = "Power :"
            # 
            # comboBox2
            # 
            comboBox2.BackColor = SystemColors.Window
            comboBox2.FormattingEnabled = True
            comboBox2.Items.AddRange(["FILL_NONE", "FILL_SIMPLE_LINE", "FILL_CROSS_LINES", "FILL_TRIPLE_LINES", "FILL_OFFSET", "FILL_SPYRAL_LINE", "FILL_DOT", "FILL_RASTER", "MASK_ENUM_PART", "FILL_UNIDIRECTIONAL", "FILL_SINGLE_POLY", "FILL_UNKNOWN"])
            comboBox2.Location = Point(93, 128)
            comboBox2.Name = "comboBox2"
            comboBox2.Size = Size(211, 28)
            comboBox2.TabIndex = 34
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged
            # 
            # label4
            # 
            label4.AutoSize = True
            label4.Font = Font("Segoe UI", 9, FontStyle.Bold, GraphicsUnit.Point)
            label4.Location = Point(4, 26)
            label4.Name = "label4"
            label4.Size = Size(89, 20)
            label4.TabIndex = 35
            label4.Text = "Frequency :"
            # 
            # groupBox4
            # 
            groupBox4.BackColor = Color.DarkGray
            groupBox4.Controls.Add(groupBox6)
            groupBox4.Controls.Add(groupBox5)
            groupBox4.Controls.Add(checkBox3)
            groupBox4.Controls.Add(button2)
            groupBox4.Controls.Add(button1)
            groupBox4.Controls.Add(groupBox2)
            groupBox4.Controls.Add(groupBox1)
            groupBox4.Location = Point(826, 1)
            groupBox4.Margin = Padding(3, 4, 3, 4)
            groupBox4.Name = "groupBox4"
            groupBox4.Padding = Padding(3, 4, 3, 4)
            groupBox4.Size = Size(340, 845)
            groupBox4.TabIndex = 18
            groupBox4.TabStop = False
            groupBox4.Enter += groupBox4_Enter
            
            
            # 
            # radioButton2
            # 
            radioButton2.AutoSize = True
            radioButton2.Location = Point(474, 719)
            radioButton2.Name = "radioButton2"
            radioButton2.Size = Size(77, 24)
            radioButton2.TabIndex = 27
            radioButton2.TabStop = True
            radioButton2.Text = "Trigger"
            radioButton2.UseVisualStyleBackColor = True
            # 
            # button11
            # 
            button11.Font = Font("Segoe UI Semibold", 10.2, FontStyle.Bold, GraphicsUnit.Point)
            button11.Location = Point(571, 755)
            button11.Name = "button11"
            button11.Size = Size(133, 81)
            button11.TabIndex = 28
            button11.Text = "IO"
            button11.UseVisualStyleBackColor = True
            # 
            # Form1
            # 
            AutoScaleDimensions = SizeF(8, 20)
            AutoScaleMode = AutoScaleMode.Font
            BackColor = Color.DarkGray
            BackgroundImageLayout = ImageLayout.Stretch
            ClientSize = Size(1178, 849)
            Controls.Add(button11)
            Controls.Add(radioButton2)
            Controls.Add(label1)
            Controls.Add(button6)
            Controls.Add(label8)
            Controls.Add(label9)
            Controls.Add(label10)
            Controls.Add(tb_tagID)
            Controls.Add(tb_jobNo)
            Controls.Add(tb_requestNo)
            Controls.Add(groupBox4)
            Controls.Add(groupBox3)
            DoubleBuffered = True
            FormBorderStyle = FormBorderStyle.Fixed3D
            Icon = resources.GetObject("$this.Icon")
            Margin = Padding(3, 4, 3, 4)
            Name = "Form1"
            Text = "Laservall_Marking_0.1"
            FormClosed += Form1_FormClosed
            Load += Form1_Load
            (picBoxPrew).EndInit()
            groupBox3.ResumeLayout(False)
            groupBox3.PerformLayout()
            (trackBar3).EndInit()
            groupBox1.ResumeLayout(False)
            groupBox1.PerformLayout()
            (trackBar1).EndInit()
            (trackBar2).EndInit()
            groupBox2.ResumeLayout(False)
            groupBox5.ResumeLayout(False)
            groupBox6.ResumeLayout(False)
            groupBox6.PerformLayout()
            groupBox4.ResumeLayout(False)
            groupBox4.PerformLayout()
            ResumeLayout(False)
            PerformLayout()
        
        
        def __init__(self):
            #instance fields found by C# to Python Converter:
            self._picBoxPrew = None
            self._label6 = None
            self._groupBox3 = None
            self._label8 = None
            self._label9 = None
            self._label10 = None
            self._tb_tagID = None
            self._tb_jobNo = None
            self._tb_requestNo = None
            self._button6 = None
            self._label1 = None
            self._trackBar3 = None
            self._timer1 = None
            self._groupBox1 = None
            self._checkBox5 = None
            self._checkBox4 = None
            self._label2 = None
            self._checkBox2 = None
            self._label3 = None
            self._checkBox1 = None
            self._trackBar1 = None
            self._trackBar2 = None
            self._button1 = None
            self._button2 = None
            self._checkBox3 = None
            self._groupBox2 = None
            self._button5 = None
            self._button3 = None
            self._button4 = None
            self._groupBox5 = None
            self._comboBox1 = None
            self._button10 = None
            self._button8 = None
            self._button9 = None
            self._button7 = None
            self._groupBox6 = None
            self._textBox1 = None
            self._label11 = None
            self._textBox2 = None
            self._label7 = None
            self._textBox3 = None
            self._label5 = None
            self._comboBox2 = None
            self._label4 = None
            self._groupBox4 = None
            self._radioButton1 = None
            self._radioButton2 = None
            self._button11 = None
        
