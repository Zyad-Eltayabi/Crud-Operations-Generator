using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using WindowsFormsApp1.Application_Tier;

namespace WindowsFormsApp1
{
    public class GenerateCode
    {
        public string DatabaseName { get; set; }
        public string TableName { get; set; }

        public System.Data.DataTable Columns { get; set; }

        public GenerateCode(string databaseName, string tableName, DataTable columns)
        {
            DatabaseName = databaseName;
            TableName = tableName;
            Columns = columns;
        }

        public string Generate()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(new AddMethod(DatabaseName, TableName, Columns).GetAddNewCode());
            stringBuilder.Append(new DeleteMethod(DatabaseName, TableName, Columns).GetDeleteCode());
            stringBuilder.Append(new ExistMethod(DatabaseName, TableName, Columns).GetExistMethod());
            stringBuilder.Append(new UpdateMethod(DatabaseName, TableName, Columns).GetUpdateMethod());
            stringBuilder.Append(new GetByIDMethod(DatabaseName, TableName, Columns).GenerateGetByIDMethod());
            stringBuilder.Append(new GetAllMethod(DatabaseName, TableName, Columns).GenerateGetAllMethod());
            
            return stringBuilder.ToString();
        }

    }
}
