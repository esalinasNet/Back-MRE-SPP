using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;

namespace Mre.OTI.Presupuesto.Application.Features.Recurso.Command
{
    public class EliminarRecursoViewModel : IRequest<CommandResponseViewModel>
    {
        public int idProgramacionRecurso { get; set; }
        public string ipModificacion { get; set; }
        public string usuarioModificacion { get; set; }
    }
}