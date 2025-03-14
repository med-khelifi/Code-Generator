using CodeGenerator_Project.Utility;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenerator_Project.Connection
{
    public static class clsConnection
    {
        
        private static string ConnectionString { get; set; } = string.Empty;
        private static string LoginConnectionString { get; set; } = string.Empty;

        private static string ServerName, UserID, Password,DataBaseName;
        public static async Task<bool> Connect(string server, string user, string password)
        {
            string connectionString = $"Server={server};User Id={user};Password={password};";
            bool connect = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    connect = true;
                    LoginConnectionString = connectionString;
                    ServerName = server;
                    UserID = user;
                    Password = password;
                }
            }
            catch (Exception ex)
            {
                clsUtil.LogError(ex);
                connect = false;
            }
            return connect;
        }
        public static async Task<List<string>> LoadDatabasesList()
        {
            List<string> list = new List<string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(LoginConnectionString))
                {
                    await conn.OpenAsync(); // Ensure the connection is open

                    using (SqlCommand cmd = new SqlCommand("SELECT name FROM sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb');\r\n", conn))
                    {
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync()) // Ensure async reading
                            {
                                list.Add(reader[0].ToString()); // Correctly fetch database name
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.LogError(ex);
            }

            return list;
        }
        public static async Task<List<string>> GetTablesNameList(string databaseName)
        {
            List<string> tables = new List<string>();
            ConnectionString = $"Server={ServerName};Database={databaseName};User Id={UserID};Password={Password};";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    await conn.OpenAsync();
                    string query = $"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';"; 
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@db",databaseName);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                tables.Add(reader["TABLE_NAME"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.LogError(ex);
            }

            return tables;
        }
        public static async Task<List<(string ColumnName, string DataType, bool IsNullable)>> GetTableColumns(string tableName)
        {
            List<(string ColumnName, string DataType, bool IsNullable)> columns = new List<(string, string, bool)>();

            try
            {
                //string connectionStringWithDb = $"{LoginConnectionString};Initial Catalog={db};";

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName; ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TableName", tableName); 
                        //cmd.Parameters.AddWithValue("@db", db);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string columnName = reader["COLUMN_NAME"].ToString();
                                string dataType = reader["DATA_TYPE"].ToString();
                                bool isNullable = reader["IS_NULLABLE"].ToString() == "YES";

                                columns.Add((columnName, dataType, isNullable));
                            }
                        }
                    }
                }

                
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"❌ Error in GetTableColumns({tableName}): {ex.Message}");
                clsUtil.LogError(ex);
            }

            return columns;
        }
    }
}
