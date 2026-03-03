using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Mre.OTI.Presupuesto.Domain.Entities;
using Mre.OTI.Presupuesto.Application.DTO.Persona;
using Mre.OTI.Presupuesto.Application.Repositories;
using System.Linq;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        readonly DBConnection DBConnection;

        public PersonaRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }
        public async Task<int> Guardar(Persona parametro)
        {
            var sql = @"SC_SEG.MEOSI_PERSONA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_TIPO_DOCUMENTO", parametro.ID_TIPO_DOCUMENTO, DbType.Int32);
            parameters.Add("@ID_PAIS_NACIMIENTO", parametro.ID_PAIS_NACIMIENTO, DbType.Int32);
            parameters.Add("@ID_ESTADO_CIVIL", parametro.ID_ESTADO_CIVIL, DbType.Int32);
            parameters.Add("@NUMERO_DOCUMENTO", parametro.NUMERO_DOCUMENTO, DbType.String);
            parameters.Add("@NOMBRES", parametro.NOMBRES, DbType.String);
            parameters.Add("@APELLIDOPATERNO", parametro.APELLIDO_PATERNO, DbType.String);
            parameters.Add("@APELLIDOMATERNO", parametro.APELLIDO_MATERNO, DbType.String);
            parameters.Add("@CORREO", parametro.CORREO, DbType.String);
            parameters.Add("@SEXO", parametro.SEXO, DbType.String);
            parameters.Add("@NUMERO_TELEFONO", parametro.NUMERO_TELEFONO, DbType.String);
            parameters.Add("@FECHA_NACIMIENTO", parametro.FECHA_NACIMIENTO, DbType.Date);

            parameters.Add("@USUARIO_CREACION", parametro.usuarioCreacion, DbType.String);
            parameters.Add("@IP_CREACION", parametro.ipCreacion, DbType.String);


            var identity = await DBConnection.Connection.ExecuteScalarAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            if (identity != null)
            {
                result = Convert.ToInt32(identity);
            }

            return result;

        }
        public async Task<int> Actualizar(Persona parametro)
        {
            var sql = @"SC_SEG.MEOSU_PERSONA";
            var parameters = new DynamicParameters();

            parameters.Add("@ID_PERSONA", parametro.ID_PERSONA, DbType.Int32);
            parameters.Add("@ID_TIPO_DOCUMENTO", parametro.ID_TIPO_DOCUMENTO, DbType.Int32);
            parameters.Add("@ID_PAIS_NACIMIENTO", parametro.ID_PAIS_NACIMIENTO, DbType.Int32);
            parameters.Add("@ID_ESTADO_CIVIL", parametro.ID_ESTADO_CIVIL, DbType.Int32);
            parameters.Add("@NUMERO_DOCUMENTO", parametro.NUMERO_DOCUMENTO, DbType.String);
            parameters.Add("@NOMBRES", parametro.NOMBRES, DbType.String);
            parameters.Add("@APELLIDOPATERNO", parametro.APELLIDO_PATERNO, DbType.String);
            parameters.Add("@APELLIDOMATERNO", parametro.APELLIDO_MATERNO, DbType.String);
            parameters.Add("@CORREO", parametro.CORREO, DbType.String);
            parameters.Add("@SEXO", parametro.SEXO, DbType.String);
            parameters.Add("@FECHA_NACIMIENTO", parametro.FECHA_NACIMIENTO, DbType.Date);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);
            parameters.Add("@NUMERO_TELEFONO", parametro.NUMERO_TELEFONO, DbType.String);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);



            int result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;


        }

        public async Task<int> Eliminar(Persona parametro)
        {
            var sql = @"SC_SEG.MEOSD_PERSONA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PERSONA", parametro.ID_PERSONA, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            return result;
        }
        public async Task<int> tieneUsuarioActivo(int idPersona)
        {
            var sql = @"SC_SEG.MEOSS_PERSONA_TIENE_USUARIO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PERSONA", idPersona, DbType.Int32);

            result = await DBConnection.Connection.QuerySingleAsync<int>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            return result;
        }
        public async Task<ObtenerPersonaResponseDTO> ObtenerPersona(int idPersona)
        {
            const string sql = @"SC_SEG.MEOSS_OBTENER_PERSONA";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PERSONA", idPersona, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerPersonaResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);


            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerPersonaPaginadoResponseDTO>> ObtenerPersonaPaginado(ObtenerPersonaPaginadoRequestDTO request)
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_PAGINADO_PERSONA";

            var parameters = new DynamicParameters();
            parameters.Add("@NOMBRES", request.nombres, DbType.String);
            parameters.Add("@APELLIDO_PATERNO", request.apellidoPaterno, DbType.String);
            parameters.Add("@ID_TIPO_DOCUMENTO", request.idTipoDocumento, DbType.Int32);
            parameters.Add("@NUMERO_DOCUMENTO", request.numeroDocumento, DbType.String);
            parameters.Add("@ID_PAIS_NACIMIENTO", request.idPaisNacimiento, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);


            var result = await DBConnection.Connection.QueryAsync<ObtenerPersonaPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<ObtenerListadoPersonaResponseDTO>> ObtenerListadoPersona()
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_PERSONA";

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoPersonaResponseDTO>(sql, null, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerPersonaValResponseDTO> ObtenerPersonaVal(ObtenerPersonaValRequestDTO request)
        {
            const string sql = @"SC_SEG.MEOSS_LISTAR_PERSONA_VAL";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_TIPO_DOCUMENTO", request.idTipoDocumento, DbType.Int32);
            parameters.Add("@NUMERO_DOCUMENTO", request.numeroDocumento, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerPersonaValResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}
