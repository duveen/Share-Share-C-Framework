using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNS.Data
{
    public interface IDBHelper : IDisposable
    {
        /// <summary>
        /// SQL 문을 실행하고 결과를 반환 합니다.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string commandText, CommandType commandType = CommandType.Text, OleDbParameter[] parameters = null);
        IDataReader ExecuteReader(string commandText, CommandType commandType = CommandType.Text, OleDbParameter[] parameters = null);
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
