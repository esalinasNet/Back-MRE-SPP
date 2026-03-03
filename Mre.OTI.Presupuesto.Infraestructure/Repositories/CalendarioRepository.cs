using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Calendario;
using Mre.OTI.Presupuesto.Application.DTO.CentroCostos;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
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
    public class CalendarioRepository : ICalendarioRepository
    {
        readonly DBConnection DBConnection;

        public CalendarioRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<IEnumerable<ObtenerCalendarioPaginadoResponseDTO>> ObtenerCalendarioPaginado(ObtenerCalendarioPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_CALENDARIO";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@MESDESCRIPCION", request.mesDescripcion, DbType.String);
            parameters.Add("@CENTRO_COSTOS", request.centroCostos, DbType.String);
            //parameters.Add("@ESTADO", request.estado, DbType.Int32);
            //parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);


            var result = await DBConnection.Connection.QueryAsync<ObtenerCalendarioPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerCalendarioResponseDTO> ObtenerCalendario(ObtenerCalendarioRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_CALENDARIO";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PERIODO", request.idPeriodo, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCalendarioResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<int> Guardar(Calendario parametro)
        {
            var sql = @"SC_SPP.MAESI_CALENDARIO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ID_MES", parametro.ID_MES, DbType.Int32);
            parameters.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.String);
            parameters.Add("@FECHAINICIO", parametro.FECHAINICIO?.Date, DbType.Date);
            parameters.Add("@FECHAFIN", parametro.FECHAFIN?.Date, DbType.Date);
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

        public async Task<int> Actualizar(Calendario parametro)
        {
            var sql = @"SC_SPP.MAESU_CALENDARIO";
            int result = 0;

            var parameters = new DynamicParameters();            
            parameters.Add("@ID_PERIODO", parametro.ID_PERIODO, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ID_MES", parametro.ID_MES, DbType.Int32);
            parameters.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.Int32);
            parameters.Add("@FECHAINICIO", parametro.FECHAINICIO?.Date, DbType.Date);
            parameters.Add("@FECHAFIN", parametro.FECHAFIN?.Date, DbType.Date);
            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(Calendario parametro)
        {
            var sql = @"SC_SPP.MAESD_CALENDARIO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PERIODO", parametro.ID_PERIODO, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<ObtenerListadoCalendarioResponseDTO>> ObtenerListadoCalendario()
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_CALENDARIO";

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoCalendarioResponseDTO>(sql, null, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
