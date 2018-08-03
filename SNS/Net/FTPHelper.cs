using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;


namespace SNS.Net
{
    public string FileName { get; set; }
    private FtpWebRequest request;
    public FTPHelper()
    {
    }

    public List<string> DownLoadFile(string FileName)
    {
        this.FileName = FileName;
        request = (FtpWebRequest)WebRequest.Create(this.FileName);
        request.Method = WebRequestMethods.Ftp.DownloadFile;
        request.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["FTP.User"], ConfigurationManager.AppSettings["FTP.Password"]);

        using (FtpWebResponse resp = (FtpWebResponse)request.GetResponse())
        {
            Stream stream = resp.GetResponseStream();
            FileStream writeStream = new FileStream(ConfigurationManager.AppSettings["FTP.DownLoadPath"] + FileName, FileMode.Create);
            using (StreamReader reader = new StreamReader(stream))
            {
                data.Add(reader.ReadToEnd());
            }
        }

    }


}