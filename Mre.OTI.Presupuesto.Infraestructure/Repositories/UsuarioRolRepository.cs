using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.UsuarioRol;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class UsuarioRolRepository : IUsuarioRolRepository
    {
        readonly DBConnection DBConnection;
        public UsuarioRolRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Guardar(UsuarioRol parametro)
        {
            var sql = @"SC_SEG.MEOSI_USUARIO_ROL";
            
            int result = 0;

            //DBConnection.BeginTransaction();

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PERFIL", parametro.ID_PERFIL, DbType.Int32);
            parameters.Add("@ID_USUARIO", parametro.ID_USUARIO, DbType.Int32);
            
            parameters.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.Int32);
            parameters.Add("@ACCESO_PRIVADO", parametro.ACCESO_PRIVADO, DbType.Int32);

            parameters.Add("@USUARIO_CREACION", parametro.usuarioCreacion, DbType.String);
            parameters.Add("@IP_CREACION", parametro.ipCreacion, DbType.String);

            var identity = await DBConnection.Connection.ExecuteScalarAsync<int>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            //DBConnection.Commit();

            if (identity != null)
            {
                result = Convert.ToInt32(identity);
            }

            return result;
        }

        public async Task<int> Actualizar(UsuarioRol parametro)
        {
            var sql = @"SC_SEG.MEOSU_USUARIO_ROL";
            var parameters = new DynamicParameters();

            parameters.Add("@ID_USUARIO_PERFIL", parametro.ID_USUARIO_ROL, DbType.Int32);
            parameters.Add("@ID_PERFIL", parametro.ID_PERFIL, DbType.Int32);
            parameters.Add("@ID_CENTRO_COSTOS", parametro.ID_CENTRO_COSTOS, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            int result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;

        }

        public async Task<int> Eliminar(UsuarioRol parametro)
        {
            var sql = @"SC_SEG.MEOSD_USUARIO_ROL";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_USUARIO_PERFIL", parametro.ID_USUARIO_ROL, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            return result;
        }

        public async Task<ObtenerUsuarioRolResponseDTO> ObtenerUsuarioRol(int idUsuarioRol, string fraseEncriptacion)
        {
            const string sql = @"SC_SEG.MEOSS_OBTENER_USUARIO_ROL";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_USUARIO_PERFIL", idUsuarioRol, DbType.Int32);
            parameters.Add("@FRASE_ENCRIPTACION", fraseEncriptacion, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerUsuarioRolResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();

        }

        public async Task<ObtenerUsuarioRolExteriorResponseDTO> ObtenerUsuarioRolExterior(int idUsuarioRol)
        {
            const string sql = @"SC_SEG.MEOSS_OBTENER_USUARIO_ROL_EXTERIOR";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_USUARIO_PERFIL", idUsuarioRol, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerUsuarioRolExteriorResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();

        }
        public async Task<IEnumerable<ObtenerUsuarioRolPaginadoResponseDTO>> ObtenerUsuarioRolPaginado(ObtenerUsuarioRolPaginadoRequestDTO request)
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_PAGINADO_USUARIO_ROL";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_SISTEMA", request.idSistema, DbType.String);
            parameters.Add("@ID_PERFIL", request.idRol, DbType.String);
            parameters.Add("@ID_USUARIO", request.idUsuario, DbType.String);            
            
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);


            var result = await DBConnection.Connection.QueryAsync<ObtenerUsuarioRolPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
        public async Task<ObtenerUsuarioRolValResponseDTO> ObtenerUsuarioRolVal(ObtenerUsuarioRolValRequestDTO request)
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_USUARIO_ROL_VAL";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PERFIL", request.idRol, DbType.String);
            parameters.Add("@ID_USUARIO", request.idUsuario, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerUsuarioRolValResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            return result.FirstOrDefault();
        }
    }
}
