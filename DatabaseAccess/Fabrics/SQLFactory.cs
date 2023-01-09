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
        public IDBDataChanger CreateDBDataChanger(IDBExecuter executer)
        {
            return new SQLDBDataChanger(executer);
        }

        public IDBInitializer CreateDBInitializer(IDBExecuter executer)
        {
            return new SQLDBInitializer(executer);
        }

        public IDBExecuter CreateDBExecuter(DBConfiguration config)
        {
            return new SQLExecuter(config);
        }

        public IDBReader CreateDBReader(IDBExecuter executer)
        {
            return new SQLDBReader(executer);
        }

        public IDBStructureChanger CreateDBStructureChanger(IDBExecuter executer)
        {
            return new SQLDBStructureChanger(executer);
        }
    }
}
