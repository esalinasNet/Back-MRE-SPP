using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.AeiCentroCostos;
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
    public class AeiCentroCostosRepository : IAeiCentroCostosRepository
    {
        readonly DBConnection DBConnection;

        public AeiCentroCostosRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public Task<EliminaAeiCentroCostosResponseDTO> EliminaAeiCentroCostos(EliminaAeiCentroCostosRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Eliminar(AeiCentroCostos parametro)
        {
            var sql = @"SC_SPP.MAESD_AEI_CENTRO_COSTOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ID_ACCIONES", parametro.ID_ACCIONES, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(AeiCentroCostos parametro)
        {
            var sql = @"SC_SPP.MAESI_AEI_CENTRO_COSTOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@ID_ACCIONES", parametro.ID_ACCIONES, DbType.Int32);

            parameters.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.Int32);

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

        /*public async Task<ObtenerAeiCentroCostosResponseDTO> ObtenerAeiCentroCostos(ObtenerAeiCentroCostosRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_AEI_CENTRO_COSTOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);
            parameters.Add("@ID_ACCIONES", request.idAcciones, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerAeiCentroCostosResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }*/

        public async Task<IEnumerable<ObtenerAeiCentroCostosResponseDTO>> ObtenerAeiCentroCostos(ObtenerAeiCentroCostosRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_AEI_CENTRO_COSTOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);
            parameters.Add("@ID_ACCIONES", request.idAcciones, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerAeiCentroCostosResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.OrderBy(x => x.idCentroCostos).ThenBy(x => x.idCentroCostos);
        }

        public async Task<IEnumerable<ObtenerAeiCentroCostosPaginadoResponseDTO>> ObtenerAeiCentroCostosPaginado(ObtenerAeiCentroCostosPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_AEI_CENTRO_COSTOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);
            parameters.Add("@ID_ACCIONES", request.idAcciones, DbType.Int32);
            parameters.Add("@CODIGO_ACCIONES", request.codigoAcciones, DbType.String);
            parameters.Add("@DESCRIPCION_ACCIONES", request.descripcionAcciones, DbType.String);

            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerAeiCentroCostosPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
