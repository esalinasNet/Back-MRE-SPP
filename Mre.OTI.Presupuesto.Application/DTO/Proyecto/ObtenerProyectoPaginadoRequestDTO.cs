using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Proyecto
{
    public class ObtenerProyectoPaginadoRequestDTO : Pagination
    {
        public int? idProgramacionTareas { get; set; }
        public int? anio { get; set; }
        public int? idActividadOperativa { get; set; }
        public int? tipoUbigeo { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}