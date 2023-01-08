using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Interfaces;

namespace DatabaseAccess.MSSQL
{
    internal class SQLDBReader : IDBReader
    {
        private readonly DBConfiguration configs;

        public SQLDBReader(DBConfiguration db_config)
        {
            configs = db_config;
        }

        public Task GetTables()
        {
            throw new NotImplementedException();
        }

        /*public async Task GetTables()
        {
            using (var connection = configs.Connection)
            {
                try
                {
                    await connection.OpenAsync();   // открываем подключение
                    connection.GetSchema
                    SqlCommand command = new SqlCommand();                    
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
        }*/
    }
}

