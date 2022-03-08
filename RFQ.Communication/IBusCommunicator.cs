namespace RFQ.Communication
{
    using System;
    using Artifacts;
    using Messages;

    public interface IBusCommunicator : IDisposable
    {
        event BrokersConfigurationCallback BrokersDetected;

        bool IsConnected { get; }

        void Connect(params string[] arguments);

        void SubscribeFor<T>(Action<T> proceedAction) where T : CommunicationMessage;
        
        void Send<T>(T message) where T : CommunicationMessage;

        void UnsubscribeFrom<T>() where T : CommunicationMessage;
        
        void UnsubscribeFromAll();

        void Disconnect();
    }
}
