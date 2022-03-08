namespace RFQ.Repository.Specs.Mappings
{
    using System;
    using Communication.Options;
    using Comparers;
    using Core.Entities;
    using FluentNHibernate.Testing;
    using Machine.Specifications;
    using Persistence;
    using Repository.Mappings;
    using Setup;
    using Utils;

    [Subject(typeof(RFQOfferMap))]
    public class when_mapping_rfq
    {
        Establish context = () =>
        {
            prerequisites = new Organization
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
            };
        };

        Because of = () =>
        {
            var repository = new OrganizationRepository(SharedSessionContext.TestSession);
            repository.SaveOrUpdate(prerequisites);
        };

        /** 
         * 1. Creates an RFQ instance
         * 2. Inserts the RFQ into the database
         * 3. Retrieves the record into a new RFQ instance
         * 4. Verifies the retrieved RFQ matches the original 
         */

        It should_pass =
            () => new PersistenceSpecification<RFQOffer>(SharedSessionContext.TestSession)
                .CheckProperty(x => x.Id, IdentityGenerator.Generate())
                .CheckProperty(x => x.Size, 44L)
                .CheckProperty(x => x.SizeBase, 1L)
                .CheckProperty(x => x.Side, Side.Both)
                .CheckProperty(x => x.State, RFQState.Open)
                .CheckProperty(x => x.Created, DateTime.Now, new DateTimeComparer())
                .CheckProperty(x => x.LastModified, null, new NullableDateTimeComparer())
                .CheckProperty(x => x.VenueId, "GtnEVSP_Java")
                .CheckProperty(x => x.ProductId, "product_01")
                .CheckProperty(x => x.InstrumentId, "1")
                .CheckProperty(x => x.InstrumentName, "BMW")
                .CheckReference(x => x.Owner,
                    new User
                    {
                        Username = "P_Dzenis1",
                        Name = "Pēteris",
                        Surname = "Dzenis",
                        Initials = "PD",
                        DefaultEmail = "peteris.dzenis@28stone.com",
                        DefaultPhone = "+371 888 888 88",
                        ExternalId = "22565",
                        FusionId = "22565",
                        VenueId = "iSwapEVSP_US_Java",
                        ProductId = "product_01",
                        LastLoggedIn = null,
                        LastLoggedOut = null,
                        Created = DateTime.Now,
                        LastModified = null,
                        CreatedBy = "Me",
                        ModifiedBy = null,
                        Organization = prerequisites
                    })
                .VerifyTheMappings();

        static Organization prerequisites;
    }
}
