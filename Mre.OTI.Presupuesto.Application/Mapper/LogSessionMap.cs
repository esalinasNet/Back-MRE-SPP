using Mre.OTI.Presupuesto.Application.Features.LogSession.Command;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class LogSessionMap
    {
        public static LogSession MaptoEntity(dynamic item)
        {
            return new LogSession()
            {
                FECHA_LOGIN = DateTime.Now,
                IP_LOGIN = item.ipAcceso,
                USUARIO_LOGIN=item.userName
            }; 
        }
        public static LogSession MaptoEntity(AgregarLogSessionViewModel item)
        {
            return new LogSession()
            {
                IP_LOGIN = item.ipCreacion,
                ORIGEN_DISPOSITIVO=item.dispositivo
            };
        }
        public static LogSession MaptoEntity(AgregarLogSessionExteriorViewModel item)
        {
            return new LogSession()
            {
                IP_LOGIN = item.ipCreacion,
                ORIGEN_DISPOSITIVO = item.dispositivo
            };
        }
    }
}
