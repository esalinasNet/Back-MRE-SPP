using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.CargoEstructuralDetalle
{
    public class ObtenerCargoClasificacionPersonalResponseDTO
    {
        public int idCargoClasificacionPersonal { get; set; }
        public int orden { get; set; }
        public string nombreClasificacion { get; set; }
        public string sigla { get; set; }
        public int idClasificacionPersonal { get; set; }
        public bool activo { get; set; }



 

    }
}
