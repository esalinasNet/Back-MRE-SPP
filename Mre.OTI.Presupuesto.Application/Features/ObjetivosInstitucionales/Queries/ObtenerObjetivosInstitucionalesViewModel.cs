using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.ObjetivosInstitucionales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ObjetivosInstitucionales.Queries
{
    public class ObtenerObjetivosInstitucionalesViewModel : IRequest<ObtenerObjetivosInstitucionalesResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idObjetivos { get; set; }
    }
}
