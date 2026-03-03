using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionTareas;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class ProgramacionTareasRepository : IProgramacionTareasRepository
    {
        readonly DBConnection DBConnection;

        public ProgramacionTareasRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(ProgramacionTareas parametro)
        {
            var sql = @"SC_SPP.MAESU_PROGRAMACION_TAREAS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_TAREAS", parametro.ID_PROGRAMACION_TAREAS, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", parametro.ID_PROGRAMACION_ACTIVIDAD, DbType.Int32);
            //parameters.Add("@ID_PROGRAMACION_CLASIFICADOR", parametro.ID_PROGRAMACION_CLASIFICADOR, DbType.Int32);
            parameters.Add("@CODIGO_TAREAS", parametro.CODIGO_TAREAS, DbType.String);
            parameters.Add("@DESCRIPCION_TAREAS", parametro.DESCRIPCION_TAREAS, DbType.String);
            parameters.Add("@UBIGEO", parametro.UBIGEO, DbType.String);
            parameters.Add("@ID_UNIDAD_MEDIDA", parametro.ID_UNIDAD_MEDIDA, DbType.Int32);
            parameters.Add("@REPRESENTATIVA", parametro.REPRESENTATIVA, DbType.Int32);
            parameters.Add("@ID_FUENTE_FINANCIAMIENTO", parametro.ID_FUENTE_FINANCIAMIENTO, DbType.Int32);

            parameters.Add("@META_FISICA", parametro.META_FISICA, DbType.Int32);
            parameters.Add("@META_FINANCIERA", parametro.META_FINANCIERA, DbType.Decimal);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(ProgramacionTareas parametro)
        {
            var sql = @"SC_SPP.MAESD_PROGRAMACION_TAREAS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_TAREAS", parametro.ID_PROGRAMACION_TAREAS, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(ProgramacionTareas parametro)
        {
            var sql = @"SC_SPP.MAESI_PROGRAMACION_TAREAS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", parametro.ID_PROGRAMACION_ACTIVIDAD, DbType.Int32);            
            parameters.Add("@CODIGO_TAREAS", parametro.CODIGO_TAREAS, DbType.String);
            parameters.Add("@DESCRIPCION_TAREAS", parametro.DESCRIPCION_TAREAS, DbType.String);
            parameters.Add("@UBIGEO", parametro.UBIGEO, DbType.String);
            parameters.Add("@ID_UNIDAD_MEDIDA", parametro.ID_UNIDAD_MEDIDA, DbType.Int32);
            parameters.Add("@REPRESENTATIVA", parametro.REPRESENTATIVA, DbType.Int32);
            parameters.Add("@ID_FUENTE_FINANCIAMIENTO", parametro.ID_FUENTE_FINANCIAMIENTO, DbType.Int32);
            parameters.Add("@META_FISICA", parametro.META_FISICA, DbType.Int32);
            parameters.Add("@META_FINANCIERA", parametro.META_FINANCIERA, DbType.Decimal);
            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
                        
            var identity = await DBConnection.Connection.ExecuteScalarAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            if (identity != null)
            {
                result = Convert.ToInt32(identity);
            }

            return result;
        }

        public async Task<ObtenerCodigoProgramacionTareasResponseDTO> ObtenerCodigoProgramacionTareas(ObtenerCodigoProgramacionTareasRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_CODIGO_PROGRAMACION_TAREAS";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@CODIGO_TAREAS", request.codigoTareas, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCodigoProgramacionTareasResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerListadoProgramacionTareasResponseDTO>> ObtenerListadoProgramacionTareas(ObtenerListadoProgramacionTareasRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PROGRAMACION_TAREAS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoProgramacionTareasResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }

        public async Task<IEnumerable<ObtenerListadoProgramacionTareasPorActividadResponseDTO>> ObtenerListadoProgramacionTareasPorActividad(ObtenerListadoProgramacionTareasPorActividadRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PROGRAMACION_POR_TAREAS_EN_ACTIVIDADES";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", request.idProgramacionActividad, DbType.Int32);
            //parameters.Add("@@ID_PROGRAMACION_CLASIFICADOR", request.idProgramacionClasificador, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoProgramacionTareasPorActividadResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }

        public async Task<ObtenerProgramacionActividadTareasResponseDTO> ObtenerProgramacionActividadTareas(ObtenerProgramacionActividadTareasRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_PROGRAMACION_CODIGO_TAREAS_POR_ACTIVIDADES";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", request.idProgramacionActividad, DbType.Int32);
            //parameters.Add("@@ID_PROGRAMACION_CLASIFICADOR", request.idProgramacionClasificador, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerProgramacionActividadTareasResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<ObtenerProgramacionTareasResponseDTO> ObtenerProgramacionTareas(ObtenerProgramacionTareasRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_PROGRAMACION_TAREAS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_TAREAS", request.idProgramacionTareas, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerProgramacionTareasResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerProgramacionTareasPaginadoResponseDTO>> ObtenerProgramacionTareasPaginado(ObtenerProgramacionTareasPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_PROGRAMACION_TAREAS";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", request.idProgramacionActividad, DbType.Int32);
            //parameters.Add("@ID_PROGRAMACION_CLASIFICADOR", request.idProgramacionClasificador, DbType.Int32);
            parameters.Add("@CODIGO_TAREAS", request.codigoTareas, DbType.String);
            //parameters.Add("@DESCRIPCION_TAREAS", request.descripcionTareas, DbType.String);            
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerProgramacionTareasPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerUnidadMedidaProgramacionTareasResponseDTO> ObtenerUnidadMedidaProgramacionTareas(ObtenerUnidadMedidaProgramacionTareasRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_UNIDADMEDIDA_PROGRAMACION_TAREAS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_TAREAS", request.idProgramacionTareas, DbType.Int32);
            parameters.Add("@ID_UNIDAD_MEDIDA", request.idUnidadMedida, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerUnidadMedidaProgramacionTareasResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}
