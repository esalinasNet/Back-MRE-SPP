using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.UnidadOrganica
{
    public class ObtenerUnidadOrganicaPaginadoResponseDTO
    {
        public int idUnidadOrganica { get; set; }
        public int idNaturaleza { get; set; }
        public string descripcionNaturaleza { get; set; }
        public int idTipo { get; set; }
        public string descripcionTipo {  get; set; }
        public int idEstructuraOrganizacional { get; set; }
        public int idTipoClasificacion { get; set; }
        public int idSede { get; set; }
        public int idProyEstructuraOrgDetalle { get; set; }
        public int idOrganismo { get; set; }
        public int? idUnidadOrganicaPadre { get; set; }

        /// <summary>
        /// obsoleto no usar
        /// </summary>
        public string codigoUnidadOrganica { get; set; }
        /// <summary>
        ///obsoleto no usar
        /// </summary>
        public string codigoUnidadOrganicaPadre { get; set; }
        public string denominacion { get; set; }
        public string sigla { get; set; }
        public int posicionPrevista { get; set; }
        public int posicionOcupada { get; set; }
        public int orden { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public string codigoUnidadOrganizacional { get; set; }
        public string codigoUnidadOrganizacionalPadre { get; set; }
        public string descripcionSede { get; set; }
        

 
    }
}
