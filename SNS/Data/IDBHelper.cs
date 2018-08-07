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
        int ExecuteNonQuery(string commandText, CommandType commandType = CommandType.Text, OleDbParameter[] parameters = null);
    }
}
