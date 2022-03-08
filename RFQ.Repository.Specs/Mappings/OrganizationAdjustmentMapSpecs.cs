namespace RFQ.Repository.Specs.Mappings
{
    using System;
    using Comparers;
    using Core.Entities;
    using FluentNHibernate.Testing;
    using Machine.Specifications;
    using Repository.Mappings;
    using Setup;

    [Subject(typeof(OrganizationAdjustmentMap))]
    public class when_mapping_organization_adjustment
    {
        /** 
         * 1. Creates an OrganizationAdjustment instance
         * 2. Inserts the OrganizationAdjustment into the database
         * 3. Retrieves the record into a new OrganizationAdjustment instance
         * 4. Verifies the retrieved OrganizationAdjustment matches the original 
         */
        It should_pass = 
            () =>  new PersistenceSpecification<OrganizationAdjustment>(SharedSessionContext.TestSession)
                .CheckProperty(x => x.IsMarketMaker, true)
                .CheckProperty(x => x.UserId, 1)
                .CheckProperty(x => x.Created, DateTime.Now.AddDays(-1), new NullableDateTimeComparer())
                .CheckProperty(x => x.LastModified, DateTime.Now, new NullableDateTimeComparer())
                .CheckProperty(x => x.CreatedBy, "Me")
                .CheckProperty(x => x.ModifiedBy, "Me")
                .CheckReference(x => x.Configuration,
                    new InstrumentConfiguration
                    {
                        Name = "Rule USD",
                        RequestTimerDefault = 70000,
                        RequestTimerMinimum = 10000,
                        RequestTimerMaximum = 360000,
                        ResponseTimerDefault = 20000,
                        ResponseTimerMaximum = 20000,
                        ResponseTimerMinimum = 400000,
                        MinimumNumOfMarketMakers = 0,
                        DefaultSize = 3,
                        MinimumSize = 1,
                        MaximumSize = 7,
                        IsAnonymous = false,
                        IsMultipleExecutionAllowed = true,
                        ShouldTradeByVWAP = true,
                        ShouldTradeByAON = false,
                        ClearingType = "2",
                        ConfigurationType = 10,
                        RuleLevel = "Indicate Total Size",
                        OrderRule = 0,
                        Magnitude = "9",
                        TradeDisclosureToMissedResponders = "8",
                        TradeDisclosureToMarketData = "9",
                        InstrumentSizeValidationRules = "12",
                        Created = DateTime.Now,
                        LastModified = null,
                        CreatedBy = "Me",
                        ModifiedBy = null,
                        VenueId = "iSwapEVSP_US_Java",
                        ProductId = "product_01"
                    })
                .CheckReference(x => x.Organization,
                    new Organization
                    {
                        Name = "DEUTSCHE LONDON99",
                        MISCode = "0",
                        HitRatio = "0",
                        SuccessfulExecution = "0",
                        TotalRequest = "0",
                        ExternalId = "NTA5Ng_e_e",
                        VenueId = "GtnEVSP_Java",
                        ProductId = "product_01",
                        Created = DateTime.Now,
                        LastModified = null,
                        CreatedBy = "Me",
                        ModifiedBy = null
                    })
                .VerifyTheMappings();
    }
}
