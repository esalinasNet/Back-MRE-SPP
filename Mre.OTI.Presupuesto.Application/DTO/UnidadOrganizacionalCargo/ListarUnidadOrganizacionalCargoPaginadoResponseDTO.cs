using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.UnidadOrganizacionalCargo
{
    public class ListarUnidadOrganizacionalCargoPaginadoResponseDTO
    {
        public int idUnidadOrganizacionalCargo { get; set; }
        public int posicionPrevista {  get; set; }
        public int posicionOcupada { get; set; }
        public string nombreCargoEstructural {  get; set; }
        public string siglaGenerada {  get; set; }
        public string codigoCargoEstructural { get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
