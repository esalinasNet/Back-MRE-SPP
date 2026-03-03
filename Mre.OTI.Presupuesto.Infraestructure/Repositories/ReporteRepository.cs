using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Reporte;
using Mre.OTI.Presupuesto.Application.Repositories;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class ReporteRepository : IReporteRepository
    {
        readonly DBConnection DBConnection;

        public ReporteRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<ObtenerReporteActividadResponseDTO> ObtenerReporteActividad(int idProgramacionActividad)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_REPORTES";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", idProgramacionActividad, DbType.Int32);

            // QueryMultiple lee los 3 result sets en orden
            using var multi = await DBConnection.Connection.QueryMultipleAsync(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            var actividad = await multi.ReadFirstOrDefaultAsync<ReporteActividadDTO>();
            var tareas = (await multi.ReadAsync<ReporteTareaDTO>()).ToList();
            var acciones = (await multi.ReadAsync<ReporteAccionDTO>()).ToList();

            return new ObtenerReporteActividadResponseDTO
            {
                actividad = actividad,
                tareas = tareas,
                acciones = acciones
            };
        }
    }
}