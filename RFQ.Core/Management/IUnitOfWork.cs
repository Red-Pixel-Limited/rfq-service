namespace RFQ.Core.Management
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void Rollback();
        void Commit();
    }
}
