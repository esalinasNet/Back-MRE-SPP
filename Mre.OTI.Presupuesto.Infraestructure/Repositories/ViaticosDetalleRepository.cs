using Dapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class ViaticosDetalleRepository : IViaticosDetalleRepository
    {
        readonly DBConnection DBConnection;

        public ViaticosDetalleRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Guardar(ViaticosDetalle parametro)
        {
            const string sql = @"SC_SPP.MAESI_PROGRAMACION_VIATICOS_DETALLE";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMACION_VIATICOS_DETALLE", parametro.ID_PROGRAMACION_VIATICOS_DETALLE, DbType.Int32);
            parameters.Add("@ID_PROGRAMACION_VIATICOS", parametro.ID_PROGRAMACION_VIATICOS, DbType.Int32);
            parameters.Add("@ID_CLASIFICADOR", parametro.ID_CLASIFICADOR, DbType.Int32);
            parameters.Add("@NOMBRE_CLASIFICADOR", parametro.NOMBRE_CLASIFICADOR, DbType.String);
            parameters.Add("@DENOMINACION_RECURSO", parametro.DENOMINACION_RECURSO, DbType.String);
            parameters.Add("@MONTO", parametro.MONTO, DbType.Decimal);
            parameters.Add("@CANTIDAD_PERSONAS", parametro.CANTIDAD_PERSONAS, DbType.Int32);
            parameters.Add("@DIAS", parametro.DIAS, DbType.Int32);
            parameters.Add("@MES", parametro.MES, DbType.Int32);

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