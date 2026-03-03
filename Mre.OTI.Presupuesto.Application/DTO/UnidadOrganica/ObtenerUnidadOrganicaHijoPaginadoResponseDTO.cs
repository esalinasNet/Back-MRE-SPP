using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.UnidadOrganica
{
    public class ObtenerUnidadOrganicaHijoPaginadoResponseDTO
    {
        public int idUnidadOrganica { get; set; }
        public int idEstructuraOrganizacional { get; set; }
        public int idNaturaleza { get; set; }
        public string descripcionNaturaleza { get; set; }
        public int idTipo { get; set; }
        public string descripcionTipo { get; set; }
        public int idSede { get; set; }
        public string descripcionSede { get; set; }
        public string denominacion { get; set; }
        public int orden { get; set; }
        public int activo { get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public string codigoUnidadOrganizacional { get; set; }
        public string sigla { get; set; }
    }
}
