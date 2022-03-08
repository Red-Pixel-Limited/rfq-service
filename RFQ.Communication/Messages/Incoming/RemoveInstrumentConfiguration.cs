namespace RFQ.Communication.Messages.Incoming
{
    using DTOs;

    public sealed class RemoveInstrumentConfiguration : CommunicationMessage
    {
        public InstrumentConfigurationDTO Configuration { get; private set; }

        public RemoveInstrumentConfiguration(string requestId,
                                             InstrumentConfigurationDTO configuration)
            : base(requestId)
        {
            Configuration = configuration;
        }
    }
}
