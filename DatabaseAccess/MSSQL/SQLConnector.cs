using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.MSSQL
{
    public class SQLConnector
    {
        private readonly DBConfiguration DBConfiguration;

        /*public SqlConnection SqlConnection { get { 
            }
            set; }
*/
        public SQLConnector(DBConfiguration dBConfiguration)
        {
            DBConfiguration = dBConfiguration;
        }
    }
}
