namespace RFQ.Repository.Specs.Mappings
{
    using System;
    using Comparers;
    using Core.Entities;
    using FluentNHibernate.Testing;
    using Machine.Specifications;
    using Repository.Mappings;
    using Setup;

    [Subject(typeof(UserMap))]
    public class when_mapping_user
    {
        /** 
         * 1. Creates an User instance
         * 2. Inserts the User into the database
         * 3. Retrieves the record into a new User instance
         * 4. Verifies the retrieved User matches the original 
         */
        It should_pass =
            () => new PersistenceSpecification<User>(SharedSessionContext.TestSession)
                .CheckProperty(x => x.Username, "P_Dzenis1")
                .CheckProperty(x => x.Name, "Pēteris")
                .CheckProperty(x => x.Surname, "Dzenis")
                .CheckProperty(x => x.Initials, "PD")
                .CheckProperty(x => x.DefaultEmail, "peteris.dzenis@28stone.com")
                .CheckProperty(x => x.DefaultPhone, "+371 888 888 88")
                .CheckProperty(x => x.ExternalId, "22565")
                .CheckProperty(x => x.FusionId, "22565")
                .CheckProperty(x => x.VenueId, "iSwapEVSP_US_Java")
                .CheckProperty(x => x.ProductId, "product_01")
                .CheckProperty(x => x.LastLoggedIn, DateTime.Now.AddMinutes(-5), new NullableDateTimeComparer())
                .CheckProperty(x => x.LastLoggedOut, DateTime.Now, new NullableDateTimeComparer())
                .CheckProperty(x => x.Created, DateTime.Now.AddDays(-1), new NullableDateTimeComparer())
                .CheckProperty(x => x.LastModified, null)
                .CheckProperty(x => x.CreatedBy, "Me")
                .CheckProperty(x => x.ModifiedBy, null)
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
