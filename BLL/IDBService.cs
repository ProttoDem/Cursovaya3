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
        string ReadData(DB_DTO configs);
        string ReadData(DB_DTO configs, int count);
        string ReadDataId(DB_DTO configs, int id);
        string UpdateData(DB_DTO configs, InsertData insert);
        string DeleteData(DB_DTO configs, int id);
    }
}
