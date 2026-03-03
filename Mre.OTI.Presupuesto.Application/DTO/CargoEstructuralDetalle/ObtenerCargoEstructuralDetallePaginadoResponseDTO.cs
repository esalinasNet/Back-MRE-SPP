using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.CargoEstructuralDetalle
{
    public class ObtenerCargoEstructuralDetallePaginadoResponseDTO
    {
        public int idCargoEstructuralDetalle {  get; set; }
        public int idCargoEstructural {  get; set; }
        public int idProyectoMccDetalle {  get; set; }
        public string codigoCargoEstructural { get; set; }
        public string nombreCargoEstructural { get;set; }
        public string nombre {  get; set; }
        public string sigla { get; set; }
        public string siglaGenerada { get; set; }
        public int idClasificacionPersonalPadre { get; set; }
        public DateTime fechaCreacion {  get; set; }
        public bool esDirectivo {  get; set; }
        public int orden {  get; set; }
        public bool activo {  get; set; }
        public int registro {  get; set; }
        public int totalRegistro {  get; set; }
    }
}
