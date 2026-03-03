using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Actividad;
using Mre.OTI.Presupuesto.Application.DTO.BienesServicios;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class BienesServiciosRepository : IBienesServiciosRepository
    {
        readonly DBConnection DBConnection;

        public BienesServiciosRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(BienesServicios parametro)
        {
            var sql = @"SC_SPP.MAESU_BIENES_SERVICIOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_BIENES_SERVICIOS", parametro.ID_BIENES_SERVICIOS, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@ITEM_BIEN", parametro.ITEM_BIEN, DbType.String);
            parameters.Add("@DENOMINACION_ITEM", parametro.DENOMINACION_ITEM, DbType.String);
            parameters.Add("@TIPO_ITEMS", parametro.TIPO_ITEMS, DbType.String);

            parameters.Add("@ID_UNIDADMEDIDA", parametro.ID_UNIDADMEDIDA, DbType.String);

            parameters.Add("@PRECIO", parametro.PRECIO, DbType.String);

            parameters.Add("@ID_CLASIFICADOR", parametro.ID_CLASIFICADOR, DbType.String);
            //parameters.Add("@DENOMINACION_EEGG", parametro.DENOMINACION_EEGG, DbType.String);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(BienesServicios parametro)
        {
            var sql = @"SC_SPP.MAESD_BIENES_SERVICIOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_BIENES_SERVICIOS", parametro.ID_BIENES_SERVICIOS, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(BienesServicios parametro)
        {
            var sql = @"SC_SPP.MAESI_BIENES_SERVICIOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@ITEM_BIEN", parametro.ITEM_BIEN, DbType.String);
            parameters.Add("@DENOMINACION_ITEM", parametro.DENOMINACION_ITEM, DbType.String);
            parameters.Add("@TIPO_ITEMS", parametro.TIPO_ITEMS, DbType.String);

            parameters.Add("@@ID_UNIDADMEDIDA", parametro.ID_UNIDADMEDIDA, DbType.String);

            parameters.Add("@PRECIO", parametro.PRECIO, DbType.String);

            parameters.Add("@ID_CLASIFICADOR", parametro.ID_CLASIFICADOR, DbType.String);
            //parameters.Add("@DENOMINACION_EEGG", parametro.DENOMINACION_EEGG, DbType.String);

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

        public async Task<ObtenerBienesServiciosResponseDTO> ObtenerBienesServicios(ObtenerBienesServiciosRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_BIENES_SERVICIOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_BIENES_SERVICIOS", request.idBienesServicios, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerBienesServiciosResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerBienesServiciosPaginadoResponseDTO>> ObtenerBienesServiciosPaginado(ObtenerBienesServiciosPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_BIENES_SERVICIOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.String);
            parameters.Add("@ITEM_BIEN", request.codigoBien, DbType.String);
            parameters.Add("@TIPO_ITEMS", request.tipoItems, DbType.String);
            parameters.Add("@DENOMINACION_ITEM", request.nombreBien, DbType.String);            
            //parameters.Add("@ESTADO", request.estado, DbType.Int32);
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);


            var result = await DBConnection.Connection.QueryAsync<ObtenerBienesServiciosPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<ObtenerListadoBienesServiciosResponseDTO>> ObtenerListadoBienesServicios(ObtenerListadoBienesServiciosRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_BIENES_SERVICIOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoBienesServiciosResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }

        public async Task<IEnumerable<ObtenerListadoBienesServiciosGrupoBienResponseDTO>> ObtenerListadoBienesServiciosGrupoBien(ObtenerListadoBienesServiciosGrupoBienRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_BIENES_SERVICIOS_GRUPO_BIEN";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);
            parameters.Add("@GRUPO_BIEN", request.grupoBien, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoBienesServiciosGrupoBienResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda
        }

        public async Task<IEnumerable<ObtenerListadoBienesServiciosTipoItemsResponseDTO>> ObtenerListadoBienesServiciosTipoItems(ObtenerListadoBienesServiciosTipoItemsRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_BIENES_SERVICIOS_TIPO_ITEMS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);
            parameters.Add("@TIPO_ITEMS", request.tipoItems, DbType.String);
            parameters.Add("@CLASIFICADOR", request.clasificadorGasto, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoBienesServiciosTipoItemsResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }

        public async Task<IEnumerable<ObtenerListadoGrupoBienesServiciosResponseDTO>> ObtenerListadoGrupoBienesServicios(ObtenerListadoGrupoBienesServiciosRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_GRUPO_BIENES_SERVICIOS";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);
            parameters.Add("@TIPO_BIEN", request.tipoBien, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoGrupoBienesServiciosResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }
    }
}
