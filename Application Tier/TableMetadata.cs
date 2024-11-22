using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Application_Tier
{
    public class TableMetadata
    {
        public string DatabaseName { get; set; }
        public string TableName { get; set; }

        public DataTable Columns { get; set; }

        public TableMetadata(string databaseName, string tableName, DataTable columns)
        {
            DatabaseName = databaseName;
            TableName = tableName;
            Columns = columns;
        }

        protected string ModifyTableName()
        {
            int len = this.TableName.Length;

            if (TableName[len - 1] != 's')
                return TableName;

            return TableName.Substring(0, len - 1);
        }

        protected string LowerFirstChar(string para)
        {
            StringBuilder stringBuilder = new StringBuilder(para);
            stringBuilder[0] = char.ToLower(stringBuilder[0]);
            return stringBuilder.ToString();
        }

        protected string GetCSharpDataType(string sqlServerDataType)
        {
            switch (sqlServerDataType.ToLower()) // Use ToLower to handle case insensitivity
            {
                case "bit":
                    return "bool";
                case "tinyint":
                    return "byte";
                case "smallint":
                    return "short";
                case "int":
                    return "int";
                case "bigint":
                    return "long";
                case "decimal":
                case "numeric":
                case "money":
                case "smallmoney":
                    return "decimal";
                case "float":
                    return "double";
                case "real":
                    return "float";
                case "char":
                case "varchar":
                case "nchar":
                case "nvarchar":
                case "text":
                case "ntext":
                    return "string";
                case "binary":
                case "varbinary":
                case "image":
                    return "byte[]";
                case "datetime":
                case "smalldatetime":
                case "date":
                    return "DateTime";
                case "time":
                    return "TimeSpan";
                case "timestamp":
                    return "byte[]";
                case "uniqueidentifier":
                    return "Guid";
                case "xml":
                    return "string";
                default:
                    return "Unknown SQL Type"; // Handle unrecognized SQL types
            }
        }

        protected string GenerateParameters()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (System.Data.DataRow row in this.Columns.Rows)
            {
                stringBuilder.Append($"{GetCSharpDataType(row[1].ToString())} {LowerFirstChar(row[0].ToString())},");
            }
            stringBuilder = stringBuilder.Remove(stringBuilder.Length - 1, 1);
            return stringBuilder.ToString();
        }

        protected string GenerateSqlCommands()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (System.Data.DataRow row in this.Columns.Rows)
            {
                if (row[2].ToString() == "NO")
                {
                    stringBuilder.Append($@"sqlCommand.Parameters.AddWithValue(""@{row[0].ToString()}"", {LowerFirstChar(row[0].ToString())});" + "\n");
                }
                else
                {
                    stringBuilder.Append($@"sqlCommand.Parameters.AddWithValue(""@{row[0].ToString()}"", {LowerFirstChar(row[0].ToString())} ??  (object)DBNull.Value);" + "\n");

                }
            }
            return stringBuilder.ToString();
        }

    }
}
