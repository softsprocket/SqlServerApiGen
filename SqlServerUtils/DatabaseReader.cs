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
    public class DatabaseReader : IEnumerable<DatabaseTable>, IDisposable
    {
        DataContext dataContext;
        IDbConnection connection;
        string sql;

        public DatabaseReader(string connectionString, string databaseName)
        {
            connection = new SqlConnection(connectionString);
            dataContext = new DataContext(connection);

            sql = $"select '{databaseName}' as DB, table_schema as Scheme, table_name as Name from {databaseName}.information_schema.tables where table_type = 'base table'";

        }

        public void Dispose()
        {
            dataContext.Dispose();
            connection.Dispose();
        }

        public IEnumerator<DatabaseTable> GetEnumerator()
        {
            return dataContext.ExecuteQuery<DatabaseTable>(sql).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dataContext.ExecuteQuery(typeof(DatabaseTable), sql).GetEnumerator();
        }
    }
}
