namespace RFQ.Workflow.Utils
{
    using System;
    using Artifacts;
    using Core.Exceptions;
    using Properties;
    using Stact;

    static class ActorRegistryExtensions
    {
        #region SendToActor Members

        internal static void SendToHeartbeatActor<T>(this ActorRegistry registry, T message)
        {
            registry.SendToActor(message, new ActorUrn(Identities.HeartbeatActorId));
        }

        internal static void SendToConfigurationActor<T>(this ActorRegistry registry, T message)
        {
            registry.SendToActor(message, new ActorUrn(Identities.ConfigurationActorId));
        }

        internal static void SendToBrokersActor<T>(this ActorRegistry registry, T message)
        {
            registry.SendToActor(message, new ActorUrn(Identities.BrokersActorId));
        }

        internal static void SendToDispatchActor<T>(this ActorRegistry registry, T message)
        {
            registry.SendToActor(message, new ActorUrn(Identities.DispatchActorId));
        }

        internal static void SendToQuotesActor<T>(this ActorRegistry registry, T message)
        {
            registry.SendToActor(message, new ActorUrn(Identities.QuotesActorId));
        }

        internal static void SendToRFQActor<T>(this ActorRegistry registry, T message)
        {
            registry.SendToActor(message, new ActorUrn(Identities.RFQActorId));
        }

        internal static void SendToGTNActor<T>(this ActorRegistry registry, T message)
        {
            registry.SendToActor(message, new ActorUrn(Identities.GTNActorId));
        }

        private static void SendToActor<T>(this ActorRegistry registry, T message, ActorUrn actorUrn)
        {
            registry.Send(message, header => header.DestinationAddress = actorUrn);
        }

        #endregion

        #region Execute Members

        internal static void HeartbeatActorExecute(this ActorRegistry registry, Action<ActorRef> action)
        {
            registry.Execute(Identities.HeartbeatActorId, action);
        }

        internal static void ConfigurationActorExecute(this ActorRegistry registry, Action<ActorRef> action)
        {
            registry.Execute(Identities.ConfigurationActorId, action);
        }

        internal static void BrokersActorExecute(this ActorRegistry registry, Action<ActorRef> action)
        {
            registry.Execute(Identities.BrokersActorId, action);
        }

        internal static void DispatchActorExecute(this ActorRegistry registry, Action<ActorRef> action)
        {
            registry.Execute(Identities.DispatchActorId, action);
        }

        internal static void QuotesActorExecute(this ActorRegistry registry, Action<ActorRef> action)
        {
            registry.Execute(Identities.QuotesActorId, action);
        }

        internal static void RFQActorExecute(this ActorRegistry registry, Action<ActorRef> action)
        {
            registry.Execute(Identities.RFQActorId, action);
        }

        internal static void GTNActorExecute(this ActorRegistry registry, Action<ActorRef> action)
        {
            registry.Execute(Identities.GTNActorId, action);
        }

        private static void Execute(this ActorRegistry registry, Guid actorId, Action<ActorRef> action)
        {
            registry.Get(actorId, action, () =>
            {
                throw new RFQRuntimeException(String.Format(Resources.ActorNotFoundMessage, actorId));
            });
        }

        #endregion
    }
}
