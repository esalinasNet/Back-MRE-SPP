using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.CargoEstructural
{
    public class ObtenerCargoEstructuralResponseDTO
    {
        public int idCargoEstructural {  get; set; }
        public int idProyectoMcc {  get; set; }
        public int idTipoDocumento {  get; set; }
        public string descripcionTipoDocumento { get; set; }
        public string nombreProyecto { get; set; }
        public string descripcion { get; set; }
        public int mes {  get; set; }
        public int anio {  get; set; }
        public int cantidadCargos {  get; set; }
        public string numeroDocumento {  get; set; }
        public DateTime? fechaDocumento {  get; set; }
        public string documentoRuta {  get; set; }
        public bool activo {  get; set; }
        public DateTime fechaCreacion {  get; set; }
        public string usuarioCreacion { get; set; }
    }
}
