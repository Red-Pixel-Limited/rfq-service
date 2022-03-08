namespace RFQ.Repository.Specs.Mappings
{
    using System;
    using Communication.Options;
    using Comparers;
    using Core.Artifacts;
    using Core.Entities;
    using FluentNHibernate.Testing;
    using Machine.Specifications;
    using Persistence;
    using Repository.Mappings;
    using Setup;
    using Utils;

    [Subject(typeof(QuoteMap))]
    public class when_mapping_quote
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
         * 1. Creates an Quote instance
         * 2. Inserts the Quote into the database
         * 3. Retrieves the record into a new Quote instance
         * 4. Verifies the retrieved Quote matches the original 
         */
        It should_pass =
            () => new PersistenceSpecification<Quote>(SharedSessionContext.TestSession)
                .CheckProperty(x => x.Id, IdentityGenerator.Generate())
                .CheckProperty(x => x.BuyPrice, (long?)80)
                .CheckProperty(x => x.BuyPriceBase, (long?)1)
                .CheckProperty(x => x.SellPrice, (long?)40)
                .CheckProperty(x => x.SellPriceBase, (long?)1)
                .CheckProperty(x => x.State, QuoteState.Filled)
                .CheckProperty(x => x.Created, DateTime.Now.AddHours(-1), new DateTimeComparer())
                .CheckProperty(x => x.LastModified, DateTime.Now, new NullableDateTimeComparer())
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
                .CheckReference(x => x.RFQ, RFQOffer.New(null, null, 0, 1, Side.Both, null, null))
                .VerifyTheMappings();

        static Organization prerequisites;
    }
}
