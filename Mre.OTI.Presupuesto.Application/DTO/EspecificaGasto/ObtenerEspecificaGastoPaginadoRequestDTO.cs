using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.EspecificaGasto
{
    public class ObtenerEspecificaGastoPaginadoRequestDTO : Pagination
    {
        
        public int anio { get; set; }
        public string clasificador { get; set; }
        public string descripcion { get; set; }
        //public string descripcion_detallada { get; set; }
        
        //public string estadoDescripcion { get; set; }
        //public int id_Categoria_Gasto { get; set; }
        //public string tipo_Clasificador { get; set; }
        public bool? activo { get; set; }
        
    }
}
