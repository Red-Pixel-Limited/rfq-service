namespace RFQ.Workflow.Actors
{
    using Communication.Messages.Incoming;
    using Core.Entities;
    using Core.Management;
    using Stact;

    sealed class QuotesActor :
        Actor
    {
        public QuotesActor(Inbox inbox,
                           IUnitOfWorkFactory uowFactory,
                           IRepositoryFactory repositories)
        {
            inbox.Loop(loop =>
            {
                // TODO: OWNER REQUIRED
                // TODO: SHOULD I ALWAYS START TRANSACTION?
                loop.Receive<PassRFQ>(message =>
                {
                    using (var uow = uowFactory.Create())
                    {
                        var rfqRepository = repositories.CreateForRFQOffer(uow);
                        var quoteRepository = repositories.CreateForQuote(uow);
                        var rfq = rfqRepository.GetById(message.RFQId);
                        var quote = Quote.Pass(null, rfq);
                        quoteRepository.SaveOrUpdate(quote);
                        uow.Commit();
                    }
                });

                loop.Receive<Exit>(message =>
                {
                    inbox.Exit();
                    loop.Continue();
                });

                loop.Receive<Fault>(fault =>
                {
                    loop.Continue();
                });
            });
        }
    }
}
