using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.CategoriaPresupuestal;
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
    public class CategoriaPresupuestalRepository : ICategoriaPresupuestalRepository
    {
        readonly DBConnection DBConnection;

        public CategoriaPresupuestalRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(CategoriaPresupuestal parametro)
        {
            var sql = @"SC_SPP.MAESU_CATEGORIA_PRESUPUESTAL";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PRESUPUESTAL", parametro.ID_PRESUPUESTAL, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@CODIGO_PRESUPUESTAL", parametro.CODIGO_PRESUPUESTAL, DbType.String);
            parameters.Add("@DESCRIPCION_PRESUPUESTAL", parametro.DESCRIPCION_PRESUPUESTAL, DbType.String);

            //parameters.Add("@ID_ACCIONES", parametro.ID_ACCIONES, DbType.Int32);
            parameters.Add("@NRO_CODIGO_ACCIONES", parametro.NRO_CODIGO_ACCIONES, DbType.Int32);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> ActualizarAEICategoria(CategoriaPresupuestal parametro)
        {
            var sql = @"SC_SPP.MAESU_CATEGORIA_PRESUPUESTAL_AEICATEGORIA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PRESUPUESTAL", parametro.ID_PRESUPUESTAL, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@CODIGO_PRESUPUESTAL", parametro.CODIGO_PRESUPUESTAL, DbType.String);
            parameters.Add("@DESCRIPCION_PRESUPUESTAL", parametro.DESCRIPCION_PRESUPUESTAL, DbType.String);

            parameters.Add("@NRO_CODIGO_ACCIONES", parametro.NRO_CODIGO_ACCIONES, DbType.Int32);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(CategoriaPresupuestal parametro)
        {
            var sql = @"SC_SPP.MAESI_CATEGORIA_PRESUPUESTAL";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@CODIGO_PRESUPUESTAL", parametro.CODIGO_PRESUPUESTAL, DbType.String);
            parameters.Add("@DESCRIPCION_PRESUPUESTAL", parametro.DESCRIPCION_PRESUPUESTAL, DbType.String);

            //parameters.Add("@ID_ACCIONES", parametro.ID_ACCIONES, DbType.Int32);

            parameters.Add("@NRO_CODIGO_ACCIONES", parametro.NRO_CODIGO_ACCIONES, DbType.Int32);

            //parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);

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

        public async Task<ObtenerCategoriaPresupuestalResponseDTO> ObtenerCategoriaPresupuestal(ObtenerCategoriaPresupuestalRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_CATEGORIA_PRESUPUESTAL";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PRESUPUESTAL", request.idPresupuestal, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCategoriaPresupuestalResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerCategoriaPresupuestalPaginadoResponseDTO>> ObtenerCategoriaPresupuestalPaginado(ObtenerCategoriaPresupuestalPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_CATEGORIA_PRESUPUESTAL";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);

            parameters.Add("@CODIGO_PRESUPUESTAL", request.codigoPresupuestal, DbType.String);
            parameters.Add("@DESCRIPCION_PRESUPUESTAL", request.descripcionPresupuestal, DbType.String);

            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);


            var result = await DBConnection.Connection.QueryAsync<ObtenerCategoriaPresupuestalPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerCodigoPresupuestalResponseDTO> ObtenerCodigoPresupuestal(ObtenerCodigoPresupuestalRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_CODIGOCATEGORIA_PRESUPUESTAL";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@CODIGO_PRESUPUESTAL", request.codigoPresupuestal, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCodigoPresupuestalResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerListadoCategoriaPresupuestalResponseDTO>> ObtenerListadoCategoriaPresupuestal(ObtenerListadoCategoriaPresupuestalRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_CATEGORIA_PRESUPUESTAL";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoCategoriaPresupuestalResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }
    }
}
