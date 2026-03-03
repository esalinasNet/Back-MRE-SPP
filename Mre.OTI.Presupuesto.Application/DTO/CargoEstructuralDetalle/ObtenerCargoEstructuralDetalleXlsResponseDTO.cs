using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.CargoEstructuralDetalle
{
    public class ObtenerCargoEstructuralDetalleXlsResponseDTO
    {
        public string clasificacion { get; set; }
        public string sigla { get; set; }
        public string nombreCargoEstructural { get; set; }


        public bool situacion { get; set; }
    }
}
