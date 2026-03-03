using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.UnidadMedida
{
    public class ObtenerUnidadMedidaPaginadoRequestDTO : Pagination
    {
        public int anio { get; set; }

        public string unidadMedida { get; set; }
        public string descripcion { get; set; }

        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }
    }
}
