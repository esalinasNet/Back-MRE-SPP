using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.EspecificaGasto;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionTareas;
using Mre.OTI.Presupuesto.Application.DTO.Ubigeo;
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
    public class EspecificaGastoRepository : IEspecificaGastoRepository
    {
        readonly DBConnection DBConnection;

        public EspecificaGastoRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }
        
        public async Task<int> Guardar(EspecificaGasto parametro)
        {
            var sql = @"SC_SPP.MAESI_CLASIFICADOR_GASTO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@CLASIFICADOR", parametro.CLASIFICADOR, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            parameters.Add("@DESCRIPCION_DETALLADA", parametro.DESCRIPCION_DETALLADA, DbType.String);
            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ID_CATEGORIA_GASTO", parametro.ID_CATEGORIA_GASTO, DbType.Int32);
            parameters.Add("@TIPO_CLASIFICADOR", parametro.TIPO_CLASIFICADOR, DbType.String);
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

        public async Task<int> Actualizar(EspecificaGasto parametro)
        {
            var sql = @"SC_SPP.MAESU_CLASIFICADOR_GASTO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_CLASIFICADOR", parametro.ID_CLASIFICADOR, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@CLASIFICADOR", parametro.CLASIFICADOR, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            parameters.Add("@DESCRIPCION_DETALLADA", parametro.DESCRIPCION_DETALLADA, DbType.String);
            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);
            parameters.Add("@ID_CATEGORIA_GASTO", parametro.ID_CATEGORIA_GASTO, DbType.Int32);
            parameters.Add("@TIPO_CLASIFICADOR", parametro.TIPO_CLASIFICADOR, DbType.String);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(EspecificaGasto parametro)
        {
            var sql = @"SC_SPP.MAESD_CLASIFICADOR_GASTO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_CLASIFICADOR", parametro.ID_CLASIFICADOR, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<ObtenerEspecificaGastoPaginadoResponseDTO>> ObtenerEspecificaGastoPaginado(ObtenerEspecificaGastoPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_CLASIFICADOR";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.String);
            parameters.Add("@CLASIFICADOR", request.clasificador, DbType.String);
            parameters.Add("@DESCRIPCION", request.descripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerEspecificaGastoPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerEspecificaGastoResponseDTO> ObtenerEspecificaGasto(int idClasificador)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_ID_CLASIFICADOR";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_CLASIFICADOR", idClasificador, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerEspecificaGastoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
        public async Task<ObtenerClasificadorResponseDTO> ObtenerClasificador(string Clasificador)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_CLASIFICADOR";

            var parameters = new DynamicParameters();
            parameters.Add("@CLASIFICADOR", Clasificador, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerClasificadorResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerListadoEspecificaGastoResponseDTO>> ObtenerListadoEspecificaGasto(ObtenerListadoEspecificaGastoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_CLASIFICADOR";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoEspecificaGastoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }

        public async Task<IEnumerable<ObtenerListadoEspecificaGastoGenericaResponseDTO>> ObtenerListadoEspecificaGastoGenerica(ObtenerListadoEspecificaGastoGenericaRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_CLASIFICADOR_GENERICA";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoEspecificaGastoGenericaResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }
    }
}
