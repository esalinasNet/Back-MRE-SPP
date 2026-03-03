using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.Sistema;
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
    public class SistemaRepository : ISistemaRepository
    {
        readonly DBConnection DBConnection;

        public SistemaRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<IEnumerable<ObtenerListadoSistemaResponseDTO>> ObtenerListadoSistema()
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_SISTEMA";

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoSistemaResponseDTO>(sql, null, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
            //throw new NotImplementedException();  //para implementar 
        }

        public async Task<int> Guardar(Sistema parametro)
        {
            var sql = @"SC_SPP.MAESI_SISTEMA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NOMBRE", parametro.NOMBRE, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            parameters.Add("@CODIGO_SISTEMA", parametro.CODIGO_SISTEMA, DbType.String);

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

        public async Task<int> Actualizar(Sistema parametro)
        {
            var sql = @"SC_SPP.MAESU_SISTEMA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_SISTEMA", parametro.ID_SISTEMA, DbType.Int32);            
            parameters.Add("@NOMBRE", parametro.NOMBRE, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            parameters.Add("@CODIGO_SISTEMA", parametro.CODIGO_SISTEMA, DbType.String);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(Sistema parametro)
        {
            var sql = @"SC_SPP.MAESD_SISTEMA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_SISTEMA", parametro.ID_SISTEMA, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;

        }

        public async Task<IEnumerable<ObtenerSistemaPaginadoResponseDTO>> ObtenerSistemaPaginado(ObtenerSistemaPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_SISTEMA";

            var parameters = new DynamicParameters();            
            parameters.Add("@NOMBRE", request.nombre, DbType.String);
            parameters.Add("@DESCRIPCION", request.descripcion, DbType.String);            
            
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);


            var result = await DBConnection.Connection.QueryAsync<ObtenerSistemaPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerSistemaResponseDTO> ObtenerSistema(int idSistema)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_SISTEMA";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_SISTEMA", idSistema, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerSistemaResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}
