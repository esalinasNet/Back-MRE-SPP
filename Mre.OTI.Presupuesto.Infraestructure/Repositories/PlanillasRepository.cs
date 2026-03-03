using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Planillas;
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
    public class PlanillasRepository : IPlanillasRepository
    {
        readonly DBConnection DBConnection;

        public PlanillasRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(Planillas parametro)
        {
            var sql = @"SC_SPP.MAESU_PLANILLA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PLANILLA", parametro.ID_PLANILLA, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ID_MES", parametro.ID_MES, DbType.Int32);

            parameters.Add("@ID_PROGRAMA", parametro.ID_PROGRAMA, DbType.Int32);
            parameters.Add("@ID_PRODUCTO", parametro.ID_PRODUCTO, DbType.Int32);
            parameters.Add("@ID_ACTIVIDAD", parametro.ID_ACTIVIDAD, DbType.Int32);
            parameters.Add("@META", parametro.META, DbType.Int32);
            parameters.Add("@ID_FINALIDAD", parametro.ID_FINALIDAD, DbType.Int32);
            parameters.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.Int32);

            parameters.Add("@TIPO_DOCUMENTO", parametro.TIPO_DOCUMENTO, DbType.Int32);
            parameters.Add("@NRO_DOCUMENTO", parametro.NRO_DOCUMENTO, DbType.String);
            parameters.Add("@APELLIDOSNOMBRES", parametro.APELLIDOSNOMBRES, DbType.String);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(Planillas parametro)
        {
            var sql = @"SC_SPP.MAESD_PLANILLA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PLANILLA", parametro.ID_PLANILLA, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(Planillas parametro)
        {
            var sql = @"SC_SPP.MAESI_PLANILLA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PLANILLA", parametro.ID_PLANILLA, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ID_MES", parametro.ID_MES, DbType.Int32);

            parameters.Add("@ID_PROGRAMA", parametro.ID_PROGRAMA, DbType.Int32);
            parameters.Add("@ID_PRODUCTO", parametro.ID_PRODUCTO, DbType.Int32);
            parameters.Add("@ID_ACTIVIDAD", parametro.ID_ACTIVIDAD, DbType.Int32);
            parameters.Add("@META", parametro.META, DbType.Int32);
            parameters.Add("@ID_FINALIDAD", parametro.ID_FINALIDAD, DbType.Int32);
            parameters.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.Int32);

            parameters.Add("@TIPO_DOCUMENTO", parametro.TIPO_DOCUMENTO, DbType.Int32);
            parameters.Add("@NRO_DOCUMENTO", parametro.NRO_DOCUMENTO, DbType.String);
            parameters.Add("@APELLIDOSNOMBRES", parametro.APELLIDOSNOMBRES, DbType.String);

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

        public async Task<ObtenerPlanillasResponseDTO> ObtenerPlanillas(ObtenerPlanillasRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_PLANILLA";

            var parameters = new DynamicParameters();            
            parameters.Add("@ID_PLANILLA", request.idPlanillas, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerPlanillasResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerPlanillasPaginadoResponseDTO>> ObtenerPlanillasPaginado(ObtenerPlanillasPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_PLANILLA";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@NRO_DOCUMENTO", request.nroDocumento, DbType.String);
            parameters.Add("@APELLIDOSNOMBRES", request.apellidosNombres, DbType.String);            
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerPlanillasPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerCodigoPlanillasResponseDTO> ObtenerCodigoPlanillas(ObtenerCodigoPlanillasRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_DOCUMENTO_PLANILLA";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@MES", request.Mes, DbType.Int32);
            parameters.Add("@NRO_DOCUMENTO", request.nroDocumento, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCodigoPlanillasResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerListadoPlanillasResponseDTO>> ObtenerListadoPlanillas(ObtenerListadoPlanillasRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PLANILLA";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);
            parameters.Add("@ID_MES", request.idMes, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoPlanillasResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }
    }
}
