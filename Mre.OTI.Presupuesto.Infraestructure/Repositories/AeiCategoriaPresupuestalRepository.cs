using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.AeiCategoriaPresupuestal;
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
    public class AeiCategoriaPresupuestalRepository : IAeiCategoriaPresupuestalRepository
    {
        readonly DBConnection DBConnection;

        public AeiCategoriaPresupuestalRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Eliminar(AeiCategoriaPresupuestal parametro)
        {
            var sql = @"SC_SPP.MAESD_AEI_CATEGORIA_PRESUPUESTAL";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@ID_PRESUPUESTAL", parametro.ID_PRESUPUESTAL, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(AeiCategoriaPresupuestal parametro)
        {
            var sql = @"SC_SPP.MAESI_AEI_CATEGORIA_PRESUPUESTAL";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@ID_PRESUPUESTAL", parametro.ID_PRESUPUESTAL, DbType.Int32);

            parameters.Add("@ID_ACCIONES", parametro.ID_ACCIONES, DbType.Int32);

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

        public async Task<IEnumerable<ObtenerAeiCategoriaPresupuestalResponseDTO>> ObtenerAeiCategoriaPresupuestal(ObtenerAeiCategoriaPresupuestalRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_AEI_CATEGORIA_PRESUPUESTAL";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);
            parameters.Add("@ID_PRESUPUESTAL", request.idPresupuestal, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerAeiCategoriaPresupuestalResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.OrderBy(x => x.idAcciones).ThenBy(x => x.idAcciones);
        }
    }
}
