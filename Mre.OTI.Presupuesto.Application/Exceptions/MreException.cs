using System;

namespace Mre.OTI.Presupuesto.Application.Exceptions
{
    public class MreException : Exception
    {
        public MreException()
        {
        }

        public MreException(string message)
            : base(message)
        {
        }

        public MreException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
