using Dapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class LogSessionRepository : ILogSessionRepository
    {
        readonly DBConnection DBConnection;

        public LogSessionRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }
        public async Task<int> Guardar(LogSession parametro)
        {
            var sql = @"SC_SEG.MEOSI_LOG_SESSION";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@USUARIO_LOGIN", parametro.USUARIO_LOGIN, DbType.String);
            parameters.Add("@RESULTADO", parametro.RESULTADO, DbType.String);
            parameters.Add("@IP_LOGIN", parametro.IP_LOGIN, DbType.String);
            parameters.Add("@ORIGEN_DISPOSITIVO", parametro.ORIGEN_DISPOSITIVO, DbType.String);


            parameters.Add("@ORIGEN_LOGIN", parametro.ORIGEN_LOGIN, DbType.String);
            parameters.Add("@FECHA_LOGIN", parametro.FECHA_LOGIN, DbType.DateTime);
            parameters.Add("@FECHA_LOGOUT", parametro.FECHA_LOGOUT, DbType.DateTime);
            parameters.Add("@COMENTARIOS", parametro.COMEMTARIOS, DbType.String);
            parameters.Add("@TOKEN", parametro.TOKEN, DbType.String); 
            parameters.Add("@FECHA_EXPIRA", parametro.FECHA_EXPIRA, DbType.DateTime);
            parameters.Add("@CODIGO_SISTEMA", parametro.CODIGO_SISTEMA, DbType.String);

 
            var identity = await DBConnection.Connection.ExecuteScalarAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            if (identity != null)
            {
                result = Convert.ToInt32(identity);
            }

            return result;

        }

        
    }
}
