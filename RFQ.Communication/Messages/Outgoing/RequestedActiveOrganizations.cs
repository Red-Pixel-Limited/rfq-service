namespace RFQ.Communication.Messages.Outgoing
{
    using System.Collections.Generic;
    using DTOs;

    public sealed class RequestedActiveOrganizations : CommunicationMessage
    {
        public IList<OrganizationDTO> Organizations { get; private set; } 

        public RequestedActiveOrganizations(string requestId, IList<OrganizationDTO> organizations) 
            : base(requestId)
        {
            Organizations = organizations;
        }
    }
}
