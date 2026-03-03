using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.BienesServicios;
using Mre.OTI.Presupuesto.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.BienesServicios
{
    public class ObtenerBienesServiciosPaginadoResponseViewModel : IMapFrom<ObtenerBienesServiciosPaginadoResponseDTO>
    {
        public int idBienesServicios { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string codigoBien { get; set; }
        public string nombreBien { get; set; }
        public string tipoItems { get; set; }

        public int idUnidadMedida { get; set; }
        public string descripcionUinidadMedida { get; set; }

        public decimal precio { get; set; }

        public int idClasificador { get; set; }
        public string clasificadorGasto { get; set; }
        public string descripcionClasificador { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool activo { get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerBienesServiciosPaginadoResponseDTO, ObtenerBienesServiciosPaginadoResponseViewModel>();
        }
    }

    public class dtBienesServiciosPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerBienesServiciosPaginadoResponseViewModel> data { get; set; }
    }
}
