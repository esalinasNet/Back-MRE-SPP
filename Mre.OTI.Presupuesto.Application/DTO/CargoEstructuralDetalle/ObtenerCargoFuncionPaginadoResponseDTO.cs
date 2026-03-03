using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.CargoEstructuralDetalle
{
    public class ObtenerCargoFuncionPaginadoResponseDTO
    {
        public int idCargoFuncion {  get; set; }
        public int idCargoEstructuralDetalle {  get; set; }
        public int idCargoEstructural { get; set; }
        public string descripcion {  get; set; }
        public int orden {  get; set; }
        public bool activo {  get; set; }
        
        public int registro {  get; set; }
        public int totalRegistro {  get; set; }
    }
}
