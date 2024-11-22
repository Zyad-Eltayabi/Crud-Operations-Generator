using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Application_Tier
{
    internal class GetAllMethod : TableMetadata
    {
        public GetAllMethod(string databaseName, string tableName, DataTable columns)
            : base(databaseName, tableName, columns)
        {
        }

        /* ====================== Start Of Generate Get All Method ======================*/
        public string GenerateGetAllMethod()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($@"
             public static DataTable GetAll{TableName}()
        {{
            DataTable dataTable = new DataTable();

            string query = @"" SELECT *  FROM {TableName} "";

            try
            {{
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""MyConnectionString""].ConnectionString))
                {{
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {{
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {{
                            dataTable.Load(sqlDataReader);
                        }}
                    }}
                }}
            }}
            catch (Exception ex)
            {{

                    clsErrorLog.Log(ex.Message);
            }}

            return dataTable;
        }}
");
            return stringBuilder.ToString();
        }
        /* ====================== End Of Generate Get All Method ======================*/
    }
}
