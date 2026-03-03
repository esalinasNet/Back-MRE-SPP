using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Paises
{
    public class ObtenerPaisesPaginadoRequestDTO : Pagination
    {
        public int id_paises { get; set; }
        public string codigo { get; set; }
        public string nombre_pais { get; set; }
        public string continente { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}
