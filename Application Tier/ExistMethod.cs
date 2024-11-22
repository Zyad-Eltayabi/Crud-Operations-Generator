using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Application_Tier
{
    internal class ExistMethod : TableMetadata
    {
        public ExistMethod(string databaseName, string tableName, DataTable columns)
            : base(databaseName, tableName, columns)
        {
        }

        /* ====================== Start Of Generate Does Exist Method ======================*/
        public string GetExistMethod()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($@"
        public static bool Does{ModifyTableName()}Exist(int {LowerFirstChar(ModifyTableName())}ID)
        {{
            bool isFound = false;
            string query = @""SELECT {ModifyTableName()}ID FROM {TableName} WHERE {ModifyTableName()}ID = @{ModifyTableName()}ID"";
            try
            {{
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""MyConnectionString""].ConnectionString))
                {{
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {{
                        sqlCommand.Parameters.AddWithValue(""{ModifyTableName()}ID"", {LowerFirstChar(ModifyTableName())}ID);

                        object result = sqlCommand.ExecuteScalar();

                        isFound = (result != null);
                    }}
                }}
            }}
            catch (Exception ex)
            {{
                        clsErrorLog.Log(ex.Message);
                                        
            }}
            return isFound;
        }}");
            return stringBuilder.ToString();
        }
        /* ====================== End Of Generate Does Exist Method ======================*/
    }
}
