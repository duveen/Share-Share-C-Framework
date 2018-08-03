using System.Collections.Generic;
using System.Net;
using System.Configuration;
using System.IO;
using System;
using WinSCP;

namespace SNS.Net
{
    public class FTPHelper
    {
        private readonly int Length = 2048;

        public string FileName { get; set; }
        private FtpWebRequest request;

        private Session SESSION;


        public FTPHelper()
        {
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Ftp,
                HostName = ConfigurationManager.AppSettings["FTP.HostName"],
                PortNumber = Convert.ToInt32(ConfigurationManager.AppSettings["FTP.PortNumber"]),
                UserName = ConfigurationManager.AppSettings["FTP.UserName"],
                Password = ConfigurationManager.AppSettings["FTP.Password"]
            };

            SESSION = new Session();
            try
            {
                SESSION.Open(sessionOptions);
            }
            catch { throw; }
        }

        public FTPHelper(string host, int port, string user, string password)
        {
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Ftp,
                HostName = host,
                PortNumber = port,
                UserName = user,
                Password = password
            };

            SESSION = new Session();
            try
            {
                SESSION.Open(sessionOptions);
            }
            catch { throw; }
        }

        public List <string> DownLoadFile(string FileName, bool remove = false)
        {
            List<string> rstList = new List<string>();
            TransferOptions transferOptions = new TransferOptions();
            transferOptions.TransferMode = TransferMode.Binary;

            TransferOperationResult transferResult;
            transferResult = SESSION.GetFiles((ConfigurationManager.AppSettings["FTP_URL"] + FileName), (ConfigurationManager.AppSettings["FTP.DownLoadPath"] + FileName), remove, transferOptions);

            transferResult.Check();

            foreach (TransferEventArgs transfer in transferResult.Transfers)
            {
                rstList.Add(transfer.FileName);
            }

            return rstList;

            //    this.FileName = FileName;
            //    try
            //    {
            //        request = (FtpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["FTP_URL"] + this.FileName);
            //        request.Method = WebRequestMethods.Ftp.DownloadFile;
            //        request.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["FTP.User"], ConfigurationManager.AppSettings["FTP.Password"]);

            //        using (FtpWebResponse resp = (FtpWebResponse)request.GetResponse())
            //        {
            //            Stream responseStream = resp.GetResponseStream();
            //            FileStream writeStream = new FileStream(ConfigurationManager.AppSettings["FTP.DownLoadPath"] + FileName, FileMode.Create);
            //            byte[] buffer = new byte[Length];
            //            int bytesRead = 0;

            //            while (responseStream.Position < responseStream.Length)
            //            {
            //                bytesRead = responseStream.Read(buffer, 0, Length);
            //                writeStream.Write(buffer, 0, bytesRead);
            //            }

            //            responseStream.Close();
            //            writeStream.Close();
            //        }
            //        return true;
            //    }
            //    catch(Exception e)
            //    {
            //        Console.WriteLine(e);                
            //        return false;
            //    }

        }
    }

}