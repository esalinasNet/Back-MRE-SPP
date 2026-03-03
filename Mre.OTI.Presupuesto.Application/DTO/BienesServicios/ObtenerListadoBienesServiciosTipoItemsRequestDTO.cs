using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.BienesServicios
{
    public class ObtenerListadoBienesServiciosTipoItemsRequestDTO
    {
        public int idAnio { get; set; }
        public string tipoItems { get; set; }
        public string clasificadorGasto { get; set; }
    }
}
