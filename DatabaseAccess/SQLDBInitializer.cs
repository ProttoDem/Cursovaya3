using System.Data;
using System.Data.SqlClient;

namespace DatabaseAccess
{
    public class SQLDBInitializer : IDBInitializer
    {
        private readonly DBConfiguration configs;

        public SQLDBInitializer(DBConfiguration db_config)
        {
            configs = db_config;
        }

        public async Task<string> CreateDB()
        {            
            using (var connection = configs.Connection)
            {
                try
                {
                    await connection.OpenAsync();   // открываем подключение

                    SqlCommand command = new SqlCommand();
                    // определяем выполняемую команду
                    command.CommandText = "CREATE DATABASE " + configs.Name + ";";
                    // определяем используемое подключение
                    command.Connection = connection;
                    // выполняем команду
                    await command.ExecuteNonQueryAsync();
                    return "База данных создана";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }                
            }
        }

        public Task<string> DropDB()
        {
            throw new NotImplementedException();
        }
    }
}