using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Recurso;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class RecursoRepository : IRecursoRepository
    {
        readonly DBConnection DBConnection;

        public RecursoRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<IEnumerable<ObtenerListadoRecursoResponseDTO>> ObtenerListadoRecurso(ObtenerListadoRecursoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PROGRAMACION_RECURSOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_TAREAS", request.idProgramacionTareas, DbType.Int32);
            parameters.Add("@USUARIO_CONSULTA", request.usuarioConsulta, DbType.String); // ✅ AGREGADO

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoRecursoResponseDTO>(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            return result ?? Enumerable.Empty<ObtenerListadoRecursoResponseDTO>();
        }

        // ✅ NUEVO: Método de Paginado
        public async Task<IEnumerable<ObtenerRecursoPaginadoResponseDTO>> ObtenerRecursoPaginado(ObtenerRecursoPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_PAGINADO_PROGRAMACION_RECURSOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", request.idProgramacionActividad, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_TAREAS", request.idProgramacionTareas, DbType.Int32);
            parameters.Add("@CODIGO_TAREAS", request.codigoTareas, DbType.String);
            parameters.Add("@DESCRIPCION_TAREAS", request.descripcionTareas, DbType.String);
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerRecursoPaginadoResponseDTO>(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<int> Guardar(Recurso parametro)
        {
            var sql = @"SC_SPP.MAESI_PROGRAMACION_RECURSOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", parametro.ID_PROGRAMACION_ACTIVIDAD, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_TAREAS", parametro.ID_PROGRAMACION_TAREAS, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ID_UBIGEO", parametro.ID_UBIGEO, DbType.Int32);
            parameters.Add("@CLASIFICADOR_GASTO", parametro.CLASIFICADOR_GASTO, DbType.String);
            parameters.Add("@DENOMINACION_RECURSO", parametro.DENOMINACION_RECURSO, DbType.String);
            parameters.Add("@ID_TIPO_GASTO", parametro.ID_TIPO_GASTO, DbType.Int32);
            parameters.Add("@ID_TIPO_ITEM", parametro.ID_TIPO_ITEM, DbType.Int32);
            parameters.Add("@MONTO_TOTAL", parametro.MONTO_TOTAL, DbType.Decimal);
            parameters.Add("@ID_FUENTE_FINANCIAMIENTO", parametro.ID_FUENTE_FINANCIAMIENTO, DbType.Int32);
            parameters.Add("@ID_UNIDAD_MEDIDA", parametro.ID_UNIDAD_MEDIDA, DbType.Int32);
            parameters.Add("@REPRESENTATIVA", parametro.REPRESENTATIVA, DbType.Boolean);
            parameters.Add("@GASTO_OBN", parametro.GASTO_OBN, DbType.Boolean);
            parameters.Add("@GASTO_PROYECTO", parametro.GASTO_PROYECTO, DbType.Boolean);
            parameters.Add("@GASTO_VIATICOS", parametro.GASTO_VIATICOS, DbType.Boolean);
            parameters.Add("@GASTO_CAJA_CHICA", parametro.GASTO_CAJA_CHICA, DbType.Boolean);
            parameters.Add("@GASTO_OTROS_GASTOS", parametro.GASTO_OTROS_GASTOS, DbType.Boolean);
            parameters.Add("@GASTO_ENCARGAS", parametro.GASTO_ENCARGAS, DbType.Boolean);
            parameters.Add("@GASTO_PLANILLA", parametro.GASTO_PLANILLA, DbType.Boolean);
            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", 1, DbType.Boolean);
            parameters.Add("@IP_CREACION", parametro.ipCreacion, DbType.String);
            parameters.Add("@USUARIO_CREACION", parametro.usuarioCreacion, DbType.String);

            var identity = await DBConnection.Connection.ExecuteScalarAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            if (identity != null)
            {
                result = Convert.ToInt32(identity);
            }

            return result;
        }

        public async Task<int> Actualizar(Recurso parametro)
        {
            var sql = @"SC_SPP.MAESU_PROGRAMACION_RECURSOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_RECURSO", parametro.ID_PROGRAMACION_RECURSO, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", parametro.ID_PROGRAMACION_ACTIVIDAD, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_TAREAS", parametro.ID_PROGRAMACION_TAREAS, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ID_UBIGEO", parametro.ID_UBIGEO, DbType.Int32);
            parameters.Add("@CLASIFICADOR_GASTO", parametro.CLASIFICADOR_GASTO, DbType.String);
            parameters.Add("@DENOMINACION_RECURSO", parametro.DENOMINACION_RECURSO, DbType.String);
            parameters.Add("@ID_TIPO_GASTO", parametro.ID_TIPO_GASTO, DbType.Int32);
            parameters.Add("@ID_TIPO_ITEM", parametro.ID_TIPO_ITEM, DbType.Int32);
            parameters.Add("@MONTO_TOTAL", parametro.MONTO_TOTAL, DbType.Decimal);
            parameters.Add("@ID_FUENTE_FINANCIAMIENTO", parametro.ID_FUENTE_FINANCIAMIENTO, DbType.Int32);
            parameters.Add("@ID_UNIDAD_MEDIDA", parametro.ID_UNIDAD_MEDIDA, DbType.Int32);
            parameters.Add("@REPRESENTATIVA", parametro.REPRESENTATIVA, DbType.Boolean);
            parameters.Add("@GASTO_OBN", parametro.GASTO_OBN, DbType.Boolean);
            parameters.Add("@GASTO_PROYECTO", parametro.GASTO_PROYECTO, DbType.Boolean);
            parameters.Add("@GASTO_VIATICOS", parametro.GASTO_VIATICOS, DbType.Boolean);
            parameters.Add("@GASTO_CAJA_CHICA", parametro.GASTO_CAJA_CHICA, DbType.Boolean);
            parameters.Add("@GASTO_OTROS_GASTOS", parametro.GASTO_OTROS_GASTOS, DbType.Boolean);
            parameters.Add("@GASTO_ENCARGAS", parametro.GASTO_ENCARGAS, DbType.Boolean);
            parameters.Add("@GASTO_PLANILLA", parametro.GASTO_PLANILLA, DbType.Boolean);
            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Boolean);
            parameters.Add("@IP_CREACION", parametro.ipModificacion, DbType.String);
            parameters.Add("@USUARIO_CREACION", parametro.usuarioModificacion, DbType.String);

            result = await DBConnection.Connection.QuerySingleAsync<int>(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }


        public async Task<int> Eliminar(Recurso parametro)
        {
            var sql = @"SC_SPP.MAESD_PROGRAMACION_RECURSOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_RECURSO", parametro.ID_PROGRAMACION_RECURSO, DbType.Int32);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);

            result = await DBConnection.Connection.QuerySingleAsync<int>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerRecursoPorIdResponseDTO> ObtenerRecursoPorId(int idProgramacionRecurso, string usuarioConsulta)
        {
            var sql = @"SC_SPP.MAESS_OBTENERID_PROGRAMACION_RECURSOS";
            var parameters = new DynamicParameters();
            parameters.Add("@IdProgramacionRecurso", idProgramacionRecurso, DbType.Int32);
            parameters.Add("@UsuarioConsulta", usuarioConsulta, DbType.String);

            var result = await DBConnection.Connection.QueryFirstOrDefaultAsync<ObtenerRecursoPorIdResponseDTO>(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}