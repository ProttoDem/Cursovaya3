using DatabaseAccess.Interfaces;
using MySqlConnector;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace DatabaseAccess.MSSQL
{
    public class SQLDBInitializer : IDBInitializer
    {
        private readonly IDBExecuter executer;

        public SQLDBInitializer(IDBExecuter _executer)
        {
            executer = _executer;
        }

        public async Task<string> CreateDB()
        {
            
            async Task<string> Create(string name, SqlConnection sqlConnection)
            {
                SqlCommand command = new SqlCommand();
                // определяем выполняемую команду
                command.CommandText = "CREATE DATABASE " + name + ";";
                // определяем используемое подключение
                command.Connection = sqlConnection;
                // выполняем команду
                await command.ExecuteNonQueryAsync();
                return "База даних створена";
            }

            Func<string, SqlConnection, Task<string>> task = Create;
            return await executer.Execute(task);
        }

        public async Task<string> DropDB()
        {
            async Task<string> Drop(string name, SqlConnection sqlConnection)
            {
                SqlCommand command = new SqlCommand();
                // определяем выполняемую команду
                command.CommandText = "DROP DATABASE " + name + ";";
                // определяем используемое подключение
                command.Connection = sqlConnection;
                // выполняем команду
                await command.ExecuteNonQueryAsync();
                return "База даних deleted";
            }

            Func<string, SqlConnection, Task<string>> task = Drop;
            return await executer.Execute(task);
        }
    }
}