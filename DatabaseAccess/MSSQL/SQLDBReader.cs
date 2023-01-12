using DatabaseAccess.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseAccess.MSSQL
{
    internal class SQLDBReader : IDBReader
    {
        private readonly IDBExecuter executer;

        private static void ReadSingleRowOneElement(IDataRecord dataRecord, List<string> result)
        {
            result.Add(dataRecord[0].ToString());
        }
        private static void ReadSingleRowManyElements(IDataRecord dataRecord, List<string> result)
        {
            result.Add(String.Format("{0}, {1}, {2}, {3}", dataRecord[1], dataRecord[3], dataRecord[4], dataRecord[5]));
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
                    ReadSingleRowOneElement((IDataRecord)reader, tables);
                }
                return tables;
            }

            Func<string, SqlConnection, Task<IEnumerable<string>>> task = Columns;
            return await executer.ExecuteMany(task);

        }

        public async Task<IEnumerable<string>> GetSchema()
        {

            async Task<IEnumerable<string>> Schema(string name, SqlConnection sqlConnection)
            {
                SqlCommand command = new SqlCommand();
                // определяем выполняемую команду
                command.CommandText = "select schema_name(tab.schema_id) as schema_name, tab.name as table_name, col.column_id, col.name as column_name, t.name as data_type, col.max_length, col.precision from sys.tables as tab inner join sys.columns as col on tab.object_id = col.object_id left join sys.types as t on col.user_type_id = t.user_type_id order by schema_name, table_name, column_id; ";
                // определяем используемое подключение
                command.Connection = sqlConnection;
                // выполняем команду
                SqlDataReader reader = await command.ExecuteReaderAsync();
                List<string> tables = new List<string>();
                while (reader.Read())
                {
                    ReadSingleRowManyElements((IDataRecord)reader, tables);
                }
                return tables;
            }

            Func<string, SqlConnection, Task<IEnumerable<string>>> task = Schema;
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
                    ReadSingleRowOneElement((IDataRecord)reader, tables);
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

