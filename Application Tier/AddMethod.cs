using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Application_Tier
{
    internal class AddMethod : TableMetadata
    {
        public AddMethod(string databaseName, string tableName, DataTable columns)
            : base(databaseName, tableName, columns)
        {
            
        }

        private string GetInsertInto()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 1; i < this.Columns.Rows.Count; i++)
            {
                stringBuilder.Append($"[{Columns.Rows[i][0].ToString()}],");

            }

            stringBuilder = stringBuilder.Remove(stringBuilder.Length - 1, 1);
            return stringBuilder.ToString();

        }

        private string GetValuesForInsertInto()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 1; i < this.Columns.Rows.Count; i++)
            {
                stringBuilder.Append($"@{Columns.Rows[i][0].ToString()},");

            }
            stringBuilder = stringBuilder.Remove(stringBuilder.Length - 1, 1);
            return stringBuilder.ToString();
        }

        // start generate custom sql commands
        private string GenerateSqlCommandsForAddNewSQL()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 1; i < this.Columns.Rows.Count; i++)
            {
                if (Columns.Rows[i][2].ToString() == "NO")
                {
                    stringBuilder.Append($@"sqlCommand.Parameters.AddWithValue(""@{Columns.Rows[i][0].ToString()}"", {LowerFirstChar(Columns.Rows[i][0].ToString())});" + "\n");
                }
                else
                {
                    stringBuilder.Append($@"sqlCommand.Parameters.AddWithValue(""@{Columns.Rows[i][0].ToString()}"", {LowerFirstChar(Columns.Rows[i][0].ToString())} ??  (object)DBNull.Value);" + "\n");

                }
            }
            return stringBuilder.ToString();
        }

        // start generate custom Parameters for Add New
        private string GenerateParametersForAddNewSQL()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 1; i < this.Columns.Rows.Count; i++)
            {
                stringBuilder.Append($"{GetCSharpDataType(Columns.Rows[i][1].ToString())} {LowerFirstChar(Columns.Rows[i][0].ToString())},");

            }
            stringBuilder = stringBuilder.Remove(stringBuilder.Length - 1, 1);
            return stringBuilder.ToString();
        }

        // generate the code
        public string GetAddNewCode()
        {
            StringBuilder generatedCode = new StringBuilder();
            generatedCode.Append($@"
                      public static int AddNew{ModifyTableName()} ({GenerateParametersForAddNewSQL()})
                        {{
                             int {LowerFirstChar(ModifyTableName())}ID = -1;   
                               string query = @"" USE [{this.DatabaseName}] 
                                                   INSERT INTO [dbo].[{this.TableName}]
                                                    ({GetInsertInto()})
                                                     VALUES
                                                      ({GetValuesForInsertInto()});
                                                        select SCOPE_IDENTITY();"";
    
            try
            {{
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""MyConnectionString""].ConnectionString))
                {{
                     sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {{
                            {GenerateSqlCommandsForAddNewSQL()}

                        object result = sqlCommand.ExecuteScalar();
                        if (result != null)
                            {LowerFirstChar(ModifyTableName())}ID  = int.Parse(result.ToString());
                            
                    }}
                }}
             }}


             catch (Exception ex)
            {{
                clsErrorLog.Log(ex.Message);
                
            }}

            return {LowerFirstChar(ModifyTableName())}ID;

                      
             }}
            ");
            return generatedCode.ToString();
        }

    }
}
