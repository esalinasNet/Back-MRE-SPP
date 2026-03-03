using Mre.OTIv1.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoEoDetalle
{
    public class ObtenerProyectoEoDetallePaginadoPdfRequestDTO : Pagination
    {
        public int idProyectoEo {  get; set; }
    }
}
