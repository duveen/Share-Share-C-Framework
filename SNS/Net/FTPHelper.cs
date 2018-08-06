﻿using System.Collections.Generic;
using System.Net;
using System.Configuration;
using System.IO;
using System;
using WinSCP;

namespace SNS.Net
{
    public class FTPHelper : IDisposable
    {
        public string FileName { get; set; }

        private Session SESSION;

        public FTPHelper()
        {
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Ftp,
                HostName = ConfigurationManager.AppSettings["FTP_URL"],
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

        public void Dispose()
        {
            if (SESSION != null)
            {
                SESSION.Close();
                SESSION.Dispose();
            }
        }

        public List<string> DownloadFile(string localPath, string remotePath, string FileName, bool remove = false)
        {
            List<string> rstList = new List<string>();
            TransferOptions transferOptions = new TransferOptions();
            transferOptions.TransferMode = TransferMode.Binary;

            TransferOperationResult transferResult;
            transferResult = SESSION.GetFiles($@"{remotePath}{FileName}", $@"{localPath}{FileName}", remove, transferOptions);

            transferResult.Check();

            foreach (TransferEventArgs transfer in transferResult.Transfers)
            {
                rstList.Add(transfer.FileName);
            }

            return rstList;
        }

        public List<string> UploadFile(string localPath, string remotePath, bool remove = false)
        {
            List<string> rstFileName = new List<string>();

            TransferOptions transferOptions = new TransferOptions();
            transferOptions.TransferMode = TransferMode.Binary;

            TransferOperationResult transferResult;
            transferResult = SESSION.PutFiles(localPath, remotePath, remove, transferOptions);

            transferResult.Check();

            foreach (TransferEventArgs transfer in transferResult.Transfers)
            {
                rstFileName.Add(transfer.FileName);
            }
            return rstFileName;
        }

    }
}