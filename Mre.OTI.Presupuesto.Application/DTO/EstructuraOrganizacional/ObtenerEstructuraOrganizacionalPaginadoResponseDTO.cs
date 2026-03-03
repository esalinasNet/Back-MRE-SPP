using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.EstructuraOrganizacional
{
    public class ObtenerEstructuraOrganizacionalPaginadoResponseDTO
    {
        public int idEstructuraOrganizacional { get; set; }
        public int idProyectoEo { get; set; }
        public string nombreProyecto { get; set; }
        public string descripcion { get; set; }
        public int mes { get; set; }
        public int anio { get; set; }
        public int cantidadUnidad {  get; set; }
        public int idTipoDocumento { get; set; }
        public string descripcionTipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public DateTime fechaDocumento { get; set; }
        public string documentoRuta { get; set; }
        public bool activo { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
