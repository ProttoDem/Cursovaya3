using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Interfaces
{
    public interface IDBProxy : IDBInitializer, IDBReader, IDBDataChanger, IDBStructureChanger, IDisposable
    {
        public string CheckConnection();
    }
}
