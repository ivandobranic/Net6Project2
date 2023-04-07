using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData
            (
            new ProductCategory
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Name = "TV",
                IsActive = true,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
                TimeStamp = DateTime.UtcNow,
            },
            new ProductCategory
            {
                Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                Name = "DJ Controllers",
                IsActive = true,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
                TimeStamp = DateTime.UtcNow,
            }
            );
        }

        #endregion Methods
    }
}