using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Usuario;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Mre.OTI.Presupuesto.Application.DTO.Rol;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        readonly DBConnection DBConnection;

        public UsuarioRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Guardar(Usuario parametro)
        {
            var sql = @"SC_SEG.MEOSI_USUARIO";
            int result = 0;

            var parameters = new DynamicParameters();
          
            parameters.Add("@CORREO", parametro.CORREO, DbType.String);
            parameters.Add("@USUARIO_CREACION", parametro.usuarioCreacion, DbType.String);
            parameters.Add("@IP_CREACION", parametro.ipCreacion, DbType.String);
            parameters.Add("@LOGIN", parametro.LOGIN, DbType.String);
            parameters.Add("@CLAVE", parametro.CLAVE, DbType.String);
            parameters.Add("@ID_PERSONA", parametro.ID_PERSONA, DbType.Int32);
            parameters.Add("@USUARIO_NT", parametro.USUARIO_NT, DbType.String);
            parameters.Add("@CLAVE_NT", parametro.CLAVE_NT, DbType.String);
            parameters.Add("@FRASE_ENCRIPTACION", parametro.fraseEncriptacion, DbType.String);

            var identity = await DBConnection.Connection.ExecuteScalarAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            if (identity != null)
            {
                result = Convert.ToInt32(identity);
            }

            return result;
        }
        public async Task<int> Actualizar(Usuario parametro)
        {
            var sql = @"SC_SEG.MEOSU_USUARIO";
            var parameters = new DynamicParameters();

            parameters.Add("@ID_USUARIO", parametro.ID_USUARIO, DbType.Int32);
            
            parameters.Add("@ID_PERSONA", parametro.ID_PERSONA, DbType.Int32);
            parameters.Add("@CORREO", parametro.CORREO, DbType.String);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);
            parameters.Add("@LOGIN", parametro.LOGIN, DbType.String);
            parameters.Add("@CLAVE", parametro.CLAVE, DbType.String);

            parameters.Add("@USUARIO_NT", parametro.USUARIO_NT, DbType.String);
            parameters.Add("@CLAVE_NT", parametro.CLAVE_NT, DbType.String);
            parameters.Add("@FRASE_ENCRIPTACION", parametro.fraseEncriptacion, DbType.String);

            int result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;

        }

        public async Task<int> Eliminar(Usuario parametro)
        {
            var sql = @"SC_SEG.MEOSD_USUARIO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_USUARIO", parametro.ID_USUARIO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerUsuarioResponseDTO> ObtenerUsuario(int idUsuario, string fraseEncriptacion)
        {
            const string sql = @"SC_SEG.MEOSS_OBTENER_USUARIO";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_USUARIO", idUsuario, DbType.Int32);
            parameters.Add("@FRASE_ENCRIPTACION", fraseEncriptacion, DbType.String);
            var result = await DBConnection.Connection.QueryAsync<ObtenerUsuarioResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerUsuarioPaginadoResponseDTO>> ObtenerUsuarioPaginado(ObtenerUsuarioPaginadoRequestDTO request)
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_PAGINADO_USUARIO";

            var parameters = new DynamicParameters();
            parameters.Add("@NOMBRES", request.nombres, DbType.String);
            parameters.Add("@APELLIDO_PATERNO", request.apellidoPaterno, DbType.String);
            parameters.Add("@CORREO", request.correo, DbType.String);
            parameters.Add("@ID_TIPO_DOCUMENTO", request.idTipoDocumento, DbType.Int32);
            parameters.Add("@NUMERO_DOCUMENTO", request.numeroDocumento, DbType.String);
            parameters.Add("@FRASE_ENCRIPTACION", request.fraseEncriptacion, DbType.String);

            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerUsuarioPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<ObtenerUsuarioLoginResponseDTO>> ObtenerUsuarioLogin(ObtenerUsuarioLoginRequestDTO request)
        {
            const string sql = @"SC_SEG.MEOSS_LOGIN";

            var parameters = new DynamicParameters();
            parameters.Add("@USUARIO_NT", request.usuarioNT, DbType.String);
            parameters.Add("@FRASE_ENCRIPTACION", request.fraseEncriptacion, DbType.String);
            parameters.Add("@CODIGO_SISTEMA", request.codigoSistema, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerUsuarioLoginResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
        public async Task<ObtenerUsuarioLoginResponseDTO> ObtenerUsuarioRol(int idUsuarioRol, string fraseEncriptacion)
        {
            const string sql = @"SC_SEG.MEOSS_OBTENER_USUARIO_ROL";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_USUARIO_PERFIL", idUsuarioRol, DbType.Int32);
            parameters.Add("@FRASE_ENCRIPTACION", fraseEncriptacion, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerUsuarioLoginResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();

        }
        
        public async Task<IEnumerable<ObtenerListadoUsuarioResponseDTO>> ObtenerListadoUsuario(ObtenerListadoUsuarioRequestDTO request )
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_USUARIO_ID_ROL";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ROL", request.idRol, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoUsuarioResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.OrderBy(x => x.apellidoPaterno).ThenBy(x=>x.apellidoMaterno);
        }
        
        public async Task<ObtenerUsuarioValResponseDTO> ObtenerUsuarioVal(ObtenerUsuarioValRequestDTO request)
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_USUARIO_VAL";

            var parameters = new DynamicParameters();
            parameters.Add("@NUMERO_DOCUMENTO", request.numeroDocumento, DbType.String);
            parameters.Add("@CORREO", request.correo, DbType.String);
            parameters.Add("@USUARIO_NT", request.usuarioNT, DbType.String);
            parameters.Add("@ID_PERSONA", request.idPersona, DbType.Int32);
            parameters.Add("@FRASE_ENCRIPTACION", request.fraseEncriptacion, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerUsuarioValResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
        public async Task<ObtenerUsuarioLoginExteriorResponseDTO> ObtenerUsuarioLoginExterior(ObtenerUsuarioLoginRequestDTO request)
        {
            const string sql = @"SC_SEG.MEOSS_LOGIN_EXTERIOR";

            var parameters = new DynamicParameters();
            parameters.Add("@LOGIN", request.login, DbType.String);
            parameters.Add("@PWD", request.pwd, DbType.String);
            parameters.Add("@CODIGO_PERFIL_CENTRO_COSTO", request.codigoPerfilCentroCosto, DbType.String);
            parameters.Add("@FRASE_ENCRIPTACION", request.fraseEncriptacion, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerUsuarioLoginExteriorResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();

        }
        public async Task<IEnumerable<string>> ObtenerCorreosCentroCosto(int codigoPerfilUsuario, int idCentroCosto)
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_CORREOS_X_NIVEL_ATENCION";
            var parameters = new DynamicParameters();
            parameters.Add("@CODIGO_PERFIL", codigoPerfilUsuario, DbType.Int32);
            parameters.Add("@ID_CENTRO_COSTO", idCentroCosto, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<string>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
        public async Task<IEnumerable<string>> ObtenerCorreosContabilidad(int codigoPerfilJefe, int codigoPerfilAux)
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_CORREOS_CONTABILIDAD";
            var parameters = new DynamicParameters();
            parameters.Add("@CODIGO_PERFIL_1", codigoPerfilJefe, DbType.Int32);
            parameters.Add("@CODIGO_PERFIL_2", codigoPerfilAux, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<string>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
        public async Task<IEnumerable<string>> ObtenerCorreosFinanzas(int codigoPerfilJefe, int codigoPerfilAux)
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_CORREOS_FINANZAS";
            var parameters = new DynamicParameters();
            parameters.Add("@CODIGO_PERFIL_1", codigoPerfilJefe, DbType.Int32);
            parameters.Add("@CODIGO_PERFIL_2", codigoPerfilAux, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<string>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
        public async Task<int> tieneAccesoActivo(int idUsuario)
        {
            var sql = @"SC_SEG.MEOSS_USUARIO_TIENE_ACCESO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_USUARIO", idUsuario, DbType.Int32);

            result = await DBConnection.Connection.QuerySingleAsync<int>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<ObtenerListadoUsuarioSelectResponseDTO>> ObtenerListadoUsuarioSelect()
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_USUARIO";

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoUsuarioSelectResponseDTO>(sql, null, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<ObtenerListarUsuariosResponseDTO>> ObtenerListarUsuarios()
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_USUARIOS";

            var result = await DBConnection.Connection.QueryAsync<ObtenerListarUsuariosResponseDTO>(sql, null, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
