using Mre.OTIv1.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.CargoEstructuralDetalle
{
    public class ObtenerCargoEstructuralDetallePaginadoRequestDTO : Pagination
    {
        public int idCargoEstructural {  get; set; }
        public string nombreCargoEstructural { get; set; }
        public string sigla {  get; set; }
    }
}
