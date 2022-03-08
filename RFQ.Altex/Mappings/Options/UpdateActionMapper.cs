namespace RFQ.Altex.Mappings.Options
{
    using Communication.Options;
    using Core.Exceptions;
    using global::Altex.MessageLibrary;
    using Utils;

    internal sealed class UpdateActionMapper : IOptionsMapper<UpdateAction, UpdateType>
    {
        public UpdateType Map(UpdateAction action)
        {
            switch (action)
            {
                case UpdateAction.Unknown:
                    return UpdateType.Unknown;
                case UpdateAction.Add:
                    return UpdateType.Add;
                case UpdateAction.Refresh:
                    return UpdateType.Refresh;
                case UpdateAction.Remove:
                    return UpdateType.Remove;
                case UpdateAction.Snapshot:
                    return UpdateType.Snapshot;
                case UpdateAction.Update:
                    return UpdateType.Update;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(action, typeof(UpdateType)));
            }
        }

        public UpdateAction Map(UpdateType updateType)
        {
            switch (updateType)
            {
                case UpdateType.Unknown:
                    return UpdateAction.Unknown;
                case UpdateType.Add:
                    return UpdateAction.Add;
                case UpdateType.Refresh:
                    return UpdateAction.Refresh;
                case UpdateType.Remove:
                    return UpdateAction.Remove;
                case UpdateType.Snapshot:
                    return UpdateAction.Snapshot;
                case UpdateType.Update:
                    return UpdateAction.Update;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(updateType, typeof(UpdateAction)));
            }
        }
    }
}
