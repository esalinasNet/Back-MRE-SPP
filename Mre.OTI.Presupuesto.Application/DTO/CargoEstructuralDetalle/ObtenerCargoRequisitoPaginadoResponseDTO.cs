using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.CargoEstructuralDetalle
{
    public class ObtenerCargoRequisitoPaginadoResponseDTO
    {
        public int idCargoRequisito { get; set; }
        public int idCargoEstructuralDetalle { get; set; }
        public int idTipoRequisito { get; set; }
        public string tipoRequisito { get; set; }
        public int idSubtipoRequisito { get; set; }
        public string subtipoRequisito { get; set; }
        public string sigla { get; set; }
        public string descripcion { get; set; }
        public int orden { get; set; }
        public bool activo { get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
