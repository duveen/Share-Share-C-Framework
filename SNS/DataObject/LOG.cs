using SNS.DataObject.SF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject
{
    [DataContract]    
    public class LOG
    {

        

        [DataMember]
        public HIGH_RANK_DIVISION H_Division { get; set; }
        [DataMember]
        public DateTime Time { get; set; }
        [DataMember]
        public string TransferType { get; set; }
        [DataMember]
        public string SF { get; set; }
        public StreamFuction SFInstance { get; set; }
        [DataMember]
        public int SystemByte { get; set; }
        [DataMember]
        public string AdditionINFO { get; set; }
        [DataMember]
        public List<string> LowRankLogs { get; set; } = new List<string>();

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
                this.SF = SFName;
                this.SFInstance = Activator.CreateInstance(Type.GetType($"SNS.DataObject.SF.{SFName}")) as StreamFuction;                
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
            LowRankLogs.Add(line);
        }
        #endregion
    }
}
