using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Viaticos;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class ViaticosRepository : IViaticosRepository
    {
        readonly DBConnection DBConnection;

        public ViaticosRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<IEnumerable<ObtenerListadoViaticosResponseDTO>> ObtenerListadoViaticos(ObtenerListadoViaticosRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PROGRAMACION_VIATICOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_RECURSO", request.idProgramacionRecurso, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_TAREAS", request.idProgramacionTareas, DbType.Int32);
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoViaticosResponseDTO>(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<IEnumerable<ObtenerViaticoPaginadoResponseDTO>> ObtenerViaticoPaginado(ObtenerViaticoPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_PAGINADO_PROGRAMACION_VIATICOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_RECURSO", request.idProgramacionRecurso, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_TAREAS", request.idProgramacionTareas, DbType.Int32);
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@TIPO_UBIGEO", request.tipoUbigeo, DbType.Int32);
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerViaticoPaginadoResponseDTO>(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<ObtenerViaticoPorIdResponseDTO> ObtenerViaticoPorId(int idProgramacionViaticos, string usuarioConsulta)
        {
            const string sql = @"SC_SPP.MAESS_OBTENERID_PROGRAMACION_VIATICOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_VIATICOS", idProgramacionViaticos, DbType.Int32);

            var result = await DBConnection.Connection.QueryFirstOrDefaultAsync<ObtenerViaticoPorIdResponseDTO>(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<int> Guardar(Viaticos parametro)
        {
            const string sql = @"SC_SPP.MAESI_PROGRAMACION_VIATICOS";
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

            // ✅ Campos específicos de Viáticos
            parameters.Add("@CLASIFICADOR_GASTO", parametro.CLASIFICADOR_GASTO, DbType.Int32);
            parameters.Add("@DENOMINACION_RECURSO", parametro.DENOMINACION_RECURSO, DbType.String);
            parameters.Add("@MONTO_DIARIO", parametro.MONTO_DIARIO, DbType.Decimal);
            parameters.Add("@DIAS", parametro.DIAS, DbType.Int32);
            parameters.Add("@CANTIDAD_PERSONAS", parametro.CANTIDAD_PERSONAS, DbType.Int32);

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

        public async Task<int> Actualizar(Viaticos parametro)
        {
            const string sql = @"SC_SPP.MAESU_PROGRAMACION_VIATICOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_VIATICOS", parametro.ID_PROGRAMACION_VIATICOS, DbType.Int32);
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

            // ✅ Campos específicos de Viáticos
            parameters.Add("@CLASIFICADOR_GASTO", parametro.CLASIFICADOR_GASTO, DbType.Int32);
            parameters.Add("@DENOMINACION_RECURSO", parametro.DENOMINACION_RECURSO, DbType.String);
            parameters.Add("@MONTO_DIARIO", parametro.MONTO_DIARIO, DbType.Decimal);
            parameters.Add("@DIAS", parametro.DIAS, DbType.Int32);
            parameters.Add("@CANTIDAD_PERSONAS", parametro.CANTIDAD_PERSONAS, DbType.Int32);

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

        public async Task<int> Eliminar(Viaticos parametro)
        {
            const string sql = @"SC_SPP.MAESD_PROGRAMACION_VIATICOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_VIATICOS", parametro.ID_PROGRAMACION_VIATICOS, DbType.Int32);
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