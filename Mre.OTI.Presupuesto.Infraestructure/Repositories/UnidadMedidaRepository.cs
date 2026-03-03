using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.UnidadMedida;
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
    public class UnidadMedidaRepository : IUnidadMedidaRepository
    {
        readonly DBConnection DBConnection;

        public UnidadMedidaRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(UnidadMedida parametro)
        {
            var sql = @"SC_SPP.MAESU_UNIDAD_MEDIDA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_UNIDADMEDIDA", parametro.ID_UNIDADMEDIDA, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@UNIDADMEDIDA", parametro.UNIDADMEDIDA, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(UnidadMedida parametro)
        {
            var sql = @"SC_SPP.MAESD_UNIDAD_MEDIDA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_UNIDADMEDIDA", parametro.ID_UNIDADMEDIDA, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(UnidadMedida parametro)
        {
            var sql = @"SC_SPP.MAESI_UNIDAD_MEDIDA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@UNIDADMEDIDA", parametro.UNIDADMEDIDA, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);

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

        public async Task<ObtenerCodigoUnidadMedidaResponseDTO> ObtenerCodigoUnidadMedida(ObtenerCodigoUnidadMedidaRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_CODIGO_UNIDAD_MEDIDA";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@UNIDADMEDIDA", request.unidadMedida, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCodigoUnidadMedidaResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<ObtenerUnidadMedidaResponseDTO> ObtenerUnidadMedida(ObtenerUnidadMedidaRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_UNIDAD_MEDIDA";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_UNIDADMEDIDA", request.idUnidadMedida, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerUnidadMedidaResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerUnidadMedidaPaginadoResponseDTO>> ObtenerUnidadMedidaPaginado(ObtenerUnidadMedidaPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_UNIDAD_MEDIDA";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@UNIDADMEDIDA", request.unidadMedida, DbType.String);
            parameters.Add("@DESCRIPCION", request.descripcion, DbType.String);

            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);


            var result = await DBConnection.Connection.QueryAsync<ObtenerUnidadMedidaPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<ObtenerListadoUnidadMedidaResponseDTO>> ObtenerListadoUnidadMedida(ObtenerListadoUnidadMedidaRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_UNIDAD_MEDIDA";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoUnidadMedidaResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }

    }
}
