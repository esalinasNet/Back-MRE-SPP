using Mre.OTI.Presupuesto.Application.DTO.FuenteFinanciamiento;
using Mre.OTI.Presupuesto.Application.DTO.Politicas;
using Mre.OTI.Presupuesto.Application.Features.FuenteFinanciamiento.Queries;
using Mre.OTI.Presupuesto.Application.Features.Politicas.Queries;
using Mre.OTI.Presupuesto.Application.Responses.FuenteFinanciamiento;
using Mre.OTI.Presupuesto.Application.Responses.Politicas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class FuenteFinanciamientoMap
    {
        public static ObtenerListadoFuenteFinanciamientoResponseViewModel MaptoViewModelFuente(dynamic item)
        {
            return new ObtenerListadoFuenteFinanciamientoResponseViewModel()
            {
                idFuente = item.idFuente,
                idAnio = item.idAnio,
                anio = item.anio,
                fuente = item.fuente,
                codigoFuente = item.codigoFuente,
                descripcionFuente = item.descripcionFuente,
                descripcionRubro = item.descripcionRubro,                
                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }
    
        public static ObtenerListadoFuenteFinanciamientoRequestDTO MaptoFuenteDTO(ObtenerListadoFuenteFinanciamientoViewModel item)
        {
            return new ObtenerListadoFuenteFinanciamientoRequestDTO()
            {
                idAnio = item.idAnio
            };
        }

    }
}
