using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.AprobacionesCostos_Detalle;
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
    public class AprobacionesCostosDetalleRepository : IAprobacionesCostosDetalleRepository
    {
        readonly DBConnection DBConnection;

        public AprobacionesCostosDetalleRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(AprobacionesCostosDetalle parametro)
        {
            var sql = @"SC_SPP.MAESU_APROBACIONES_DETALLE";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_APROBACIONES_DETALLE", parametro.ID_APROBACIONES_DETALLE, DbType.Int32);

            parameters.Add("@ID_APROBACIONES", parametro.ID_APROBACIONES, DbType.Int32);

            parameters.Add("@ID_PERSONA", parametro.ID_PERSONA, DbType.Int32);

            //parameters.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.Int32);

            parameters.Add("@PUESTO_TRABAJO", parametro.PUESTO_TRABAJO, DbType.String);

            //parameters.Add("@FECHA_INICIO", parametro.FECHA_INICIO, DbType.DateTime);

            //parameters.Add("@FECHA_FIN", parametro.FECHA_FIN, DbType.DateTime);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);

            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Actualizar2(AprobacionesCostosDetalle parametro)
        {
            var sql = @"SC_SPP.MAESU_APROBACIONES_DETALLE_APROBADOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_APROBACIONES_DETALLE", parametro.ID_APROBACIONES_DETALLE, DbType.Int32);

            parameters.Add("@FECHA_INICIO", parametro.FECHA_INICIO, DbType.DateTime);

            parameters.Add("@FECHA_FIN", parametro.FECHA_FIN, DbType.DateTime);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(AprobacionesCostosDetalle parametro)
        {
            var sql = @"SC_SPP.MAESD_APROBACIONES_DETALLE";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_APROBACIONES_DETALLE", parametro.ID_APROBACIONES_DETALLE, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(AprobacionesCostosDetalle parametro)
        {
            var sql = @"SC_SPP.MAESI_APROBACIONES_DETALLE";
            int result = 0;

            var parameters = new DynamicParameters();
            //parameters.Add("@ID_APROBACIONES_DETALLE", parametro.ID_APROBACIONES_DETALLE, DbType.Int32);

            parameters.Add("@ID_APROBACIONES", parametro.ID_APROBACIONES, DbType.Int32);

            parameters.Add("@ID_PERSONA", parametro.ID_PERSONA, DbType.Int32);

            //parameters.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.Int32);

            parameters.Add("@PUESTO_TRABAJO", parametro.PUESTO_TRABAJO, DbType.String);

            //parameters.Add("@FECHA_INICIO", parametro.FECHA_INICIO, DbType.DateTime);

            //parameters.Add("@FECHA_FIN", parametro.FECHA_FIN, DbType.DateTime);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);            

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

        public async Task<ObtenerAprobacionesCostosDetalleResponseDTO> ObtenerAprobacionesCostosDetalle(ObtenerAprobacionesCostosDetalleRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_APROBACIONES_DETALLE";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_APROBACIONES_DETALLE", request.idAprobacionesDetalle, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerAprobacionesCostosDetalleResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerAprobacionesCostosDetallePaginadoResponseDTO>> ObtenerAprobacionesCostosDetallePaginado(ObtenerAprobacionesCostosDetallePaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_APROBACIONES_DETALLE";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_APROBACIONES", request.idAprobaciones, DbType.Int32);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerAprobacionesCostosDetallePaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        /*public async Task<ObtenerCodigoAprobacionesCostosDetalleResponseDTO> ObtenerCodigoAprobacionesCostosDetalle(ObtenerCodigoAprobacionesCostosDetalleRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_DOCUMENTO_AprobacionesCostos";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@MES", request.Mes, DbType.Int32);
            parameters.Add("@NRO_DOCUMENTO", request.nroDocumento, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCodigoAprobacionesCostosDetalleResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }*/

        /*public async Task<IEnumerable<ObtenerListadoAprobacionesCostosDetalleResponseDTO>> ObtenerListadoAprobacionesCostosDetalle(ObtenerListadoAprobacionesCostosDetalleRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_AprobacionesCostos";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);
            parameters.Add("@ID_MES", request.idMes, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoAprobacionesCostosDetalleResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }*/
    }

}
