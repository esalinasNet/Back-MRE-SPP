using Mre.OTIv1.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.CargoEstructural
{
    public class ObtenerCargoEstructuralPaginadoRequestDTO : Pagination
    {
        public string descripcionCargo {  get; set; }
        public int idTipoDocumento {  get; set; }
        public bool? activo {  get; set; }
        public string fraseDesencriptacion {  get; set; }
    }
}
