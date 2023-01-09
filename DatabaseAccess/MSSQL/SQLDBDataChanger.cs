using DatabaseAccess.Interfaces;

namespace DatabaseAccess.MSSQL
{
    public class SQLDBDataChanger : IDBDataChanger
    {
        private readonly IDBExecuter executer;

        public SQLDBDataChanger(IDBExecuter _executer)
        {
            executer = _executer;
        }
    }
}
