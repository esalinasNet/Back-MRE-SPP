using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.ProductoProyecto;
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
    public class ProductoRepository : IProductoRepository
    {
        readonly DBConnection DBConnection;

        public ProductoRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(Producto parametro)
        {
            var sql = @"SC_SPP.MAESU_PRODUCTO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PRODUCTO", parametro.ID_PRODUCTO, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@PRODUCTO", parametro.PRODUCTO, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(Producto parametro)
        {
            var sql = @"SC_SPP.MAESD_PRODUCTO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PRODUCTO", parametro.ID_PRODUCTO, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(Producto parametro)
        {
            var sql = @"SC_SPP.MAESI_PRODUCTO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@PRODUCTO", parametro.PRODUCTO, DbType.String);
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

        public async Task<ObtenerCodigoProductoResponseDTO> ObtenerCodigoProducto(ObtenerCodigoProductoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_CODIGO_PRODUCTO";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@PRODUCTO", request.producto, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCodigoProductoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerListadoProductoResponseDTO>> ObtenerListadoProducto(ObtenerListadoProductoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PRODUCTO";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoProductoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }

        public async Task<ObtenerProductoResponseDTO> ObtenerProducto(ObtenerProductoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_PRODUCTO";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PRODUCTO", request.idProducto, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerProductoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerProductoPaginadoResponseDTO>> ObtenerProductoPaginado(ObtenerProductoPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_PRODUCTO";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@PRODUCTO", request.producto , DbType.String);
            parameters.Add("@DESCRIPCION", request.descripcion, DbType.String);

            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);


            var result = await DBConnection.Connection.QueryAsync<ObtenerProductoPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
