using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Objetivos;
using Mre.OTI.Presupuesto.Application.Responses.Politicas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Objetivos.Queries
{
    public class ObtenerListadoObjetivosViewModel : IRequest<IEnumerable<ObtenerListadoObjetivosResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
    }
}
