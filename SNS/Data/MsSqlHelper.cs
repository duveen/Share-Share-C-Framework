using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNS.Data
{
    class MsSqlHelper : IDBHelper
    {
        #region [ Variable ]
        private SqlConnection m_DbConnection = null;
        private SqlTransaction m_Transaction = null;
        #endregion

        #region [ Property ]
        public IDbConnection DbConnection
        {
            get { return this.m_DbConnection; }
            set { this.m_DbConnection = value as SqlConnection; }
        }
        public string ConnectionString { get; set; }

        public bool IsTransaction { get; protected set; } = false;

        #endregion

        #region [ Constructor ]

        public MsSqlHelper(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public void Dispose()
        {
            try
            {
                if (this.m_DbConnection == null)
                {
                    return;
                }
                this.m_DbConnection.Close();
                this.m_DbConnection.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                this.m_DbConnection = null;
            }
        }
        #endregion

        #region [ Method ]
        /// <summary> 
        /// 활성화 된 DbConnection을 반환합니다.
        /// </summary>
        /// <returns></returns>
        private SqlConnection GetConnection()
        {
            try
            {
                if (this.m_DbConnection == null) this.m_DbConnection = new SqlConnection(this.ConnectionString);
                if (this.m_DbConnection.State == ConnectionState.Closed) this.m_DbConnection.Open();
                if (this.IsTransaction == true && this.m_Transaction == null) this.m_Transaction = this.m_DbConnection.BeginTransaction();

                return this.m_DbConnection;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public int ExecuteNonQuery(string commandText, CommandType commandType, OleDbParameter[] parameters)
        {
            SqlConnection connection = null;
            int result = 0;
            try
            {
                connection = this.GetConnection();
                using (SqlCommand command = new SqlCommand(commandText, connection, m_Transaction))
                {
                    command.CommandType = commandType;
                    command.CommandText = commandText;
                    if (parameters != null)
                    {
                        foreach (OleDbParameter param in parameters)
                        {
                            if (param.OleDbType == OleDbType.Empty)
                                continue;
                            command.Parameters.Add(new SqlParameter(param.ParameterName, param.Value));
                        }
                    }
                    result = command.ExecuteNonQuery();
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw e;
            }
            finally
            {
                if (this.m_Transaction == null) connection.Close();
            }
        }

        public IDataReader ExecuteReader(string commandText, CommandType commandType = CommandType.Text, OleDbParameter[] parameters = null)
        {
            SqlConnection connection = null;
            try
            {
                IDataReader result = null;

                connection = GetConnection();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = commandType;
                    command.CommandText = commandText;
                    if(parameters != null)
                    {
                        foreach(OleDbParameter param in parameters)
                        {
                            if (param.OleDbType == OleDbType.Empty) continue;
                            command.Parameters.Add(new SqlParameter(param.ParameterName, param.Value));
                        }
                    }

                    result = command.ExecuteReader();
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (this.m_Transaction == null) connection.Close();
            }

        }

        public void BeginTransaction()
        {
            this.IsTransaction = true;
        }

        public void Commit()
        {
            if (this.m_Transaction == null) return;
            this.m_Transaction.Commit();
            this.m_Transaction = null;
            this.IsTransaction = false;
            this.DbConnection.Close();
        }

        public void Rollback()
        {
            if (this.m_Transaction == null) return;
            this.m_Transaction.Rollback();
            this.m_Transaction = null;
            this.IsTransaction = false;
            this.DbConnection.Close();
        }        
        #endregion
    }
}
