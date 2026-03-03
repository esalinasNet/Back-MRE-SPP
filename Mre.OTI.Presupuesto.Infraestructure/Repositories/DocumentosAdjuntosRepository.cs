using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class DocumentosAdjuntosRepository : IDocumentosAdjuntosRepository
    {
        readonly DBConnection DBConnection;

        public DocumentosAdjuntosRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }
        public async Task<int> Guardar(DocumentosAdjuntos parametro)
        {
            var sql = @"SC_SGED.SGEDSI_DOCUMENTOS_ADJUNTOS";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_TIPO_DOCUMENTO", parametro.ID_TIPO_DOCUMENTO, DbType.Int32);
            parameters.Add("@ID_SUB_TIPO_DOCUMENTO", parametro.ID_SUB_TIPO_DOCUMENTO, DbType.Int32);
            parameters.Add("@ID_SOLICITUD", parametro.ID_SOLICITUD, DbType.Int32);
            parameters.Add("@ID_ESTADO_DOCUMENTO", parametro.ID_ESTADO_DOCUMENTO, DbType.Int32);
            parameters.Add("@RUTA_DOCUMENTO", parametro.RUTA_DOCUMENTO, DbType.String);
            parameters.Add("@IMPORTE", parametro.IMPORTE, DbType.Decimal);
            parameters.Add("@DETALLE", parametro.DETALLE, DbType.String);


            parameters.Add("@USUARIO_CREACION", parametro.usuarioCreacion, DbType.String);
            parameters.Add("@IP_CREACION", parametro.ipCreacion, DbType.String);


            var identity = await DBConnection.Connection.ExecuteScalarAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            if (identity != null)
            {
                result = Convert.ToInt32(identity);
            }

            return result;

        }
        public async Task<int> Eliminar(DocumentosAdjuntos parametro)
        {
            var sql = @"SC_SGED.SGEDSD_DOCUMENTO_ADJUNTO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_DOCUMENTO_ADJUNTO", parametro.ID_DOCUMENTO_ADJUNTO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            return result;
        }
        public async Task<int> ActualizarEstado(DocumentosAdjuntos parametro)
        {
            var sql = @"SC_SGED.SGEDSU_DOCUMENTO_ADJUNTO_ESTADO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_DOCUMENTO_ADJUNTO", parametro.ID_DOCUMENTO_ADJUNTO, DbType.Int32);
            parameters.Add("@ID_ESTADO_DOCUMENTO", parametro.ID_ESTADO_DOCUMENTO, DbType.Int32);
            parameters.Add("@COMENTARIO_OBS", parametro.COMENTARIO_OBS, DbType.String);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            return result;
        }
        public async Task<int> Actualizar(DocumentosAdjuntos parametro)
        {
            var sql = @"SC_SGED.SGEDSU_DOCUMENTO_ADJUNTO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_DOCUMENTO_ADJUNTO", parametro.ID_DOCUMENTO_ADJUNTO, DbType.Int32);
            parameters.Add("@ID_ESTADO_DOCUMENTO", parametro.ID_ESTADO_DOCUMENTO, DbType.Int32);
            parameters.Add("@RUTA_DOCUMENTO", parametro.RUTA_DOCUMENTO, DbType.String);
            parameters.Add("@ID_TIPO_DOCUMENTO", parametro.ID_TIPO_DOCUMENTO, DbType.Int32);
            parameters.Add("@ID_SUB_TIPO_DOCUMENTO", parametro.ID_SUB_TIPO_DOCUMENTO, DbType.Int32);
            parameters.Add("@DETALLE", parametro.DETALLE, DbType.String);
            parameters.Add("@IMPORTE", parametro.IMPORTE, DbType.Decimal);
            parameters.Add("@COMENTARIO_OBS", parametro.COMENTARIO_OBS, DbType.String);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            return result;
        }
       
    }
}
