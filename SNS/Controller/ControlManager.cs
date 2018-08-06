using SNS.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SNS.Controller
{
    public class ControlManager
    {
        public static ControlManager Instance { get; set; } = new ControlManager();

        public IDBHelper DBHelper
        {
            get
            {
                string strDbProvider = ConfigurationManager.ConnectionStrings["SNSDB"].ProviderName;
                string strDbConnctionString = ConfigurationManager.ConnectionStrings["SNSDB"].ConnectionString;
                return this.GetDBHelper(strDbProvider, strDbConnctionString);
            }
        }

        public FileHelper FileHelper
        {
            get
            {
                return new FileHelper();
            }            
        }
        

        private IDBHelper GetDBHelper(string providerName, string connectionString)
        {
            try
            {
                Type provider = typeof(IDBHelper);
                Assembly assem = Assembly.GetAssembly(provider);
                if (assem == null) return null;

                object[] args = new object[] { connectionString };
                IDBHelper dBHelper = assem.CreateInstance(providerName, true, BindingFlags.Default, null, args, null, null) as IDBHelper;

                return dBHelper;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

    }
}
