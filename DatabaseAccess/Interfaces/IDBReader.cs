using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Interfaces
{
    public interface IDBReader
    {
        public Task<IEnumerable<string>> GetTables();
        public Task<IEnumerable<string>> GetColumns(string tableName);
        public Task<IEnumerable<string>> GetSequences();
        public Task<string> ReadId(string id);
        public Task<string> ReadTop(string count);
        public Task<string> ReadAll();
    }
}
