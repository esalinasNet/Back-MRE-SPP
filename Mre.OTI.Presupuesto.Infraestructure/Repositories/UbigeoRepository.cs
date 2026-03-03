using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.Ubigeo;
using Mre.OTI.Presupuesto.Application.DTO.Usuario;
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
    public class UbigeoRepository : IUbigeoRepository
    {

        readonly DBConnection DBConnection;

        public UbigeoRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<IEnumerable<ObtenerListadoUbigeoDepartamentoResponseDTO>> ObtenerListadoUbigeoDepartamento()
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_UBIGEO_DEPARTAMENTO";

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoUbigeoDepartamentoResponseDTO>(sql, null, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<ObtenerListadoUbigeoProvinciaResponseDTO>> ObtenerListadoUbigeoProvincia(ObtenerListadoUbigeoProvinciaRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_UBIGEO_PROVINCIA";

            var parameters = new DynamicParameters();
            parameters.Add("@DEPARTAMENTO", request.departamento, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoUbigeoProvinciaResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.OrderBy(x => x.descripcion).ThenBy(x => x.descripcion);
        }

        public async Task<IEnumerable<ObtenerListadoUbigeoDistritoResponseDTO>> ObtenerListadoUbigeoDistrito(ObtenerListadoUbigeoDistritoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_UBIGEO_DISTRITO";

            var parameters = new DynamicParameters();
            parameters.Add("@DEPARTAMENTO", request.departamento, DbType.String);
            parameters.Add("@PROVINCIA", request.provincia, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoUbigeoDistritoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.OrderBy(x => x.descripcion).ThenBy(x => x.descripcion);
        }

        public async Task<IEnumerable<ObtenerUbigeoPaginadoResponseDTO>> ObtenerUbigeoPaginado(ObtenerUbigeoPaginadoRequestDTO request)
        {
            if (request.departamento == "0") request.departamento = null;
            if (request.provincia == "0") request.provincia = null;
            if (request.distrito == "0") request.distrito = null;

            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_UBIGEO";

            var parameters = new DynamicParameters();
            parameters.Add("@DEPARTAMENTO", request.departamento, DbType.String);
            parameters.Add("@PROVINCIA", request.provincia, DbType.String);
            parameters.Add("@DISTRITO", request.distrito, DbType.String);
            parameters.Add("@DESCRIPCION", request.descripcion, DbType.String);
            //parameters.Add("@ESTADO", request.estado, DbType.Int32);
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);

            var result = await DBConnection.Connection.QueryAsync<ObtenerUbigeoPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> GuardarUbigeoDepartamento(Ubigeo parametro)
        {
            var sql = @"SC_SPP.MAESI_UBIGEO_DEPARTAMENTO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            //parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
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

        public async Task<int> GuardarUbigeoProvincia(Ubigeo parametro)
        {
            var sql = @"SC_SPP.MAESI_UBIGEO_PROVINCIA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@DEPARTAMENTO", parametro.DEPARTAMENTO, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            //parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
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

        public async Task<int> GuardarUbigeoDistrito(Ubigeo parametro)
        {
            var sql = @"SC_SPP.MAESI_UBIGEO_DISTRITO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@DEPARTAMENTO", parametro.DEPARTAMENTO, DbType.String);
            parameters.Add("@PROVINCIA", parametro.PROVINCIA, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            //parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
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
        public async Task<ObtenerDepartamentoResponseDTO> ObtenerUbigeoDepartamento(string ubigeo)
        {
            var departamento = ubigeo.Substring(0, 2);

            var sql = @"SC_SPP.MAESS_OBTENER_UBIGEO_DEPARTAMENTO";

            var parameters = new DynamicParameters();
            parameters.Add("@DEPARTAMENTO", departamento, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerDepartamentoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<ObtenerProvinciaResponseDTO> ObtenerUbigeoProvincia(string ubigeo)
        {
            var departamento = ubigeo.Substring(0, 2);  
            var provincia = ubigeo.Substring(2, 2);

            var sql = @"SC_SPP.MAESS_OBTENER_UBIGEO_PROVINCIA";

            var parameters = new DynamicParameters();
            parameters.Add("@DEPARTAMENTO", departamento, DbType.String);
            parameters.Add("@PROVINCIA", provincia, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerProvinciaResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<ObtenerDistritoResponseDTO> ObtenerUbigeoDistrito(string ubigeo)
        {
            var departamento = ubigeo.Substring(0, 2);     
            var provincia = ubigeo.Substring(2, 2);
            var distrito = ubigeo.Substring(4, 2);

            var sql = @"SC_SPP.MAESS_OBTENER_UBIGEO_DISTRITO";

            var parameters = new DynamicParameters();
            parameters.Add("@DEPARTAMENTO", departamento, DbType.String);
            parameters.Add("@PROVINCIA", provincia, DbType.String);
            parameters.Add("@DISTRITO", distrito, DbType.String);

            var result = await DBConnection.Connection.QueryAsync<ObtenerDistritoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<int> ActualizarDepartamento(Ubigeo parametro)
        {
            var sql = @"SC_SPP.MAESU_UBIGEO_DEPARTAMENTO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_UBIGEO", parametro.ID_UBIGEO, DbType.Int32);            
            parameters.Add("@DEPARTAMENTO", parametro.DEPARTAMENTO, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            //parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> ActualizarProvincia(Ubigeo parametro)
        {
            var sql = @"SC_SPP.MAESU_UBIGEO_PROVINCIA";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_UBIGEO", parametro.ID_UBIGEO, DbType.Int32);
            parameters.Add("@DEPARTAMENTO", parametro.DEPARTAMENTO, DbType.String);
            parameters.Add("@PROVINCIA", parametro.PROVINCIA, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            //parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> ActualizarDistrito(Ubigeo parametro)
        {
            var sql = @"SC_SPP.MAESU_UBIGEO_DISTRITO";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_UBIGEO", parametro.ID_UBIGEO, DbType.Int32);
            parameters.Add("@DEPARTAMENTO", parametro.DEPARTAMENTO, DbType.String);
            parameters.Add("@PROVINCIA", parametro.PROVINCIA, DbType.String);
            parameters.Add("@DISTRITO", parametro.DISTRITO, DbType.String);
            parameters.Add("@DESCRIPCION", parametro.DESCRIPCION, DbType.String);
            //parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }




    }
}
