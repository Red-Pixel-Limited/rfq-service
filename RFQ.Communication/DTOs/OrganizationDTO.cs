namespace RFQ.Communication.DTOs
{
    public sealed class OrganizationDTO
    {
        public string OrganizationId { get; private set; }
        public string DisplayName { get; private set; }
        public string ShortName { get; private set; }

        public OrganizationDTO(string organizationId, 
                               string displayName, 
                               string shortName)
        {
            OrganizationId = organizationId;
            DisplayName = displayName;
            ShortName = shortName;
        }
    }
}
