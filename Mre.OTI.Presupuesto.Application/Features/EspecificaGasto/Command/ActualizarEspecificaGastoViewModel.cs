using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.EspecificaGasto.Command
{
    public class ActualizarEspecificaGastoViewModel : IRequest<CommandResponseViewModel>
    {
        public int idClasificador { get; set; }
        public int idAnio { get; set; }
        //public int anio { get; set; }
        public string clasificador { get; set; }
        public string descripcion { get; set; }
        public string descripcion_detallada { get; set; }
        public int idEstado { get; set; }
        //public int estado { get; set; }
        public bool? activo { get; set; }
        public string estadoDescripcion { get; set; }
        public int idCategoria_gasto { get; set; }
        public string tipo_clasificador { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
