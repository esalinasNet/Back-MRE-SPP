using Dapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class CajaChicaDetalleRepository : ICajaChicaDetalleRepository
    {
        readonly DBConnection DBConnection;

        public CajaChicaDetalleRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Guardar(CajaChicaDetalle parametro)
        {
            const string sql = @"SC_SPP.MAESI_PROGRAMACION_CAJA_CHICA_DETALLE";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_CAJA_CHICA_DETALLE", parametro.ID_PROGRAMACION_CAJA_CHICA_DETALLE, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_CAJA_CHICA", parametro.ID_PROGRAMACION_CAJA_CHICA, DbType.Int32);
            parameters.Add("@CODIGO_ITEM", parametro.CODIGO_ITEM, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            parameters.Add("@CANTIDAD", parametro.CANTIDAD, DbType.Decimal);
            parameters.Add("@ID_UNIDAD_MEDIDA", parametro.ID_UNIDAD_MEDIDA, DbType.Int32);
            parameters.Add("@PRECIO_UNITARIO", parametro.PRECIO_UNITARIO, DbType.Decimal);
            parameters.Add("@ID_CLASIFICADOR", parametro.ID_CLASIFICADOR, DbType.Int32);
            parameters.Add("@NOMBRE_CLASIFICADOR", parametro.NOMBRE_CLASIFICADOR, DbType.String);

            // Montos mensuales
            parameters.Add("@MONTO_ENERO", parametro.MONTO_ENERO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_FEBRERO", parametro.MONTO_FEBRERO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_MARZO", parametro.MONTO_MARZO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_ABRIL", parametro.MONTO_ABRIL ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_MAYO", parametro.MONTO_MAYO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_JUNIO", parametro.MONTO_JUNIO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_JULIO", parametro.MONTO_JULIO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_AGOSTO", parametro.MONTO_AGOSTO ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_SETIEMBRE", parametro.MONTO_SETIEMBRE ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_OCTUBRE", parametro.MONTO_OCTUBRE ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_NOVIEMBRE", parametro.MONTO_NOVIEMBRE ?? 0, DbType.Decimal);
            parameters.Add("@MONTO_DICIEMBRE", parametro.MONTO_DICIEMBRE ?? 0, DbType.Decimal);

            parameters.Add("@ACTIVO", parametro.ACTIVO ?? true, DbType.Boolean);
            parameters.Add("@IP_CREACION", parametro.ipCreacion, DbType.String);
            parameters.Add("@USUARIO_CREACION", parametro.usuarioCreacion, DbType.String);

            var identity = await DBConnection.Connection.ExecuteScalarAsync(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            if (identity != null)
            {
                result = Convert.ToInt32(identity);
            }

            return result;
        }
    }
}