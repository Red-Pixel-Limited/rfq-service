namespace RFQ.Communication.DTOs
{
    using System.Collections.Generic;

    public sealed class OrganizationMetricsDTO
    {
        public string OrganizationId { get; private set; }
        public string Name { get; private set; }
        public string MISCode { get; private set; }
        public string HitRatio { get; private set; }
        public bool IsMarketMaker { get; private set; }
        public string TotalRequest { get; private set; }
        public string SuccessfulExecution { get; private set; }
        public IList<UserDTO> Employees { get; private set; }

        public OrganizationMetricsDTO(string organizationId, 
                                      string name, 
                                      string misCode, 
                                      string hitRatio, 
                                      bool isMarketMaker, 
                                      string totalRequest, 
                                      string successfulExecution, 
                                      IList<UserDTO> employees = null)
        {
            Employees = employees ?? new List<UserDTO>();
            SuccessfulExecution = successfulExecution;
            TotalRequest = totalRequest;
            IsMarketMaker = isMarketMaker;
            HitRatio = hitRatio;
            MISCode = misCode;
            Name = name;
            OrganizationId = organizationId;
        }
    }
}
