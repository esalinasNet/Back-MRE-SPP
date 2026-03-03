using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Catalogo;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class CatalogoRepository : ICatalogoRepository
    {
        readonly DBConnection DBConnection;

        public CatalogoRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Guardar(Catalogo parametro)
        {
            var sql = @"SC_SEG.MEOSI_CATALOGO";
            int result = 0;
            var parameters = new DynamicParameters();
            parameters.Add("@CODIGO_CATALOGO", parametro.CODIGO_CATALOGO, DbType.Int32);
            parameters.Add("@DESCRIPCION_CATALOGO", parametro.DESCRIPCION_CATALOGO, DbType.String);
            parameters.Add("@MANTENIBLE_POR_USUARIO", parametro.MANTENIBLE_POR_USUARIO, DbType.Boolean);
            parameters.Add("@USUARIO_CREACION", parametro.usuarioCreacion, DbType.String);
            parameters.Add("@IP_CREACION", parametro.ipCreacion, DbType.String);


            var identity = await DBConnection.Connection.ExecuteScalarAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            if (identity != null)
            {
                result = Convert.ToInt32(identity);
            }

            return result;

        }

        public async Task<int> Eliminar(Catalogo parametro)
        {
            var sql = @"SC_SEG.MEOSD_CATALOGO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_CATALOGO", parametro.ID_CATALOGO, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);


            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);



            return result;

        }

        public async Task<int> Actualizar(Catalogo parametro)
        {
            var sql = @"SC_SEG.MEOSU_CATALOGO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_CATALOGO", parametro.ID_CATALOGO, DbType.Int32);
            parameters.Add("@CODIGO_CATALOGO", parametro.CODIGO_CATALOGO, DbType.Int32);
            parameters.Add("@DESCRIPCION_CATALOGO", parametro.DESCRIPCION_CATALOGO, DbType.String);
            parameters.Add("@MANTENIBLE_POR_USUARIO", parametro.MANTENIBLE_POR_USUARIO, DbType.Boolean);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);


            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);



            return result;

        }

        public async Task<ObtenerCatalogoResponseDTO> ObtenerCatalogo(int idCatalogo)
        {
            const string sql = @"SC_SEG.MEOSS_OBTENER_CATALOGO";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_CATALOGO", idCatalogo, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCatalogoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Catalogo>> ObtenerCatalogoPaginado(ObtenerCatalogoPaginadoRequestDTO request)
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_PAGINADO_CATALOGO";

            var parameters = new DynamicParameters();

            parameters.Add("@DESCRIPCION_CATALOGO", request.nombreCatalogo, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);


            var result = await DBConnection.Connection.QueryAsync<Catalogo>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);



            return result;
        }

        public async Task<IEnumerable<Catalogo>> ObtenerListadoCatalogo()
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_CATALOGO";


            var result = await DBConnection.Connection.QueryAsync<Catalogo>(sql, null, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            return result;
        }

        public async Task<ObtenerCatalogoValResponseDTO> ObtenerCatalogoVal(ObtenerCatalogoValRequestDTO request)
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_CATALOGO_VAL";

            var parameters = new DynamicParameters();
            parameters.Add("@DESCRIPCION_CATALOGO", request.nombreCatalogo, DbType.String);
            parameters.Add("@CODIGO_CATALOGO", request.codigoCatalogo, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCatalogoValResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            return result.FirstOrDefault();
        }

    }
}
