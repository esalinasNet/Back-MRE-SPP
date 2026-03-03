using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ClasificacionPersonal
{
    public class ObtenerClasificacionPersonalPaginadoResponseDTO
    {
        public int idClasificacionPersonal {  get; set; }
        public string nombreClasificacion { get; set; }
        public string siglaClasificacion {  get; set; }
        public int? idClasificacionPersonalPadre { get; set; }
        public string siglaPadreClasificacion { get; set; }
        //public string siglaGen {  get; set; }
        public DateTime fechaCreacion {  get; set; }
        public string usuarioCreacion { get; set; }
        public bool activo {  get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
