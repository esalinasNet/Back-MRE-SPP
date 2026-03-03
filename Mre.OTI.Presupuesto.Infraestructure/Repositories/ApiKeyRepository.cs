using Dapper;
//using Mre.OTI.Passport.Application.DTO.Catalogo;
using Mre.OTI.Presupuesto.Application.Repositories;
//using OfficeOpenXml.FormulaParsing.Excel.Functions.Database;
using System;
//using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
//using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class ApiKeyRepository: IApiKeyRepository
    {

        readonly DBConnection DBConnection;

        public ApiKeyRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<bool> ValidateApiKey(string apiKeyId, string apiKeyEncriptado)
        {
            const string sql = @"SC_SAP.MEOSS_LISTAR_CATALOGO_VAL";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_APIKEY", apiKeyId, DbType.String);
            parameters.Add("@APIKEY_ENCRIPTADO", apiKeyEncriptado, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<bool>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            return result.FirstOrDefault();
        }

        //public bool ValidateApiKey(string apiKey)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();
        //        var command = new SqlCommand("SELECT EncryptedApiKey FROM ApiKeys", connection);

        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                var encryptedApiKey = (byte[])reader["EncryptedApiKey"];
        //                var decryptedApiKey = Decrypt(encryptedApiKey);

        //                if (decryptedApiKey == apiKey)
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //        return true;
        //    }
        //    return false;
        //}
    }
}
