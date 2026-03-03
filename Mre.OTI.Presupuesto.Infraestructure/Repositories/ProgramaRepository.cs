using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.Programa;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionAcciones;
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
    public class ProgramaRepository : IProgramaRepository
    {

        readonly DBConnection DBConnection;

        public ProgramaRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }      

        public async Task<int> Guardar(Programa parametro)
        {
            var sql = @"SC_SPP.MAESI_PROGRAMA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@PROGRAMA", parametro.PROGRAMA, DbType.String);
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

        public async Task<int> Actualizar(Programa parametro)
        {
            var sql = @"SC_SPP.MAESU_PROGRAMA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMA", parametro.ID_PROGRAMA, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);
            parameters.Add("@PROGRAMA", parametro.PROGRAMA, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(Programa parametro)
        {
            var sql = @"SC_SPP.MAESD_PROGRAMA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMA", parametro.ID_PROGRAMA, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;

        }

        public async Task<IEnumerable<ObtenerProgramaPaginadoResponseDTO>> ObtenerProgramaPaginado(ObtenerProgramaPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_PROGRAMA";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.Anio, DbType.String);
            parameters.Add("@PROGRAMA", request.programa, DbType.String);
            parameters.Add("@DESCRIPCION", request.descripcion, DbType.String);
            //parameters.Add("@ESTADO", request.estado, DbType.Int32);
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);


            var result = await DBConnection.Connection.QueryAsync<ObtenerProgramaPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerProgramaResponseDTO> ObtenerPrograma(int idPrograma)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_PROGRAMA";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PROGRAMA", idPrograma, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerProgramaResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
                
        public async Task<IEnumerable<ObtenerListadoProgramaResponseDTO>> ObtenerListadoPrograma(ObtenerListadoProgramaRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PROGRAMA";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoProgramaResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }
    }
}
