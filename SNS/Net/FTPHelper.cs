using System.Collections.Generic;
using System.Net;
using System.Configuration;
using System.IO;
using System;
using WinSCP;

namespace SNS.Net
{
    public class FTPHelper : IDisposable
    {
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

        public List<string> GetFileList(string path = "/")
        {
            List<string> rstList = new List<string>();

            RemoteDirectoryInfo directory = SESSION.ListDirectory(path);
            foreach (RemoteFileInfo fileInfo in directory.Files)
            {
                rstList.Add($"{fileInfo.Name} with size {fileInfo.Length}, permissions {fileInfo.FilePermissions} and last modification at {fileInfo.LastWriteTime}");
            }
            return rstList;
        }

        public List<string> DownloadFile(string remotePath, string localPath, bool remove = false)
        {
            List<string> rstList = new List<string>();
            TransferOptions transferOptions = new TransferOptions();
            transferOptions.TransferMode = TransferMode.Binary;

            TransferOperationResult transferResult;
            transferResult = SESSION.GetFiles($@"{remotePath}", $@"{localPath}", remove, transferOptions);

            try
            {
                transferResult.Check();
                foreach (TransferEventArgs transfer in transferResult.Transfers)
                {
                    rstList.Add(transfer.FileName);
                }

                return rstList;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public List<string> DownloadFile(string localPath, string remotePath, string FileName, bool remove = false)
        {
            List<string> rstList = new List<string>();
            TransferOptions transferOptions = new TransferOptions();
            transferOptions.TransferMode = TransferMode.Binary;

            TransferOperationResult transferResult;
            transferResult = SESSION.GetFiles($@"{remotePath}{FileName}", $@"{localPath}{FileName}", remove, transferOptions);

            try
            {
                transferResult.Check();
                foreach (TransferEventArgs transfer in transferResult.Transfers)
                {
                    rstList.Add(transfer.FileName);
                }

                return rstList;
            }
            catch (Exception e)
            {
                throw e;
            }

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

        public bool RemoveFile(string path)
        {
            try
            {
                SESSION.RemoveFiles(path);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}