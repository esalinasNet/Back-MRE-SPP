using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.AccionesInstitucionales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AccionesInstitucionales.Queries
{
    public class ObtenerAccionesInstitucionalesViewModel : IRequest<ObtenerAccionesInstitucionalesResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idAcciones { get; set; }
    }
}
