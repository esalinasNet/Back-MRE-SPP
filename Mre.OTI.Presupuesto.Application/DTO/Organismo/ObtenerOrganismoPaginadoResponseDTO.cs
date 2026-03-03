using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.Organismo
{
    public class ObtenerOrganismoPaginadoResponseDTO
    {
        public int idOrganismo {  get; set; }
        public int idPais {  get; set; }
        public string descripcionPais {  get; set; }
        public int idTipoEntidad {  get; set; }
        public string descripcionTipoEntidad { get; set; }
        public string nombre { get; set; }
        public string descripcion {  get; set; }
        public string abreviatura { get; set; }
        public string correo { get; set; }
        public int registro {  get; set; }
        public int totalRegistro {  get; set; }
    }
}
