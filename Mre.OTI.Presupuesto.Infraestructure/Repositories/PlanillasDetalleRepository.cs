using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Planillas_Detalle;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{    
    public class PlanillasDetalleRepository : IPlanillasDetalleRepository
    {
        readonly DBConnection DBConnection;

        public PlanillasDetalleRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(PlanillasDetalle parametro)
        {
            var sql = @"SC_SPP.MAESU_PLANILLA_DETALLE";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PLANILLA_DETALLE", parametro.ID_PLANILLA_DETALLE, DbType.Int32);

            parameters.Add("@ID_PLANILLA", parametro.ID_PLANILLA, DbType.Int32);

            parameters.Add("@ID_ESPECIFICA", parametro.ID_ESPECIFICA, DbType.Int32);

            //parameters.Add("@PERIODO", parametro.PERIODO, DbType.DateTime);

            parameters.Add("@IMPORTE", parametro.IMPORTE, DbType.Decimal);
                        
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(PlanillasDetalle parametro)
        {
            var sql = @"SC_SPP.MAESD_PLANILLA_DETALLE";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PLANILLA_DETALLE", parametro.ID_PLANILLA_DETALLE, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(PlanillasDetalle parametro)
        {
            var sql = @"SC_SPP.MAESI_PLANILLA_DETALLE";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PLANILLA", parametro.ID_PLANILLA, DbType.Int32);            

            parameters.Add("@ID_ESPECIFICA", parametro.ID_ESPECIFICA, DbType.Int32);

            //parameters.Add("@PERIODO", parametro.PERIODO, DbType.DateTime);

            parameters.Add("@IMPORTE", parametro.IMPORTE, DbType.Decimal);

            parameters.Add("@FECHA_CREACION", parametro.fechaCreacion, DbType.DateTime);
            parameters.Add("@USUARIO_CREACION", parametro.usuarioCreacion, DbType.String);
            parameters.Add("@IP_CREACION", parametro.ipCreacion, DbType.String);

            var identity = await DBConnection.Connection.ExecuteScalarAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            if (identity != null)
            {
                result = Convert.ToInt32(identity);
            }

            return result;
        }

        public async Task<ObtenerPlanillasDetalleResponseDTO> ObtenerPlanillasDetalle(ObtenerPlanillasDetalleRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_PLANILLA_DETALLE";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PLANILLA_DETALLE", request.idPlanillaDetalle, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerPlanillasDetalleResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerPlanillasDetallePaginadoResponseDTO>> ObtenerPlanillasDetallePaginado(ObtenerPlanillasDetallePaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_PLANILLA_DETALLE";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PLANILLA", request.idPlanillas, DbType.Int32);            
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerPlanillasDetallePaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        /*public async Task<ObtenerCodigoPlanillasDetalleResponseDTO> ObtenerCodigoPlanillasDetalle(ObtenerCodigoPlanillasDetalleRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_DOCUMENTO_PLANILLA";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@MES", request.Mes, DbType.Int32);
            parameters.Add("@NRO_DOCUMENTO", request.nroDocumento, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCodigoPlanillasDetalleResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }*/

        /*public async Task<IEnumerable<ObtenerListadoPlanillasDetalleResponseDTO>> ObtenerListadoPlanillasDetalle(ObtenerListadoPlanillasDetalleRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PLANILLA";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);
            parameters.Add("@ID_MES", request.idMes, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoPlanillasDetalleResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }*/
    }
}
