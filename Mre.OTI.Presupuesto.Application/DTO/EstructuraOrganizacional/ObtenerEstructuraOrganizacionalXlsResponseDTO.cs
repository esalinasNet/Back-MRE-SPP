using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.EstructuraOrganizacional
{
    public class ObtenerEstructuraOrganizacionalXlsResponseDTO
    {
        public int mes { get; set; }
        public int anio { get; set; }
        public string descripcion { get; set; }
        public string nombreProyecto { get; set; }
        public string descripcionTipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
    }
}
