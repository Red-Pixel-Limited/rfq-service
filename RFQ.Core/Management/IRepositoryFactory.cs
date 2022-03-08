namespace RFQ.Core.Management
{
    using Persistence;

    public interface IRepositoryFactory
    {
        IUserRepository CreateForUser(IUnitOfWork uow);
        IQuoteRepository CreateForQuote(IUnitOfWork uow);
        IBrokerRepository CreateForBroker(IUnitOfWork uow);
        IRFQOfferRepository CreateForRFQOffer(IUnitOfWork uow);
        IAttributeRepository CreateForAttribute(IUnitOfWork uow);
        IOrganizationRepository CreateForOrganization(IUnitOfWork uow);
        IConfigurationRepository CreateForConfiguration(IUnitOfWork uow);
    }
}
