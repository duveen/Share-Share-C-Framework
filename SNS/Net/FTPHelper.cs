using System.Collections.Generic;
using System.Net;
using System.Configuration;
using System.IO;
using System;

namespace SNS.Net
{
    public class FTPHelper
    {
        private readonly int Length = 2048;

        public string FileName { get; set; }
        private FtpWebRequest request;
        public FTPHelper()
        {
        }

        public bool DownLoadFile(string FileName)
        {
            this.FileName = FileName;
            try
            {
                request = (FtpWebRequest)WebRequest.Create(this.FileName);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["FTP.User"], ConfigurationManager.AppSettings["FTP.Password"]);

                using (FtpWebResponse resp = (FtpWebResponse)request.GetResponse())
                {
                    Stream responseStream = resp.GetResponseStream();
                    FileStream writeStream = new FileStream(ConfigurationManager.AppSettings["FTP.DownLoadPath"] + FileName, FileMode.Create);
                    byte[] buffer = new byte[Length];
                    int bytesRead = 0;

                    while (responseStream.Position < responseStream.Length)
                    {
                        bytesRead = responseStream.Read(buffer, 0, Length);
                        writeStream.Write(buffer, 0, bytesRead);
                    }

                    responseStream.Close();
                    writeStream.Close();
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }
    }

}