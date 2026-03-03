using Mre.OTI.Presupuesto.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.ObjetivosInstitucionales
{
    public class ObtenerObjetivosInstitucionalesPaginadoRequestDTO : Pagination
    {
        public int anio { get; set; }
        public string codigoObjetivos { get; set; }
        public string descripcionObjetivos { get; set; }
        public string codigoAcciones { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}
