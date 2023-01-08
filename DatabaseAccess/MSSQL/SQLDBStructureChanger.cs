using DatabaseAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.MSSQL
{
    public class SQLDBStructureChanger : IDBStructureChanger
    {
        public Task<string> AlterTable()
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateTable()
        {
            throw new NotImplementedException();
        }

        public Task<string> DropTable()
        {
            throw new NotImplementedException();
        }
    }
}
