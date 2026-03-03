using Mre.OTIv1.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoEo
{
    public class ObtenerProyectoEoPaginadoRequestDTO : Pagination
    {
        public string nombreProyecto { get; set; }
        public string fraseDesencriptacion {  get; set; }
        public int idTipoDocumento { get; set; }
        // public string numeroDocumento { get; set; }
        public bool? activo { get; set; }

        //public int idTipoDocumento { get; set; }
        public int idEstadoProyecto { get; set; }
        //public string nombreProyecto { get; set; }
        public int idPeriodo { get; set; }

        public int situacion { get; set; }
    }
}
