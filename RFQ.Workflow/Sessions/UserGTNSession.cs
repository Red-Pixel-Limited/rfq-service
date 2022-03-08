namespace RFQ.Workflow.Sessions
{
    public sealed class UserGTNSession
    {
        public string Id { get; private set; }

        public UserGTNSession(string id)
        {
            Id = id;
        }
    }
}
