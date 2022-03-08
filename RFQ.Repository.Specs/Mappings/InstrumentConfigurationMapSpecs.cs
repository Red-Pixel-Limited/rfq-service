namespace RFQ.Repository.Specs.Mappings
{
    using System;
    using Comparers;
    using Core.Entities;
    using FluentNHibernate.Testing;
    using Machine.Specifications;
    using Repository.Mappings;
    using Setup;

    [Subject(typeof(InstrumentConfigurationMap))]
    public class when_mapping_instrument_configuration
    {
        /** 
         * 1. Creates an InstrumentConfiguration instance
         * 2. Inserts the InstrumentConfiguration into the database
         * 3. Retrieves the record into a new InstrumentConfiguration instance
         * 4. Verifies the retrieved InstrumentConfiguration matches the original 
         */
        It should_pass =
            () => new PersistenceSpecification<InstrumentConfiguration>(SharedSessionContext.TestSession)
                .CheckProperty(x => x.Name, "Rule USD")
                .CheckProperty(x => x.RequestTimerDefault, 70000)
                .CheckProperty(x => x.RequestTimerMinimum, 10000)
                .CheckProperty(x => x.RequestTimerMaximum, 360000)
                .CheckProperty(x => x.ResponseTimerDefault, 20000)
                .CheckProperty(x => x.ResponseTimerMinimum, 20000)
                .CheckProperty(x => x.ResponseTimerMaximum, 400000)
                .CheckProperty(x => x.MinimumNumOfMarketMakers, 0)
                .CheckProperty(x => x.DefaultSize, 3)
                .CheckProperty(x => x.MinimumSize, 1)
                .CheckProperty(x => x.MaximumSize, (long?)7)
                .CheckProperty(x => x.IsAnonymous, false)
                .CheckProperty(x => x.IsMultipleExecutionAllowed, true)
                .CheckProperty(x => x.ShouldTradeByVWAP, true)
                .CheckProperty(x => x.ShouldTradeByAON, false)
                .CheckProperty(x => x.ClearingType, "2")
                .CheckProperty(x => x.ConfigurationType, 10)
                .CheckProperty(x => x.RuleLevel, "Indicate Total Size")
                .CheckProperty(x => x.OrderRule, 0)
                .CheckProperty(x => x.Magnitude, "9")
                .CheckProperty(x => x.TradeDisclosureToMissedResponders, "8")
                .CheckProperty(x => x.TradeDisclosureToMarketData, "9")
                .CheckProperty(x => x.InstrumentSizeValidationRules, "12")
                .CheckProperty(x => x.Created, DateTime.Now, new NullableDateTimeComparer())
                .CheckProperty(x => x.LastModified, null)
                .CheckProperty(x => x.CreatedBy, "Me")
                .CheckProperty(x => x.ModifiedBy, null)
                .CheckProperty(x => x.VenueId, "iSwapEVSP_US_Java")
                .CheckProperty(x => x.ProductId, "product_01")
                .VerifyTheMappings();
    }
}
