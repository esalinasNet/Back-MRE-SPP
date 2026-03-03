using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoMcc
{
    public class ObtenerProyectoMccCargoRequisitoResponseDTO
    {
        public int idCargoRequisito { get; set; }
        public int idProyectoMccDetalle { get; set; }
        
        public int idTipoRequisito { get; set; }
        public int orden { get; set; }
        public string descripcion { get; set; }
        public int idSubTipoRequisito { get; set; }
 
    }
}
