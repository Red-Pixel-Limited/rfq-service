namespace RFQ.Repository.Management
{
    using System;
    using Core.Management;
    using NHibernate;

    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private bool _isDisposed;
        private readonly ISessionFactory _factory;

        public UnitOfWorkFactory(ISessionFactory factory)
        {
            _factory = factory;
        }

        ~UnitOfWorkFactory()
        {
            Dispose(false);
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(_factory.OpenSession());
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;
            if (disposing) _factory.Dispose();
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
