using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Seguridad
{
    public class ObtenerAutozacionInfoResponseViewModel
    {
        public List<OpcionViewModel> Opciones { get; set; }
        public List<PermisoViewModel> Permisos { get; set; }
        public bool result { get; set; }
        public string message { get; set; }
    }

    public class OpcionViewModel
    {
        public int IdOpcion { get; set; }
        public int? IdOpcionPadre { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
    }

    public class PermisoViewModel
    {
        public int IdOpcion { get; set; }
        public int IdPerfil { get; set; }
        public string Accion { get; set; }
    }
}
