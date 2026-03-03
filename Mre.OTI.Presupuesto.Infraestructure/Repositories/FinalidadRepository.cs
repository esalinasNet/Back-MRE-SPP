using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Finalidad;
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
    public class FinalidadRepository : IFinalidadRepository
    {
        readonly DBConnection DBConnection;

        public FinalidadRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(Finalidad parametro)
        {
            var sql = @"SC_SPP.MAESU_FINALIDAD";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_FINALIDAD", parametro.ID_FINALIDAD, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@FINALIDAD", parametro.FINALIDAD, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(Finalidad parametro)
        {
            var sql = @"SC_SPP.MAESD_FINALIDAD";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_FINALIDAD", parametro.ID_FINALIDAD, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(Finalidad parametro)
        {
            var sql = @"SC_SPP.MAESI_FINALIDAD";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@FINALIDAD", parametro.FINALIDAD, DbType.String);
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

        public async Task<IEnumerable<ObtenerFinalidadPaginadoResponseDTO>> ObtenerFinalidadPaginado(ObtenerFinalidadPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_FINALIDAD";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@FINALIDAD", request.finalidad, DbType.String);
            parameters.Add("@DESCRIPCION", request.descripcion, DbType.String);
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);

            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);


            var result = await DBConnection.Connection.QueryAsync<ObtenerFinalidadPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerFinalidadResponseDTO> ObtenerFinalidad(ObtenerFinalidadRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_FINALIDAD";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_FINALIDAD", request.idFinalidad, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerFinalidadResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<ObtenerCodigoFinalidadResponseDTO> ObtenerCodigoFinalidad(ObtenerCodigoFinalidadRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_CODIGO_FINALIDAD";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@FINALIDAD", request.finalidad, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCodigoFinalidadResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerListadoFinalidadResponseDTO>> ObtenerListadoFinalidad(ObtenerListadoFinalidadRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_FINALIDAD";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoFinalidadResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }
    }
}
