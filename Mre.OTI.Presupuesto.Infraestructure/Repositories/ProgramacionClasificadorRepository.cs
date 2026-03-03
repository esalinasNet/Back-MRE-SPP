using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionClasificador;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionTareas;
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
    public class ProgramacionClasificadorRepository : IProgramacionClasificadorRepository
    {
        readonly DBConnection DBConnection;

        public ProgramacionClasificadorRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(ProgramacionClasificador parametro)
        {
            var sql = @"SC_SPP.MAESU_PROGRAMACION_CLASIFICADOR";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_CLASIFICADOR", parametro.ID_PROGRAMACION_CLASIFICADOR, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", parametro.ID_PROGRAMACION_ACTIVIDAD, DbType.Int32);            
            parameters.Add("@ID_FUENTE_FINANCIAMIENTO", parametro.ID_FUENTE_FINANCIAMIENTO, DbType.Int32);
            parameters.Add("@ID_CLASIFICADOR", parametro.ID_CLASIFICADOR, DbType.Int32);

            parameters.Add("@CODIGO_CLASIFICADOR", parametro.CODIGO_CLASIFICADOR, DbType.String);
            parameters.Add("@DESCRIPCION_CLASIFICADOR", parametro.DESCRIPCION_CLASIFICADOR, DbType.String);

            parameters.Add("@META_FINANCIERA", parametro.META_FINANCIERA, DbType.Decimal);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(ProgramacionClasificador parametro)
        {
            var sql = @"SC_SPP.MAESD_PROGRAMACION_CLASIFICADOR";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_CLASIFICADOR", parametro.ID_PROGRAMACION_CLASIFICADOR, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;  
        }

        public async Task<int> Guardar(ProgramacionClasificador parametro)
        {
            var sql = @"SC_SPP.MAESI_PROGRAMACION_CLASIFICADOR";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);            
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", parametro.ID_PROGRAMACION_ACTIVIDAD, DbType.Int32);
            parameters.Add("@ID_FUENTE_FINANCIAMIENTO", parametro.ID_FUENTE_FINANCIAMIENTO, DbType.Int32);
            parameters.Add("@ID_CLASIFICADOR", parametro.ID_CLASIFICADOR, DbType.Int32);

            parameters.Add("@CODIGO_CLASIFICADOR", parametro.CODIGO_CLASIFICADOR, DbType.String);
            parameters.Add("@DESCRIPCION_CLASIFICADOR", parametro.DESCRIPCION_CLASIFICADOR, DbType.String);

            parameters.Add("@META_FINANCIERA", parametro.META_FINANCIERA, DbType.Decimal);

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

        public async Task<ObtenerCodigoProgramacionClasificadorResponseDTO> ObtenerCodigoProgramacionClasificador(ObtenerCodigoProgramacionClasificadorRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_CODIGO_PROGRAMACION_CLASIFICADOR";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@CODIGO_CLASIFICADOR", request.codigoClasificador, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCodigoProgramacionClasificadorResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerListadoProgramacionClasificadorResponseDTO>> ObtenerListadoProgramacionClasificador(ObtenerListadoProgramacionClasificadorRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PROGRAMACION_CLASIFICADOR";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoProgramacionClasificadorResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }

        public async Task<IEnumerable<ObtenerListadoProgramacionClasificadorPorActividadResponseDTO>> ObtenerListadoProgramacionClasificadorPorActividad(ObtenerListadoProgramacionClasificadorPorActividadRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PROGRAMACION_POR_CLASIFICADOR_EN_ACTIVIDADES";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", request.idProgramacionActividad, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoProgramacionClasificadorPorActividadResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }

        public async Task<ObtenerProgramacionActividadClasificadorResponseDTO> ObtenerProgramacionActividadClasificador(ObtenerProgramacionActividadClasificadorRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_PROGRAMACION_CODIGO_CLASIFICADOR_POR_ACTIVIDAD";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", request.idProgramacionActividad, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerProgramacionActividadClasificadorResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<ObtenerProgramacionClasificadorResponseDTO> ObtenerProgramacionClasificador(ObtenerProgramacionClasificadorRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_PROGRAMACION_CLASIFICADOR";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_CLASIFICADOR", request.idProgramacionClasificador, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerProgramacionClasificadorResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerProgramacionClasificadorPaginadoResponseDTO>> ObtenerProgramacionClasificadorPaginado(ObtenerProgramacionClasificadorPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_PROGRAMACION_CLASIFICADOR";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", request.idProgramacionActividad, DbType.Int32);
            parameters.Add("@CODIGO_ESPECIFICA", request.codigoClasificador, DbType.String);
            parameters.Add("@DESCRIPCION_ESPECIFICA", request.descripcionClasificador, DbType.String);
            
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerProgramacionClasificadorPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
