using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Actividad;
using Mre.OTI.Presupuesto.Application.DTO.Actividad;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mre.OTI.Presupuesto.Application.Util.VariablesGlobales;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class ActividadRepository : IActividadRepository
    {
        readonly DBConnection DBConnection;

        public ActividadRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(Actividad parametro)
        {
            var sql = @"SC_SPP.MAESU_ACTIVIDAD";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ACTIVIDAD", parametro.ID_ACTIVIDAD, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ACTIVIDAD", parametro.ACTIVIDAD, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(Actividad parametro)
        {
            var sql = @"SC_SPP.MAESD_ACTIVIDAD";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ACTIVIDAD", parametro.ID_ACTIVIDAD, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(Actividad parametro)
        {
            var sql = @"SC_SPP.MAESI_ACTIVIDAD";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ACTIVIDAD", parametro.ACTIVIDAD, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
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

        public async Task<ObtenerActividadResponseDTO> ObtenerActividad(int idActividad)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_ACTIVIDAD";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ACTIVIDAD", idActividad, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerActividadResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerActividadPaginadoResponseDTO>> ObtenerActividadPaginado(ObtenerActividadPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_ACTIVIDAD";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.Anio, DbType.String);
            parameters.Add("@ACTIVIDAD", request.actividad, DbType.String);
            parameters.Add("@DESCRIPCION", request.descripcion, DbType.String);
            //parameters.Add("@ESTADO", request.estado, DbType.Int32);
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);


            var result = await DBConnection.Connection.QueryAsync<ObtenerActividadPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<ObtenerListadoActividadResponseDTO>> ObtenerListadoActividad(ObtenerListadoActividadRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_ACTIVIDAD";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoActividadResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }
    }
}
