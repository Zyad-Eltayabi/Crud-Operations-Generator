using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Application_Tier
{
    internal class GetByIDMethod : TableMetadata
    {
        public GetByIDMethod(string databaseName, string tableName, DataTable columns)
            : base(databaseName, tableName, columns)
        {
        }

        /* ====================== Start Of GetByID Method ======================*/

        private string GenerateGetByIDParameters()
        {
            StringBuilder stringBuilder = new StringBuilder();

            // first write the ID with out ref
            stringBuilder.Append($"{GetCSharpDataType(Columns.Rows[0][1].ToString())} {LowerFirstChar(Columns.Rows[0][0].ToString())},");

            for (int i = 1; i < this.Columns.Rows.Count; i++)
            {
                stringBuilder.Append($"ref {GetCSharpDataType(Columns.Rows[i][1].ToString())} {LowerFirstChar(Columns.Rows[i][0].ToString())},");
            }

            stringBuilder = stringBuilder.Remove(stringBuilder.Length - 1, 1);
            return stringBuilder.ToString();
        }

        private string GenerateConverterFromObjectToDataType()
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"isFound = true;" + "\n");

            for (int i = 1; i < this.Columns.Rows.Count; i++)
            {
                stringBuilder.Append($"{LowerFirstChar(Columns.Rows[i][0].ToString())} = ");
                stringBuilder.Append($"({GetCSharpDataType(Columns.Rows[i][1].ToString())})");
                stringBuilder.Append($"sqlDataReader[\"{Columns.Rows[i][0].ToString()}\"]; \n");
            }
            return stringBuilder.ToString();
        }

        public string GenerateGetByIDMethod()
        {
            string text = $@"
                public static bool Get{ModifyTableName()}ByID({GenerateGetByIDParameters()})
                 {{
                bool isFound = false;
                string query = ""SELECT TOP 1 * FROM {TableName} WHERE {ModifyTableName()}ID = @{ModifyTableName()}ID"";

                try
                {{
                    using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""MyConnectionString""].ConnectionString))
                    {{
                        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                        {{
                            sqlConnection.Open();
                            sqlCommand.Parameters.AddWithValue(""{ModifyTableName()}ID"", {LowerFirstChar(ModifyTableName())}ID);

                            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                            {{
                                if (sqlDataReader.Read())
                                {{
                                    {GenerateConverterFromObjectToDataType()}
                                }}
                            }}
                        }}
                    }}
                }}
                catch (Exception ex)
                {{

                    clsErrorLog.Log(ex.Message);
                }}

                return isFound;
                }}";

            return text;
        }

        /* ====================== End Of GetByID Method ======================*/
    }
}
