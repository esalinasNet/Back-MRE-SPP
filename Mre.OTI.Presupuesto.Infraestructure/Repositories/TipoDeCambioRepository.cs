using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.TipoDeCambio;
using Mre.OTI.Presupuesto.Application.DTO.Ubigeo;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class TipoDeCambioRepository : ITipoDeCambioRepository
    {
        readonly DBConnection DBConnection;

        public TipoDeCambioRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<IEnumerable<ObtenerTipoDeCambioPaginadoResponseDTO>> ObtenerTipoDeCambioPaginado(ObtenerTipoDeCambioPaginadoRequestDTO request)
        {

            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_TIPODECAMBIO";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@CODIGO_ISO", request.codigoIso, DbType.String);
            parameters.Add("@NOMBRE", request.nombre, DbType.String);
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);

            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerTipoDeCambioPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<ObtenerListadoTipoDeCambioResponseDTO>> ObtenerListadoTipoDeCambio(ObtenerListadoTipoDeCambioRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_TIPODECAMBIO";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoTipoDeCambioResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }

        public async Task<int> Guardar(TipoDeCambio parametro)
        {
            var sql = @"SC_SPP.MAESI_TIPODECAMBIO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@CODIGO_ISO", parametro.CODIGO_ISO, DbType.String);
            parameters.Add("@NOMBRE", parametro.NOMBRE, DbType.String);            
            parameters.Add("@VALOR", parametro.VALOR, DbType.Decimal);

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

        public async Task<int> Actualizar(TipoDeCambio parametro)
        {
            int activo = parametro.ACTIVO == true ? 1 : 0;

            var sql = @"SC_SPP.MAESU_TIPODECAMBIO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_MONEDA", parametro.ID_MONEDA, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@CODIGO_ISO", parametro.CODIGO_ISO, DbType.String);
            parameters.Add("@NOMBRE", parametro.NOMBRE, DbType.String);
            
            parameters.Add("@VALOR", parametro.VALOR, DbType.Decimal);
            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerTipoDeCambioResponseDTO> ObtenerTipoDeCambio(ObtenerTipoDeCambioRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_TIPODECAMBIO";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_MONEDA", request.idMoneda, DbType.Int32);
            
            var result = await DBConnection.Connection.QueryAsync<ObtenerTipoDeCambioResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerTipoDeCambioMonedaResponseDTO>> ObtenerListadoTipoDeCambioMoneda(ObtenerTipoDeCambioMonedaRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_TIPOCAMBIO_MONEDA";

            var parameters = new DynamicParameters();            
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);
            parameters.Add("@CODIGO_ISO", request.codigoIso, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerTipoDeCambioMonedaResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }
    }
}
