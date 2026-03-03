using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.FuenteFinanciamiento;
using Mre.OTI.Presupuesto.Application.DTO.Politicas;
using Mre.OTI.Presupuesto.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class FuenteFinanciamientoRepository : IFuenteFinanciamientoRepository
    {
        readonly DBConnection DBConnection;

        public FuenteFinanciamientoRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<IEnumerable<ObtenerListadoFuenteFinanciamientoResponseDTO>> ObtenerListadoFuente(ObtenerListadoFuenteFinanciamientoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_FUENTE_FINANCIAMIENTO";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoFuenteFinanciamientoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }
    }
}
