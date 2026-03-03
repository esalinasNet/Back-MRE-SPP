using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Cmn;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class CmnRepository : ICmnRepository
    {
        readonly DBConnection DBConnection;

        public CmnRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<IEnumerable<ObtenerListadoCmnResponseDTO>> ObtenerListadoCmn(ObtenerListadoCmnRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_PROGRAMACION_CMN";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_RECURSO", request.idProgramacionRecurso, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_TAREAS", request.idProgramacionTareas, DbType.Int32);
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);
            parameters.Add("@ACTIVO", true, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoCmnResponseDTO>(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<IEnumerable<ObtenerCmnPaginadoResponseDTO>> ObtenerCmnPaginado(ObtenerCmnPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_PAGINADO_PROGRAMACION_CMN";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_RECURSO", request.idProgramacionRecurso, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_TAREAS", request.idProgramacionTareas, DbType.Int32);
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@TIPO_UBIGEO", request.tipoUbigeo, DbType.Int32);
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCmnPaginadoResponseDTO>(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<ObtenerCmnPorIdResponseDTO> ObtenerCmnPorId(int idProgramacionCmn, string usuarioConsulta)
        {
            const string sql = @"SC_SPP.MAESS_OBTENERID_PROGRAMACION_CMN";

            var parameters = new DynamicParameters();
            parameters.Add("@IdProgramacionCmn", idProgramacionCmn, DbType.Int32);
            parameters.Add("@UsuarioConsulta", usuarioConsulta, DbType.String);

            var result = await DBConnection.Connection.QueryFirstOrDefaultAsync<ObtenerCmnPorIdResponseDTO>(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<int> Guardar(Cmn parametro)
        {
            const string sql = @"SC_SPP.MAESI_PROGRAMACION_CMN";
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

        public async Task<int> Actualizar(Cmn parametro)
        {
            const string sql = @"SC_SPP.MAESU_PROGRAMACION_CMN";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_CMN", parametro.ID_PROGRAMACION_CMN, DbType.Int32);
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

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Boolean);
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

        public async Task<int> Eliminar(Cmn parametro)
        {
            const string sql = @"SC_SPP.MAESD_PROGRAMACION_CMN";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_CMN", parametro.ID_PROGRAMACION_CMN, DbType.Int32);
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