using DatabaseAccess.Interfaces;
using System.Data.SqlClient;

namespace DatabaseAccess.MSSQL
{
    public class SQLDBDataChanger : IDBDataChanger
    {
        private readonly IDBExecuter executer;

        public SQLDBDataChanger(IDBExecuter _executer)
        {
            executer = _executer;
        }

        public async Task<string> Delete(DeleteData deleteData)
        {
            async Task<string> Delete(string name, SqlConnection sqlConnection)
            {
                SqlCommand command = new SqlCommand();
                // определяем выполняемую команду
                string sql = "Delete FROM " + deleteData.TableName + " WHERE " + deleteData.Condition + " ;";
                command.CommandText = sql;
                command.Connection = sqlConnection;
                // выполняем команду
                await command.ExecuteNonQueryAsync();
                return "Видалено строку з таблицы " + deleteData.TableName;
            }

            Func<string, SqlConnection, Task<string>> task = Delete;
            return await executer.Execute(task);
        }

        public async Task<string> Insert(InsertData insertData)
        {
            async Task<string> InsertData(string name, SqlConnection sqlConnection)
            {
                SqlCommand command = new SqlCommand();
                // определяем выполняемую команду
                string sql = "insert into " + insertData.TableName + " values( ";
                foreach (var input in insertData.InsertColumns)
                {
                    sql += $"'{input}',";
                }
                sql = sql[..^1];
                sql += ")";
                command.CommandText = sql;
                command.Connection = sqlConnection;
                // выполняем команду
                await command.ExecuteNonQueryAsync();
                return "Додано строку у таблицю " + insertData.TableName;
            }

            Func<string, SqlConnection, Task<string>> task = InsertData;
            return await executer.Execute(task);
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

        public Task<string> Update(InsertData insertData)
        {
            throw new NotImplementedException();
        }
    }
}
