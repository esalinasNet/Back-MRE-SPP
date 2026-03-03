using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Planilla;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class PlanillaRepository : IPlanillaRepository
    {
        readonly DBConnection DBConnection;

        public PlanillaRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<IEnumerable<ObtenerListadoPlanillaResponseDTO>> ObtenerListadoPlanilla(ObtenerListadoPlanillaRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PROGRAMACION_PLANILLA";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_RECURSO", request.idProgramacionRecurso, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_TAREAS", request.idProgramacionTareas, DbType.Int32);
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoPlanillaResponseDTO>(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<IEnumerable<ObtenerPlanillaPaginadoResponseDTO>> ObtenerPlanillaPaginado(ObtenerPlanillaPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_PAGINADO_PROGRAMACION_PLANILLA";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_TAREAS", request.idProgramacionTareas, DbType.Int32);
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@ID_ACTIVIDAD_OPERATIVA", null, DbType.Int32);
            parameters.Add("@TIPO_UBIGEO", request.tipoUbigeo, DbType.Int32);
            parameters.Add("@NOMBRE_TRABAJADOR", request.nombreTrabajador, DbType.String);
            parameters.Add("@CARGO", request.cargo, DbType.String);
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);
            parameters.Add("@PAGINA_ACTUAL", request.paginaActual, DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerPlanillaPaginadoResponseDTO>(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<ObtenerPlanillaPorIdResponseDTO> ObtenerPlanillaPorId(int idProgramacionPlanilla, string usuarioConsulta)
        {
            const string sql = @"SC_SPP.MAESS_OBTENERID_PROGRAMACION_PLANILLA";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_PLANILLA", idProgramacionPlanilla, DbType.Int32);

            var result = await DBConnection.Connection.QueryFirstOrDefaultAsync<ObtenerPlanillaPorIdResponseDTO>(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            return result; // ← Puede ser NULL
        }

        public async Task<int> Guardar(Planilla parametro)
        {
            const string sql = @"SC_SPP.MAESI_PROGRAMACION_PLANILLA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_RECURSO", parametro.ID_PROGRAMACION_RECURSO, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_TAREAS", parametro.ID_PROGRAMACION_TAREAS, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ID_ACTIVIDAD_OPERATIVA", parametro.ID_ACTIVIDAD_OPERATIVA, DbType.Int32);
            parameters.Add("@ID_TAREA", parametro.ID_TAREA, DbType.Int32);
            parameters.Add("@ID_UNIDAD_MEDIDA", parametro.ID_UNIDAD_MEDIDA, DbType.Int32);
            parameters.Add("@REPRESENTATIVA", parametro.REPRESENTATIVA, DbType.Boolean);
            parameters.Add("@ID_FUENTE_FINANCIAMIENTO", parametro.ID_FUENTE_FINANCIAMIENTO, DbType.Int32);
            parameters.Add("@ID_UBIGEO", parametro.ID_UBIGEO, DbType.Int32);
            parameters.Add("@TIPO_UBIGEO", parametro.TIPO_UBIGEO, DbType.Int32);

            // Datos del trabajador y clasificador
            parameters.Add("@ID_TRABAJADOR", parametro.ID_TRABAJADOR, DbType.Int32);
            parameters.Add("@NOMBRE_TRABAJADOR", parametro.NOMBRE_TRABAJADOR, DbType.String);
            parameters.Add("@CARGO", parametro.CARGO, DbType.String);
            parameters.Add("@ID_CLASIFICADOR", parametro.ID_CLASIFICADOR, DbType.Int32);
            parameters.Add("@CODIGO_CLASIFICADOR", parametro.CODIGO_CLASIFICADOR, DbType.String);
            parameters.Add("@DESCRIPCION_CLASIFICADOR", parametro.DESCRIPCION_CLASIFICADOR, DbType.String);

            // Montos mensuales
            parameters.Add("@MONTO_ENERO", parametro.MONTO_ENERO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_FEBRERO", parametro.MONTO_FEBRERO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_MARZO", parametro.MONTO_MARZO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_ABRIL", parametro.MONTO_ABRIL ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_MAYO", parametro.MONTO_MAYO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_JUNIO", parametro.MONTO_JUNIO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_JULIO", parametro.MONTO_JULIO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_AGOSTO", parametro.MONTO_AGOSTO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_SETIEMBRE", parametro.MONTO_SETIEMBRE ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_OCTUBRE", parametro.MONTO_OCTUBRE ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_NOVIEMBRE", parametro.MONTO_NOVIEMBRE ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_DICIEMBRE", parametro.MONTO_DICIEMBRE ?? 0, DbType.Decimal);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", true, DbType.Boolean);
            parameters.Add("@IP_CREACION", parametro.ipCreacion, DbType.String);
            parameters.Add("@USUARIO_CREACION", parametro.usuarioCreacion, DbType.String);

            var identity = await DBConnection.Connection.ExecuteScalarAsync(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            if (identity != null)
            {
                result = Convert.ToInt32(identity);
            }

            return result;
        }

        public async Task<int> Actualizar(Planilla parametro)
        {
            const string sql = @"SC_SPP.MAESU_PROGRAMACION_PLANILLA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_PLANILLA", parametro.ID_PROGRAMACION_PLANILLA, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_RECURSO", parametro.ID_PROGRAMACION_RECURSO, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_TAREAS", parametro.ID_PROGRAMACION_TAREAS, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ID_ACTIVIDAD_OPERATIVA", parametro.ID_ACTIVIDAD_OPERATIVA, DbType.Int32);
            parameters.Add("@ID_TAREA", parametro.ID_TAREA, DbType.Int32);
            parameters.Add("@ID_UNIDAD_MEDIDA", parametro.ID_UNIDAD_MEDIDA, DbType.Int32);
            parameters.Add("@REPRESENTATIVA", parametro.REPRESENTATIVA, DbType.Boolean);
            parameters.Add("@ID_FUENTE_FINANCIAMIENTO", parametro.ID_FUENTE_FINANCIAMIENTO, DbType.Int32);
            parameters.Add("@ID_UBIGEO", parametro.ID_UBIGEO, DbType.Int32);
            parameters.Add("@TIPO_UBIGEO", parametro.TIPO_UBIGEO, DbType.Int32);

            // Datos del trabajador y clasificador
            parameters.Add("@ID_TRABAJADOR", parametro.ID_TRABAJADOR, DbType.Int32);
            parameters.Add("@NOMBRE_TRABAJADOR", parametro.NOMBRE_TRABAJADOR, DbType.String);
            parameters.Add("@CARGO", parametro.CARGO, DbType.String);
            parameters.Add("@ID_CLASIFICADOR", parametro.ID_CLASIFICADOR, DbType.Int32);
            parameters.Add("@CODIGO_CLASIFICADOR", parametro.CODIGO_CLASIFICADOR, DbType.String);
            parameters.Add("@DESCRIPCION_CLASIFICADOR", parametro.DESCRIPCION_CLASIFICADOR, DbType.String);

            // Montos mensuales
            parameters.Add("@MONTO_ENERO", parametro.MONTO_ENERO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_FEBRERO", parametro.MONTO_FEBRERO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_MARZO", parametro.MONTO_MARZO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_ABRIL", parametro.MONTO_ABRIL ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_MAYO", parametro.MONTO_MAYO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_JUNIO", parametro.MONTO_JUNIO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_JULIO", parametro.MONTO_JULIO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_AGOSTO", parametro.MONTO_AGOSTO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_SETIEMBRE", parametro.MONTO_SETIEMBRE ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_OCTUBRE", parametro.MONTO_OCTUBRE ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_NOVIEMBRE", parametro.MONTO_NOVIEMBRE ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_DICIEMBRE", parametro.MONTO_DICIEMBRE ?? 0, DbType.Decimal);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);

            result = await DBConnection.Connection.QuerySingleAsync<int>(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<int> Eliminar(Planilla parametro)
        {
            const string sql = @"SC_SPP.MAESD_PROGRAMACION_PLANILLA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_PLANILLA", parametro.ID_PROGRAMACION_PLANILLA, DbType.Int32);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);

            result = await DBConnection.Connection.QuerySingleAsync<int>(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}