using Dapper;
using Microsoft.Data.SqlClient;
using perpustakaan.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace perpustakaan.Repositories
{
    public class RakRepository
    {
        private readonly SqlConnection sqlConnection;
        private readonly DynamicParameters parameters = new DynamicParameters();
        public RakRepository(ConnectionString connection)
        {

            sqlConnection = new SqlConnection(connection.Value);

        }

        public List<dynamic> GetAllRak()
        {
            var sp = "SP_GetAllRak";
            var command = CommandType.StoredProcedure;
            var result = sqlConnection.Query(sp, parameters, commandType: command);
            return result.ToList();
        }
        public List<dynamic> GetRakPakai()
        {
            var sp = "SP_GetRakwithCount";
            var command = CommandType.StoredProcedure;
            var result = sqlConnection.Query(sp, parameters, commandType: command);
            return result.ToList();
        }
        public async Task<int> SaveRak(SaveRak Rak)
        {
            var sp = "SP_SaveRak";
            DynamicParameters parameters = new DynamicParameters();
            parameters.AddDynamicParams(Rak);
            var command = CommandType.StoredProcedure;
            var result = await sqlConnection.ExecuteAsync(sp, parameters, commandType: command);
            return result;
        }
    }
}
