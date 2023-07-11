using RestSharp;
using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace LaserMarking
{
    public partial class Form1 : Form
    {
        //ControlLighter controlLighter = new ControlLighter();
        ControlLighter controlLighter;
        ReadDatFile readDataFile = new ReadDatFile();
        public bool bAiming = false;
        public bool bLasering = false;
        public string postResult = "";
        public string getResult = "";
        public bool postStatus = false;
        public bool getStatus = false;
        public string TextID = "1";
        public bool breakLine;
        public string ModuleName = "Moudel.xlp";
        public double MoveDistance = 2;

        public class Post
        {
            public string username { get; set; }
            public string key { get; set; }
            public string statusID { get; set; }
            public string TagID { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            controlLighter = new ControlLighter(this);
            // this.pictureBox1.Load(Application.StartupPath + "\\" + "icon1.png");
            //this.pictureBox2.Load(Application.StartupPath + "\\" + "icon2.png");
        }
        public Form1()
        {
            InitializeComponent();
        }

        public void SetradioButton1(bool ischeck)   // add for redio button
        {
            if (ischeck)
                radioButton1.Checked = true;
            else
                radioButton1.Checked = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Initilaize the xlp file
            controlLighter.LoadDoc(Application.StartupPath + "\\" + "Moudel.xlp");
            controlLighter.Set_Text(ControlLighter.eMarkingType.String, "1", "PurityHUID", controlLighter.GetLE_LaserDoc());
            controlLighter.Update();
            controlLighter.SaveXlpDoc(Application.StartupPath + "\\" + "Moudel.xlp");
            controlLighter.LoadDoc(Application.StartupPath + "\\" + "Moudel2.xlp");
            controlLighter.Set_Text(ControlLighter.eMarkingType.String, "1", "Purity", controlLighter.GetLE_LaserDoc());
            controlLighter.Set_Text(ControlLighter.eMarkingType.String, "2", "HUID", controlLighter.GetLE_LaserDoc());
            controlLighter.Update();
            controlLighter.SaveXlpDoc(Application.StartupPath + "\\" + "Moudel2.xlp");

            if (controlLighter.LE != null)
            {
                try
                {
                    for (int i = 1; i < 25; i++)
                    {
                        controlLighter.ResetPort(i);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                controlLighter.LaserDisconnect();//Disconnect
            }
            System.Environment.Exit(0);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (readDataFile.ReadName() == "" && readDataFile.ReadKey() == "")
            {
                MessageBox.Show("Please input username and key to dat file");
            }

            if (controlLighter.Initialize(true, readDataFile.Readip()))//readDataFile.Readip()
            {
                MessageBox.Show("Connect Device OK!");
                button1.Enabled = false;
                button2.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                MessageBox.Show("Connect Device Failed!");
            }
        }

        bool bLoad = false;

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            button4.Enabled = true;
            if (!controlLighter.LoadDoc(Application.StartupPath + "\\" + ModuleName)) //Load xlp文档
            {
                MessageBox.Show("Load Moudel.xlp document failed!");
            }

            bLoad = true;
            controlLighter.Set_Display(this.picBoxPrew, trackBar3.Value / 200, trackBar3.Value / 100);
            trackBar1.Value = (int)Convert.ToDouble(controlLighter.Get_Size(ControlLighter.eMarkingType.String, "1")[0]) * 100;
            trackBar2.Value = (int)Convert.ToDouble(controlLighter.Get_Size(ControlLighter.eMarkingType.String, "1")[1]) * 100;


            textBox1.Text = controlLighter.GetFrequency(TextID).ToString();  //ADD by 138 line
            textBox2.Text = controlLighter.GetPower(TextID).ToString();
            textBox3.Text = controlLighter.GetSpeed(TextID).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (controlLighter.StopLaserAndAiming())//Turn off the red light before hitting the laser
            {
                Thread.Sleep(200);
                if (controlLighter.LaserMarking())
                {
                    Task.Run(async () => await PostJson(tb_requestNo.Text, tb_jobNo.Text, tb_tagID.Text, readDataFile.username, readDataFile.key, "1", tb_tagID.Text)).Wait();//异步等待                       
                    if (postStatus)
                    {
                        Log.logOut("LaserMarking!!!!");
                        label1.Text = "Today Marked: " + Log.logCount().ToString();
                        MessageBox.Show(postResult);
                        postStatus = false;
                    }
                    else
                    {
                        MessageBox.Show("Post information failed!!");
                    }
                    postResult = "";
                    button3.Enabled = false;

                }
                else
                {
                    MessageBox.Show("LaserMarking failed!");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (controlLighter.Aiming())
            {
                button4.Enabled = false;
                button5.Enabled = true;
            }
            else
            {
                MessageBox.Show("Aiming failed!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (controlLighter.StopLaserAndAiming())
            {
                button3.Enabled = false;
                button5.Enabled = false;
                button4.Enabled = true;
            }
            else
            {
                MessageBox.Show("Stop Laser/Aiming failed!");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            controlLighter.StopLaserAndAiming();
            if (e.KeyChar == '\r')
            {
                controlLighter.Set_Size(ControlLighter.eMarkingType.String, TextID, (double)trackBar1.Value / 100, 0);//改变字体长度，宽带为0则不变
                controlLighter.SaveXlpDoc(Application.StartupPath + "\\" + ModuleName);
                controlLighter.Update();
                controlLighter.Set_Display(this.picBoxPrew, trackBar3.Value / 200, trackBar3.Value / 100);
                controlLighter.Aiming();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            controlLighter.StopLaserAndAiming();
            if (e.KeyChar == '\r')
            {
                controlLighter.Set_Size(ControlLighter.eMarkingType.String, TextID, 0, (double)trackBar2.Value / 100);//改变字体宽度，长度为0则不变
                controlLighter.SaveXlpDoc(Application.StartupPath + "\\" + ModuleName);
                controlLighter.Update();
                controlLighter.Set_Display(this.picBoxPrew, trackBar3.Value / 200, trackBar3.Value / 100);
                controlLighter.Aiming();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (readDataFile.ReadName() != "" && readDataFile.ReadKey() != "")
            {
                Task.Run(async () => await GetJson(tb_requestNo.Text, tb_jobNo.Text, tb_tagID.Text, readDataFile.username, readDataFile.key)).Wait();//异步等待
                                                                                                                                                     //               getResult = "[{\"jobno\":\"101296547\",\"tag_id\":\"7\",\"laser_marking\":\"22K916K23H1Y\",\"printing_status_id\":\"0\"}]"; getStatus = true;
                MessageBox.Show(getResult);
                //               Log.logOut("Get Json Result: " + getResult);
                if (getStatus)
                {
                    getStatus = false;
                    int x1 = getResult.IndexOf("laser_marking");
                    int x2 = getResult.IndexOf("printing_status_id");
                    string Purity;
                    string HUID;
                    if (!breakLine)
                    {
                        HUID = getResult.Substring(x1 + 16, x2 - x1 - 19);
                        controlLighter.Set_Text(ControlLighter.eMarkingType.String, "1", HUID, controlLighter.GetLE_LaserDoc());
                    }
                    else
                    {
                        Purity = getResult.Substring(x1 + 16, 6);
                        controlLighter.Set_Text(ControlLighter.eMarkingType.String, "1", Purity, controlLighter.GetLE_LaserDoc());
                        HUID = getResult.Substring(x1 + 22, x2 - x1 - 25);
                        controlLighter.Set_Text(ControlLighter.eMarkingType.String, "2", HUID, controlLighter.GetLE_LaserDoc());
                    }
                    controlLighter.SaveXlpDoc(Application.StartupPath + "\\" + ModuleName);
                    controlLighter.Update();
                    controlLighter.StopLaserAndAiming();
                    Thread.Sleep(100);
                    controlLighter.Aiming();
                    controlLighter.Set_Display(this.picBoxPrew, trackBar3.Value / 200, trackBar3.Value / 100);
                    button3.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Failed to get the information!");
                }
                getResult = "";
            }
            else
            {
                MessageBox.Show("Please input username and key to dat file");
            }
        }

        public async Task PostJson(string reqno, string jobno, string tagid, string username, string key, string bodyStatusID, string bodyTagID)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            Post post = new Post();
            string url = "https://newmanak.uat.dcservices.in/MANAK/getJobHuiddetailsByTagId?reqno=" + reqno + "&jobno=" + jobno + "&tagId=" + tagid;
            //           Log.logOut("Post Url:  " + url);
            var client = new RestClient(url);
            var request = new RestRequest();
            request.Method = Method.Post;
            var body = @"{" + "\r\n" + @"""username"":" + @"""" + readDataFile.ReadName() + @"""" + "," + "\r\n" +
                        @"""key"":" + @"""" + readDataFile.ReadKey() + @"""" + "," + "\r\n" +
                        @"""printing_status_id"":" + "[" + @"""" + bodyStatusID + @"""" + "]" + "," + "\r\n" +
                        @"""tag_id"":" + "[" + @"""" + bodyTagID + @"""" + "]" + "\r\n" +
                        @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            postStatus = response.IsSuccessful;
            var responseContent = response.Content;
            postResult = responseContent;
        }

        public async Task GetJson(string reqno, string jobno, string tagid, string username, string key)
        {
            string url = "https://newmanak.uat.dcservices.in/MANAK/getHuiddetailsbyTagId?reqno=" + reqno + "&jobno=" + jobno + "&tagid=" + tagid;
            //           Log.logOut("Get Url:  "+url);
            var client = new RestClient(url);
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Connection", "keep-alive");
            request.Method = Method.Get;
            var body = @"{" + "\r\n" + @"""username"":" + @"""" + readDataFile.ReadName() + @"""" + "," + "\r\n" +
                        @"""key"":" + @"""" + readDataFile.ReadKey() + @"""" + "\r\n" +
                        @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            getStatus = response.IsSuccessful;
            var responseContent = response.Content;
            getResult = responseContent;
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                controlLighter.Set_Size(ControlLighter.eMarkingType.Import, TextID, (double)trackBar1.Value / 100, 0);//Change the length of the logo, if the width is 0, it will remain the same
            }
            else
            {
                controlLighter.Set_Size(ControlLighter.eMarkingType.String, TextID, (double)trackBar1.Value / 100, 0);//Change the font length, if the width is 0, it will not change
            }

            controlLighter.SaveXlpDoc(Application.StartupPath + "\\" + ModuleName);
            //controlLighter.Update();
            controlLighter.Set_Display(this.picBoxPrew, trackBar3.Value / 200, trackBar3.Value / 100);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                controlLighter.Set_Size(ControlLighter.eMarkingType.Import, TextID, 0, ((double)trackBar2.Value / 100));//改变字体宽度，长度为0则不变
            }
            else
            {
                controlLighter.Set_Size(ControlLighter.eMarkingType.String, TextID, 0, ((double)trackBar2.Value / 100));//改变字体宽度，长度为0则不变
            }
            controlLighter.SaveXlpDoc(Application.StartupPath + "\\" + ModuleName);
            //controlLighter.Update();
            controlLighter.Set_Display(this.picBoxPrew, trackBar3.Value / 200, trackBar3.Value / 100);
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            controlLighter.StopLaserAndAiming();
            controlLighter.SaveXlpDoc(Application.StartupPath + ModuleName); // line 360
            Thread.Sleep(200);
            if (controlLighter.Aiming())
            {
                button4.Enabled = false;
                button5.Enabled = true;
            }
            else
            {
                MessageBox.Show("Aiming failed!");
            }
        }

        private void trackBar2_MouseUp(object sender, MouseEventArgs e)
        {
            controlLighter.StopLaserAndAiming();
            controlLighter.SaveXlpDoc(Application.StartupPath + ModuleName); // from line 378
            Thread.Sleep(200);
            if (controlLighter.Aiming())
            {
                button4.Enabled = false;
                button5.Enabled = true;
            }
            else
            {
                MessageBox.Show("Aiming failed!");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                TextID = "1";
                trackBar1.Value = (int)Convert.ToDouble(controlLighter.Get_Size(ControlLighter.eMarkingType.String, TextID)[0]) * 100;
                trackBar2.Value = (int)Convert.ToDouble(controlLighter.Get_Size(ControlLighter.eMarkingType.String, TextID)[1]) * 100;
            }

            textBox1.Text = controlLighter.GetFrequency(TextID).ToString();
            textBox2.Text = controlLighter.GetPower(TextID).ToString();
            textBox3.Text = controlLighter.GetSpeed(TextID).ToString();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                TextID = "2";
                trackBar1.Value = (int)Convert.ToDouble(controlLighter.Get_Size(ControlLighter.eMarkingType.String, TextID)[0]) * 100;
                trackBar2.Value = (int)Convert.ToDouble(controlLighter.Get_Size(ControlLighter.eMarkingType.String, TextID)[1]) * 100;
            }

            textBox1.Text = controlLighter.GetFrequency(TextID).ToString();
            textBox2.Text = controlLighter.GetPower(TextID).ToString();
            textBox3.Text = controlLighter.GetSpeed(TextID).ToString();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (bLoad == false)       //from line 432
                return;
            groupBox1.Visible = false;
            TextID = "1";
            trackBar1.Value = (int)Convert.ToDouble(controlLighter.Get_Size(ControlLighter.eMarkingType.String, TextID)[0]) * 100;
            trackBar2.Value = (int)Convert.ToDouble(controlLighter.Get_Size(ControlLighter.eMarkingType.String, TextID)[1]) * 100;
            if (checkBox3.Checked)
            {
                checkBox1.Checked = true;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox5.Visible = false;
                ModuleName = "Moudel2.xlp";
                breakLine = true;
            }
            else
            {
                checkBox5.Checked = true;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox5.Visible = true;
                ModuleName = "Moudel.xlp";
                breakLine = false;
            }

            textBox1.Text = controlLighter.GetFrequency(TextID).ToString();
            textBox2.Text = controlLighter.GetPower(TextID).ToString();
            textBox3.Text = controlLighter.GetSpeed(TextID).ToString();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox5.Checked = false;
                TextID = "3";
                trackBar1.Value = (int)Convert.ToDouble(controlLighter.Get_Size(ControlLighter.eMarkingType.Import, TextID)[0]) * 100;
                trackBar2.Value = (int)Convert.ToDouble(controlLighter.Get_Size(ControlLighter.eMarkingType.Import, TextID)[1]) * 100;
            }

            textBox1.Text = controlLighter.GetFrequency(TextID).ToString();
            textBox2.Text = controlLighter.GetPower(TextID).ToString();
            textBox3.Text = controlLighter.GetSpeed(TextID).ToString();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox4.Checked = false;
                TextID = "1";
                trackBar1.Value = (int)Convert.ToDouble(controlLighter.Get_Size(ControlLighter.eMarkingType.String, TextID)[0]) * 100;
                trackBar2.Value = (int)Convert.ToDouble(controlLighter.Get_Size(ControlLighter.eMarkingType.String, TextID)[1]) * 100;
            }

            textBox1.Text = controlLighter.GetFrequency(TextID).ToString();
            textBox2.Text = controlLighter.GetPower(TextID).ToString();
            textBox3.Text = controlLighter.GetSpeed(TextID).ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (bLoad == false)
                return;


            if (checkBox4.Checked)
            {
                controlLighter.MoveStr(ControlLighter.eMarkingType.Import, TextID, 0, MoveDistance);
            }
            else
            {
                controlLighter.MoveStr(ControlLighter.eMarkingType.String, TextID, 0, MoveDistance);
            }
            controlLighter.Set_Display(this.picBoxPrew, trackBar3.Value / 200, trackBar3.Value / 100);
            controlLighter.StopLaserAndAiming();
            controlLighter.Aiming();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (bLoad == false)
                return;           // line 512
            if (checkBox4.Checked)
            {
                controlLighter.MoveStr(ControlLighter.eMarkingType.Import, TextID, 0, -MoveDistance);
            }
            else
            {
                controlLighter.MoveStr(ControlLighter.eMarkingType.String, TextID, 0, -MoveDistance);
            }
            controlLighter.Set_Display(this.picBoxPrew, trackBar3.Value / 200, trackBar3.Value / 100);
            controlLighter.StopLaserAndAiming();
            controlLighter.Aiming();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (bLoad == false)  // added by line 529
                return;
            if (checkBox4.Checked)
            {
                controlLighter.MoveStr(ControlLighter.eMarkingType.Import, TextID, -MoveDistance, 0);
            }
            else
            {
                controlLighter.MoveStr(ControlLighter.eMarkingType.String, TextID, -MoveDistance, 0);
            }
            controlLighter.Set_Display(this.picBoxPrew, trackBar3.Value / 200, trackBar3.Value / 100);
            controlLighter.StopLaserAndAiming();
            controlLighter.Aiming();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (bLoad == false)
                return;
            if (checkBox4.Checked)
            {
                controlLighter.MoveStr(ControlLighter.eMarkingType.Import, TextID, MoveDistance, 0);
            }
            else
            {
                controlLighter.MoveStr(ControlLighter.eMarkingType.String, TextID, MoveDistance, 0);
            }
            controlLighter.Set_Display(this.picBoxPrew, trackBar3.Value / 200, trackBar3.Value / 100);
            controlLighter.StopLaserAndAiming();
            controlLighter.Aiming();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString()) //获取选择的内容
            {
                case "2mm": MoveDistance = 1; break;

                case "1mm": MoveDistance = 1; break;

                case "0.5mm": MoveDistance = 0.5; break;

                case "0.1mm": MoveDistance = 0.1; break;

                case "0.05mm": MoveDistance = 0.05; break;
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (bLoad == false)
                return;
            if (comboBox2.SelectedIndex == 0)
                controlLighter.SetFilling(ControlLighter.eMarkingType.Import, TextID, ControlLighter.eMarkingFilling.FILL_NONE);
            else if (comboBox2.SelectedIndex == 1)
                controlLighter.SetFilling(ControlLighter.eMarkingType.Import, TextID, ControlLighter.eMarkingFilling.FILL_SIMPLE_LINE);
            else if (comboBox2.SelectedIndex == 2)
                controlLighter.SetFilling(ControlLighter.eMarkingType.Import, TextID, ControlLighter.eMarkingFilling.FILL_CROSS_LINES);
            else if (comboBox2.SelectedIndex == 3)
                controlLighter.SetFilling(ControlLighter.eMarkingType.Import, TextID, ControlLighter.eMarkingFilling.FILL_TRIPLE_LINES);
            else if (comboBox2.SelectedIndex == 4)
                controlLighter.SetFilling(ControlLighter.eMarkingType.Import, TextID, ControlLighter.eMarkingFilling.FILL_OFFSET);
            else if (comboBox2.SelectedIndex == 5)
                controlLighter.SetFilling(ControlLighter.eMarkingType.Import, TextID, ControlLighter.eMarkingFilling.FILL_SPYRAL_LINE);
            else if (comboBox2.SelectedIndex == 6)
                controlLighter.SetFilling(ControlLighter.eMarkingType.Import, TextID, ControlLighter.eMarkingFilling.FILL_DOT);
            else if (comboBox2.SelectedIndex == 7)
                controlLighter.SetFilling(ControlLighter.eMarkingType.Import, TextID, ControlLighter.eMarkingFilling.FILL_RASTER);
            else if (comboBox2.SelectedIndex == 8)
                controlLighter.SetFilling(ControlLighter.eMarkingType.Import, TextID, ControlLighter.eMarkingFilling.MASK_ENUM_PART);
            else if (comboBox2.SelectedIndex == 9)
                controlLighter.SetFilling(ControlLighter.eMarkingType.Import, TextID, ControlLighter.eMarkingFilling.FILL_UNIDIRECTIONAL);
            else if (comboBox2.SelectedIndex == 10)
                controlLighter.SetFilling(ControlLighter.eMarkingType.Import, TextID, ControlLighter.eMarkingFilling.FILL_SINGLE_POLY);
            else if (comboBox2.SelectedIndex == 11)
                controlLighter.SetFilling(ControlLighter.eMarkingType.Import, TextID, ControlLighter.eMarkingFilling.FILL_UNKNOWN);
            controlLighter.Set_Display(this.picBoxPrew, trackBar3.Value / 200, trackBar3.Value / 100);
            controlLighter.SaveXlpDoc(Application.StartupPath + "\\" + ModuleName);
        }


        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            controlLighter.Set_Display(this.picBoxPrew, trackBar3.Value / 200, trackBar3.Value / 100);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tb_requestNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_requestNo_TextChanged_1(object sender, EventArgs e)
        {

        }


        private void tb_tagID_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_jobNo_TextChanged(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (controlLighter.bIoLaserMarking && button3.Enabled)
            {
                if (controlLighter.StopLaserAndAiming())//先关掉红光再打激光
                {
                    Thread.Sleep(50);
                    if (controlLighter.LaserMarking())
                    {
                        Task.Run(async () => await PostJson(tb_requestNo.Text, tb_jobNo.Text, tb_tagID.Text, readDataFile.username, readDataFile.key, "1", tb_tagID.Text)).Wait();//异步等待                       
                        if (postStatus)
                        {
                            Log.logOut("LaserMarking!!!!");
                            label1.Text = "Today Marked: " + Log.logCount().ToString();
                            MessageBox.Show(postResult);
                            postStatus = false;
                        }
                        else
                        {
                            MessageBox.Show("Post information failed!!");
                        }
                        postResult = "";
                        button3.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show("LaserMarking failed!");
                    }
                }
            }
            controlLighter.bIoLaserMarking = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void picBoxPrew_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }


        static class HandleFiles
        {
            public static void EncryptFile(string inputFile, string outputFile)   //加密
            {
                try
                {
                    string password = @"12345678";
                    UnicodeEncoding UE = new UnicodeEncoding();
                    byte[] key = UE.GetBytes(password);

                    string cryptFile = outputFile;
                    FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                    RijndaelManaged RMCrypto = new RijndaelManaged();

                    CryptoStream cs = new CryptoStream(fsCrypt,
                        RMCrypto.CreateEncryptor(key, key),
                        CryptoStreamMode.Write);

                    FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                    int data;
                    while ((data = fsIn.ReadByte()) != -1)
                        cs.WriteByte((byte)data);


                    fsIn.Close();
                    cs.Close();
                    fsCrypt.Close();


                    // MessageBox.Show("Encrypt Source file succeed!", "Msg :");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Source file error!", "Error :");
                }
            }
            public static void DecryptFile(string inputFile, string outputFile)   //解密
            {
                try
                {
                    string password = @"12345678";
                    UnicodeEncoding UE = new UnicodeEncoding();
                    byte[] key = UE.GetBytes(password);

                    FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                    RijndaelManaged RMCrypto = new RijndaelManaged();

                    CryptoStream cs = new CryptoStream(fsCrypt,
                        RMCrypto.CreateDecryptor(key, key),
                        CryptoStreamMode.Read);


                    FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                    int data;
                    while ((data = cs.ReadByte()) != -1)
                        fsOut.WriteByte((byte)data);

                    fsOut.Close();
                    cs.Close();
                    fsCrypt.Close();

                    //MessageBox.Show("Decrypt Source file succeed!", "Msg :");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Source file error", "Error :");
                }
            }
        }
    }
}
