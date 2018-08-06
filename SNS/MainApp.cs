using SNS.Controller;
using SNS.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNS
{
    class MainApp
    {
        public static void Main(String[] args)
        {
            FTPHelper fh = new FTPHelper();
            StringBuilder stringfile = ControlManager.Instance.FileHelper.GetStringFile(@"C:\Users\whdgu\Desktop\2018-06-18\2018-06-18.log");

            Console.WriteLine(stringfile.ToString());
        }
    }
}
