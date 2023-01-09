using DatabaseAccess;
using DatabaseAccess.Fabrics;
using DatabaseAccess.MSSQL;
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
            DBConfiguration dBConfiguration = new DBConfiguration
            {
                Name = configs.Name,
                ConnectionString = configs.ConnectionString
            };

            switch (configs.Type)
            {
                case ("SQL"):
                    var fabric = new SQLFactory();
                    var executer = fabric.CreateDBExecuter(dBConfiguration);
                    var initializer = fabric.CreateDBInitializer(executer);
                    return initializer.CreateDB().Result;
                    
                default:
                    return "Цей тип БД або не існує, або ще не підтримується";                    
            }
        }

        public string DropDB(DB_DTO configs){
            
            DBConfiguration dBConfiguration = new DBConfiguration
            {
                Name = configs.Name,
                ConnectionString = configs.ConnectionString
            };

            switch (configs.Type)
            {
                case ("SQL"):
                    var fabric = new SQLFactory();
                    var executer = fabric.CreateDBExecuter(dBConfiguration);
                    var initializer = fabric.CreateDBInitializer(executer);
                    return initializer.DropDB().Result;

                default:
                    return "Not found";
            }
        }
    }
}
