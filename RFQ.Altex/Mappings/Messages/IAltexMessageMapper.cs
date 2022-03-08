namespace RFQ.Altex.Mappings.Messages
{
    using Communication.Messages;
    using global::Altex.MessageLibrary;

    internal interface IAltexMessageMapper<out T> where T : CommunicationMessage
    {
        T Map(MsgBase altexMessage);
    }
}
