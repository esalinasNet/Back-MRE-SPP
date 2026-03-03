using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Reporte;
using Mre.OTI.Presupuesto.Application.Repositories;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class ReporteFinancieroRepository : IReporteFinancieroRepository
    {
        readonly DBConnection DBConnection;

        public ReporteFinancieroRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<ObtenerReporteFinancieroResponseDTO> ObtenerReporteFinanciero(int idProgramacionActividad)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_REPORTE_FINANCIERO";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", idProgramacionActividad, DbType.Int32);

            using var multi = await DBConnection.Connection.QueryMultipleAsync(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 120
            );

            var header = await multi.ReadFirstOrDefaultAsync<ReporteFinancieroActividadHeaderDTO>();
            var jerarquia = (await multi.ReadAsync<ReporteFinancieroJerarquiaDTO>()).ToList();
            var totalGeneral = await multi.ReadFirstOrDefaultAsync<ReporteFinancieroTotalGeneralDTO>();

            return new ObtenerReporteFinancieroResponseDTO
            {
                header = header,
                jerarquia = jerarquia,
                totalGeneral = totalGeneral
            };
        }
    }
}