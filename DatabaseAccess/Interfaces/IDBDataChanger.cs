using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Interfaces
{
    public interface IDBDataChanger
    {
        Task<string> Insert(InsertData insertData);
        Task<string> ReadId(string id);
        Task<string> ReadTop(string count);
        Task<string> ReadAll();
        Task<string> Update(InsertData insertData);
        Task<string> Delete(string id);

    }
}
