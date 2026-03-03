using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;

namespace Mre.OTI.Presupuesto.Application.Features.Recurso.Command
{
    public class ActualizarRecursoViewModel : IRequest<CommandResponseViewModel>
    {
        public int idProgramacionRecurso { get; set; }
        public int idProgramacionActividad { get; set; }
        public int idProgramacionTareas { get; set; }
        public int? idAnio { get; set; }
        public int? idUbigeo { get; set; }
        public string clasificadorGasto { get; set; }
        public string denominacionRecurso { get; set; }
        public int? idTipoGasto { get; set; }
        public int? idTipoItem { get; set; }
        public decimal? montoTotal { get; set; }
        public int? idFuenteFinanciamiento { get; set; }
        public int? idUnidadMedida { get; set; }
        public bool? representativa { get; set; }
        public bool? gastoObn { get; set; }
        public bool? gastoProyecto { get; set; }
        public bool? gastoViaticos { get; set; }
        public bool? gastoCajaChica { get; set; }
        public bool? gastoOtrosGastos { get; set; }
        public bool? gastoEncargas { get; set; }
        public bool? gastoPlanilla { get; set; }
        public int idEstado { get; set; }
        public string ipModificacion { get; set; }
        public string usuarioModificacion { get; set; }
    }
}