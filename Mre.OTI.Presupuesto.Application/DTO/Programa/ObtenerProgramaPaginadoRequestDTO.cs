using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Programa
{
    public class ObtenerProgramaPaginadoRequestDTO : Pagination
    {
        public int Anio { get; set; }
        public string programa { get; set; }
        public string descripcion { get; set; }
        //public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}
