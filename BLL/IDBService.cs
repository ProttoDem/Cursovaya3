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
    }
}
