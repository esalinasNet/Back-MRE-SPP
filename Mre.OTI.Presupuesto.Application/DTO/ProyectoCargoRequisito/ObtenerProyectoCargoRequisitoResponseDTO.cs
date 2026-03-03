using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoCargoRequisito
{
    public class ObtenerProyectoCargoRequisitoResponseDTO
    {
        public int idCargoRequisito { get; set; }
        public int idProyectoMccDetalle { get; set; }
        public int idTipoRequisito { get; set; }
        public string tipoRequisito { get; set; }
        public int idSubtipoRequisito { get; set; }
        public string subtipoRequisito { get; set; }
        public string descripcion { get; set; }
        public int orden {  get; set; }
        public int activo { get; set; }
    }
}
