using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserMarking
{
    class ReadDatFile
    {
        public string username = "";
        public string key = "";
        public string ip = "";
        public string ReadName()
        {         
                //读取用户登录信息库
                StreamReader userData = new StreamReader(System.IO.Directory.GetCurrentDirectory() + @"\user.dat");
                string data = "";
                while ((data = userData.ReadLine()) != null & data != "") //data读取每一行信息
                {
                    string[] str = data.Split(';');//以分号为分隔符
                    username = str[0].Substring(9);
                    //key = str[1].Substring(4);
                }
                userData.Close();//关闭StreamReader
                return username;
        }

        public string ReadKey()
        {
            //读取用户登录信息库
            StreamReader userData = new StreamReader(System.IO.Directory.GetCurrentDirectory() + @"\user.dat");
            string data = "";
            while ((data = userData.ReadLine()) != null & data != "") //data读取每一行信息
            {
                string[] str = data.Split(';');//以分号为分隔符
                //username = str[0].Substring(9);
                key = str[1].Substring(4);
            }
            userData.Close();//关闭StreamReader
            return key;
        }

        public string Readip()
        {
            //读取用户登录信息库
            StreamReader userData = new StreamReader(System.IO.Directory.GetCurrentDirectory() + @"\user.dat");
            string data = "";
            while ((data = userData.ReadLine()) != null & data != "") //data读取每一行信息
            {
                string[] str = data.Split(';');//以分号为分隔符
                //username = str[0].Substring(9);
                ip = str[2].Substring(8);
            }
            userData.Close();//关闭StreamReader
            return ip;
        }
    }
}
