using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.Politicas
{
    public class ObtenerPoliticasResponseDTO
    {
        public int idPoliticas { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public string codigoPoliticas { get; set; }
        public string descripcionPoliticas { get; set; }
        public string codigoObjetivo { get; set; }
        public string descripcionObjetivo { get; set; }
        public string codigoLinemiento { get; set; }
        public string descripcionLineamiento { get; set; }
        public string codigoServicio { get; set; }
        public string descripcionServicio { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}
