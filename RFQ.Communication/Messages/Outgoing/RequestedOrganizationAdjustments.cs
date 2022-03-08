namespace RFQ.Communication.Messages.Outgoing
{
    using System.Collections.Generic;
    using DTOs;

    public sealed class RequestedOrganizationAdjustments : CommunicationMessage
    {
        public IList<OrganizationMetricsDTO> Adjustments { get; private set; }

        public RequestedOrganizationAdjustments(string requestId, IList<OrganizationMetricsDTO> adjustments)
            : base(requestId)
        {
            Adjustments = adjustments;
        }
    }
}
