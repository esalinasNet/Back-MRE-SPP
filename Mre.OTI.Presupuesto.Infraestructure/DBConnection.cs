using System;
using System.Data;
using System.Data.SqlClient;

namespace Mre.OTI.Presupuesto.Infraestructure
{
    public class DBConnection : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DBConnection(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
