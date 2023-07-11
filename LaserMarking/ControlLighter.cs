using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using laserengineLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Printing;
//using static LaserMarking.ControlLighter;

namespace LaserMarking
{
    public class ControlLighter : Form
    {
        //Used to connect to lighter
        public laserengineLib.LaserAxApp LE;
        public laserengineLib.System LE_System;
        public laserengineLib.LaserDoc LE_LaserDoc;
        public laserengineLib.IIoPort LE_Port;
        public laserengineLib.RenderArea LE_RenderArea;//Only used pictures saved as BMP saveBitmap();

        public bool bScanStatus = false;
        public bool bReadIO_ignore = true;
        public int readInputData;
        public bool bLaserBusy = false;
        public bool bIoLaserMarking;  
        //Use 25-pin IO, 2-pin output0 to control the laser, 4-pin output4 to control the red light
        public bool bIoAiming;


        Form1 Frm_main;              //added from 31to35 line
        public ControlLighter(Form1 main)
        {
          Frm_main = main;
        }

        public enum eMarkingType //Create a menu to modify the marking content
        {
            String,
            Barcode,
            QRCode,
            Datamatrix,
            Import,
            Group,
            None,           
        }
        public enum eMarkingFilling
        {
            FILL_NONE = 0x0001,
            FILL_SIMPLE_LINE = 0x0002,
            FILL_CROSS_LINES = (0x0004),
            FILL_TRIPLE_LINES = (0x0008),
            FILL_OFFSET = (0x0010),
            FILL_SPYRAL_LINE = (0x0020),
            FILL_DOT = (0x0040),
            FILL_RASTER = (0x0080),
            MASK_ENUM_PART = (0x000FFF),
            FILL_UNIDIRECTIONAL = (0x001000),
            FILL_SINGLE_POLY = (0x002000),
            FILL_UNKNOWN = (0xFFFF),
        }


        public static System.Timers.Timer ReadIO = new System.Timers.Timer(100);
        public bool Initialize(bool remode ,string ip)
        {
            try
            {
                if (LE == null)
                    LE = new laserengineLib.LaserAxApp();
                LE_System = LE.System;
                //LE.visible = true;
                LE_LaserDoc = new laserengineLib.LaserDoc();
                LE_RenderArea = new laserengineLib.RenderArea();
                LE_Port = LE.IoPort;
                if (remode)
                {
                    LE_System.connectToDevice(ip, 1000); //If the lighter in remote mode is connected to the ip
                }               
                LE_System.sigLaserEvent += new laserengineLib.ISystemEvents_sigLaserEventEventHandler(LE_System_sigLaserEvent);//注册事件
                ReadIO.Elapsed += new ElapsedEventHandler(timer_ReadStatus_Tick);
                ReadIO.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Card initialization failed" + ex.ToString());
                return false;
            }
            for (int i = 1; i < 25; i++)
            {
                ResetPort(i);
            }
            return true;
        }

