using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IDBService
    {
        string CreateDB(DB_DTO configs);
        string DropDB(DB_DTO configs);
        string CreateTable(DB_DTO configs, Table_DTO table);
        string DropTable(DB_DTO configs, Table_DTO table);
        string AlterTable(DB_DTO configs, Table_DTO table);

        string InsertData(DB_DTO configs, InsertData_DTO insert);
        string ReadData(DB_DTO configs, ReadData_DTO readData);
        string ReadDataTop(DB_DTO configs, ReadData_DTO readData);
        string ReadDataCondition(DB_DTO configs, ReadData_DTO readData);
        string UpdateData(DB_DTO configs, InsertData_DTO update);
        string DeleteData(DB_DTO configs, DeleteData_DTO deleteData);
        IEnumerable<string> GetTables(DB_DTO configs);
        IEnumerable<string> GetSequences(DB_DTO configs);
        IEnumerable<string> GetColumns(DB_DTO configs, string tableName);
    }
}
