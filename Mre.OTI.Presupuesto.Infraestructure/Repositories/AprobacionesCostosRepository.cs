using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.AprobacionesCostos;
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
    public class AprobacionesCostosRepository : IAprobacionesCostosRepository
    {
        readonly DBConnection DBConnection;

        public AprobacionesCostosRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(AprobacionesCostos parametro)
        {
            var sql = @"SC_SPP.MAESU_APROBACIONES";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_APROBACIONES", parametro.ID_APROBACIONES, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", parametro.ID_PROGRAMACION_ACTIVIDAD, DbType.Int32);

            parameters.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.Int32);
            
            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(AprobacionesCostos parametro)
        {
            var sql = @"SC_SPP.MAESD_APROBACIONES";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_APROBACIONES", parametro.ID_APROBACIONES, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(AprobacionesCostos parametro)
        {
            var sql = @"SC_SPP.MAESI_APROBACIONES";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", parametro.ID_PROGRAMACION_ACTIVIDAD, DbType.Int32);

            parameters.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.Int32);            

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

        public async Task<ObtenerAprobacionesCostosResponseDTO> ObtenerAprobacionesCostos(ObtenerAprobacionesCostosRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_APROBACIONES";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_APROBACIONES", request.idAprobaciones, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerAprobacionesCostosResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerAprobacionesCostosPaginadoResponseDTO>> ObtenerAprobacionesCostosPaginado(ObtenerAprobacionesCostosPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_APROBACIONES";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@CENTRO_COSTOS", request.centroCostos, DbType.String);
            parameters.Add("@DESCRIPCIONCOSTOS", request.descripcionCostos, DbType.String);            
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerAprobacionesCostosPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public Task<ObtenerAprobacionesCentroCostosResponseDTO> ObtenerAprobacionesCentroCostos(ObtenerAprobacionesCentroCostosRequestDTO request)
        {
            throw new NotImplementedException();
        }

        /*public async Task<ObtenerAprobacionesCentroCostosResponseDTO> ObtenerCodigoAprobacionesCostos(ObtenerAprobacionesCentroCostosRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_CODIGOAprobacionesCostos";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@CODIGO_AprobacionesCostos", request.codigoAprobacionesCostos, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCodigoAprobacionesCostosResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();            
        }*/

        public async Task<IEnumerable<ObtenerListadoAprobacionesCostosResponseDTO>> ObtenerListadoAprobacionesCostos(ObtenerListadoAprobacionesCostosRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTADO_APROBACIONES";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoAprobacionesCostosResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }
    }
}
