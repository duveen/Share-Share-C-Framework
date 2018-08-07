using SNS.DataObject.SF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject
{
    public class LOG
    {

        static public readonly string SF_PAKAGE_PATH = "SNS.DataObject.SF";
        
        public HIGH_RANK_DIVISION H_Division { get; set; }
        public DateTime Time { get; set; }
        public string TransferType { get; set; }
        public StreamFuction SF { get; set; }
        public int SystemByte { get; set; }        
        public string AdditionINFO { get; set; }
        public List<string> LowRankLogs { get; set; } = null;

        #region [ Constructor ]
        public LOG() { }
        public LOG(DateTime Time, HIGH_RANK_DIVISION H_Division, string TransferType)
        {
            this.Time = Time;
            this.H_Division = H_Division;
            this.SystemByte = SystemByte;
            this.TransferType = TransferType;

            
        }
        public LOG(DateTime Time, HIGH_RANK_DIVISION H_Division, string TransferType, string AdditionINFO) : this(Time, H_Division, TransferType)
        {            
            this.AdditionINFO = AdditionINFO;
        }
        public LOG(DateTime Time, HIGH_RANK_DIVISION H_Division, string TransferType, string SFName, int SystemByte) : this(Time, H_Division, TransferType)
        {
            
            this.SystemByte = SystemByte;
            try
            {
                this.SF = Activator.CreateInstance(Type.GetType($"{SF_PAKAGE_PATH}.{SFName}")) as StreamFuction;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(SFName);
                throw;
            }
        }
        #endregion

        #region [ Method ] 
        public void AddLowRankLog(string line)
        {
            if (LowRankLogs == null)
                LowRankLogs = new List<string>();
            LowRankLogs.Add(line);
        }
        #endregion
    }
}
