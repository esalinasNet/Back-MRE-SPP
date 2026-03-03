using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.Objetivos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Acciones.Queries
{                                                                       
    public class ObtenerListadoAccionesViewModel : IRequest<IEnumerable<ObtenerListadoAccionesResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
    }
}
