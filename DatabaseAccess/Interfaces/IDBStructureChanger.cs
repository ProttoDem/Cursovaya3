using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Interfaces
{
    public interface IDBStructureChanger
    {
        public Task<string> CreateTable(string tableName, IEnumerable<TableColumn> columns);
        public Task<string> AlterTable(string tableName, IEnumerable<TableColumnAlter> columns);
        public Task<string> DropTable(string tableName);
    }
}
