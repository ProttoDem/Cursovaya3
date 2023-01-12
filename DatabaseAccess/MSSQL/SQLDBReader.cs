using DatabaseAccess.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseAccess.MSSQL
{
    internal class SQLDBReader : IDBReader
    {
        private readonly IDBExecuter executer;

        private static void ReadSingleRow(IDataRecord dataRecord, List<string> result)
        {
            result.Add(dataRecord[0].ToString());
        }

        public SQLDBReader(IDBExecuter _executer)
        {
            executer = _executer;
        }        

        public async Task<IEnumerable<string>> GetColumns(string tableName)
        {
            
                async Task<IEnumerable<string>> Columns(string name, SqlConnection sqlConnection)
                {
                SqlCommand command = new SqlCommand();
                // определяем выполняемую команду
                command.CommandText = "SELECT *\r\nFROM INFORMATION_SCHEMA.COLUMNS\r\nWHERE TABLE_NAME = N'" + tableName + "'";
                // определяем используемое подключение
                command.Connection = sqlConnection;
                // выполняем команду
                SqlDataReader reader = await command.ExecuteReaderAsync();
                List<string> tables = new List<string>();
                while (reader.Read())
                {
                    ReadSingleRow((IDataRecord)reader, tables);
                }
                return tables;
            }

            Func<string, SqlConnection, Task<IEnumerable<string>>> task = Columns;
            return await executer.ExecuteMany(task);

        }

        public Task<IEnumerable<string>> GetSequences()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string>> GetTables()
        {
            async Task<IEnumerable<string>> Tables(string name, SqlConnection sqlConnection)
            {
                SqlCommand command = new SqlCommand();
                // определяем выполняемую команду
                command.CommandText = "SELECT name FROM sys.objects WHERE type_desc = 'USER_TABLE'";
                // определяем используемое подключение
                command.Connection = sqlConnection;
                // выполняем команду
                SqlDataReader reader = await command.ExecuteReaderAsync();
                List<string> tables = new List<string>();
                while (reader.Read())
                {
                    ReadSingleRow((IDataRecord)reader, tables);
                }
                return tables;
            }

            Func<string, SqlConnection, Task<IEnumerable<string>>> task = Tables;
            return await executer.ExecuteMany(task);
        }
        
        public Task<string> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<string> ReadId(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> ReadTop(string count)
        {
            throw new NotImplementedException();
        }
    }
}

