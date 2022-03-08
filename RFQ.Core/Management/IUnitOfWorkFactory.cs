namespace RFQ.Core.Management
{
    using System;

    public interface IUnitOfWorkFactory : IDisposable
    {
        IUnitOfWork Create();
    }
}
