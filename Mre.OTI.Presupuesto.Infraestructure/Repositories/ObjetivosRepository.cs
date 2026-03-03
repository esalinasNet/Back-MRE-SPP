using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Objetivos;
using Mre.OTI.Presupuesto.Application.DTO.Politicas;
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
    public class ObjetivosRepository : IOjetivosRepository
    {
        readonly DBConnection DBConnection;

        public ObjetivosRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(Objetivos parametro)
        {
            var sql = @"SC_SPP.MAESU_OBJETIVOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_OBJETIVOS", parametro.ID_OBJETIVOS, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@CODIGO_OBJETIVOS", parametro.CODIGO_OBJETIVOS, DbType.String);
            parameters.Add("@DESCRIPCION_OBJETIVOS", parametro.DESCRIPCION_OBJETIVOS, DbType.String);

            parameters.Add("@ID_POLITICAS", parametro.ID_POLITICAS, DbType.Int32);
            //parameters.Add("@CODIGO_PRIORITARIOS", parametro.CODIGO_PRIORITARIOS, DbType.String);
            //parameters.Add("@DESCRIPCION_PRIORITARIOS", parametro.DESCRIPCION_PRIORITARIOS, DbType.String);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(Objetivos parametro)
        {
            var sql = @"SC_SPP.MAESD_OBJETIVOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_OBJETIVOS", parametro.ID_OBJETIVOS, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(Objetivos parametro)
        {
            var sql = @"SC_SPP.MAESI_OBJETIVOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@CODIGO_OBJETIVOS", parametro.CODIGO_OBJETIVOS, DbType.String);
            parameters.Add("@DESCRIPCION_OBJETIVOS", parametro.DESCRIPCION_OBJETIVOS, DbType.String);

            parameters.Add("@ID_POLITICAS", parametro.ID_POLITICAS, DbType.Int32);
            //parameters.Add("@CODIGO_PRIORITARIOS", parametro.CODIGO_PRIORITARIOS, DbType.String);
            //parameters.Add("@DESCRIPCION_PRIORITARIOS", parametro.DESCRIPCION_PRIORITARIOS, DbType.String);

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

        public async Task<ObtenerCodigoObjetivosResponseDTO> ObtenerCodigoObjetivos(ObtenerCodigoObjetivosRequestDTO request)
        {
             const string sql = @"SC_SPP.MAESS_OBTENER_CODIGOOBJETIVOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@CODIGO_OBJETIVOS", request.codigoObjetivos, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCodigoObjetivosResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerListadoObjetivosResponseDTO>> ObtenerListadoObjetivos(ObtenerListadoObjetivosRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_OBJETIVOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoObjetivosResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }

        public async Task<ObtenerObjetivosResponseDTO> ObtenerObjetivos(ObtenerObjetivosRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_OBJETIVOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_OBJETIVOS", request.idObjetivos, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerObjetivosResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerObjetivosPaginadoResponseDTO>> ObtenerObjetivosPaginado(ObtenerObjetivosPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_OBJETIVOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@CODIGO_OBJETIVOS", request.codigoObjetivos, DbType.String);
            parameters.Add("@DESCRIPCION_OBJETIVOS", request.descripcionObjetivos, DbType.String);
            parameters.Add("@CODIGO_PRIORITARIOS", request.codigoPrioritarios, DbType.String);
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);


            var result = await DBConnection.Connection.QueryAsync<ObtenerObjetivosPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
