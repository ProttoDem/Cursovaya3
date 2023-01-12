using DatabaseAccess.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace DatabaseAccess.MSSQL
{
    public class SQLExecuter : IDBExecuter
    {
        private readonly DBConfiguration DBConfiguration;

        public SQLExecuter(DBConfiguration dBConfiguration)
        {
            DBConfiguration = dBConfiguration;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<string> Execute(Func<string, SqlConnection, Task<string>> command)
        {
            using (var connection = DBConfiguration.Connection)
            {
                try
                {
                    await connection.OpenAsync();   // открываем подключение
                    return await command(DBConfiguration.Name, connection);
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

        public async Task<IEnumerable<string>> ExecuteMany(Func<string, SqlConnection, Task<IEnumerable<string>>> command)
        {
            using (var connection = DBConfiguration.Connection)
            {
                try
                {
                    await connection.OpenAsync();   // открываем подключение
                    return await command(DBConfiguration.Name, connection);
                }
                catch (Exception ex)
                {
                    var res = new List<string>();
                    res.Add(ex.Message);
                    return res;
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
    }
}
