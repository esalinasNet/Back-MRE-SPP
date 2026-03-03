using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoEoDetalle
{
    public class ObtenerProyectoEoDetalleHijoPaginadoResponseDTO
    {
        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public int idProyectoEoDetalle { get; set; }
        public int idNaturaleza {  get; set; }
        public string descripcionNaturaleza { get; set; }
        public int idTipo {  get; set; }
        public string descripcionTipo {  get; set; }
        public string denominacion {  get; set; }
        public bool activo { get; set; }
        public int orden { get; set; }
        public string codigoUnidadOrganica { get; set; }
        public string codigoUnidadOrganicaPadre { get; set; }
        public string descripcionSede { get; set; }
        public string sigla { get; set; }
    }
}
