using DatabaseAccess.Interfaces;

namespace DatabaseAccess.MSSQL
{
    internal class SQLDBReader : IDBReader
    {
        private readonly IDBExecuter executer;

        public SQLDBReader(IDBExecuter _executer)
        {
            executer = _executer;
        }

        public Task GetTables()
        {
            throw new NotImplementedException();
        }
    }
}

