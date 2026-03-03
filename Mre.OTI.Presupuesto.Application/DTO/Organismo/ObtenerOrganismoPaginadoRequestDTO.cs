using Mre.OTIv1.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.Organismo
{
    public class ObtenerOrganismoPaginadoRequestDTO : Pagination
    {
        public int idPais { get; set; }
        public int idTipoEntidad { get; set; }
    }
}
