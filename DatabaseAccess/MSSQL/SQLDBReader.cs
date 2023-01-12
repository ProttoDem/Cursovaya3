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
            result.Add(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
        }

        public SQLDBReader(IDBExecuter _executer)
        {
            executer = _executer;
        }        

        public async Task<IEnumerable<TableColumn>> GetColumns(string tableName)
        {
            async Task<string> Columns(string name, SqlConnection sqlConnection)
            {
                SqlCommand command = new SqlCommand();
                // определяем выполняемую команду
                command.CommandText = "DROP TABLE " + tableName + ";";
                // определяем используемое подключение
                command.Connection = sqlConnection;
                // выполняем команду
                await command.ExecuteNonQueryAsync();
                return "Таблиця " + tableName + " видалена";
            }

            Func<string, SqlConnection, Task<string>> task = Columns;
            return await executer.Execute(task);       
        
        }

        public Task<IEnumerable<Sequence>> GetSequences()
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

