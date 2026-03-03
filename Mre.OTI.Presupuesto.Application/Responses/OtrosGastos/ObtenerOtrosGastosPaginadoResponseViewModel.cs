using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.OtrosGastos;
using Mre.OTI.Presupuesto.Application.Mapper;
using System;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Responses.OtrosGastos
{
    public class ObtenerOtrosGastosPaginadoResponseViewModel : IMapFrom<ObtenerOtrosGastosPaginadoResponseDTO>
    {
        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public int idProgramacionOtrosGastos { get; set; }
        public int idProgramacionRecurso { get; set; }
        public int idProgramacionTareas { get; set; }
        public int idAnio { get; set; }
        public int idActividadOperativa { get; set; }
        public int idTarea { get; set; }
        public int? idUnidadMedida { get; set; }
        public bool? representativa { get; set; }
        public int? idFuenteFinanciamiento { get; set; }
        public int? idUbigeo { get; set; }
        public int? tipoUbigeo { get; set; }

        // Montos mensuales
        public decimal? montoEnero { get; set; }
        public decimal? montoFebrero { get; set; }
        public decimal? montoMarzo { get; set; }
        public decimal? montoAbril { get; set; }
        public decimal? montoMayo { get; set; }
        public decimal? montoJunio { get; set; }
        public decimal? montoJulio { get; set; }
        public decimal? montoAgosto { get; set; }
        public decimal? montoSetiembre { get; set; }
        public decimal? montoOctubre { get; set; }
        public decimal? montoNoviembre { get; set; }
        public decimal? montoDiciembre { get; set; }
        public decimal? montoTotal { get; set; }

        // ✅ Campos específicos de Otros Gastos
        public int? idGenerico { get; set; }
        public int? clasificadorGasto { get; set; }
        public string denominacionRecurso { get; set; }
        public decimal? valor { get; set; }

        // Datos relacionados
        public int anio { get; set; }
        public string codigoTareas { get; set; }
        public string descripcionTareas { get; set; }
        public string codigoProgramacion { get; set; }
        public string denominacionActividad { get; set; }
        public string descripcionUnidadMedida { get; set; }
        public string descripcionFuenteFinanciamiento { get; set; }
        public string descripcionUbigeo { get; set; }

        public int idEstado { get; set; }
        public string estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public string usuarioCreacion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioModificacion { get; set; }
        public DateTime? fechaModificacion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerOtrosGastosPaginadoResponseDTO, ObtenerOtrosGastosPaginadoResponseViewModel>();
        }
    }

    public class dtOtrosGastosPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public IEnumerable<ObtenerOtrosGastosPaginadoResponseViewModel> data { get; set; }
    }
}