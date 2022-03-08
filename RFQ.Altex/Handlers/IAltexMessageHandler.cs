namespace RFQ.Altex.Handlers
{
    using global::Altex.MessageLibrary;

    internal interface IAltexMessageHandler
    {
        void Handle(MsgBase altexMessage);
    }
}
