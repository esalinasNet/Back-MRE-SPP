using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Calendario;
using Mre.OTI.Presupuesto.Application.DTO.Politicas;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Calendario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Politicas
{
    public class ObtenerPoliticasPaginadoResponseViewModel : IMapFrom<ObtenerPoliticasPaginadoResponseDTO>
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

        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerPoliticasPaginadoResponseDTO, ObtenerPoliticasPaginadoResponseViewModel>();
        }
    }

    public class dtPoliticasPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerPoliticasPaginadoResponseViewModel> data { get; set; }
    }
}
