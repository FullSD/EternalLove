using EternalLove.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EternalLove.Server.Configurations.Entities
{
    public class UserDetailSeedConfiguration : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.HasData(
                new UserDetail
                {
                    Id = 1,
                    Name = "Vince",
                    GenderId = 1,
                    LocationId = 1,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"

                },
                new UserDetail
                {
                    Id = 2,
                    Name = "Sarin",
                    GenderId = 1,
                    LocationId = 1,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"

                },
                new UserDetail
                {
                    Id = 3,
                    Name = "Gary",
                    GenderId = 1,
                    LocationId = 3,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"

                },
                new UserDetail
                {
                    Id = 4,
                    Name = "Mary",
                    GenderId = 2,
                    LocationId = 2,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"

                },
                new UserDetail
                {
                    Id = 5,
                    Name = "Jane",
                    GenderId = 2,
                    LocationId = 4,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"

                },
                new UserDetail
                {
                    Id = 6,
                    Name = "Tom",
                    GenderId = 1,
                    LocationId = 4,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"

                },
                new UserDetail
                {
                    Id = 7,
                    Name = "Stacia",
                    GenderId = 2,
                    LocationId = 3,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"

                },
                new UserDetail
                {
                    Id = 8,
                    Name = "Ming",
                    GenderId = 1,
                    LocationId = 2,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"

                },
                new UserDetail
                {
                    Id = 9,
                    Name = "Hana",
                    GenderId = 2,
                    LocationId = 2,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"

                },
                new UserDetail
                {
                    Id = 10,
                    Name = "Sam",
                    GenderId = 1,
                    LocationId = 1,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"

                },
                new UserDetail
                {
                    Id = 11,
                    Name = "Kim",
                    GenderId = 2,
                    LocationId = 2,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"

                }
                );
        }
    }
}
