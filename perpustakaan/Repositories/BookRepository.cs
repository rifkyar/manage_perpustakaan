using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace perpustakaan.Repositories
{
    public class BookRepository
    {
        private readonly SqlConnection sqlConnection;
        private readonly DynamicParameters parameters = new DynamicParameters();
        public BookRepository(ConnectionString connection)
        {

            sqlConnection = new SqlConnection(connection.Value);

        }

        public List<dynamic> GetAllBook()
        {
            var sp = "SP_GetAllBook";
            var command = CommandType.StoredProcedure;
            var result = sqlConnection.Query(sp, parameters, commandType: command);
            return result.ToList();
        }
    }
}
