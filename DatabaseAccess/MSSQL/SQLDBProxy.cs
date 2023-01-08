using DatabaseAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.MSSQL
{
    internal class SQLDBProxy : IDBProxy
    {
        private readonly DBConfiguration configs;
        private readonly IDBInitializer initializer;
        private readonly IDBReader reader;
        private readonly IDBDataChanger dataChanger;
        private readonly IDBStructureChanger structureChanger;

        public SQLDBProxy(DBConfiguration db_config, IDBInitializer dBInitializer, IDBReader dBReader, IDBStructureChanger dBStructureChanger, IDBDataChanger dBDataChanger)
        {
            configs = db_config;
            initializer = dBInitializer;
            reader = dBReader;
            structureChanger = dBStructureChanger;
            dataChanger = dBDataChanger;
        }
        public Task<string> AlterTable()
        {
            throw new NotImplementedException();
        }

        public string CheckConnection()
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateDB()
        {
            /*using (var connection = configs.Connection)
            {*/
                try
                {
                    await configs.Connection.OpenAsync();
                    return await initializer.CreateDB();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    if (configs.Connection.State == ConnectionState.Open)
                    {
                        configs.Connection.Close();
                    }

                }
            /*}*/
        }


        public Task<string> CreateTable()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<string> DropDB()
        {
            throw new NotImplementedException();
        }

        public Task<string> DropTable()
        {
            throw new NotImplementedException();
        }

        public Task GetTables()
        {
            throw new NotImplementedException();
        }
    }
}
