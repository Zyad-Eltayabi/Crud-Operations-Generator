using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Application_Tier
{
    internal class UpdateMethod : TableMetadata
    {
        public UpdateMethod(string databaseName, string tableName, DataTable columns)
            : base(databaseName, tableName, columns)
        {
        }

        /* ====================== Start Of Generate Update Method ======================*/
        private string GetSetUpdateMethod()
        {
            StringBuilder stringBuilder = new StringBuilder("SET ");
 

            for (int i = 1; i < this.Columns.Rows.Count; i++)
            {
                stringBuilder.Append($@" [{Columns.Rows[i][0].ToString()}] = @{Columns.Rows[i][0].ToString()}," + "\n");
            }

            stringBuilder = stringBuilder.Remove(stringBuilder.Length - 2, 2);
            return stringBuilder.ToString();
        }

        public string GetUpdateMethod()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($@"
         public static bool Update{ModifyTableName()}({GenerateParameters()})
        {{
            int rowsAffected = 0;
            string query = @""USE [{DatabaseName}]
                                        UPDATE [dbo].[{TableName}]
                                              {GetSetUpdateMethod()}
                                         WHERE {ModifyTableName()}ID = @{ModifyTableName()}ID"";

            try
            {{
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""MyConnectionString""].ConnectionString))
                {{
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {{
                       {GenerateSqlCommands()}

                        rowsAffected = int.Parse(sqlCommand.ExecuteNonQuery().ToString());
                    }}
                }}
            }}
            catch (Exception ex)
            {{

                clsErrorLog.Log(ex.Message);
            }}
            return rowsAffected > 0;}}");
            return stringBuilder.ToString();
        }
        /* ====================== End Of Generate Update Method ======================*/
    }
}
