using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Planillas.Command
{   
    public class ActualizarPlanillasViewModel : IRequest<CommandResponseViewModel>
    {
        public int idPlanillas { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public int idMes { get; set; }
        public int Mes { get; set; }

        public int idPrograma { get; set; }
        
        public int idProducto { get; set; }
        
        public int idActividad { get; set; }        

        public int Meta { get; set; }

        public int idFinalidad { get; set; }        

        public int idCentroCostos { get; set; }        

        public int tipoDocumento { get; set; }
        public string nroDocumento { get; set; }
        public string apellidosNombres { get; set; }

        public int idEstado { get; set; }
        
        public bool? activo { get; set; }

        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
