using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Recurso;
using Mre.OTI.Presupuesto.Application.Mapper;
using System;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Responses.Recurso
{
    public class ObtenerRecursoPaginadoResponseViewModel : IMapFrom<ObtenerRecursoPaginadoResponseDTO>
    {        
        public int idProgramacionRecurso { get; set; }
        public int? idAnio { get; set; }
        public int? anio { get; set; }

        public int idProgramacionActividad { get; set; }
        public string codigoProgramacion { get; set; }

        public int idProgramacionTareas { get; set; }
        public string codigoTareas { get; set; }
        public string descripcionTareas { get; set; }

        //public int idProgramacionClasificador { get; set; }
        public int? idClasificador { get; set; }
        public string clasificador { get; set; }
        public string descripcionClasificador { get; set; }

        public string clasificadorGasto { get; set; }
        public string denominacionRecurso { get; set; }

        public int? idTipoGasto { get; set; }
        public int? idTipoItem { get; set; }
        public int? idUbigeo { get; set; }
        public string descripcionUbigeo { get; set; }

        public int idFuenteFinanciamiento { get; set; }
        public string codigoFuente { get; set; }
        public string descripcionFuenteFinanciamento { get; set; }
        
        public decimal? montoTotal { get; set; }
        public bool? gastoObn { get; set; }
        public bool? gastoProyecto { get; set; }
        public bool? gastoViaticos { get; set; }
        public bool? gastoCajaChica { get; set; }
        public bool? gastoOtrosGastos { get; set; }
        public bool? gastoEncargas { get; set; }
        public bool? gastoPlanilla { get; set; }

        public int idEstado { get; set; }
        public string estado { get; set; }
        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }

        /*public string usuarioCreacion { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public string usuarioModificacion { get; set; }
        public DateTime? fechaModificacion { get; set; }*/

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerRecursoPaginadoResponseDTO, ObtenerRecursoPaginadoResponseViewModel>();
        }
    }

    public class dtRecursoPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public IEnumerable<ObtenerRecursoPaginadoResponseViewModel> data { get; set; }
    }
}