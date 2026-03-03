using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.FasesPoi
{
    public class ObtenerFasesPoiPaginadoResponseDTO
    {
        public int idFasesPoi { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string codigoFases { get; set; }
        public string descripcionFases { get; set; }

        public int anioInicial { get; set; }
        public int anioFinal { get; set; }        

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public int draw { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
