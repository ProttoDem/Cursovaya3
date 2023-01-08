using DatabaseAccess.Interfaces;
using DatabaseAccess.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Fabrics
{
    public class SQLFactory : IAbstractFactory
    {
        public IDBDataChanger CreateDBDataChanger(DBConfiguration config)
        {
            return new SQLDBDataChanger();
        }

        public IDBInitializer CreateDBInitializer(DBConfiguration config)
        {
            return new SQLDBInitializer(config);
        }

        public IDBProxy CreateDBProxy(DBConfiguration config, IDBInitializer dBInitializer, IDBReader dBReader, IDBStructureChanger dBStructureChanger, IDBDataChanger dBDataChanger)
        {
            return new SQLDBProxy(config, dBInitializer, dBReader, dBStructureChanger, dBDataChanger);
        }

        public IDBReader CreateDBReader(DBConfiguration config)
        {
            return new SQLDBReader(config);
        }

        public IDBStructureChanger CreateDBStructureChanger(DBConfiguration config)
        {
            return new SQLDBStructureChanger();
        }
    }
}
