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
                    var proxy = fabric.CreateDBProxy(new DBConfiguration
                                                                        {
                                                                            Name = configs.Name,
                                                                            ConnectionString = configs.ConnectionString
                                                                        }, 
                                                                        fabric.CreateDBInitializer(dBConfiguration), 
                                                                        fabric.CreateDBReader(dBConfiguration), fabric.CreateDBStructureChanger(dBConfiguration), fabric.CreateDBDataChanger(dBConfiguration));
                    return proxy.CreateDB().Result;
                default:
                    return "Цей тип БД або не існує, або ще не підтримується";                    
            }
        }

        public string DropDB(DB_DTO configs)
        {
            SQLDBInitializer i = new SQLDBInitializer(new DBConfiguration
            {
                Name = configs.Name,
                ConnectionString = configs.ConnectionString
            });

            return i.DropDB().Result;
        }
    }
}
