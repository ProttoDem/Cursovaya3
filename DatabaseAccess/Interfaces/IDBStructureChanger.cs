using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Interfaces
{
    public interface IDBStructureChanger
    {
        public Task<string> CreateTable();
        public Task<string> AlterTable();
        public Task<string> DropTable();
    }
}
