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
        public async Task<string> AlterTable(string tableName, IEnumerable<TableColumnAlter> tableColumns)
        {
            async Task<string> Alter(string name, SqlConnection sqlConnection)
            {
                SqlCommand command = new SqlCommand();
                string sql = "ALTER TABLE " + tableName + " ";
                foreach (var column in tableColumns)
                {
                    sql += column.Action + " " ;
                    switch (column.Action)
                    {
                        case ("ADD"):
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
                            break;

                        case ("RENAME"):
                            sql = "EXEC sp_rename '" + tableName+"."+column.Name+ "', '"+column.NewName + "'";                            
                            break;

                        case ("DROP"):
                            sql += "COLUMN " + column.Name;                            
                            break;

                        case ("ALTER"):
                            sql += "COLUMN " + column.Name + " " + column.NewDataType + " ";
                            break;
                        default:
                            sql = "";
                            break;
                    }                   
                    
                    sql += "";                

                }
                sql += ";";
                // определяем выполняемую команду
                command.CommandText = sql;
                // определяем используемое подключение
                command.Connection = sqlConnection;
                // выполняем команду
                await command.ExecuteNonQueryAsync();
                return "Таблиця " + tableName + "створена";
            }
            Func<string, SqlConnection, Task<string>> task = Alter;
            return await executer.Execute(task);
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
