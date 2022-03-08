namespace RFQ.Repository.Specs.Mappings
{
    using System;
    using Core.Entities;
    using FluentNHibernate.Testing;
    using Machine.Specifications;
    using Repository.Mappings;
    using Setup;
    using Attribute = Core.Entities.Attribute;

    [Subject(typeof(AttributeMap))]
    public class when_mapping_attribute
    {
        /** 
         * 1. Creates an Attribute instance
         * 2. Inserts the Attribute into the database
         * 3. Retrieves the record into a new Attribute instance
         * 4. Verifies the retrieved Attribute matches the original 
         */
        It should_pass =
            () => new PersistenceSpecification<Attribute>(SharedSessionContext.TestSession)
                .CheckProperty(attribute => attribute.Name, "Venue")
                .CheckProperty(attribute => attribute.DisplayName, "Venue")
                .CheckProperty(attribute => attribute.Value, "GtnEVSP_Java")
                .CheckReference(attribute => attribute.Configuration, 
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
                .VerifyTheMappings();
    }
}
