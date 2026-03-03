using Mre.OTIv1.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.CargoEstructuralDetalle
{
    public class ObtenerCargoRequisitoPaginadoRequestDTO : Pagination
    {
        public int idCargoEstructuralDetalle {  get; set; }
    }
}
