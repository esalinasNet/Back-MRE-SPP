using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Componente;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Componente;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Componente
{
    public class ObtenerComponentePaginadoResponseViewModel : IMapFrom<ObtenerComponentePaginadoResponseDTO>
    {
        public int idComponente { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public string componente { get; set; }
        public string tipoComponente { get; set; }
        public string descripcion { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public int activo { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerComponentePaginadoResponseDTO, ObtenerComponentePaginadoResponseViewModel>();
        }
    }

    public class dtComponentePaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerComponentePaginadoResponseViewModel> data { get; set; }
    }
}
