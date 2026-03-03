using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.Objetivos;
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
    public class AccionesRepository : IAccionesRepository
    {
        readonly DBConnection DBConnection;

        public AccionesRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(Acciones parametro)
        {
            var sql = @"SC_SPP.MAESU_ACCIONES";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ACCIONES", parametro.ID_ACCIONES, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@CODIGO_ACCIONES", parametro.CODIGO_ACCIONES, DbType.String);
            parameters.Add("@DESCRIPCION_ACCIONES", parametro.DESCRIPCION_ACCIONES, DbType.String);

            parameters.Add("@ID_OBJETIVOS", parametro.ID_OBJETIVOS, DbType.Int32);
            //parameters.Add("@CODIGO_OBJETIVOS", parametro.CODIGO_OBJETIVOS, DbType.String);
            //parameters.Add("@DESCRIPCION_OBJETIVOS", parametro.DESCRIPCION_OBJETIVOS, DbType.String);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(Acciones parametro)
        {
            var sql = @"SC_SPP.MAESD_ACCIONES";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ACCIONES", parametro.ID_ACCIONES, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(Acciones parametro)
        {
            var sql = @"SC_SPP.MAESI_ACCIONES";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@CODIGO_ACCIONES", parametro.CODIGO_ACCIONES, DbType.String);
            parameters.Add("@DESCRIPCION_ACCIONES", parametro.DESCRIPCION_ACCIONES, DbType.String);

            parameters.Add("@ID_OBJETIVOS", parametro.ID_OBJETIVOS, DbType.Int32);
            //parameters.Add("@CODIGO_OBJETIVOS", parametro.CODIGO_OBJETIVOS, DbType.String);
            //parameters.Add("@DESCRIPCION_OBJETIVOS", parametro.DESCRIPCION_OBJETIVOS, DbType.String);

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

        public async Task<ObtenerAccionesResponseDTO> ObtenerAcciones(ObtenerAccionesRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_ACCIONES";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ACCIONES", request.idAcciones, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerAccionesResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerAccionesPaginadoResponseDTO>> ObtenerAccionesPaginado(ObtenerAccionesPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_ACCIONES";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@CODIGO_ACCIONES", request.codigoAcciones, DbType.String);
            parameters.Add("@DESCRIPCION_ACCIONES", request.descripcionAcciones, DbType.String);
            parameters.Add("@CODIGO_OBJETIVOS", request.codigoObjetivos, DbType.String);
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerAccionesPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerCodigoAccionesResponseDTO> ObtenerCodigoAcciones(ObtenerCodigoAccionesRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_CODIGOACCIONES";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@CODIGO_ACCIONES", request.codigoAcciones, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCodigoAccionesResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerListadoAccionesResponseDTO>> ObtenerListadoAcciones(ObtenerListadoAccionesRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_ACCIONES";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoAccionesResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }
    }
}
