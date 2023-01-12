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
    public class DBService : IDBService
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

        public string CreateTable(DB_DTO configs, Table_DTO table)
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
                    var structureChanger = fabric.CreateDBStructureChanger(executer);
                    return structureChanger.CreateTable(table.Name, table.Columns).Result;
                default:
                    return "Something went wrong";
            }
        }

        public string DropTable(DB_DTO configs, Table_DTO table)
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
                    var structureChanger = fabric.CreateDBStructureChanger(executer);
                    return structureChanger.DropTable(table.Name).Result;
                default:
                    return "Something went wrong";
            }
        }

        public string AlterTable(DB_DTO configs, Table_DTO table)
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
                    var structureChanger = fabric.CreateDBStructureChanger(executer);
                    return structureChanger.AlterTable(table.Name, table.AlterColumns).Result;
                default:
                    return "Something went wrong";
            }
        }

        public string InsertData(DB_DTO configs, InsertData_DTO insertData)
        {
            DBConfiguration dBConfiguration = new DBConfiguration
            {
                Name = configs.Name,
                ConnectionString = configs.ConnectionString
            };
            InsertData insert = new InsertData
            {
                TableName = insertData.TableName,
                InsertColumns = insertData.InsertColumns
            };
            switch (configs.Type)
            {
                case ("SQL"):
                    var fabric = new SQLFactory();
                    var executer = fabric.CreateDBExecuter(dBConfiguration);
                    var dataChanger = fabric.CreateDBDataChanger(executer);
                    return dataChanger.Insert(insert).Result;
                default:
                    return "Something went wrong";
            }
        }

        public string ReadData(DB_DTO configs, ReadData_DTO readData)
        {
            throw new NotImplementedException();
        }

        public string ReadDataTop(DB_DTO configs, ReadData_DTO readData)
        {
            throw new NotImplementedException();
        }

        public string ReadDataCondition(DB_DTO configs, ReadData_DTO readData)
        {
            throw new NotImplementedException();
        }

        public string DeleteData(DB_DTO configs, DeleteData_DTO deleteData)
        {
            DBConfiguration dBConfiguration = new DBConfiguration
            {
                Name = configs.Name,
                ConnectionString = configs.ConnectionString
            };
            DeleteData delete = new DeleteData
            {
                TableName = deleteData.TableName,
                Condition = deleteData.Condition
            };
            switch (configs.Type)
            {
                case ("SQL"):
                    var fabric = new SQLFactory();
                    var executer = fabric.CreateDBExecuter(dBConfiguration);
                    var dataChanger = fabric.CreateDBDataChanger(executer);
                    return dataChanger.Delete(delete).Result;
                default:
                    return "Something went wrong";
            }
        }

        public string UpdateData(DB_DTO configs, InsertData_DTO insert)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetTables(DB_DTO configs)
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
                    var reader = fabric.CreateDBReader(executer);
                    return reader.GetTables().Result;
                default:
                    var res = new List<string>();
                    res.Add("Something went wrong");
                    return res;
            }
        }

        public IEnumerable<string> GetSequences(DB_DTO configs)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetColumns(DB_DTO configs, string tableName)
        {
            throw new NotImplementedException();
        }
    }
}
