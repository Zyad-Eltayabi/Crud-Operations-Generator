using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Application_Tier
{
    public class DeleteMethod : TableMetadata
    {
        public DeleteMethod(string databaseName, string tableName, DataTable columns) 
            : base(databaseName, tableName, columns)
        {
        }

        /* ====================== Start Of Generate Delete Method ======================*/
        public string GetDeleteCode()
        {
            StringBuilder generatedCode = new StringBuilder();
            generatedCode.Append($"public static bool Delete{ModifyTableName()}(int {LowerFirstChar(ModifyTableName())}ID)");
            generatedCode.Append($@"{{
                        string query = @""delete from {TableName} where {ModifyTableName()}ID = @{ModifyTableName()}ID"";
                        int rowsAffected = 0;");
            generatedCode.Append($@"
                            try
                            {{
                                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""MyConnectionString""].ConnectionString))
                                {{
                                    sqlConnection.Open();
                                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                                    {{
                                        sqlCommand.Parameters.AddWithValue(""@{ModifyTableName()}ID"", {LowerFirstChar(ModifyTableName())}ID);
                                        rowsAffected = (int)sqlCommand.ExecuteNonQuery();
                                    }}
                                }}
                            }}");

            generatedCode.Append($@"
                                catch (Exception ex)
                                {{
                                    clsErrorLog.Log(ex.Message);
                                }}
                                return rowsAffected > 0; }}");

            return generatedCode.ToString();
        }
        /* ====================== End Of Generate Delete Method ======================*/
    }
}
