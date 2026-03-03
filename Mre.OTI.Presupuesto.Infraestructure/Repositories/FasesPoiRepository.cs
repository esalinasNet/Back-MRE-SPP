using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.FasesPoi;
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
    public class FasesPoiRepository : IFasesPoiRepository
    {
        readonly DBConnection DBConnection;

        public FasesPoiRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(FasesPoi parametro)
        {
            var sql = @"SC_SPP.MAESU_FASESPOI";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_FASES_POI", parametro.ID_FASES_POI, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@CODIGO_FASES", parametro.CODIGO_FASES, DbType.String);
            parameters.Add("@DESCRIPCION_FASES", parametro.DESCRIPCION_FASES, DbType.String);

            parameters.Add("@ANIO_INICIAL", parametro.ANIO_INICIAL, DbType.Int32);
            parameters.Add("@ANIO_FINAL", parametro.ANIO_FINAL, DbType.Int32);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(FasesPoi parametro)
        {
            var sql = @"SC_SPP.MAESD_FASESPOI";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_FASES_POI", parametro.ID_FASES_POI, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(FasesPoi parametro)
        {
            var sql = @"SC_SPP.MAESI_FASESPOI";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@CODIGO_FASES", parametro.CODIGO_FASES, DbType.String);
            parameters.Add("@DESCRIPCION_FASES", parametro.DESCRIPCION_FASES, DbType.String);

            parameters.Add("@ANIO_INICIAL", parametro.ANIO_INICIAL, DbType.Int32);
            parameters.Add("@ANIO_FINAL", parametro.ANIO_FINAL, DbType.Int32);

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

        public async Task<ObtenerFasesPoiResponseDTO> ObtenerFasesPoi(ObtenerFasesPoiRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_FASESPOI";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_FASES_POI", request.idFasesPoi, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerFasesPoiResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerFasesPoiPaginadoResponseDTO>> ObtenerFasesPoiPaginado(ObtenerFasesPoiPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_FASESPOI";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@CODIGO_FASES", request.codigoFases, DbType.String);
            parameters.Add("@DESCRIPCION_FASES", request.descripcionFases, DbType.String);
            parameters.Add("@ANIO_INICIAL", request.anioInicial, DbType.Int32);
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);


            var result = await DBConnection.Connection.QueryAsync<ObtenerFasesPoiPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<ObtenerListadoFasesPoiResponseDTO>> ObtenerListadoFasesPoi(ObtenerListadoFasesPoiRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_FASESPOI";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoFasesPoiResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }
    }
}
