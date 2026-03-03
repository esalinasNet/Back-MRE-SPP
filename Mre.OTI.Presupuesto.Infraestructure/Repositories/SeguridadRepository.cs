using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Seguridad;
using Mre.OTI.Presupuesto.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class SeguridadRepository : ISeguridadRepository
    {
        readonly DBConnection DBConnection;

        public SeguridadRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<ObtenerAutorizacionResponseDTO> ObtenerAutorizacion(int idSistema, int idOpcion, int idPerfil, string accion)
        {
            const string sql = @"SC_SEG.MEOSS_OBTENER_PERMISO_PERFIL";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_SISTEMA", idSistema);
            parameters.Add("@ID_OPCION", idOpcion);
            parameters.Add("@ID_PERFIL", idPerfil);
            parameters.Add("@ACCION", accion);

            var result = await DBConnection.Connection.QueryAsync<ObtenerAutorizacionResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerOpcionResponseDTO>> ObtenerOpcion(string codigoSistema,int idPerfil)
        {

            const string sql = @"SC_SEG.MEOSS_OBTENER_OPCION";

            var parameters = new DynamicParameters();
            parameters.Add("@CODIGO_SISTEMA", codigoSistema);
            parameters.Add("@ID_PERFIL", idPerfil);
            var result = await DBConnection.Connection.QueryAsync<ObtenerOpcionResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;

        }

        public async Task<IEnumerable<ObtenerPerfilOpcionResponseDTO>> ObtenerPerfilOpcion(string codigoSistema, int idPerfil)
        {
            const string sql = @"SC_SEG.MEOSS_OBTENER_PERFIL_OPCION";

            var parameters = new DynamicParameters();
            parameters.Add("@CODIGO_SISTEMA", codigoSistema);
            parameters.Add("@ID_PERFIL", idPerfil);

            var result = await DBConnection.Connection.QueryAsync<ObtenerPerfilOpcionResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
