using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Politicas
{
    public class ObtenerPoliticasPaginadoRequestDTO : Pagination
    {
        public int anio { get; set; }
        public string codigoPoliticas { get; set; }        
        public string descripcionObjetivo { get; set; }        
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}
