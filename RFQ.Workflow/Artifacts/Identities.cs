namespace RFQ.Workflow.Artifacts
{
    using System;
    using Magnum;

    static class Identities
    {
        internal static Guid ConfigurationActorId = CombGuid.Generate();
        internal static Guid HeartbeatActorId = CombGuid.Generate();
        internal static Guid BrokersActorId = CombGuid.Generate();
        internal static Guid DispatchActorId = CombGuid.Generate();
        internal static Guid QuotesActorId = CombGuid.Generate();
        internal static Guid RFQActorId = CombGuid.Generate();
        internal static Guid GTNActorId = CombGuid.Generate();
    }
}
