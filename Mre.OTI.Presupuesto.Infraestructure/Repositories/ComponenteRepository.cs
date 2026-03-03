using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Componente;
using Mre.OTI.Presupuesto.Application.DTO.Componente;
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
    public class ComponenteRepository : IComponenteRepository
    {
        readonly DBConnection DBConnection;

        public ComponenteRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<IEnumerable<ObtenerListadoComponenteResponseDTO>> ObtenerListadoComponente()
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_COMPONENTE";

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoComponenteResponseDTO>(sql, null, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
        public async Task<int> Guardar(Componente parametro)
        {
            var sql = @"SC_SPP.MAESI_COMPONENTE";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@COMPONENTE", parametro.COMPONENTE, DbType.String);
            parameters.Add("@TIPO_COMPONENTE", parametro.TIPO_COMPONENTE, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
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

        public async Task<int> Actualizar(Componente parametro)
        {
            var sql = @"SC_SPP.MAESU_COMPONENTE";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_COMPONENTE", parametro.ID_COMPONENTE, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@COMPONENTE", parametro.COMPONENTE, DbType.String);
            parameters.Add("@TIPO_COMPONENTE", parametro.TIPO_COMPONENTE, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(Componente parametro)
        {
            var sql = @"SC_SPP.MAESD_COMPONENTE";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_COMPONENTE", parametro.ID_COMPONENTE
                , DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;

        }

        public async Task<IEnumerable<ObtenerComponentePaginadoResponseDTO>> ObtenerComponentePaginado(ObtenerComponentePaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_COMPONENTE";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.Anio, DbType.String);
            parameters.Add("@COMPONENTE", request.componente, DbType.String);
            parameters.Add("@DESCRIPCION", request.descripcion, DbType.String);
            //parameters.Add("@ESTADO", request.estado, DbType.Int32);
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);


            var result = await DBConnection.Connection.QueryAsync<ObtenerComponentePaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerComponenteResponseDTO> ObtenerComponente(int idComponente)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_COMPONENTE";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_COMPONENTE", idComponente, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerComponenteResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}
