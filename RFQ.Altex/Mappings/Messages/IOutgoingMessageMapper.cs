namespace RFQ.Altex.Mappings.Messages
{
    using Communication.Messages;
    using global::Altex.MessageLibrary;

    internal interface IOutgoingMessageMapper<in T> 
        where T : CommunicationMessage
    {
        MsgBase Map(T message);
    }
}
