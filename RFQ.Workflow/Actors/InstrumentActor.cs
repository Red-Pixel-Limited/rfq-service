namespace RFQ.Workflow.Actors
{
    using Stact;

    sealed class InstrumentActor : 
        Actor
    {
        public InstrumentActor(Inbox inbox)
        {
            inbox.Loop(loop =>
            {
                
            });
        }
    }
}
