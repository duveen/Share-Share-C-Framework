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
            fh.DownLoadFile(@"C:\LOG_FILE\", @"/LOG_FILE/", @"2018-06-05.log");
        }
    }
}
