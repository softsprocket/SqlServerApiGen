using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerUtils
{
    public class TableReader : IEnumerable<TableColumn>, IDisposable
    {
        DataContext dataContext;
        IDbConnection connection;
        string sql;

        public TableReader(DatabaseTable table, string connectionString)
        {
            connection = new SqlConnection(connectionString);
            dataContext = new DataContext(connection);

            sql = $"select data_type as Type, column_name as Name, is_nullable as IsNullable, character_maximum_length as MaxLength from {table.DB}.information_schema.columns "
                + $"where table_schema = '{table.Scheme}' and table_name = '{table.Name}'";
        }

        public void Dispose()
        {
            dataContext.Dispose();
            connection.Dispose();
        }

        public IEnumerator<TableColumn> GetEnumerator()
        {
            return dataContext.ExecuteQuery<TableColumn>(sql).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dataContext.ExecuteQuery(typeof(TableColumn), sql).GetEnumerator(); 
        }
    }
}
