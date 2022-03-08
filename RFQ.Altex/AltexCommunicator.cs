namespace RFQ.Altex
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Communication;
    using Communication.Artifacts;
    using Communication.Messages;
    using global::Altex.MessageLibrary;
    using Handlers;
    using Management;
    using Mappings.Messages;
    using Utils;

    public sealed class AltexCommunicator : IBusCommunicator
    {
        private bool _isDisposed;
        private readonly MsgLib _engine = new MsgLib("Altex");
        private readonly IDictionary<Type, IAltexMessageHandler> _handlersRegistry = 
            new Dictionary<Type, IAltexMessageHandler>();

        public event BrokersConfigurationCallback BrokersDetected;

        public bool IsConnected { get; private set; }

        ~AltexCommunicator()
        {
            Dispose(false);
        }

        #region IBusCommunicator Members

        public void Connect(params string[] arguments)
        {
            if (IsConnected) return;

            _engine.GetComponentSettings(ArgumentsParser.GetProcessName(arguments), Setup);
            _engine.StartHeartBeatManager(ArgumentsParser.GetHeartbeatTopic(arguments));

            IsConnected = true;
        }

        public void SubscribeFor<T>(Action<T> proceedAction) where T : CommunicationMessage
        {
            var typeOfMessage = typeof(T);

            if (_handlersRegistry.ContainsKey(typeOfMessage))
                return;

            var msgType = AltexTypesMatcher.Created.MatchMessageType(typeOfMessage);

            var mapper = AltexMapFactory.Create<IAltexMessageMapper<T>>();
            var handler = new AltexMessageHandler<T>(proceedAction, mapper);

            _handlersRegistry.Add(typeOfMessage, handler);
            _engine.CreateListener("*", msgType, handler.Handle);
        }

        public void Send<T>(T message) where T : CommunicationMessage
        {
            var mapper = AltexMapFactory.Create<IOutgoingMessageMapper<T>>();
            var altexMessage = mapper.Map(message);
            altexMessage.SendMessage(_engine);
        }

        public void UnsubscribeFrom<T>() where T : CommunicationMessage
        {
            var typeOfMessage = typeof(T);

            if (!_handlersRegistry.ContainsKey(typeOfMessage))
                return;

            Unsubscribe(typeOfMessage, _handlersRegistry[typeOfMessage]);
            _handlersRegistry.Remove(typeOfMessage);
        }

        public void UnsubscribeFromAll()
        {
            foreach (var entry in _handlersRegistry)
                Unsubscribe(entry.Key, entry.Value);

            _handlersRegistry.Clear();
        }

        private void Unsubscribe(Type typeOfMessage, IAltexMessageHandler handler)
        {
            var msgType = AltexTypesMatcher.Created.MatchMessageType(typeOfMessage);
            _engine.DeleteListener("*", msgType, handler.Handle);
        }

        public void Disconnect()
        {
            if (!IsConnected) return;

            _engine.StopHeartBeatManager();
            
            IsConnected = false;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            if (disposing)
            {
                Disconnect();
                UnsubscribeFromAll();
                _engine.Dispose();
            }

            _isDisposed = true;
        }

        #endregion

        #region Brokers Configuration

        private void Setup(DataSet dataSet)
        {
            var configuration = ConfigurationParser.Parse(dataSet);
            OnBrokersDetected(configuration);
        }

        private void OnBrokersDetected(IList<BrokerConfiguration> configuration)
        {
            var handler = BrokersDetected;
            if (handler != null) handler(configuration);
        }

        #endregion
    }
}
