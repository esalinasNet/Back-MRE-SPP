using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.Objetivos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Acciones.Queries
{
    public class ObtenerAccionesViewModel : IRequest<ObtenerAccionesResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idAcciones { get; set; }
    }
}
