using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Actividad;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Actividad.Queries
{
    public class ObtenerListadoActividadViewModel : IRequest<IEnumerable<ObtenerListadoActividadResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }

    }
}
