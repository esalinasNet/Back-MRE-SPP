using Mre.OTIv1.Application.Base.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoEoDetalle
{
    public class ObtenerProyectoEoDetalleHijoPaginadoRequestDTO : Pagination
    {
        public int idProyectoEoDetallePadre {  get; set; }
        //public int idNaturaleza {  get; set; }
        //public int idTipo {  get; set; }
        //public string denominacion {  get; set; }
    }
}
