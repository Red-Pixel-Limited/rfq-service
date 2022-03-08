namespace RFQ.Communication.DTOs
{
    public sealed class UserDTO
    {
        public string UserId { get; private set; }
        public string DisplayName { get; private set; }
        public string ShortName { get; private set; }
        public string OrganizationId { get; private set; }
        public string UserRole { get; private set; }
        public bool IsMarketMaker { get; private set; }

        public UserDTO(string userId, 
                       string displayName, 
                       string shortName, 
                       string organizationId, 
                       string userRole, 
                       bool isMarketMaker)
        {
            IsMarketMaker = isMarketMaker;
            UserRole = userRole;
            OrganizationId = organizationId;
            ShortName = shortName;
            DisplayName = displayName;
            UserId = userId;
        }
    }
}
