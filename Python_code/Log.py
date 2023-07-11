class LaserMarking: #this class replaces the original namespace 'LaserMarking'
    class Log:
        #       static ReaderWriterLockSlim LogWriteLock = new ReaderWriterLockSlim()
        @staticmethod
        def logOut(str):
            print(str)
            currentPath = AppDomain.CurrentDomain.BaseDirectory
            logFilePath = None
            currentTime = System.DateTime()
            currentTime = System.DateTime.Now
            year = currentTime.Year
            month = currentTime.Month
            day = currentTime.Day
            hour = currentTime.Hour
            minute = currentTime.Minute
            second = currentTime.Second
            conStr = None
            logFilePath = currentPath + "Log\\"
            headStr = str(hour) + ":" + str(minute) + ":" + str(second) + "   "
            conStr = headStr + str + "\r\n"
            txtName = logFilePath + str(year) + "-" + str(month) + "-" + str(day) + ".txt"
            if not File.Exists(txtName):
                fileNameExt = logFilePath[logFilePath.rfind("\\") + 1:] #获取文件名，不带路径
                folderPath = logFilePath[0:len(logFilePath) - len(fileNameExt)]
                if not Directory.Exists(logFilePath):
                    Directory.CreateDirectory(logFilePath)
                if not File.Exists(txtName):
                    File.Create(txtName).Close()
            fs = FileStream(txtName, FileMode.Append)
            #获得字节数组
            data = System.Text.Encoding.Default.GetBytes(conStr)
            #开始写入
            fs.Write(data, 0, len(data))
            #清空缓冲区、关闭流
            fs.Flush()
            fs.Close()

        @staticmethod
        def logCount():
            currentPath = AppDomain.CurrentDomain.BaseDirectory
            logFilePath = currentPath
            #           System.DateTime currentTime = new System.DateTime()
            #           currentTime = System.DateTime.Now
            #           int year = currentTime.Year
            #           int month = currentTime.Month
            #           int day = currentTime.Day
            txtName = logFilePath + "LaserMarking.lld"
            if not File.Exists(txtName):
                fileNameExt = logFilePath[logFilePath.rfind("\\") + 1:] #获取文件名，不带路径
                folderPath = logFilePath[0:len(logFilePath) - len(fileNameExt)]
                if not Directory.Exists(logFilePath):
                    Directory.CreateDirectory(logFilePath)
                if not File.Exists(txtName):
                    File.Create(txtName).Close()

                fs = FileStream(txtName, FileMode.Append)
                #获得字节数组
                data = System.Text.Encoding.Default.GetBytes("Total LaserMarking Total : 1")
                #开始写入
                fs.Write(data, 0, len(data))
                #清空缓冲区、关闭流
                fs.Flush()
                fs.Close()
                return 1
            strTxt = File.ReadAllText(txtName)
            Count = int(strTxt[strTxt.find(":")+2:])
            File.WriteAllText(txtName, "Total LaserMarking : "+ str(Count+1))
            return Count+1
