using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Domain.Setting
{
    public class SmtpSettings
    {
        private string host;
        private string username;
        private string password;

        public string Host { get => host; set => host = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public int Port { get; set; }

        public string OutgoingMail { get; set; }
        /// <summary>
        /// INDICADOR SI SE ENNVIA EL CORREO O NO SE ENVIA
        /// </summary>
        public bool Enabled { get; set; }
        
    }

}
