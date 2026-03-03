using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Finalidad;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionActividad;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class ProgramacionActividadRepository : IProgramacionActividadRepository
    {
        readonly DBConnection DBConnection;

        public ProgramacionActividadRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(ProgramacionActividad parametro)
        {
            var sql = @"SC_SPP.MAESU_PROGRAMACION_ACTIVIDADES";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", parametro.ID_PROGRAMACION_ACTIVIDAD, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@CODIGO_PROGRAMACION", parametro.CODIGO_PROGRAMACION, DbType.String);
            parameters.Add("@DENOMINACION", parametro.DENOMINACION, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            parameters.Add("@OBJETIVO_PRIORITARIO", parametro.OBJETIVO_PRIORITARIO, DbType.String);
            parameters.Add("@LINEAMIENTO", parametro.LINEAMIENTO, DbType.String);

            parameters.Add("@ID_POLITICAS", parametro.ID_POLITICAS, DbType.Int32);
            parameters.Add("@ID_OBJETIVOS_ESTRATEGICOS", parametro.ID_OBJETIVOS_ESTRATEGICOS, DbType.Int32);
            parameters.Add("@ID_ACCIONES_ESTRATEGICOS", parametro.ID_ACCIONES_ESTRATEGICOS, DbType.Int32);
            parameters.Add("@ID_OBJETIVOS_INSTITUCIONALES", parametro.ID_OBJETIVOS_INSTITUCIONALES, DbType.Int32);
            parameters.Add("@ID_ACCIONES_INSTITUCIONALES", parametro.ID_ACCIONES_INSTITUCIONALES, DbType.Int32);
            parameters.Add("@ID_CATEGORIA_PRESUPUESTAL", parametro.ID_CATEGORIA_PRESUPUESTAL, DbType.Int32);
            parameters.Add("@ID_PRODUCO_PROYECTO", parametro.ID_PRODUCO_PROYECTO, DbType.Int32);
            parameters.Add("@ID_FUNCION", parametro.ID_FUNCION, DbType.Int32);
            parameters.Add("@ID_DIVISION_FUNCIONAL", parametro.ID_DIVISION_FUNCIONAL, DbType.Int32);
            parameters.Add("@ID_GRUPO_FUNCIONAL", parametro.ID_GRUPO_FUNCIONAL, DbType.Int32);
            parameters.Add("@ID_ACTIVIDAD_PRESUPUESTAL", parametro.ID_ACTIVIDAD_PRESUPUESTAL, DbType.Int32);
            parameters.Add("@ID_FINALIDAD", parametro.ID_FINALIDAD, DbType.Int32);
            parameters.Add("@ID_UNIDAD_MEDIDA", parametro.ID_UNIDAD_MEDIDA, DbType.Int32);
            parameters.Add("@TIPO_UBIGEO", parametro.TIPO_UBIGEO, DbType.Int32);
            parameters.Add("@UBIGEO", parametro.UBIGEO, DbType.String);
            parameters.Add("@REGION", parametro.REGION, DbType.String);
            parameters.Add("@PAIS", parametro.PAIS, DbType.String);
            parameters.Add("@OSE", parametro.OSE, DbType.String);
            parameters.Add("@ID_MONEDA", parametro.ID_MONEDA, DbType.Int32);
            parameters.Add("@ACTIVIDAD_OPERATIVA", parametro.ACTIVIDAD_OPERATIVA, DbType.Int32);
            parameters.Add("@ACTIVIDAD_INVERSION", parametro.ACTIVIDAD_INVERSION, DbType.Int32);
            parameters.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.Int32);

            parameters.Add("@META_FISICA", parametro.META_FISICA, DbType.Int32);
            parameters.Add("@META_FINANCIERA", parametro.META_FINANCIERA, DbType.Decimal);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            if (result != null)
            {                
                var sql2 = @"SC_SPP.MAESU_APROBACIONES_COSTOS";

                var parameters2 = new DynamicParameters();
                parameters2.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);                
                parameters2.Add("@ID_PROGRAMACION_ACTIVIDAD", parametro.ID_PROGRAMACION_ACTIVIDAD, DbType.Int32);

                parameters2.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.Int32);

                parameters2.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);

                parameters2.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

                parameters2.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
                parameters2.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

                var result2 = await DBConnection.Connection.ExecuteAsync(sql2, parameters2, DBConnection.Transaction, commandType: CommandType.StoredProcedure);
                                
            }

            return result;
        }

        public async Task<int> ActualizarEstadosAprobados(ProgramacionActividad parametro)
        {
            var sql = @"SC_SPP.MAESU_PROGRAMACION_ACTIVIDADES_APROBACIONES";
            int result = 0;

            var parameters = new DynamicParameters();            
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.Int32);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> ActualizarObservado(ProgramacionActividad parametro)
        {
            var sql = @"SC_SPP.MAESU_PROGRAMACION_ACTIVIDADES_OBSERVADO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", parametro.ID_PROGRAMACION_ACTIVIDAD, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@CODIGO_PROGRAMACION", parametro.CODIGO_PROGRAMACION, DbType.String);
            parameters.Add("@OBSERVACION", parametro.OBSERVACION, DbType.String);
            
            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(ProgramacionActividad parametro)
        {
            var sql = @"SC_SPP.MAESD_PROGRAMACION_ACTIVIDADES";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", parametro.ID_PROGRAMACION_ACTIVIDAD, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(ProgramacionActividad parametro)
        {
            var sql = @"SC_SPP.MAESI_PROGRAMACION_ACTIVIDADES";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@CODIGO_PROGRAMACION", parametro.CODIGO_PROGRAMACION, DbType.String);
            parameters.Add("@DENOMINACION", parametro.DENOMINACION, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            parameters.Add("@OBJETIVO_PRIORITARIO", parametro.OBJETIVO_PRIORITARIO, DbType.String);
            parameters.Add("@LINEAMIENTO", parametro.LINEAMIENTO, DbType.String);

            parameters.Add("@ID_POLITICAS", parametro.ID_POLITICAS, DbType.Int32);
            parameters.Add("@ID_OBJETIVOS_ESTRATEGICOS", parametro.ID_OBJETIVOS_ESTRATEGICOS, DbType.Int32);
            parameters.Add("@ID_ACCIONES_ESTRATEGICOS", parametro.ID_ACCIONES_ESTRATEGICOS, DbType.Int32);
            parameters.Add("@ID_OBJETIVOS_INSTITUCIONALES", parametro.ID_OBJETIVOS_INSTITUCIONALES, DbType.Int32);
            parameters.Add("@ID_ACCIONES_INSTITUCIONALES", parametro.ID_ACCIONES_INSTITUCIONALES, DbType.Int32);
            parameters.Add("@ID_CATEGORIA_PRESUPUESTAL", parametro.ID_CATEGORIA_PRESUPUESTAL, DbType.Int32);
            parameters.Add("@ID_PRODUCO_PROYECTO", parametro.ID_PRODUCO_PROYECTO, DbType.Int32);
            parameters.Add("@ID_FUNCION", parametro.ID_FUNCION, DbType.Int32);
            parameters.Add("@ID_DIVISION_FUNCIONAL", parametro.ID_DIVISION_FUNCIONAL, DbType.Int32);
            parameters.Add("@ID_GRUPO_FUNCIONAL", parametro.ID_GRUPO_FUNCIONAL, DbType.Int32);
            parameters.Add("@ID_ACTIVIDAD_PRESUPUESTAL", parametro.ID_ACTIVIDAD_PRESUPUESTAL, DbType.Int32);
            parameters.Add("@ID_FINALIDAD", parametro.ID_FINALIDAD, DbType.Int32);
            parameters.Add("@ID_UNIDAD_MEDIDA", parametro.ID_UNIDAD_MEDIDA, DbType.Int32);
            parameters.Add("@TIPO_UBIGEO", parametro.TIPO_UBIGEO, DbType.Int32);
            parameters.Add("@UBIGEO", parametro.UBIGEO, DbType.String);
            parameters.Add("@REGION", parametro.REGION, DbType.String);
            parameters.Add("@PAIS", parametro.PAIS, DbType.String);
            parameters.Add("@OSE", parametro.OSE, DbType.String);
            parameters.Add("@ID_MONEDA", parametro.ID_MONEDA, DbType.Int32);
            parameters.Add("@ACTIVIDAD_OPERATIVA", parametro.ACTIVIDAD_OPERATIVA, DbType.Int32);
            parameters.Add("@ACTIVIDAD_INVERSION", parametro.ACTIVIDAD_INVERSION, DbType.Int32);
            parameters.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.Int32);

            parameters.Add("@META_FISICA", parametro.META_FISICA, DbType.Int32);
            parameters.Add("@META_FINANCIERA", parametro.META_FINANCIERA, DbType.Decimal);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);

            parameters.Add("@FECHA_CREACION", parametro.fechaCreacion, DbType.DateTime);
            parameters.Add("@USUARIO_CREACION", parametro.usuarioCreacion, DbType.String);
            parameters.Add("@IP_CREACION", parametro.ipCreacion, DbType.String);

            var identity = await DBConnection.Connection.ExecuteScalarAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            if (identity != null)
            {
                var ID_PROGRAMACION = identity;
                var sql2 = @"SC_SPP.MAESI_APROBACIONES";
                
                var parameters2 = new DynamicParameters();
                parameters2.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
                parameters2.Add("@ID_PROGRAMACION_ACTIVIDAD", ID_PROGRAMACION, DbType.Int32);

                parameters2.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.Int32);

                parameters2.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);

                parameters2.Add("@FECHA_CREACION", parametro.fechaCreacion, DbType.DateTime);
                parameters2.Add("@USUARIO_CREACION", parametro.usuarioCreacion, DbType.String);
                parameters2.Add("@IP_CREACION", parametro.ipCreacion, DbType.String);

                var identity2 = await DBConnection.Connection.ExecuteScalarAsync(sql2, parameters2, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

                result = Convert.ToInt32(identity);
            }

            return result;
        }

        public async Task<ObtenerCodigoProgramacionActividadResponseDTO> ObtenerCodigoProgramacionActividad(ObtenerCodigoProgramacionActividadRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_CODIGO_PROGRAMACION_ACTIVIDADES";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@CODIGO_PROGRAMACION", request.codigoProgramacion, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCodigoProgramacionActividadResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerListadoProgramacionActividadResponseDTO>> ObtenerListadoProgramacionActividad(ObtenerListadoProgramacionActividadRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PROGRAMACION_ACTIVIDADES";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoProgramacionActividadResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }

        public async Task<ObtenerProgramacionActividadResponseDTO> ObtenerProgramacionActividad(ObtenerProgramacionActividadRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_PROGRAMACION_ACTIVIDADES";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_ACTIVIDAD", request.idProgramacionActividad, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerProgramacionActividadResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<ObtenerProgramacionActividadAniosResponseDTO> ObtenerProgramacionActividadAnios(ObtenerProgramacionActividadAniosRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_PROGRAMACION_CODIGO_ACTIVIDAD_POR_ANIO";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerProgramacionActividadAniosResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async  Task<IEnumerable<ObtenerProgramacionActividadCentroCostosResponseDTO>> ObtenerProgramacionActividadCentroCostos(ObtenerProgramacionActividadCentroCostosRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_PROGRAMACION_ACTIVIDADES_CENTROCOSTOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@ID_CENTRO_COSTOS", request.idCentroCostos, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerProgramacionActividadCentroCostosResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerProgramacionActividadPaginadoResponseDTO>> ObtenerProgramacionActividadPaginado(ObtenerProgramacionActividadPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_PROGRAMACION_ACTIVIDADES";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@CODIGO_PROGRAMACION", request.codigoProgramacion, DbType.String);
            parameters.Add("@ID_CENTRO_COSTOS", request.idCentroCostos, DbType.Int32);
            parameters.Add("@DENOMINACION", request.denominacion, DbType.String);
            parameters.Add("@DESCRIPCION", request.descripcion, DbType.String);

            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerProgramacionActividadPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

    }
}
