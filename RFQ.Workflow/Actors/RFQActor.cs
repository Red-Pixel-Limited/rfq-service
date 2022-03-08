namespace RFQ.Workflow.Actors
{
    using Stact;

    sealed class RFQActor : 
        Actor
    {
        public RFQActor(Inbox inbox)
        {
            inbox.Loop(loop =>
            {
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
