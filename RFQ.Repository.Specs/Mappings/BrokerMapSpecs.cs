namespace RFQ.Repository.Specs.Mappings
{
    using System;
    using Comparers;
    using Core.Entities;
    using FluentNHibernate.Testing;
    using Machine.Specifications;
    using Setup;

    [Subject(typeof(Broker))]
    public class when_mapping_broker
    {
        /** 
         * 1. Creates an Broker instance
         * 2. Inserts the Broker into the database
         * 3. Retrieves the record into a new Broker instance
         * 4. Verifies the retrieved Broker matches the original 
         */
        It should_pass = 
            () => new PersistenceSpecification<Broker>(SharedSessionContext.TestSession)
                .CheckProperty(x => x.IBUsername, "john_doe")
                .CheckProperty(x => x.IBPassword, "supersecret")
                .CheckProperty(x => x.CanAutoConnect, true)
                .CheckProperty(x => x.Notes, "Note 1")
                .CheckProperty(x => x.VenueId, "iSwapEVSP_US_Java")
                .CheckProperty(x => x.ProductId, "product_01")
                .CheckProperty(x => x.Created, DateTime.Now, new NullableDateTimeComparer())
                .CheckProperty(x => x.LastModified, null)
                .CheckProperty(x => x.CreatedBy, "Me")
                .CheckProperty(x => x.ModifiedBy, null)
                .VerifyTheMappings();
    }
}
