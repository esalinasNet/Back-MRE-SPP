using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Calendario;
using Mre.OTI.Presupuesto.Application.DTO.CentroCostos;
using Mre.OTI.Presupuesto.Application.DTO.EspecificaGasto;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.TipoDeCambio;
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
    public class CentroCostosRepository : ICentroCostosRepository
    {
        readonly DBConnection DBConnection;

        public CentroCostosRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(CentroCostos parametro)
        {
            var sql = @"SC_SPP.MAESU_CENTROCOSTOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ID_EJECUTORA", parametro.ID_EJECUTORA, DbType.Int32);
            parameters.Add("@CENTRO_COSTOS", parametro.CENTRO_COSTOS, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            parameters.Add("@CENTRO_COSTOS_PADRE", parametro.CENTRO_COSTOS_PADRE, DbType.String);
            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(CentroCostos parametro)
        {
            var sql = @"SC_SPP.MAESD_CENTROCOSTOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(CentroCostos parametro)
        {
            var sql = @"SC_SPP.MAESI_CENTROCOSTOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ID_EJECUTORA", parametro.ID_EJECUTORA, DbType.Int32);
            parameters.Add("@CENTRO_COSTOS", parametro.CENTRO_COSTOS, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            parameters.Add("@CENTRO_COSTOS_PADRE", parametro.CENTRO_COSTOS_PADRE, DbType.String);
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

        public async Task<ObtenerCentroCostosResponseDTO> ObtenerCentroCostos(ObtenerCentroCostosRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_CENTROCOSTOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_CENTRO_COSTOS", request.idCentroCostos, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCentroCostosResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerCentroCostosPaginadoResponseDTO>> ObtenerCentroCostosPaginado(ObtenerCentroCostosPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_CENTROCOSTOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@CENTRO_COSTOS", request.centroCostos, DbType.String);
            parameters.Add("@DESCRIPCION", request.descripcion, DbType.String);
            parameters.Add("@CENTRO_COSTOS_PADRE", request.centroCostosPadre, DbType.String);
            //parameters.Add("@ESTADO", request.estado, DbType.Int32);
            //parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);


            var result = await DBConnection.Connection.QueryAsync<ObtenerCentroCostosPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerCentroCostosResponseDTO> ObtenerCodigoCostos(string centroCostos)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_CODIGOCOSTOS";

            var parameters = new DynamicParameters();
            parameters.Add("@CENTRO_COSTOS", centroCostos, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCentroCostosResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerListadoCentroCostosResponseDTO>> ObtenerListadoCentroCostos(ObtenerListadoCentroCostosRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_CENTROCOSTOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoCentroCostosResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }
    }
}
