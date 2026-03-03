using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.DivisionFuncional;
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
    public class DivisionFuncionalRepository : IDivisionFuncionalRepository
    {
        readonly DBConnection DBConnection;

        public DivisionFuncionalRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(DivisionFuncional parametro)
        {
            var sql = @"SC_SPP.MAESU_DIVISION_FUNCIONAL";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_DIVISIONFUNCIONAL", parametro.ID_DIVISIONFUNCIONAL, DbType.Int32);
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@DIVISIONFUNCIONAL", parametro.DIVISIONFUNCIONAL, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);

            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(DivisionFuncional parametro)
        {
            var sql = @"SC_SPP.MAESD_DIVISION_FUNCIONAL";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_DIVISIONFUNCIONAL", parametro.ID_DIVISIONFUNCIONAL, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(DivisionFuncional parametro)
        {
            var sql = @"SC_SPP.MAESI_DIVISION_FUNCIONAL";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", parametro.ID_ANIO, DbType.Int32);

            parameters.Add("@DIVISIONFUNCIONAL", parametro.DIVISIONFUNCIONAL, DbType.String);
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

        public async Task<ObtenerCodigoDivisionResponseDTO> ObtenerCodigoDivision(ObtenerCodigoDivisionRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_CODIGO_DIVISION_FUNCIONAL";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@DIVISIONFUNCIONAL", request.divisionFuncional, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerCodigoDivisionResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<ObtenerDivisionFuncionalResponseDTO> ObtenerDivisionFuncional(ObtenerDivisionFuncionalRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_DIVISION_FUNCIONAL";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_DIVISIONFUNCIONAL", request.idDivisionFuncional, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerDivisionFuncionalResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerDivisionFuncionalPaginadoResponseDTO>> ObtenerDivisionFuncionalPaginado(ObtenerDivisionFuncionalPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_DIVISION_FUNCIONAL";

            var parameters = new DynamicParameters();
            parameters.Add("@ANIO", request.anio, DbType.Int32);
            parameters.Add("@@DIVISIONFUNCIONAL", request.divisionFuncional, DbType.String);
            parameters.Add("@DESCRIPCION", request.descripcion, DbType.String);

            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerDivisionFuncionalPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<ObtenerListadoDivisionFuncionalResponseDTO>> ObtenerListadoDivisionFuncional(ObtenerListadoDivisionFuncionalRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_DIVISION_FUNCIONAL";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_ANIO", request.idAnio, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoDivisionFuncionalResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result; //.OrderBy(x => x.idMoneda).ThenBy(x => x.idMoneda);
        }
    }
}
