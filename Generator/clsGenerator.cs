using CodeGenerator_Project.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeGenerator_Project
{
    public static class clsGenerator
    {
        public static string clsDataAccessUtil()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Diagnostics;");
            sb.AppendLine("using System.Configuration;");
            sb.AppendLine();

            sb.AppendLine("     /*");

            sb.AppendLine("     ***  YOU HAVE TO ADD ADD A FRERANCE TO DATA ACCESS LAYER TO USE - Configuration Manager -  ***");
            sb.AppendLine("                    Go To Reeferences and Add \"System.Configuration\"");
            sb.AppendLine("     */");

            sb.AppendLine("namespace DataLayer");
            sb.AppendLine("{");
            sb.AppendLine("    public static class clsDataAccessUtil");
            sb.AppendLine("    {");
            sb.AppendLine("        // Put here your connection string name");
            sb.AppendLine("        private static string ConnectionStringName = string.Empty;");
            sb.AppendLine("        // Method to log error messages to the Windows Event Log");
            sb.AppendLine("        public static void LogError(Exception ex)");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                // Check if the Event Log source exists, if not, create it");
            sb.AppendLine("                if (!EventLog.SourceExists(\"MyApp\"))");
            sb.AppendLine("                {");
            sb.AppendLine("                    EventLog.CreateEventSource(\"MyApp\", \"Application\");");
            sb.AppendLine("                }");
            sb.AppendLine();
            sb.AppendLine("                // Write the error message to the Windows Event Log");
            sb.AppendLine("                EventLog.WriteEntry(\"MyApp\", $\"Error: {ex.Message}\\nStackTrace: {ex.StackTrace}\", EventLogEntryType.Error);");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception logEx)");
            sb.AppendLine("            {");
            sb.AppendLine("                // If logging fails, write the error to the console (as a fallback)");
            sb.AppendLine("                Console.WriteLine(\"Logging failed: \" + logEx.Message);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("         // Get Connection String From App.config File");
            sb.AppendLine("         public static string GetConnectionString()");
            sb.AppendLine("         {");
            sb.AppendLine("             return ConfigurationManager.ConnectionStrings[ConnectionStringName]?.ConnectionString ?? string.Empty;");
            sb.AppendLine("         }");


            sb.AppendLine("    }");
            sb.AppendLine("}");


            return sb.ToString();
        }

        public static string GenerateDataLayer(string tableName, List<(string ColumnName, string DataType, bool IsNullable)> columns)
        {
            StringBuilder sb = new StringBuilder();
            string className = $"cls{tableName}Data";

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Configuration;");
            sb.AppendLine("using System.Data.SqlClient;");
            sb.AppendLine("namespace DataLayer");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("     /*");

            sb.AppendLine("     ***  YOU HAVE TO ADD YOUR CONNECTION STRING IN - App.config - FILE  ***");
            sb.AppendLine("       < connectionStrings>");
            sb.AppendLine("              < add name=\"MyDatabaseConnection\" ");
            sb.AppendLine("             connectionString=\"Connection String Here\" ");
            sb.AppendLine("             providerName=\"System.Data.SqlClient\" /> ");
            sb.AppendLine("     </connectionStrings>");
            sb.AppendLine("     */");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("{");
            sb.AppendLine($"    public static class {className}");
            sb.AppendLine("    {");

            // GetByID Method
            sb.AppendLine($"        public static bool GetByID({clsUtil.ConvertSqlTypeToCSharp(columns[0].DataType, columns[0].IsNullable)} {columns[0].ColumnName}, {string.Join(", ", columns.Skip(1).Select(c => $"ref {clsUtil.ConvertSqlTypeToCSharp(c.DataType, c.IsNullable)} {c.ColumnName}"))})");
            sb.AppendLine("        {");
            sb.AppendLine("            bool isFound = false;");
            sb.AppendLine("            using (SqlConnection connection = new SqlConnection(clsDataAccessUtil.GetConnectionString()))");
            sb.AppendLine("            {");
            sb.AppendLine($"                string query = \"SELECT * FROM {tableName} WHERE {columns[0].ColumnName} = @ID;\";");
            sb.AppendLine("                using (SqlCommand command = new SqlCommand(query, connection))"); // Fixed missing brace
            sb.AppendLine("                {");
            sb.AppendLine($"                    command.Parameters.AddWithValue(\"@ID\", {columns[0].ColumnName});");
            sb.AppendLine("                    try");
            sb.AppendLine("                    {");
            sb.AppendLine("                        connection.Open();");
            sb.AppendLine("                        using (SqlDataReader reader = command.ExecuteReader())"); // Fixed missing brace
            sb.AppendLine("                        {");
            sb.AppendLine("                            if (reader.Read())");
            sb.AppendLine("                            {");
            sb.AppendLine("                                isFound = true;");
            foreach (var column in columns.Skip(1)) // Skip the first column because it's used for filtering
            {
                sb.AppendLine($"                                {column.ColumnName} = {clsUtil.GenerateConversionExpression(clsUtil.ConvertSqlTypeToCSharp(column.DataType, column.IsNullable), $"reader[\"{column.ColumnName}\"]")};");
            }
            sb.AppendLine("                            }");
            sb.AppendLine("                            reader.Close();");
            sb.AppendLine("                        }"); // Closed SqlDataReader using
            sb.AppendLine("                    }");
            sb.AppendLine("                    catch (Exception ex)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        clsDataAccessUtil.LogError(ex);");
            sb.AppendLine("                        isFound = false;");
            sb.AppendLine("                    }");
            sb.AppendLine("                }"); // Closed SqlCommand using
            sb.AppendLine("            }"); // Closed SqlConnection using
            sb.AppendLine("            return isFound;");
            sb.AppendLine("        }");


            // Delete Method
            sb.AppendLine($"        public static bool Delete({clsUtil.ConvertSqlTypeToCSharp(columns[0].DataType, columns[0].IsNullable)} {columns[0].ColumnName})");
            sb.AppendLine("        {");
            sb.AppendLine("            int result = 0;");
            sb.AppendLine("            using (SqlConnection connection = new SqlConnection(clsDataAccessUtil.GetConnectionString()))");
            sb.AppendLine("            {");
            sb.AppendLine($"                string query = \"DELETE FROM {tableName} WHERE {columns[0].ColumnName} = @ID;\";");
            sb.AppendLine("                using (SqlCommand command = new SqlCommand(query, connection))"); // Fixed missing brace
            sb.AppendLine("                {");
            sb.AppendLine($"                    command.Parameters.AddWithValue(\"@ID\", {columns[0].ColumnName});");
            sb.AppendLine("                    try");
            sb.AppendLine("                    {");
            sb.AppendLine("                        connection.Open();");
            sb.AppendLine("                        result = command.ExecuteNonQuery();");
            sb.AppendLine("                    }");
            sb.AppendLine("                    catch (Exception ex)"); // Moved catch inside using
            sb.AppendLine("                    {");
            sb.AppendLine("                        clsDataAccessUtil.LogError(ex);");
            sb.AppendLine("                    }");
            sb.AppendLine("                }"); // Closed SqlCommand using
            sb.AppendLine("            }"); // Closed SqlConnection using
            sb.AppendLine("            return result > 0;");
            sb.AppendLine("        }");


            // GetAll Method
            sb.AppendLine($"        public static DataTable GetAll()");
            sb.AppendLine("        {");
            sb.AppendLine("            DataTable allRecords = new DataTable();");
            sb.AppendLine("            using (SqlConnection connection = new SqlConnection(clsDataAccessUtil.GetConnectionString()))");
            sb.AppendLine("            {");
            sb.AppendLine($"                string query = \"SELECT * FROM {tableName};\";");
            sb.AppendLine("                SqlCommand command = new SqlCommand(query, connection);");
            sb.AppendLine("                try");
            sb.AppendLine("                {");
            sb.AppendLine("                    connection.Open();");
            sb.AppendLine("                    SqlDataReader reader = command.ExecuteReader();");
            sb.AppendLine("                    allRecords.Load(reader);");
            sb.AppendLine("                    reader.Close();");
            sb.AppendLine("                }");
            sb.AppendLine("                catch (Exception ex)");
            sb.AppendLine("                {");
            sb.AppendLine("                    clsDataAccessUtil.LogError(ex);");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            return allRecords;");
            sb.AppendLine("        }");

            // AddNew Method
            sb.AppendLine($"        public static {clsUtil.ConvertSqlTypeToCSharp(columns[0].DataType, columns[0].IsNullable)} AddNew({string.Join(", ", columns.Skip(1).Select(c => $"{clsUtil.ConvertSqlTypeToCSharp(c.DataType, c.IsNullable)} {c.ColumnName}"))})");
            sb.AppendLine("        {");
            sb.AppendLine($"            {clsUtil.ConvertSqlTypeToCSharp(columns[0].DataType, columns[0].IsNullable)} result = 0;");
            sb.AppendLine("            using (SqlConnection connection = new SqlConnection(clsDataAccessUtil.GetConnectionString()))");
            sb.AppendLine("            {");
            sb.AppendLine($"                string query = \"INSERT INTO {tableName} ({string.Join(", ", columns.Skip(1).Select(c => c.ColumnName))}) VALUES ({string.Join(", ", columns.Skip(1).Select(c => "@" + c.ColumnName))});Select SCOPE_IDENTITY();\";");
            sb.AppendLine("                SqlCommand command = new SqlCommand(query, connection);");
            foreach (var column in columns.Skip(1))
            {
                sb.AppendLine($"                command.Parameters.AddWithValue(\"@{column.ColumnName}\", {column.ColumnName});");
            }
            sb.AppendLine("                try");
            sb.AppendLine("                {");
            sb.AppendLine("                    connection.Open();");
            sb.AppendLine($"                    result = {clsUtil.GenerateConversionExpression(clsUtil.ConvertSqlTypeToCSharp(columns[0].DataType, columns[0].IsNullable), "command.ExecuteScalar()")};");
            sb.AppendLine("                }");
            sb.AppendLine("                catch (Exception ex)");
            sb.AppendLine("                {");
            sb.AppendLine("                    clsDataAccessUtil.LogError(ex);");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            return result;");
            sb.AppendLine("        }");

            // Update Method
            sb.AppendLine($"        public static bool Update({string.Join(", ", columns.Select(c => $"{clsUtil.ConvertSqlTypeToCSharp(c.DataType, c.IsNullable)} {c.ColumnName}"))})");
            sb.AppendLine("        {");
            sb.AppendLine("            int result = 0;");
            sb.AppendLine("            using (SqlConnection connection = new SqlConnection(clsDataAccessUtil.GetConnectionString()))");
            sb.AppendLine("            {");
            sb.AppendLine($"                string query = \"UPDATE {tableName} SET {string.Join(", ", columns.Skip(1).Select(c => c.ColumnName + " = @" + c.ColumnName))} WHERE {columns[0].ColumnName} = @{columns[0].ColumnName};\";");
            sb.AppendLine("                SqlCommand command = new SqlCommand(query, connection);");
            foreach (var column in columns)
            {
                sb.AppendLine($"                command.Parameters.AddWithValue(\"@{column.ColumnName}\", {column.ColumnName});");
            }
            sb.AppendLine("                try");
            sb.AppendLine("                {");
            sb.AppendLine("                    connection.Open();");
            sb.AppendLine("                    result = command.ExecuteNonQuery();");
            sb.AppendLine("                }");
            sb.AppendLine("                catch (Exception ex)");
            sb.AppendLine("                {");
            sb.AppendLine("                    clsDataAccessUtil.LogError(ex);");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            return result > 0;");
            sb.AppendLine("        }");

            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        public static string GenerateBusinessLayer(string tableName, List<(string ColumnName, string DataType, bool IsNullable)> columns)
        {
            StringBuilder sb = new StringBuilder();
            string className = $"cls{tableName}";

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("namespace BusinessLayer");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {className}");
            sb.AppendLine("    {");
            sb.AppendLine("        public enum enMode { AddNew = 0, Update = 1 };");
            sb.AppendLine("        public enMode Mode = enMode.AddNew;");
            sb.AppendLine();

            foreach (var column in columns)
            {
                sb.AppendLine($"        public {clsUtil.ConvertSqlTypeToCSharp(column.DataType, column.IsNullable)} {column.ColumnName} {{ get; set; }}");
            }

            sb.AppendLine();

            #region Default Constructor
            sb.AppendLine($"        public {className}()");
            sb.AppendLine("        {");
            sb.AppendLine("            Mode = enMode.AddNew;");
            foreach (var column in columns)
            {
                sb.AppendLine($"            {column.ColumnName} = {clsUtil.GetDefaultValue(column.DataType, column.IsNullable)};");
            }
            sb.AppendLine("        }");
            #endregion

            #region Private constructor to initialize the object with found data
            sb.AppendLine($"        private {className}({string.Join(", ", columns.Select(c => $"{clsUtil.ConvertSqlTypeToCSharp(c.DataType, c.IsNullable)} {c.ColumnName}"))})");
            sb.AppendLine("        {");
            foreach (var column in columns)
            {
                sb.AppendLine($"            this.{column.ColumnName} = {column.ColumnName};");
            }

            sb.AppendLine("                 Mode = enMode.Update;");
            sb.AppendLine("        }");
            #endregion

            #region Save Method 
            sb.AppendLine("        public bool Save()");
            sb.AppendLine("        {");
            sb.AppendLine("            bool success = false;");
            sb.AppendLine("            if (Mode == enMode.AddNew)");
            sb.AppendLine("            {");
            sb.AppendLine($"                success = _addnew();");
            sb.AppendLine("                if (success)");  // If AddNew is successful, change Mode to Update
            sb.AppendLine("                {");
            sb.AppendLine("                    Mode = enMode.Update;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            else if (Mode == enMode.Update)");
            sb.AppendLine("            {");
            sb.AppendLine($"                success = _update();");
            sb.AppendLine("            }");
            sb.AppendLine("            return success;");
            sb.AppendLine("        }");
            #endregion

            #region _addnew method
            sb.AppendLine("        private bool _addnew()");
            sb.AppendLine("        {");
            sb.AppendLine($"            this.{columns[0].ColumnName} = cls{tableName}Data.AddNew(this.{string.Join(", this.", columns.Skip(1).Select(c => c.ColumnName))});");
            sb.AppendLine($"             return this.{columns[0].ColumnName} != 0;");
            sb.AppendLine("        }");
            #endregion

            #region _update method
            sb.AppendLine("        private bool _update()");
            sb.AppendLine("        {");
            sb.AppendLine("            return cls" + tableName + "Data.Update(" + string.Join(", ", columns.Select(c => c.ColumnName)) + ");");
            sb.AppendLine("        }");
            #endregion

            #region Delete method
            sb.AppendLine("        public bool Delete()");
            sb.AppendLine("        {");
            sb.AppendLine($"            return cls{tableName}Data.Delete(this.{columns[0].ColumnName});");
            sb.AppendLine("        }");
            #endregion

            #region GetAll Method
            sb.AppendLine($"        public static DataTable GetAll{tableName}Table()");
            sb.AppendLine("        {");
            sb.AppendLine($"            return cls{tableName}Data.GetAll();");
            sb.AppendLine("        }");
            #endregion

            #region Find Method
            sb.AppendLine($"        public static {className} Find({clsUtil.ConvertSqlTypeToCSharp(columns[0].DataType, columns[0].IsNullable)} {columns[0].ColumnName})");
            sb.AppendLine("        {");
            foreach (var column in columns.Skip(1))
            {
                sb.AppendLine($"            {clsUtil.ConvertSqlTypeToCSharp(column.DataType, column.IsNullable)} {column.ColumnName} = {clsUtil.GetDefaultValue(column.DataType, column.IsNullable)};");
            }
            sb.AppendLine($"            if (cls{tableName}Data.GetByID({columns[0].ColumnName}, {string.Join(", ", columns.Skip(1).Select(c => "ref " + c.ColumnName))}))");
            sb.AppendLine("            {");
            sb.AppendLine($"                return new {className}({string.Join(", ", columns.Select(c => c.ColumnName))});");  // Call the private constructor
            sb.AppendLine("            }");
            sb.AppendLine("            return null;");
            sb.AppendLine("        }");

            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();
            #endregion
        }
    }
}

