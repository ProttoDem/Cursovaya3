using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DBService
    {
        public DBService()
        {

        }
        public string CreateDB(DB_DTO configs)
        {
            SQLDBInitializer i = new SQLDBInitializer(new DBConfiguration { Name = configs.Name, 
                                                    ConnectionString = configs.ConnectionString, 
                                                    Type = configs.Type });
            
            return i.CreateDB().Result;
        }
    }
}
