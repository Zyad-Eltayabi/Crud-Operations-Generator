using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Database_Tier
{
    public static class DatabaseMethods
    {
        static public string ConnectionString = "Server=.;User Id=sa;Password=sa123456";

        public static DataTable GetDatabaseNames()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT name FROM sys.databases;";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            dt.Load(sqlDataReader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return dt;
        }

        public static DataTable GetTableNames(string databaseName)
        {
            DataTable dt = new DataTable();
            string query = $@"USE {databaseName}; SELECT name FROM sys.tables;";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            dt.Load(sqlDataReader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

           return dt;
        }

        public static DataTable GetTable(string databaseName,string tableName)
        {
            DataTable dt = new DataTable();
            string query = $@"USE {databaseName};   SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE
                                                        FROM INFORMATION_SCHEMA.COLUMNS
                                                        WHERE TABLE_NAME = '{tableName}';";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            dt.Load(sqlDataReader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return dt;
        }
    }
}
