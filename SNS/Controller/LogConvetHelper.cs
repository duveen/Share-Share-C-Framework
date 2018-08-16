using SNS.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNS.Controller
{
    public class LogConvetHelper
    {
        #region [ static ]
        static public readonly int YEAR_MONTH_DAY_INDEX = 1;
        static public readonly int HOUR_MINUTE_INDEX = 2;
        static public readonly int TRANSFER_TYPE_INDEX = 4;
        static public readonly int SF_INDEX = 5;
        static public readonly int SYSTEMBYTE_INDEX = 9;
        static public readonly string DATE_TIME_FORMAT = "yyyy/MM/dd HH:mm:ss.fff";
        #endregion

        #region [ Method ]
        /// <summary>
        /// 문자열 로그를 LOG 객체로 인스턴스화하여 반환 합니다.
        /// </summary>
        /// <param name="strLog"></param>
        /// <returns></returns>
        public List<LOG> ConvertToLogInstance(List<string> strLog)
        {
            List<LOG> LogList = new List<LOG>();
            
            LOG currentLog = null;

            foreach (string line in strLog)
            {
                HIGH_RANK_DIVISION H_Division = GetkHighRankLogDivision(line);

                if (H_Division != HIGH_RANK_DIVISION.NON)
                {
                    string[] SplitedLog = SplitHighRankLog(line);
                    DateTime Time = DateTime.ParseExact($"{SplitedLog[YEAR_MONTH_DAY_INDEX]} {SplitedLog[HOUR_MINUTE_INDEX]}", DATE_TIME_FORMAT, null);
                    string TransferType = SplitedLog[TRANSFER_TYPE_INDEX];
                    string SFName = SplitedLog[SF_INDEX];

                    if (H_Division == HIGH_RANK_DIVISION.WARN || H_Division == HIGH_RANK_DIVISION.INFO)
                    {
                        StringBuilder AdditionINFOBuilder = new StringBuilder();
                        for (int i = TRANSFER_TYPE_INDEX + 1; i < SplitedLog.Length; i++)
                        {
                            AdditionINFOBuilder.Append($"{SplitedLog[i]} ");
                        }
                        currentLog = new LOG(Time, H_Division, TransferType, AdditionINFOBuilder.ToString());
                    }
                    else
                    {
                        int SystemByte = int.Parse(SplitedLog[SYSTEMBYTE_INDEX]);
                        currentLog = new LOG(Time, H_Division, TransferType, SFName, SystemByte);
                    }                    
                    LogList.Add(currentLog);
                }
                else
                {
                    currentLog.AddLowRankLog(line);
                }
            }
            return LogList;
        }

        private HIGH_RANK_DIVISION GetkHighRankLogDivision(string line)
        {
            if (line.IndexOf("[") == -1)
                return HIGH_RANK_DIVISION.NON;

            if (line.IndexOf("WARN") != -1)
                return HIGH_RANK_DIVISION.WARN;
            else if (line.IndexOf("INFO") != -1)
                return HIGH_RANK_DIVISION.INFO;
            else if (line.IndexOf("SEND") != -1)
                return HIGH_RANK_DIVISION.SEND;
            else
                return HIGH_RANK_DIVISION.RECV;
        }

        private string[] SplitHighRankLog(string line)
        {
            string[] parsedLog = line.Split(' ', '=', '[', ']');
            return parsedLog;
        }
        #endregion
    }
}