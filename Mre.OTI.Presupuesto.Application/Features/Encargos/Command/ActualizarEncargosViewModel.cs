using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;

namespace Mre.OTI.Presupuesto.Application.Features.Encargos.Command
{
    public class ActualizarEncargosViewModel : IRequest<CommandResponseViewModel>
    {
        public int idProgramacionEncargos { get; set; }
        public int idProgramacionRecurso { get; set; }
        public int idProgramacionTareas { get; set; }
        public int idAnio { get; set; }
        public int idActividadOperativa { get; set; }
        public int idTarea { get; set; }
        public int? idUnidadMedida { get; set; }
        public bool? representativa { get; set; }
        public int? idFuenteFinanciamiento { get; set; }
        public int? idUbigeo { get; set; }
        public int? tipoUbigeo { get; set; }

        // Montos mensuales
        public decimal? montoEnero { get; set; }
        public decimal? montoFebrero { get; set; }
        public decimal? montoMarzo { get; set; }
        public decimal? montoAbril { get; set; }
        public decimal? montoMayo { get; set; }
        public decimal? montoJunio { get; set; }
        public decimal? montoJulio { get; set; }
        public decimal? montoAgosto { get; set; }
        public decimal? montoSetiembre { get; set; }
        public decimal? montoOctubre { get; set; }
        public decimal? montoNoviembre { get; set; }
        public decimal? montoDiciembre { get; set; }

        // Campos específicos de Encargos
        public int? clasificadorGasto { get; set; }
        public string denominacionRecurso { get; set; }
        public decimal? valor { get; set; }

        public int idEstado { get; set; }
        public string ipModificacion { get; set; }
        public string usuarioModificacion { get; set; }
    }
}