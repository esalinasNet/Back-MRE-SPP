using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.Organismo
{
    public class ObtenerOrganismoFiltradoResponseDTO
    {
        public int idOrganismo { get; set; }
        public int idPais { get; set; }
        public string nombrePais { get; set; }
        public int idTipoEntidad { get; set; }
        public string nombreTipoEntidad { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string correo { get; set; }
        public string abreviatura { get; set; }
        //public bool esEmbajada { get; set; }
        //public bool activo { get; set; }
    }
}
