using Mre.OTIv1.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ClasificacionPersonal
{
    public class ObtenerClasificacionPersonalPaginadoRequestDTO : Pagination
    {
        public string nombreClasificacion { get; set; }
        public string siglaClasificacion { get; set; }
        public int idClasificacionPersonalPadre { get; set; }
        public bool? activo { get; set; }
    }
}
