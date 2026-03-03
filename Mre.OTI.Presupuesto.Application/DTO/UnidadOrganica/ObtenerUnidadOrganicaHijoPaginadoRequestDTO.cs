using Mre.OTIv1.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.UnidadOrganica
{
    public class ObtenerUnidadOrganicaHijoPaginadoRequestDTO : Pagination
    {
        public int idUnidadOrganicaPadre {  get; set; }
    }
}
