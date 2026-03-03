using Mre.OTIv1.Application.DTO.UnidadOrganizacionalCargo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.UnidadOrganica
{
    public class ObtenerUnidadOrganicaXlsResponseDTO
    {
        public string codigoUnidadOrganizacional { get; set; }
        public string descripcionSede { get; set; }
        public string descripcionNaturaleza { get; set; }
        public string descripcionTipo { get; set; }
        public string sigla { get; set; }
        public string denominacion { get; set; }
        public List<ListarUnidadOrganizacionalCargoPaginadoResponseDTO> cargosAsignados { get; set; }
    }
}
