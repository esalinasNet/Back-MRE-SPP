using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Calendario;
using Mre.OTI.Presupuesto.Application.DTO.Politicas;
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
    public class PoliticasRepository : IPoliticasRepository
    {
        readonly DBConnection DBConnection;

        public PoliticasRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(Politicas parametro)
        {
            var sql = @"SC_SPP.MAESU_POLITICAS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_POLITICAS", parametro.ID_POLITICAS, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@CODIGO_POLITICAS", parametro.CODIGO_POLITICAS, DbType.String);
            parameters.Add("@DESCRIPCION_POLITICAS", parametro.DESCRIPCION_POLITICAS, DbType.String);
            parameters.Add("@CODIGO_OBJETIVO", parametro.CODIGO_OBJETIVO, DbType.String);
            parameters.Add("@DESCRIPCION_OBJETIVO", parametro.DESCRIPCION_OBJETIVO, DbType.String);
            parameters.Add("@CODIGO_LINEAMIENTO", parametro.CODIGO_LINEAMIENTO, DbType.String);
            parameters.Add("@DESCRIPCION_LINEAMIENTO", parametro.DESCRIPCION_LINEAMIENTO, DbType.String);
            parameters.Add("@CODIGO_SERVICIO", parametro.CODIGO_SERVICIO, DbType.String);
            parameters.Add("@DESCRIPCION_SERVICIO", parametro.DESCRIPCION_SERVICIO, DbType.String);
            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(Politicas parametro)
        {
            var sql = @"SC_SPP.MAESD_POLITICAS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_POLITICAS", parametro.ID_POLITICAS, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(Politicas parametro)
        {
            var sql = @"SC_SPP.MAESI_POLITICAS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@CODIGO_POLITICAS", parametro.CODIGO_POLITICAS, DbType.String);
            parameters.Add("@DESCRIPCION_POLITICAS", parametro.DESCRIPCION_POLITICAS, DbType.String);
            parameters.Add("@CODIGO_OBJETIVO", parametro.CODIGO_OBJETIVO, DbType.String);
            parameters.Add("@DESCRIPCION_OBJETIVO", parametro.DESCRIPCION_OBJETIVO, DbType.String);
            parameters.Add("@CODIGO_LINEAMIENTO", parametro.CODIGO_LINEAMIENTO, DbType.String);
            parameters.Add("@DESCRIPCION_LINEAMIENTO", parametro.DESCRIPCION_LINEAMIENTO, DbType.String);
            parameters.Add("@CODIGO_SERVICIO", parametro.CODIGO_SERVICIO, DbType.String);
            parameters.Add("@DESCRIPCION_SERVICIO", parametro.DESCRIPCION_SERVICIO, DbType.String);
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

        public async Task<ObtenerCodigoPoliticasResponseDTO> ObtenerCodigoPoliticas(ObtenerCodigoPoliticasRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_CODIGOPOLITICAS";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@CODIGO_POLITICAS", request.codigoPoliticas, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCodigoPoliticasResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerListadoPoliticasResponseDTO>> ObtenerListadoPoliticas(ObtenerListadoPoliticasRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_POLITICAS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoPoliticasResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }

        public async Task<ObtenerPoliticasResponseDTO> ObtenerPoliticas(ObtenerPoliticasRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_POLITICAS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_POLITICAS", request.idPoliticas, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerPoliticasResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerPoliticasPaginadoResponseDTO>> ObtenerPoliticasPaginado(ObtenerPoliticasPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_POLITICAS";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@CODIGO_POLITICAS", request.codigoPoliticas, DbType.String);
            parameters.Add("@DESCRIPCION_OBJETIVO", request.descripcionObjetivo, DbType.String);            
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);


            var result = await DBConnection.Connection.QueryAsync<ObtenerPoliticasPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
