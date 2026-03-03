using Mre.OTIv1.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoMccSeguimiento
{
    public class ObtenerProyectoMccSeguimientoPaginadoRequestDTO : Pagination
    {
        public int idProyectoMcc {  get; set; }
    }
}
