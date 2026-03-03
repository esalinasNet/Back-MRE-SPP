using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Services
{
    public class TokenService
    {
        readonly DBConnection DBConnection;

        public TokenService(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }
        public async Task<bool> ValidateTokenAsync(string token,string apiKey)
        {

            const string sql = @"SC_SEG.fechaExpira";

            var parameters = new DynamicParameters();
            parameters.Add("@TOKEN", token, DbType.String);
            parameters.Add("@APIKEY_ENCRIPTADO", apiKey, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerTokenResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            if (result == null)
            {
                return false;
            }
            var objToken = result.FirstOrDefault();

            if (objToken.fechExpira < DateTime.Now)
            {
                return false;
            }

            return true;



        }
    }
}
