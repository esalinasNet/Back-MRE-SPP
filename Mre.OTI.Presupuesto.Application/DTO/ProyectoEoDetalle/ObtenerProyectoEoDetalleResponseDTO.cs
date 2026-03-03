using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTIv1.Application.DTO.ProyectoEoDetalle
{
    public class ObtenerProyectoEoDetalleResponseDTO
    {
        public int idProyectoEstructuraOrgDetalle { get; set; }
        public int idProyectoEstructuraOrgDetallePadre { get; set; }
        public int idNaturaleza { get; set; }
        public string descripcionNaturaleza { get; set; }
        public int idTipo { get; set; }
        public string descripcionTipo {  get; set; }
        public int idProyectoEstructuraOrg { get; set; }
        public int idSede { get; set; }
        public int codigoSede { get; set; }
        public int idOrganismo { get; set; }
        public int idPais { get; set; }
        public int idTipoEntidad { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string sigla { get; set; }
        public int posPrevista { get; set; }
        public int posOcupada { get; set; }
        public string descripcionSede {  get; set; }
        public string denominacion { get; set; }
        public int cantidadCargo { get; set; }
        public int orden { get; set; }
        public bool activo { get; set; }
        public string codigoUnidadOrganizacional { get; set; }
        public string codigoUnidadOrganizacionalPadre { get; set; }

        public int idTipoClasificacion { get; set; }
    }
}
