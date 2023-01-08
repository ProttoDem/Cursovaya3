using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Interfaces;

namespace DatabaseAccess.Fabrics
{
    public interface IAbstractFactory
    {
        IDBInitializer CreateDBInitializer(DBConfiguration config);
        IDBReader CreateDBReader(DBConfiguration config);
        IDBStructureChanger CreateDBStructureChanger(DBConfiguration config);
        IDBDataChanger CreateDBDataChanger(DBConfiguration config);
        IDBProxy CreateDBProxy(DBConfiguration config, IDBInitializer dBInitializer, IDBReader dBReader, IDBStructureChanger dBStructureChanger, IDBDataChanger dBDataChanger);
    }
}
