using Humanizer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator_Project.Utility
{
    public static class clsUtil
    {
        public static bool RememberUsernameAndPassword(string server,string userID, string password)
        {

            string keyPath = @"HKEY_CURRENT_USER\Software\CodeGenerator";
            string Server_ValueName = "Server";
            string UserID_ValueName = "UserID";
            string Password_ValueName = "Password";


            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, Server_ValueName, server, RegistryValueKind.String);
                Registry.SetValue(keyPath, UserID_ValueName, userID, RegistryValueKind.String);
                Registry.SetValue(keyPath, Password_ValueName, password, RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                LogError(ex);                
                return false;
            }
            return true;
        }

        public static bool GetStoredCredential(ref string Server,ref string UserID ,ref string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\Software\CodeGenerator";
            string Server_ValueName = "Server";
            string UserID_ValueName = "UserID";
            string Password_ValueName = "Password";

            try
            {
                // Read the value from the Registry
                Server = Registry.GetValue(keyPath, Server_ValueName, null) as string;
                UserID = Registry.GetValue(keyPath, UserID_ValueName, null) as string;
                Password = Registry.GetValue(keyPath, Password_ValueName, null) as string;


                if (Server == null || UserID == null || Password == null)
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
            return true;

        }

        public static void LogError(Exception ex)
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error_log.txt");
            string errorMessage = $"[{DateTime.Now}] {ex.Message}\n{ex.StackTrace}\n\n";

            try
            {
                using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(errorMessage);
                }
            }
            catch (Exception logEx)
            {
                // Fallback logging in case writing fails
                Debug.WriteLine("Error logging failed: " + logEx.Message);
            }
        }

        public static string ConvertSqlTypeToCSharp(string sqlType, bool isNullable)
        {
            string type = sqlType.ToLower();

            switch (type)
            {
                // Integer types
                case "int": type = "int"; break;
                case "bigint": type = "long"; break;
                case "smallint": type = "short"; break;
                case "tinyint": type = "byte"; break;

                // Boolean
                case "bit": type = "bool"; break;

                // Decimal & floating point
                case "decimal":
                case "numeric": type = "decimal"; break;
                case "float": type = "double"; break;
                case "real": type = "float"; break;
                case "money":
                case "smallmoney": type = "decimal"; break;

                // Date and time
                case "datetime":
                case "smalldatetime":
                case "date":
                case "datetime2":
                case "time":
                case "datetimeoffset": type = "DateTime"; break;

                // Strings
                case "char":
                case "varchar":
                case "text":
                case "nchar":
                case "nvarchar":
                case "ntext":
                case "uniqueidentifier": type = "string"; break;

                // Binary and image data
                case "binary":
                case "varbinary":
                case "image": type = "byte[]"; break;

                // XML
                case "xml": type = "string"; break;

                // SQL Variant
                case "sql_variant": type = "object"; break;

                default: type = "object"; break;
            }

            // Handle nullable types (except string, object, byte[] which can be null already)
            if (isNullable && type != "string" && type != "object" && type != "byte[]")
            {
                return type + "?";  // e.g., "int?" for nullable integer
            }

            return type;
        }

        public static string GenerateConversionExpression(string sqlType, string value)
        {
            string type = sqlType.ToLower();
            string conversionExpression;

            switch (type)
            {
                case "int":
                    conversionExpression = $"Convert.ToInt32({value})";
                    break;
                case "bigint":
                case "long":
                    conversionExpression = $"Convert.ToInt64({value})";
                    break;
                case "smallint":
                case "short":
                    conversionExpression = $"Convert.ToInt16({value})";
                    break;
                case "tinyint":
                case "byte":
                    conversionExpression = $"Convert.ToByte({value})";
                    break;
                case "bit":
                    conversionExpression = $"Convert.ToBoolean({value})";
                    break;
                case "decimal":
                case "numeric":
                case "money":
                case "smallmoney":
                    conversionExpression = $"Convert.ToDecimal({value})";
                    break;
                case "float":
                    conversionExpression = $"Convert.ToDouble({value})";
                    break;
                case "real":
                    conversionExpression = $"Convert.ToSingle({value})";
                    break;
                case "datetime":
                case "smalldatetime":
                case "date":
                case "datetime2":
                case "time":
                    conversionExpression = $"Convert.ToDateTime({value})";
                    break;
                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext":
                case "string":
                    conversionExpression = $"{value}.ToString()";
                    break;
                case "uniqueidentifier":
                    conversionExpression = $"Guid.Parse({value}.ToString())";
                    break;
                case "binary":
                case "varbinary":
                case "image":
                    conversionExpression = $"({value} as byte[]) ?? new byte[0]";
                    break;
                default:
                    conversionExpression = $"{value}"; // No conversion, treat as an object
                    break;
            }

            return conversionExpression;
        }


        public static string GetDefaultValue(string sqlType, bool isNullable)
        {
            string type = sqlType.ToLower();

            if (isNullable)
                return "null";

            switch (type)
            {
                case "int":
                case "bigint":
                case "smallint":
                case "tinyint":
                    return "-1";
                case "bit":
                    return "false";
                case "decimal":
                case "numeric":
                case "float":
                case "real":
                    return "0";
                case "datetime":
                case "smalldatetime":
                case "date":
                case "datetime2":
                case "time":
                    return "DateTime.Now";
                case "char":
                case "varchar":
                case "text":
                case "nvarchar":
                case "ntext":
                case "uniqueidentifier":
                    return "\"\"";
                default:
                    return "null";
            }
        }

        public static async Task SaveToFile(string content, string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    await writer.WriteAsync(content); // ✅ نكتب المحتوى بطريقة async
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        public static string ToSingular(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                return tableName;

            return tableName.Singularize(false); // false = don't treat the word as a known proper noun
        }

        public static string FormatParam((string ColumnName, string DataType, int? Size, bool IsNullablee) col)
        {
         
            if (col.DataType == "varchar" || col.DataType == "nvarchar" || col.DataType == "char")
            {
                return $"@{col.ColumnName} {col.DataType}({col.Size})";
            }
            return $"@{col.ColumnName} {col.DataType}";
        }
    }
}
