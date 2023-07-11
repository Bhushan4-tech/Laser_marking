import laserengineLib
import os
from enum import Enum
import sys as System
from ctypes import *

laserengineLib = cdll.LoadLibrary('laserengineLib.dll')

laserengineLib.testDLL(3)

class ControlLighter:
    def __init__(self, main):
        self.LE = laserengineLib.LaserAxApp()
        self.LE_System = self.LE.System
        self.LE_LaserDoc = laserengineLib.LaserDoc()
        self.LE_RenderArea = laserengineLib.RenderArea()
        self.LE_Port = self.LE.IoPort
        self.Frm_main = main

    def Initialize(self, remode, ip):
        try:
            if self.LE == None:
                self.LE = laserengineLib.LaserAxApp()
            self.LE_System = self.LE.System
            # self.LE.visible = True
            self.LE_LaserDoc = laserengineLib.LaserDoc()
            self.LE_RenderArea = laserengineLib.RenderArea()
            self.LE_Port = self.LE.IoPort
            if remode:
                self.LE_System.connectToDevice(ip, 1000)
            self.LE_System.sigLaserEvent += self.LE_System_sigLaserEvent
            self.ReadIO.Elapsed += self.timer_ReadStatus_Tick
            self.ReadIO.Start()
        except Exception as ex:
            print("Card initialization failed", ex)
            return False
        for i in range(1, 25):
            self.ResetPort(i)
        return True

    def LE_System_sigLaserEvent(self, nEventId):
        if self.InvokeRequired:
            self.Invoke(self.LE_System_sigLaserEvent, nEventId)
            return
        strEvent = Enum.GetName(type(laserengineLib.SystemEvents), nEventId)
        # if strEvent == "EVENT_QUERY_START":
        #     self.LaserMarking()

    def LaserDisconnect(self):
        self.LE_System.disconnectFromDevice()

    def timer_ReadStatus_Tick(self, sender, e):
        if self.LE == None:
            return
        # 获取IO
        if not self.bReadIO_ignore:
            readInputData = self.LE.IoPort.getPort(0)
            # Detect the pedal with input9 IO
            if ((readInputData & (0x01 << 9)) > 0):
                self.bIoLaserMarking = True
                self.Frm_main.SetradioButton1(True)
            else:
                self.bIoLaserMarking = False
                self.Frm_main.SetradioButton1(False)

            # Get marking status
            if self.LE_System.isLaserBusy() == True:
                self.bLaserBusy = True
            else:
                self.bLaserBusy = False
                
                
    def ResetPort(Pin):
        if Pin == 2:
            LE_Port.resetPort(0, 0x1)
        elif Pin == 3:
            LE_Port.resetPort(0, 0x4)
        elif Pin == 4:
            LE_Port.resetPort(0, 0x10)
        elif Pin == 5:
            LE_Port.resetPort(0, 0x40)
        elif Pin == 6:
            LE_Port.resetPort(0, 0x100)
        elif Pin == 14:
            LE_Port.resetPort(0, 0x1000)
        elif Pin == 15:
            LE_Port.resetPort(0, 0x2)
        elif Pin == 16:
            LE_Port.resetPort(0, 0x8)
        elif Pin == 17:
            LE_Port.resetPort(0, 0x20)
        elif Pin == 18:
            LE_Port.resetPort(0, 0x80)

    def SetPort(Pin):
        if Pin == 2:
            LE_Port.setPort(0, 0x1)
        elif Pin == 3:
            LE_Port.setPort(0, 0x4)
        elif Pin == 4:
            LE_Port.setPort(0, 0x10)
        elif Pin == 5:
            LE_Port.setPort(0, 0x40)
        elif Pin == 6:
            LE_Port.setPort(0, 0x100)
        elif Pin == 14:
            LE_Port.setPort(0, 0x1000)
        elif Pin == 15:
            LE_Port.setPort(0, 0x2)
        elif Pin == 16:
            LE_Port.setPort(0, 0x8)
        elif Pin == 17:
            LE_Port.setPort(0, 0x20)
        elif Pin == 18:
            LE_Port.setPort(0, 0x80)
    
    def LoadDoc(DocPath):
        if not LE_LaserDoc.load(DocPath):
            return False
        LE_LaserDoc.updateDocument()
        return True
    
    def SaveXlpDoc(path):
        return LE_LaserDoc.saveAs(path)
    
    def Set_Display(i_pPic, x_y, width_length):
        tmpFilePath = Application.StartupPath + "\\" + "Moudel.bmp"
        LE_RenderArea.saveBitmap(LE_LaserDoc, tmpFilePath, i_pPic.Width, i_pPic.Height, -x_y, -x_y, width_length, width_length)
        
        FileStream fs = open(tmpFilePath, "rb")
        try:
            i_pPic.Image = Image.open(fs)
        finally:
            fs.close()
    
    def Update():
        LE_LaserDoc.updateDocument()
    
    def GetLE_LaserDoc():
        return LE_LaserDoc
    
    def Set_Text(i_eType, IdName, Text, lE_LaserDoc):
        if i_eType == eMarkingType.String:
            lE_LaserDoc.getLaserString(IdName).enable = True
            lE_LaserDoc.getLaserString(IdName).text = Text
            return True
        else:
            return False
    
    def LaserMarking():
        bReadIO_ignore = True
        LE_Port.resetPort(0, 0x10)
        LE_Port.setPort(0, 0x1)
        Thread.sleep(100)
        if LE_LaserDoc.execute(True, True, True):
            while LE_System.isLaserBusy():
                pass
            bReadIO_ignore = False
            Aiming()
            return True
        return False

    def Aiming():
        bReadIO_ignore = True
        LE_Port.resetPort(0, 0x1)
        LE_Port.setPort(0, 0x10)
        Thread.sleep(100)
        if LE_LaserDoc.execute(True, False, True):
           bReadIO_ignore = False
           return True
        return False
    
    def StopLaserAndAiming():
        return LE_System.stopLaser()
    
    def Set_Size(i_eType, IdName, x, y):
        try:
            if i_eType == eMarkingType.String:
                LE_LaserDoc.getLaserString(IdName).keepAspect = False
                if x != 0:
                    LE_LaserDoc.getLaserString(IdName).width = x
                else:
                    LE_LaserDoc.getLaserString(IdName).height = y
            elif i_eType == eMarkingType.Import:
                LE_LaserDoc.getImportedObj(IdName).keepAspect = False
                if x != 0:
                    LE_LaserDoc.getImportedObj(IdName).width = x
                else:
                    LE_LaserDoc.getImportedObj(IdName).height = y
        except Exception as ex:
            MessageBox.Show(ex.ToString())
    
    def Get_Size(i_eType, IdName):
        size = ["", ""]
        try:
            if i_eType == eMarkingType.String:
                size[0] = LE_LaserDoc.getLaserString(IdName).width.ToString()
                size[1] = LE_LaserDoc.getLaserString(IdName).height.ToString()
                return size
            elif i_eType == eMarkingType.Import:
                size[0] = LE_LaserDoc.getImportedObj(IdName).width.ToString()
                size[1] = LE_LaserDoc.getImportedObj(IdName).height.ToString()
                return size
            elif i_eType == eMarkingType.Group:
                size[0] = LE_LaserDoc.getLaserGroup(IdName).width.ToString()
                size[1] = LE_LaserDoc.getLaserGroup(IdName).height.ToString()
                return size
            else:
                return None
        except Exception as ex:
            MessageBox.Show(ex.ToString())
            return None
        
        
    def MoveStr(i_eType, IdName, x, y):
        if i_eType == eMarkingType.String:
            LE_LaserDoc.getLaserString(IdName).moveBy(x, y)
        elif i_eType == eMarkingType.Import:
            LE_LaserDoc.getImportedObj(IdName).moveBy(x, y)
    
    def SetFilling(i_eType, IdName, FillingType):
        Type = LE_LaserDoc.getObjectType(IdName)
        if Type == ((int)eMarkingType.String):
            LE_LaserDoc.getLaserString(IdName).filling = ((int)FillingType)
        elif Type == ((int)eMarkingType.Import):
            LE_LaserDoc.getImportedObj(IdName).filling = ((int)FillingType)
    
    def GetFrequency(IdName):
        Type = LE_LaserDoc.getObjectType(IdName)
        if Type == ((int)eMarkingType.String):
            return LE_LaserDoc.getLaserString(IdName).getLaserFrequency(0)
        elif Type == ((int)eMarkingType.Import):
            return LE_LaserDoc.getImportedObj(IdName).getLaserFrequency(0)
        return 0
    
    def GetPower(IdName):
        Type = LE_LaserDoc.getObjectType(IdName)
        if Type == ((int)eMarkingType.String):
            return LE_LaserDoc.getLaserString(IdName).getLaserPower(0)
        elif Type == ((int)eMarkingType.Import):
            return LE_LaserDoc.getImportedObj(IdName).getLaserPower(0)
        return 0
    
    def GetSpeed(IdName):
        Type = LE_LaserDoc.getObjectType(IdName)
        if Type == ((int)eMarkingType.String):
            return LE_LaserDoc.getLaserString(IdName).getSpeed(0)
        elif Type == ((int)eMarkingType.Import):
            return LE_LaserDoc.getImportedObj(IdName).getSpeed(0)
        return 0
    
    def SetFrequency(nFreq, IdName):
        Type = LE_LaserDoc.getObjectType(IdName)
        if Type == ((int)eMarkingType.String):
            LE_LaserDoc.getLaserString(IdName).setLaserFrequency(nFreq, 0)
        elif Type == ((int)eMarkingType.Import):
            LE_LaserDoc.getImportedObj(IdName).setLaserFrequency(nFreq, 0)
    
    def SetPower(Power, IdName):
        Type = LE_LaserDoc.getObjectType(IdName)
        if Type == ((int)eMarkingType.String):
            LE_LaserDoc.getLaserString(IdName).setLaserPower(Power, 0)
        elif Type == ((int)eMarkingType.Import):
            LE_LaserDoc.getImportedObj(IdName).setLaserPower(Power, 0)
    
    def SetSpeed(speed, IdName):
        Type = LE_LaserDoc.getObjectType(IdName)
        if Type == ((int)eMarkingType.String):
            LE_LaserDoc.getLaserString(IdName).setSpeed(speed, 0)
        elif Type == ((int)eMarkingType.Import):
            LE_LaserDoc.getImportedObj(IdName).setSpeed(speed, 0)