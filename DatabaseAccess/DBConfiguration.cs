using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class DBConfiguration
    {
        public SqlConnection Connection { get
            {
                return new SqlConnection(ConnectionString);
            }
        }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public string Type { get; set; }
    }
       
}
