using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Objetivos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Objetivos.Queries
{
    public class ObtenerCodigoObjetivosViewModel : IRequest<ObtenerCodigoObjetivosResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int anio { get; set; }
        public string codigoObjetivos { get; set; }
    }
}
