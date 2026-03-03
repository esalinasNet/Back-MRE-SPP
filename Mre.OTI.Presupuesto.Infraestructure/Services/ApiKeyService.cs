using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Passport.Infraestructure.Services
{
    public class ApiKeyService
    {
        readonly DBConnection DBConnection;

        public ApiKeyService(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }
        public async Task<bool> ValidateApiKeyAsync(string appKey,string apiKey)
        {

            const string sql = @"SC_SEG.MEOSS_OBTENER_APIKEY";

            var parameters = new DynamicParameters();
            parameters.Add("@CODIGO_SISTEMA", appKey, DbType.String);
            parameters.Add("@APIKEY_ENCRIPTADO", apiKey, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<bool>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            return result.FirstOrDefault();

 

        }
    }
}
