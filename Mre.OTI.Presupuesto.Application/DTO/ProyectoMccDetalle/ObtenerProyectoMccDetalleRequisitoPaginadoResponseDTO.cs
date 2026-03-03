using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoMccDetalle
{
    public class ObtenerProyectoMccDetalleRequisitoPaginadoResponseDTO
    {
     



        public int registro { get; set; }
        public int totalRegistro { get; set; }
        public int idCargoRequisito { get; set; }


        public string descripcion { get; set; }
        public int orden { get; set; }
        public int idTipoRequisito { get; set; }
        public int idSubTipoRequisito { get; set; }
        
        public string tipoRequisito { get; set; }
        public string subTipoRequisito { get; set; }
    }
}
