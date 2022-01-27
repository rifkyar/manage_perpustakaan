using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace perpustakaan.Repositories
{
    public class JenisRepository
    {
        private readonly SqlConnection sqlConnection;
        private readonly DynamicParameters parameters = new DynamicParameters();
        public JenisRepository(ConnectionString connection)
        {

            sqlConnection = new SqlConnection(connection.Value);

        }
        public List<dynamic> GetAllJenis()
        {
            var sp = "SP_GetJenis";
            var command = CommandType.StoredProcedure;
            var result = sqlConnection.Query(sp, parameters, commandType: command);
            return result.ToList();
        }
    }
}
