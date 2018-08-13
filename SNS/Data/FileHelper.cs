using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNS.Data
{
    public class FileHelper : IDisposable
    {
        #region [ Property ]
        public StreamReader streamReader { get; set; }
        public string FilePath { get; set; }
        #endregion

        #region [ Constructor ]
        public FileHelper() { }
        public FileHelper(string FilePath)
        {
            this.FilePath = FilePath;
        }
        public void Dispose()
        {
            try
            {
                if (streamReader == null) return;
                streamReader.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                streamReader = null;
                FilePath = string.Empty;
            }
        }
        #endregion

        #region [ Method ]
        private StreamReader GetStreamReader()
        {
            this.streamReader = new StreamReader(FilePath);
            return this.streamReader;
        }

        public List<string> GetStringFile(string FilePath)
        {
            StreamReader stream = null;
            this.FilePath = FilePath;
            List<string> StringFile = new List<string>();
            try
            {

                using (stream = this.GetStreamReader())
                {
                    while (stream.EndOfStream == false)
                    {
                        StringFile.Add(stream.ReadLine());
                    }
                }
                return StringFile;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public bool DeleteFile(string FilePath)
        {
            this.FilePath = FilePath;
            FileInfo file = new FileInfo(this.FilePath);
            try
            {
                file.Delete();
                return true;
            }
            catch (Exception e)
            {                
                return false;
            }
            
        }
        #endregion
    }
}