using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Objetivos;
using Mre.OTI.Presupuesto.Application.Responses.ObjetivosInstitucionales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ObjetivosInstitucionales.Queries
{
    public class ObtenerListadoObjetivosInstitucionalesViewModel : IRequest<IEnumerable<ObtenerListadoObjetivosInstitucionalesResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
    }
}
