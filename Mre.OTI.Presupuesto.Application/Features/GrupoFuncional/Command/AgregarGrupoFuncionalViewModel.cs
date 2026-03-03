using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.GrupoFuncional.Command
{
    public class AgregarGrupoFuncionalViewModel : IRequest<CommandResponseViewModel>
    {
        public int idGrupoFuncional { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string grupoFuncional { get; set; }
        public string descripcion { get; set; }

        public int idEstado { get; set; }

        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }

    }
}
