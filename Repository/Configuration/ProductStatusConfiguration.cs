using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ProductStatusConfiguration : IEntityTypeConfiguration<ProductStatus>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<ProductStatus> builder)
        {
            builder.HasData
            (
            new ProductStatus
            {
                Id = Guid.NewGuid(),
                Name = "Active",
                Abrv = "active",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
                TimeStamp = DateTime.UtcNow
            },
            new ProductStatus
            {
                Id = Guid.NewGuid(),
                Name = "Inactive",
                Abrv = "inactive",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
                TimeStamp = DateTime.UtcNow
            });
        }

        #endregion Methods
    }
}