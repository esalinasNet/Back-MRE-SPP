using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.Ubigeo;
using Mre.OTI.Presupuesto.Application.DTO.UbigeoExterior;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mre.OTI.Presupuesto.Application.Util.VariablesGlobales;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class UbigeoExteriorRepository : IUbigeoExteriorRepository
    {
        readonly DBConnection DBConnection;

        public UbigeoExteriorRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<IEnumerable<ObtenerUbigeoExteriorPaginadoResponseDTO>> ObtenerUbigeoExteriorPaginado(ObtenerUbigeoExteriorPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_EXTERIOR";

            var parameters = new DynamicParameters();
            parameters.Add("@ZONE", request.zone, DbType.String);
            parameters.Add("@REGION", request.region, DbType.String);
            parameters.Add("@PAIS", request.pais, DbType.String);
            parameters.Add("@OSE_RES", request.oseRes, DbType.String);
            //parameters.Add("@ESTADO", request.estado, DbType.Int32);
            //parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerUbigeoExteriorPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerUbigeoExteriorResponseDTO> ObtenerUbigeoExterior(int idUbigeoExterior)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_UBIGEO_EXTERIOR";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_UBIGEO_EXTERIOR", idUbigeoExterior, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerUbigeoExteriorResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<int> GuardarUbigeoExterior(UbigeoExterior parametro)
        {
            var sql = @"SC_SPP.MAESI_UBIGEO_EXTERIOR";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ZONE", parametro.ZONE, DbType.String);
            parameters.Add("@REGION", parametro.REGION, DbType.String);
            parameters.Add("@PAIS", parametro.PAIS, DbType.String);
            parameters.Add("@OSE_RES", parametro.OSE_RES, DbType.String);
            parameters.Add("@OSE", parametro.OSE, DbType.String);
            parameters.Add("@TIPO_MISION", parametro.TIPO_MISION, DbType.String);
            parameters.Add("@NOMBRE_OSE", parametro.NOMBRE_OSE, DbType.String);
            parameters.Add("@MONEDA", parametro.MONEDA, DbType.String);
            parameters.Add("@MON", parametro.MON, DbType.String);
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

        public async Task<int> ActualizarUbigeoExterior(UbigeoExterior parametro)
        {
            var sql = @"SC_SPP.MAESU_UBIGEO_EXTERIOR";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_UBIGEO_EXTERIOR", parametro.ID_UBIGEO_EXTERIOR, DbType.Int32);
            parameters.Add("@ZONE", parametro.ZONE, DbType.String);
            parameters.Add("@REGION", parametro.REGION, DbType.String);
            parameters.Add("@PAIS", parametro.PAIS, DbType.String);
            parameters.Add("@OSE_RES", parametro.OSE_RES, DbType.String);
            parameters.Add("@OSE", parametro.OSE, DbType.String);
            parameters.Add("@TIPO_MISION", parametro.TIPO_MISION, DbType.String);
            parameters.Add("@NOMBRE_OSE", parametro.NOMBRE_OSE, DbType.String);
            parameters.Add("@MONEDA", parametro.MONEDA, DbType.String);
            parameters.Add("@MON", parametro.MON, DbType.String);
            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> EliminarUbigeoExterior(UbigeoExterior parametro)
        {
            var sql = @"SC_SPP.MAESD_UBIGEO_EXTERIOR";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_UBIGEO_EXTERIOR", parametro.ID_UBIGEO_EXTERIOR, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;

        }

        public async Task<IEnumerable<ObtenerListadoUbigeoExteriorRegionResponseDTO>> ObtenerListadoUbigeoExteriorRergion()
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_EXTERIOR_REGION";

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoUbigeoExteriorRegionResponseDTO>(sql, null, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<ObtenerListadoUbigeoExteriorPaisResponseDTO>> ObtenerListadoUbigeoExteriorPais(ObtenerListadoUbigeoExteriorPaisRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_EXTERIOR_PAIS";

            var parameters = new DynamicParameters();
            parameters.Add("@CODIGO_REGION", request.codigoRegion, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoUbigeoExteriorPaisResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.OrderBy(x => x.pais).ThenBy(x => x.pais);
        }

        public async Task<IEnumerable<ObtenerListadoUbigeoExteriorOseResponseDTO>> ObtenerListadoUbigeoExteriorOse(ObtenerListadoUbigeoExteriorOseRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_EXTERIOR_OSE";

            var parameters = new DynamicParameters();
            parameters.Add("@CODIGO_REGION", request.codigoRegion, DbType.String);
            parameters.Add("@CODIGO_PAIS", request.codigoPais, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoUbigeoExteriorOseResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.OrderBy(x => x.ciudad).ThenBy(x => x.ciudad);
        }
    }
}