        private void LE_System_sigLaserEvent(int nEventId)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int>(LE_System_sigLaserEvent), nEventId);
                return;
            }
            string strEvent = Enum.GetName(typeof(laserengineLib.SystemEvents), nEventId);
 /*           
  *           if (strEvent == "EVENT_QUERY_START") //脚踏连接到START 信号，所以有该事件回送
            {
                LaserMarking();
            }
 */
        }
        public void LaserDisconnect()
        {
            LE_System.disconnectFromDevice();
        }
        private void timer_ReadStatus_Tick(object sender, ElapsedEventArgs e)
        {
            if (LE == null)
                return;
            //获取IO
            if (!bReadIO_ignore) //Whether to scan IO
            {
                readInputData = LE.IoPort.getPort(0);
                //Detect the pedal with input9 IO
                if ((readInputData & (0x01 << 9)) > 0) //Determine whether the Pin19 pin has an output
                {
                    bIoLaserMarking = true;
                    Frm_main.SetradioButton1(true); //added from line 136
                }
                else
                {
                    bIoLaserMarking = false;
                    Frm_main.SetradioButton1(false);
                }


                //Get marking status             
                if (LE_System.isLaserBusy() == true)   //doubt case
                {
                    bLaserBusy = true;
                }
                else
                {
                    bLaserBusy = false;
                }
            }
        }

        public void ResetPort(int Pin)  //25脚
        {
            switch (Pin)
            {
                case 2:
                    LE_Port.resetPort(0, 0x1); break;  //output 0
                case 3:
                    LE_Port.resetPort(0, 0x4); break;   //output 2
                case 4:
                    LE_Port.resetPort(0, 0x10); break;  //output 4
                case 5:
                    LE_Port.resetPort(0, 0x40); break;  //output 6
                case 6:
                    LE_Port.resetPort(0, 0x100); break; //output 8
                case 14:
                    LE_Port.resetPort(0, 0x1000); break;//output 12
                case 15:
                    LE_Port.resetPort(0, 0x2); break;   //output 1
                case 16:
                    LE_Port.resetPort(0, 0x8); break;   //output 3
                case 17:
                    LE_Port.resetPort(0, 0x20); break;  //output 5
                case 18:
                    LE_Port.resetPort(0, 0x80); break;  //output 7
                default:
                    break;
            }
        }

        public void SetPort(int Pin)//25 pin
        {
            switch (Pin)
            {
                case 2:
                    LE_Port.setPort(0, 0x1); break;  //output 0
                case 3:
                    LE_Port.setPort(0, 0x4); break;   //output 2
                case 4:
                    LE_Port.setPort(0, 0x10); break;  //output 4
                case 5:
                    LE_Port.setPort(0, 0x40); break;  //output 6
                case 6:
                    LE_Port.setPort(0, 0x100); break; //output 8
                case 14:
                    LE_Port.setPort(0, 0x1000); break;//output 12
                case 15:
                    LE_Port.setPort(0, 0x2); break;   //output 1
                case 16:
                    LE_Port.setPort(0, 0x8); break;   //output 3
                case 17:
                    LE_Port.setPort(0, 0x20); break;  //output 5
                case 18:
                    LE_Port.setPort(0, 0x80); break;  //output 7
                default:
                    break;
            }
        }

        public bool LoadDoc(string DocPath)
        {
            if (LE_LaserDoc.load(DocPath) == false) //Load the xlp file to lighter
            {
                return false;
            }
            LE_LaserDoc.updateDocument();//Update lighter content
            return true;
        }

        public bool SaveXlpDoc(string path)
        {
            return (LE_LaserDoc.saveAs(path));
        }

        public void Set_Display(PictureBox i_pPic, double x_y, double width_length) // the picture
        {
            string tmpFilePath = Application.StartupPath + "\\" + "Moudel.bmp";
            //Saves a bitmap of the document preview
            LE_RenderArea.saveBitmap(LE_LaserDoc, tmpFilePath, i_pPic.Width, i_pPic.Height, -x_y, -x_y, width_length, width_length);//-LE_LaserDoc.areaWidth / 2, -LE_LaserDoc.areaHeight / 2, LE_LaserDoc.areaWidth, LE_LaserDoc.areaHeight

            FileStream fs = new System.IO.FileStream(tmpFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            try
            {
                i_pPic.Image = System.Drawing.Image.FromStream(fs);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error - " + ex.Message);
            }
            fs.Close();

        }

        public void Update() //update
        {
            LE_LaserDoc.updateDocument();
        }

        public LaserDoc GetLE_LaserDoc()
        {
            return LE_LaserDoc;
        }

        public bool Set_Text(eMarkingType i_eType, string IdName, string Text, LaserDoc lE_LaserDoc)//Determined text
        {
            try
            {
                if (i_eType == eMarkingType.String)
                {
                    LE_LaserDoc.getLaserString(IdName).enable = true;//Allow modification
                    lE_LaserDoc.getLaserString(IdName).text = Text; // Modify content
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public bool LaserMarking()
        {
            bReadIO_ignore = true; //Laser and scanning IO cannot be performed at the same time
            LE_Port.resetPort(0, 0x10);
            LE_Port.setPort(0, 0x1);
            Thread.Sleep(100);
            if (LE_LaserDoc.execute(true, true, true) == true) //Laser
            {
                do
                {
                    bLaserBusy = true;
                    Application.DoEvents();
                } 
                
                while (LE_System.isLaserBusy()); //Judging whether the laser is being fired
                bLaserBusy = false;
                bReadIO_ignore = false;//Scan the IO after firing the laser

                Aiming(); //Turn on the red light after laser
                return true;
            }
            return false;
        }

        public bool Aiming()
        {
            bReadIO_ignore = true; //Red light and scanning IO cannot be performed at the same time
            LE_Port.resetPort(0, 0x1);
            LE_Port.setPort(0, 0x10);
            Thread.Sleep(100);
            if (LE_LaserDoc.execute(true, false,true))
            {
               bReadIO_ignore = false;//Scan the IO after turning on the red light
                return true;
            }
            return false;
        }
        public bool StopLaserAndAiming()
        {
            return LE_System.stopLaser();
        }

        public void Set_Size(eMarkingType i_eType, string IdName, double x, double y)
        {
            try
            {              
                if (i_eType == eMarkingType.String)
                {
                    LE_LaserDoc.getLaserString(IdName).keepAspect = false;//Cancel the aspect ratio setting
                    if (x != 0)
                    {
                        LE_LaserDoc.getLaserString(IdName).width = x;
                    }
                    else if (y != 0)
                    {
                        LE_LaserDoc.getLaserString(IdName).height = y;
                    }
                }
                else if (i_eType == eMarkingType.Import)
                {
                    LE_LaserDoc.getImportedObj(IdName).keepAspect = false;//取消纵横比设置
                    if (x != 0)
                    {
                        LE_LaserDoc.getImportedObj(IdName).width = x;
                    }
                    else if (y != 0)
                    {
                        LE_LaserDoc.getImportedObj(IdName).height = y;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public string[] Get_Size(eMarkingType i_eType, string IdName)
        {
            string[] size = { "",""};
            try
            {
                if (i_eType == eMarkingType.String)
                {
                    size[0] = LE_LaserDoc.getLaserString(IdName).width.ToString();
                    size[1] = LE_LaserDoc.getLaserString(IdName).height.ToString();
                    return size;
                }
                else if (i_eType == eMarkingType.Import)
                {
                    size[0] = LE_LaserDoc.getImportedObj(IdName).width.ToString();
                    size[1] = LE_LaserDoc.getImportedObj(IdName).height.ToString();

                    return size;
                }
                else if (i_eType == eMarkingType.Group)
                {
                    size[0] = LE_LaserDoc.getLaserGroup(IdName).width.ToString();
                    size[1] = LE_LaserDoc.getLaserGroup(IdName).height.ToString();
                }   
                    
                    return null;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public void MoveStr(eMarkingType i_eType, string IdName, double x,double y)
        {
            if (i_eType == eMarkingType.String)
            {
                LE_LaserDoc.getLaserString(IdName).moveBy(x, y);
            }
            else if(i_eType == eMarkingType.Import)
            {
                LE_LaserDoc.getImportedObj(IdName).moveBy(x, y);
            }
            
        }


        public void SetFilling(eMarkingType i_eType, string IdName, eMarkingFilling FillingType)
        {
            int Type = LE_LaserDoc.getObjectType(IdName);
            if (Type == ((int)eMarkingType.String))
            {
                LE_LaserDoc.getLaserString(IdName).filling = ((int)FillingType);
            }
            else if (Type == ((int)eMarkingType.Import))
            {
                LE_LaserDoc.getImportedObj(IdName).filling = ((int)FillingType);
            }

        }



        public int GetFrequency(string IdName)
        {
            int Type = LE_LaserDoc.getObjectType(IdName);
            if (Type == ((int)eMarkingType.String))
            {
                return LE_LaserDoc.getLaserString(IdName).getLaserFrequency(0);

            }
            else if (Type == ((int)eMarkingType.Import))
            {
                return LE_LaserDoc.getImportedObj(IdName).getLaserFrequency(0);
            }
            return 0;
        }


        public int GetPower(string IdName)
        {
            int Type = LE_LaserDoc.getObjectType(IdName);
            if (Type == ((int)eMarkingType.String))
            {
                return LE_LaserDoc.getLaserString(IdName).getLaserPower(0);
            }
            else if (Type == ((int)eMarkingType.Import))
            {
                return LE_LaserDoc.getImportedObj(IdName).getLaserPower(0);
            }
            return 0;
        }
        public double GetSpeed(string IdName)
        {
            int Type = LE_LaserDoc.getObjectType(IdName);
            if (Type == ((int)eMarkingType.String))
            {
                return LE_LaserDoc.getLaserString(IdName).getSpeed(0);
            }
            else if (Type == ((int)eMarkingType.Import))
            {
                return LE_LaserDoc.getImportedObj(IdName).getSpeed(0);
            }
            return 0;
        }

        public void SetFrequency(int nFreq, string IdName)
        {
            int Type = LE_LaserDoc.getObjectType(IdName);
            if (Type == ((int)eMarkingType.String))
            {
                LE_LaserDoc.getLaserString(IdName).setLaserFrequency(nFreq, 0);

            }
            else if (Type == ((int)eMarkingType.Import))
            {
                LE_LaserDoc.getImportedObj(IdName).setLaserFrequency(nFreq, 0);
            }

        }
        public void SetPower(int Power, string IdName)
        {
            int Type = LE_LaserDoc.getObjectType(IdName);
            if (Type == ((int)eMarkingType.String))
            {
                LE_LaserDoc.getLaserString(IdName).setLaserPower(Power, 0);
            }
            else if (Type == ((int)eMarkingType.Import))
            {
                LE_LaserDoc.getImportedObj(IdName).setLaserPower(Power, 0);
            }
        }

        public void SetSpeed(double speed, string IdName)
        {
            int Type = LE_LaserDoc.getObjectType(IdName);
            if (Type == ((int)eMarkingType.String))
            {
                LE_LaserDoc.getLaserString(IdName).setSpeed(speed, 0);
            }
            else if (Type == ((int)eMarkingType.Import))
            {
                LE_LaserDoc.getImportedObj(IdName).setSpeed(speed, 0);
            }
        }

    }
}
