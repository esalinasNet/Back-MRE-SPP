using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoMccSeguimiento
{
    public class ObtenerProyectoMccSeguimientoPaginadoResponseDTO
    {
        public int idProyectoMccSeguimiento {  get; set; }
        public int idProyectoMcc {  get; set; }
        public int idEstado { get; set; }
        public int idTipoComentario {  get; set; }
        public string comentario {  get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
