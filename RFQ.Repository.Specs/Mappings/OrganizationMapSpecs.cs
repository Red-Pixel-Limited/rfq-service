namespace RFQ.Repository.Specs.Mappings
{
    using System;
    using Comparers;
    using Core.Entities;
    using FluentNHibernate.Testing;
    using Machine.Specifications;
    using Repository.Mappings;
    using Setup;

    [Subject(typeof(OrganizationMap))]
    public class when_mapping_organization
    {
        /** 
         * 1. Creates an Organization instance
         * 2. Inserts the Organization into the database
         * 3. Retrieves the record into a new Organization instance
         * 4. Verifies the retrieved Organization matches the original 
         */
        It should_pass =
            () => new PersistenceSpecification<Organization>(SharedSessionContext.TestSession)
                .CheckProperty(x => x.Name, "DEUTSCHE LONDON99")
                .CheckProperty(x => x.MISCode, "0")
                .CheckProperty(x => x.HitRatio, "0")
                .CheckProperty(x => x.SuccessfulExecution, "0")
                .CheckProperty(x => x.TotalRequest, "0")
                .CheckProperty(x => x.ExternalId, "NTA5Ng_e_e")
                .CheckProperty(x => x.VenueId, "GtnEVSP_Java")
                .CheckProperty(x => x.ProductId, "product_01")
                .CheckProperty(x => x.Created, DateTime.Now.AddDays(-1), new NullableDateTimeComparer())
                .CheckProperty(x => x.LastModified, DateTime.Now, new NullableDateTimeComparer())
                .CheckProperty(x => x.CreatedBy, "Me")
                .CheckProperty(x => x.ModifiedBy, "Me")
                .VerifyTheMappings();
    }
}
