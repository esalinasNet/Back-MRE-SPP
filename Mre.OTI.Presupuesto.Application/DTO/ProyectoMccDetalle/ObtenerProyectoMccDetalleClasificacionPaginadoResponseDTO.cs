using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoMccDetalle
{
    public class ObtenerProyectoMccDetalleClasificacionPaginadoResponseDTO
    {
        public int registro { get; set; }
        public int totalRegistro { get; set; }
 
        public int idCargoClasificacionPersonal { get; set; }
        public int idClasificacionPersonal { get; set; }


        public string nombreClasificacion { get; set; }
        public string siglaClasificacion { get; set; }
        public int orden { get; set; }
       
    }
}
