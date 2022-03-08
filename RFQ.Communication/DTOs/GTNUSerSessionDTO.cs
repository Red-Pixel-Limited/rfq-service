namespace RFQ.Communication.DTOs
{
    using System;
    using Options;

    public sealed class GTNUserSessionDTO
    {
        public string UserId { get; private set; }
        public string OrganizationId { get; private set; }
        public string GTNUserSessionId { get; private set; }
        public GTNUserSessionStatus SessionStatus { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public GTNUserSessionDTO(string userId, 
                                 string organizationId, 
                                 string sessionId,
                                 GTNUserSessionStatus sessionStatus,
                                 DateTime createdAt)
        {
            CreatedAt = createdAt;
            SessionStatus = sessionStatus;
            GTNUserSessionId = sessionId;
            OrganizationId = organizationId;
            UserId = userId;
        }
    }
}
