using Dapper;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionAnios;
using Mre.OTI.Presupuesto.Application.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Repositories
{
    public class ProgramacionAniosRepository : IProgramacionAniosRepository
    {
        readonly DBConnection DBConnection;

        public ProgramacionAniosRepository(DBConnection _DBConnection)
        {
            this.DBConnection = _DBConnection;
        }

        public async Task<CopiarProgramacionAniosResponseDTO> CopiarProgramacion(
            int anioOrigen,
            List<int> aniosDestino,
            List<int> actividades,
            string usuarioCreacion)
        {
            const string sql = @"SC_SPP.prc_copiar_programacion_anios";

            var parameters = new DynamicParameters();
            parameters.Add("@AnioOrigen", anioOrigen, DbType.Int32);
            parameters.Add("@AniosDestinoJson", JsonConvert.SerializeObject(aniosDestino), DbType.String);
            parameters.Add("@ActividadesJson", JsonConvert.SerializeObject(actividades), DbType.String);

            var result = await DBConnection.Connection.QueryAsync<CopiarProgramacionAniosResponseDTO>(
                sql,
                parameters,
                DBConnection.Transaction,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault() ?? new CopiarProgramacionAniosResponseDTO
            {
                estado = "ERROR",
                mensaje = "No se obtuvo respuesta del procedimiento almacenado",
                aniosDestinoProcesados = 0,
                actividadesCopiadas = 0
            };
        }
    }
}