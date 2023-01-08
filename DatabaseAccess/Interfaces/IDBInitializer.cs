using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Interfaces
{
    public interface IDBInitializer
    {
        Task<string> CreateDB();

        Task<string> DropDB();
    }
}
