using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.CatalogoItem;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class CatalogoItemRepository : ICatalogoItemRepository
    {
        readonly DBConnection DBConnection;

        public CatalogoItemRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Guardar(CatalogoItem parametro)
        {
            var sql = @"SC_SEG.MEOSI_CATALOGO_ITEM";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_CATALOGO", parametro.idCatalogo, DbType.Int32);
            parameters.Add("@CODIGO_CATALOGO_ITEM", parametro.codigoCatalogoItem, DbType.Int32);
            parameters.Add("@ORDEN", parametro.orden, DbType.Int32);
            parameters.Add("@DESCRIPCION_CATALOGO_ITEM", parametro.descripcionCatalogoItem, DbType.String);
            parameters.Add("@ABREVIATURA_CATALOGO_ITEM", parametro.AbreviaturaCatalogoItem, DbType.String);
            parameters.Add("@FECHA_CREACION", parametro.fechaCreacion, DbType.DateTime);
            parameters.Add("@USUARIO_CREACION", parametro.usuarioCreacion, DbType.String);
            parameters.Add("@IP_CREACION", parametro.ipCreacion, DbType.String);
            parameters.Add("@DETALLE_CATALOGO_ITEM", parametro.detalleCatalogoItem, DbType.String);

            var identity = await DBConnection.Connection.ExecuteScalarAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            if (identity != null)
            {
                result = Convert.ToInt32(identity);
            }

            return result;

        }
        public async Task<int> Eliminar(CatalogoItem parametro)
        {
            var sql = @"SC_SEG.MEOSD_CATALOGO_ITEM";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_CATALOGO_ITEM", parametro.idCatalogoItem, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);
            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Actualizar(CatalogoItem parametro)
        {
            var sql = @"SC_SEG.MEOSU_CATALOGO_ITEM";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_CATALOGO_ITEM", parametro.idCatalogoItem, DbType.Int32);
            parameters.Add("@ORDEN", parametro.orden, DbType.Int32);
            parameters.Add("@DESCRIPCION_CATALOGO_ITEM", parametro.descripcionCatalogoItem, DbType.String);
            parameters.Add("@ABREVIATURA_CATALOGO_ITEM", parametro.AbreviaturaCatalogoItem, DbType.String);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);
            parameters.Add("@DETALLE_CATALOGO_ITEM", parametro.detalleCatalogoItem, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);
            return result;          
        }

        public async Task<IEnumerable<dynamic>> ObtenerCatalogoItemsXCodigoCatalogo(int codigoCatalogo)
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_CATALOGO_ITEM_POR_CODIGO_CATALOGO";

            var parameters = new DynamicParameters();
            parameters.Add("@CODIGO_CATALOGO", codigoCatalogo, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);
           
            return result;
        }
 
        public async Task<ObtenerCatalogoItemResponseDTO> ObtenerCatalogoItemsActivosXIdCatalogoItem(int idCatalogoItem)
        {
            const string sql = @"SC_SEG.MEOSS_OBTENER_CATALOGO_ITEM";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_CATALOGO_ITEM", idCatalogoItem, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCatalogoItemResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            return result.FirstOrDefault();
        }
        
        public async Task<int> ObtenerIdCatalogoItem(int codigoCatalogo, int codigoCatalogoItem)
        {
            const string sql = @"SC_SEG.MEOSS_OBTENER_ID_CATALOGO_ITEM";

            var parameters = new DynamicParameters();
            parameters.Add("@CODIGO_CATALOGO_ITEM", codigoCatalogoItem, DbType.Int32);
            parameters.Add("@CODIGO_CATALOGO", codigoCatalogo, DbType.Int32);

            var result = await DBConnection.Connection.QuerySingleAsync<int>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
        public async Task<int> ObtenerCodigoCatalogoItem(int idCatalogoItem)
        {
            const string sql = @"SC_SEG.MEOSS_OBTENER_CODIGO_CATALOGO_POR_CODIGOCATALOGOITEM";

            var parameters = new DynamicParameters();
            parameters.Add("@CODIGO_CATALOGO_ITEM", idCatalogoItem, DbType.Int32);


            var result = await DBConnection.Connection.QuerySingleAsync<int>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            return result;
        }
        
        public async Task<IEnumerable<CatalogoItem>> ObtenerCatalogoItemPaginado(ObtenerCatalogoItemPaginadoRequestDTO request)
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_PAGINADO_CATALOGO_ITEM";

            var parameters = new DynamicParameters();

            parameters.Add("@ID_CATALOGO", request.idCatalogo, DbType.Int32);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);


            var result = await DBConnection.Connection.QueryAsync<CatalogoItem>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> ObtenerNumeroOrderCatalogo(int idCatalogo)
        {
            const string sql = @"SC_SEG.MEOSS_OBTENER_ORDEN_CATALOGO";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_CATALOGO", idCatalogo, DbType.Int32);

            var result = await DBConnection.Connection.QuerySingleAsync<int>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerCatalogoItemValResponseDTO> ObtenerCatalogoItemVal(ObtenerCatalogoItemValRequestDTO request)
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_CATALOGO_ITEM_VAL";

            var parameters = new DynamicParameters();
            parameters.Add("@DESCRIPCION_CATALOGO_ITEM", request.nombreCatalogoItem, DbType.String);
            parameters.Add("@CODIGO_CATALOGO_ITEM", request.codigoCatalogoItem, DbType.Int32);
            parameters.Add("@ID_CATALOGO", request.idCatalogo, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCatalogoItemValResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            return result.FirstOrDefault();
        }
    }
}
