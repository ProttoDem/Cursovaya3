using DatabaseAccess.Interfaces;

using System.Data.SqlClient;


namespace DatabaseAccess.MSSQL
{
    public class SQLDBStructureChanger : IDBStructureChanger
    {
        private readonly IDBExecuter executer;

        public SQLDBStructureChanger(IDBExecuter _executer)
        {
            executer = _executer;
        }
        public Task<string> AlterTable(string tableName, IEnumerable<TableColumn> tableColumns)
        {
            throw new NotImplementedException();

        }

        public async Task<string> CreateTable(string tableName, IEnumerable<TableColumn> tableColumns)
        {
            async Task<string> Create(string name, SqlConnection sqlConnection)
            {
                SqlCommand command = new SqlCommand();
                string sql = "CREATE TABLE " + tableName + "(";
                foreach (var column in tableColumns)
                {
                    sql += column.Name + " " + column.DataType + " ";
                    if (column.NOT_NULL)
                    {
                        sql += "NOT NULL ";
                    }
                    if (column.UNIQUE)
                    {
                        sql += "UNIQUE ";
                    }
                    if (column.PRIMARY_KEY)
                    {
                        sql += "PRIMARY KEY";
                    }
                    sql += ",";
                }
                sql += ");";
                // определяем выполняемую команду
                command.CommandText = sql;
                // определяем используемое подключение
                command.Connection = sqlConnection;
                // выполняем команду
                await command.ExecuteNonQueryAsync();
                return "Таблиця " + tableName + "створена";
            }
            Func<string, SqlConnection, Task<string>> task = Create;
            return await executer.Execute(task);
            
        }

        public async Task<string> DropTable(string tableName)
        {
            async Task<string> Drop(string name, SqlConnection sqlConnection)
            {
                SqlCommand command = new SqlCommand();
                // определяем выполняемую команду
                command.CommandText = "DROP TABLE " + tableName + ";";
                // определяем используемое подключение
                command.Connection = sqlConnection;
                // выполняем команду
                await command.ExecuteNonQueryAsync();
                return "Таблиця "+ tableName + " видалена";
            }

            Func<string, SqlConnection, Task<string>> task = Drop;
            return await executer.Execute(task);
        }
    }
}
