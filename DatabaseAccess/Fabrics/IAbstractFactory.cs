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
        IDBInitializer CreateDBInitializer(IDBExecuter executer);
        IDBReader CreateDBReader(IDBExecuter executer);
        IDBStructureChanger CreateDBStructureChanger(IDBExecuter executer);
        IDBDataChanger CreateDBDataChanger(IDBExecuter executer);
        IDBExecuter CreateDBExecuter(DBConfiguration config);
    }
}
