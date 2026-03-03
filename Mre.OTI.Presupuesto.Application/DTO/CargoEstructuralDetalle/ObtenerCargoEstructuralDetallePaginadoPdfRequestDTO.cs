using Mre.OTIv1.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.CargoEstructuralDetalle
{
    public class ObtenerCargoEstructuralDetallePaginadoPdfRequestDTO : Pagination
    {
        public int idCargoEstructural {  get; set; }
    }
}
