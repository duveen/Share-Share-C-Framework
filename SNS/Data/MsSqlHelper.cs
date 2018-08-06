using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNS.Data
{
    class MsSqlHelper
    {
        #region [ Variable ]
        private SqlConnection m_DbConnection = null;
        #endregion

        #region [ Property ]
        public IDbConnection DbConnection
        {
            get { return this.m_DbConnection; }
            set { this.m_DbConnection = value as SqlConnection; }
        }
        public string ConnectionString { get; set; }

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
                return this.m_DbConnection;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public bool Connect()
        {
            try
            {
                GetConnection();
                return true;
            }
            catch
            {
                return false;
            }

            #endregion
        }
    }
}
