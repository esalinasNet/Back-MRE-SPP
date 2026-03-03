using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.Paises;
using Mre.OTI.Presupuesto.Application.DTO.Paises;
using Mre.OTI.Presupuesto.Application.DTO.Paises;
using Mre.OTI.Presupuesto.Application.DTO.Paises;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mre.OTI.Presupuesto.Application.Util.VariablesGlobales;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class PaisesRepository : IPaisesRepository
    {
        readonly DBConnection DBConnection;

        public PaisesRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<int> Actualizar(Paises parametro)
        {
            var sql = @"SC_SPP.MAESU_PAISES";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PAISES", parametro.ID_PAISES, DbType.Int32);            
            parameters.Add("@CODIGO", parametro.CODIGO, DbType.String);
            parameters.Add("@NOMBRE_PAIS", parametro.NOMBRE_PAIS, DbType.String);
            parameters.Add("@CONTINENTE", parametro.CONTINENTE, DbType.String);
            parameters.Add("@ID_ESTADO", parametro.ID_ESTADO, DbType.Int32);
            parameters.Add("@ACTIVO", parametro.ACTIVO, DbType.Int32);

            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Eliminar(Paises parametro)
        {
            var sql = @"SC_SPP.MAESD_PAISES";
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PAISES", parametro.ID_PAISES, DbType.Int32);
            parameters.Add("@USUARIO_MODIFICACION", parametro.usuarioModificacion, DbType.String);
            parameters.Add("@IP_MODIFICACION", parametro.ipModificacion, DbType.String);

            result = await DBConnection.Connection.ExecuteAsync(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Guardar(Paises parametro)
        {
            var sql = @"SC_SPP.MAESI_PAISES";
            int result = 0;

            var parameters = new DynamicParameters();
            //parameters.Add("@ID_PAISES", parametro.ID_PAISES, DbType.Int32);
            parameters.Add("@CODIGO", parametro.CODIGO, DbType.String);
            parameters.Add("@NOMBRE_PAIS", parametro.NOMBRE_PAIS, DbType.String);
            parameters.Add("@CONTINENTE", parametro.CONTINENTE, DbType.String);
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

        public async Task<IEnumerable<ObtenerListadoPaisesResponseDTO>> ObtenerListadoPaises()
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAISES";

            var result = await DBConnection.Connection.QueryAsync<ObtenerListadoPaisesResponseDTO>(sql, null, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<ObtenerPaisesResponseDTO> ObtenerPaises(int idPaises)
        {
            const string sql = @"SC_SPP.MAESS_OBTENER_PAISES";

            var parameters = new DynamicParameters();
            parameters.Add("@ID_PAISES", idPaises, DbType.Int32);

            var result = await DBConnection.Connection.QueryAsync<ObtenerPaisesResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ObtenerPaisesPaginadoResponseDTO>> ObtenerPaisesPaginado(ObtenerPaisesPaginadoRequestDTO request)
        {
            const string sql = @"SC_SPP.MAESS_LISTAR_PAGINADO_PAISES";

            var parameters = new DynamicParameters();            
            parameters.Add("@CODIGO", request.codigo, DbType.String);
            parameters.Add("@NOMBRE_PAIS", request.nombre_pais, DbType.String);
            //parameters.Add("@ESTADO", request.estado, DbType.Int32);
            parameters.Add("@ESTADO_DESCRIPCION", request.estadoDescripcion, DbType.String);
            parameters.Add("@INICIO_PAGINA", ((request.paginaActual - 1) * request.tamanioPagina), DbType.Int32);
            parameters.Add("@TAMANIO_PAGINA", request.tamanioPagina, DbType.Int32);
            parameters.Add("@ACTIVO", request.activo, DbType.Boolean);


            var result = await DBConnection.Connection.QueryAsync<ObtenerPaisesPaginadoResponseDTO>(sql, parameters, DBConnection.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
