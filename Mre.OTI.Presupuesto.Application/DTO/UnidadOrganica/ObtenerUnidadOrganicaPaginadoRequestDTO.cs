using Mre.OTIv1.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.UnidadOrganica
{
    public class ObtenerUnidadOrganicaPaginadoRequestDTO : Pagination
    {
        public string usuarioConsulta { get; set; }
        public int idEstructuraOrganizacional { get; set; }
        public int idNaturaleza { get; set; }
        public int idTipo { get; set; }
        public int idSede {  get; set; }
        public string sigla {  get; set; }
        public string denominacion { get; set; }
    }
}
