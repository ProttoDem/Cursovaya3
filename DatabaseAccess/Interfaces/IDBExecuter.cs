using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Interfaces
{
    public interface IDBExecuter : IDisposable
    {
        Task<string> Execute(Func<string, SqlConnection, Task<string>> command);
        Task<IEnumerable<string>> ExecuteMany(Func<string, SqlConnection, Task<IEnumerable<string>>> command);
    }
}
