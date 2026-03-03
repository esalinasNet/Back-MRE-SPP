using Mre.OTI.Presupuesto.Application.Repositories;

namespace Mre.OTI.Presupuesto.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBConnection _DBConnection;

        public UnitOfWork(DBConnection DBConnection)
        {
            _DBConnection = DBConnection;
        }

        public void BeginTransaction()
        {
            _DBConnection.Transaction = _DBConnection.Connection.BeginTransaction();
        }

        public void Commit()
        {
            _DBConnection.Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _DBConnection.Transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            _DBConnection.Transaction?.Dispose();
        }
    }
}
