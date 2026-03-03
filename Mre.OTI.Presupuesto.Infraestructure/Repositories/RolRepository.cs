using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Rol;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        readonly DBConnection DBConnection;

        public RolRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Guardar(Rol parametro)
        {
            var sql = @"SC_SEG.MEOSI_ROL";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@CODIGO_ROL", parametro.CODIGO_ROL, DbType.Int32);
            parameters.Add("@ID_SISTEMA", parametro.ID_SISTEMA, DbType.Int32);
            parameters.Add("@NOMBRE", parametro.NOMBRE, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            parameters.Add("@USUARIO_CREACION", parametro.usuarioCreacion, DbType.String);
            parameters.Add("@IP_CREACION", parametro.ipCreacion, DbType.String);


            var identity = await DBConnection.Connection.ExecuteScalarAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            if (identity != null)
            {
                result = Convert.ToInt32(identity);
            }

            return result;

        }
        public async Task<int> Actualizar(Rol parametro)
        {
            var sql = @"SC_SEG.MEOSU_ROL";
            var parameters = new DynamicParameters();

            parameters.Add("@ID_PERFIL", parametro.ID_ROL, DbType.Int32);
            parameters.Add("@CODIGO_ROL", parametro.CODIGO_ROL, DbType.Int32);
            //parameters.Add("@ID_SISTEMA", parametro.ID_SISTEMA, DbType.Int32);
            parameters.Add("@NOMBRE", parametro.NOMBRE, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);            

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            int result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(Rol parametro)
        {
            var sql = @"SC_SEG.MEOSD_ROL";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PERFIL", parametro.ID_ROL, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerRolResponseDTO> ObtenerRol(int idRol)
        {
            const string sql = @"SC_SEG.MEOSS_OBTENER_ROL";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PERFIL", idRol, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerRolResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);
            var response = result;

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerListaRolResponseDTO>> ObtenerListaRol()
        {
            const string sql = @"SC_SEG.MEOSS_OBTENER_LISTADO_ROL";

            var result = await DBConnection.Connection.QueryAsync<ObtenerListaRolResponseDTO>(sql, null, DBConnection.Transaction, commandType: CommandType.StoredProcedure);
            
            return result;  
        }

        public async Task<IEnumerable<ObtenerRolPaginadoResponseDTO>> ObtenerRolPaginado(ObtenerRolPaginadoRequestDTO request)
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_PAGINADO_ROL";

            var parameters = new DynamicParameters();
            parameters.Add("@NOMBRE", request.nombre, DbType.String);
            parameters.Add("@DESCRIPCION", request.descripcion, DbType.String);


            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);


            var result = await DBConnection.Connection.QueryAsync<ObtenerRolPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
        //esv 08-09-25
        public async Task<IEnumerable<ObtenerListadoRolResponseDTO>> ObtenerListadoRol(ObtenerListadoRolRequestDTO request)
        {
            //const string sql = @"SC_SEG.MEOSS_LISTAR_ROL";
            const string sql = @"SC_SEG.MEOSS_OBTENER_LISTA_ROL";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_SISTEMA", request.idSistema, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoRolResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
        //end esv
        public async Task<ObtenerRolValResponseDTO> ObtenerRolVal(ObtenerRolValRequestDTO request)
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_ROL_VAL";

            var parameters = new DynamicParameters();
            parameters.Add("@NOMBRE", request.nombre, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerRolValResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        //Task<IEnumerable<ObtenerListaRolResponseDTO>> IRolRepository.ObtenerListaRol(int idSistema)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
