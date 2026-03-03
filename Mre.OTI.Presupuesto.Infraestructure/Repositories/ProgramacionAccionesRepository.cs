using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionAcciones;
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
    public class ProgramacionAccionesRepository : IProgramacionAccionesRepository
    {
        readonly DBConnection DBConnection;

        public ProgramacionAccionesRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(ProgramacionAcciones parametro)
        {
            var sql = @"SC_SPP.MAESU_PROGRAMACION_ACCIONES";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_ACCIONES", parametro.ID_PROGRAMACION_ACCIONES, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", parametro.ID_PROGRAMACION_ACTIVIDAD, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_TAREAS", parametro.ID_PROGRAMACION_TAREAS, DbType.Int32);

            parameters.Add("@CODIGO_ACCIONES", parametro.CODIGO_ACCIONES, DbType.String);
            parameters.Add("@DESCRIPCION_ACCIONES", parametro.DESCRIPCION_ACCIONES, DbType.String);
            
            parameters.Add("@ID_UNIDAD_MEDIDA", parametro.ID_UNIDAD_MEDIDA, DbType.Int32);
            parameters.Add("@REPRESENTATIVA", parametro.REPRESENTATIVA, DbType.Int32);
            parameters.Add("@ACUMULATIVA", parametro.ACUMULATIVA, DbType.Int32);

            parameters.Add("@META_FISICA", parametro.META_FISICA, DbType.Int32);
            parameters.Add("@ENERO", parametro.ENERO, DbType.Int32);
            parameters.Add("@FEBRERO", parametro.FEBRERO, DbType.Int32);
            parameters.Add("@MARZO", parametro.MARZO, DbType.Int32);
            parameters.Add("@ABRIL", parametro.ABRIL, DbType.Int32);
            parameters.Add("@MAYO", parametro.MAYO, DbType.Int32);
            parameters.Add("@JUNIO", parametro.JUNIO, DbType.Int32);
            parameters.Add("@JULIO", parametro.JULIO, DbType.Int32);
            parameters.Add("@AGOSTO", parametro.AGOSTO, DbType.Int32);
            parameters.Add("@SETIEMBRE", parametro.SETIEMBRE, DbType.Int32);            
            parameters.Add("@OCTUBRE", parametro.OCTUBRE, DbType.Int32);
            parameters.Add("@NOVIEMBRE", parametro.NOVIEMBRE, DbType.Int32);
            parameters.Add("@DICIEMBRE", parametro.DICIEMBRE, DbType.Int32);
            parameters.Add("@TOTAL_ANUAL", parametro.TOTAL_ANUAL, DbType.Int32);            

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(ProgramacionAcciones parametro)
        {
            var sql = @"SC_SPP.MAESD_PROGRAMACION_ACCIONES";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_ACCIONES", parametro.ID_PROGRAMACION_ACCIONES, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async  Task<int> Guardar(ProgramacionAcciones parametro)
        {
            var sql = @"SC_SPP.MAESI_PROGRAMACION_ACCIONES";
            int result = 0;

            var parameters = new DynamicParameters();            
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", parametro.ID_PROGRAMACION_ACTIVIDAD, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_TAREAS", parametro.ID_PROGRAMACION_TAREAS, DbType.Int32);

            parameters.Add("@CODIGO_ACCIONES", parametro.CODIGO_ACCIONES, DbType.String);
            parameters.Add("@DESCRIPCION_ACCIONES", parametro.DESCRIPCION_ACCIONES, DbType.String);

            parameters.Add("@ID_UNIDAD_MEDIDA", parametro.ID_UNIDAD_MEDIDA, DbType.Int32);
            parameters.Add("@REPRESENTATIVA", parametro.REPRESENTATIVA, DbType.Int32);
            parameters.Add("@ACUMULATIVA", parametro.ACUMULATIVA, DbType.Int32);

            parameters.Add("@META_FISICA", parametro.META_FISICA, DbType.Int32);
            parameters.Add("@ENERO", parametro.ENERO, DbType.Int32);
            parameters.Add("@FEBRERO", parametro.FEBRERO, DbType.Int32);
            parameters.Add("@MARZO", parametro.MARZO, DbType.Int32);
            parameters.Add("@ABRIL", parametro.ABRIL, DbType.Int32);
            parameters.Add("@MAYO", parametro.MAYO, DbType.Int32);
            parameters.Add("@JUNIO", parametro.JUNIO, DbType.Int32);
            parameters.Add("@JULIO", parametro.JULIO, DbType.Int32);
            parameters.Add("@AGOSTO", parametro.AGOSTO, DbType.Int32);
            parameters.Add("@SETIEMBRE", parametro.SETIEMBRE, DbType.Int32);
            parameters.Add("@OCTUBRE", parametro.OCTUBRE, DbType.Int32);
            parameters.Add("@NOVIEMBRE", parametro.NOVIEMBRE, DbType.Int32);
            parameters.Add("@DICIEMBRE", parametro.DICIEMBRE, DbType.Int32);
            parameters.Add("@TOTAL_ANUAL", parametro.TOTAL_ANUAL, DbType.Int32);

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

        public async Task<ObtenerCodigoProgramacionAccionesResponseDTO> ObtenerCodigoProgramacionAcciones(ObtenerCodigoProgramacionAccionesRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_CODIGO_PROGRMACION_ACCIONES";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@CODIGO_ACCIONES", request.codigoAcciones, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCodigoProgramacionAccionesResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerListadoProgramacionAccionesResponseDTO>> ObtenerListadoProgramacionAcciones(ObtenerListadoProgramacionAccionesRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PROGRAMACION_ACCIONES";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoProgramacionAccionesResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }

        public async Task<IEnumerable<ObtenerListadoProgramacionAccionesPorTareasResponseDTO>> ObtenerListadoProgramacionAccionesPorTareas(ObtenerListadoProgramacionAccionesPorTareasRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PROGRAMACION_POR_ACCIONES_EN_TAREAS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", request.idProgramacionActividad, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_TAREAS", request.idProgramacionTareas, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoProgramacionAccionesPorTareasResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }

        public async Task<ObtenerProgramacionAccionesResponseDTO> ObtenerProgramacionAcciones(ObtenerProgramacionAccionesRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_PROGRAMACION_ACCIONES";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_ACCIONES", request.idProgramacionAcciones, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerProgramacionAccionesResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerProgramacionAccionesPaginadoResponseDTO>> ObtenerProgramacionAccionesPaginado(ObtenerProgramacionAccionesPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_PROGRAMACION_ACCIONES";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", request.idProgramacionActividad, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_TAREAS", request.idProgramacionTareas, DbType.Int32);
            parameters.Add("@CODIGO_ACCIONES", request.codigoAcciones, DbType.String);            
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerProgramacionAccionesPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerProgramacionTareasAccionesResponseDTO> ObtenerProgramacionTareasAcciones(ObtenerProgramacionTareasAccionesRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_PROGRAMACION_CODIGO_ACCIONES_POR_TREAS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", request.idProgramacionActividad, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_TAREAS", request.idProgramacionTareas, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerProgramacionTareasAccionesResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<ObtenerUnidadMedidaProgramacionAccionesResponseDTO> ObtenerUnidadMedidaProgramacionAcciones(ObtenerUnidadMedidaProgramacionAccionesRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_UNIDADMEDIDA_PROGRAMACION_TAREAS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_TAREAS", request.idProgramacionTareas, DbType.Int32);
            parameters.Add("@ID_UNIDAD_MEDIDA", request.idUnidadMedida, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerUnidadMedidaProgramacionAccionesResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}
