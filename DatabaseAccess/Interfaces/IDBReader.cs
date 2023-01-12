using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Interfaces
{
    public interface IDBReader
    {
        public Task<string> GetTables();
        public Task<IEnumerable<TableColumn>> GetColumns(string tableName);

        public Task<IEnumerable<Sequence>> GetSequences();
        public Task<string> ReadId(string id);
        public Task<string> ReadTop(string count);
        public Task<string> ReadAll();
    }
}
