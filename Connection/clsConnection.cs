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

        private static string ServerName, UserID, Password;
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
                    string query = $"SELECT TABLE_NAME \r\nFROM INFORMATION_SCHEMA.TABLES \r\nWHERE TABLE_TYPE = 'BASE TABLE'\r\n  AND TABLE_NAME != 'sysdiagrams';\r\n"; 
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
        public static async Task<List<(string ColumnName, string DataType, int? Size, bool IsNullable)>> GetTableColumnsForSP(string tableName)
        {
            var columns = new List<(string ColumnName, string DataType, int? Size, bool IsNullable)>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    await conn.OpenAsync();

                    string query = @"
                SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE 
                FROM INFORMATION_SCHEMA.COLUMNS 
                WHERE TABLE_NAME = @TableName;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TableName", tableName);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string columnName = reader["COLUMN_NAME"].ToString();
                                string dataType = reader["DATA_TYPE"].ToString();
                                bool isNullable = reader["IS_NULLABLE"].ToString() == "YES";

                                object sizeObj = reader["CHARACTER_MAXIMUM_LENGTH"];
                                int? size = sizeObj != DBNull.Value ? Convert.ToInt32(sizeObj) : (int?)null;

                                columns.Add((columnName, dataType, size, isNullable));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.LogError(ex);
            }

            return columns;
        }
        public static async Task<List<(string ColumnName, string DataType, bool IsNullable)>> GetTableColumns(string tableName)
        {
            var columns = new List<(string ColumnName, string DataType, bool IsNullable)>();

            using (var connection = new SqlConnection("YourConnectionStringHere"))
            {
                await connection.OpenAsync();

                string query = @"
                                    SELECT 
                                        COLUMN_NAME,
                                        DATA_TYPE,
                                        CHARACTER_MAXIMUM_LENGTH,
                                        IS_NULLABLE
                                    FROM INFORMATION_SCHEMA.COLUMNS
                                    WHERE TABLE_NAME = @TableName;";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TableName", tableName);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string columnName = reader.GetString(0);
                            string dataType = reader.GetString(1);
                            object charLengthObj = reader.GetValue(2);
                            string isNullableStr = reader.GetString(3);

                            // Append length if it's a variable-length type
                            if (charLengthObj != DBNull.Value)
                            {
                                int length = Convert.ToInt32(charLengthObj);
                                if (length > 0 || length == -1)
                                {
                                    string size = length == -1 ? "max" : length.ToString();
                                    if (dataType == "varchar" || dataType == "nvarchar" || dataType == "char" || dataType == "nchar")
                                    {
                                        dataType += $"({size})";
                                    }
                                }
                            }

                            bool isNullable = isNullableStr.Equals("YES", StringComparison.OrdinalIgnoreCase);

                            columns.Add((columnName, dataType, isNullable));
                        }
                    }
                }
            }

            return columns;
        }

    }

}
