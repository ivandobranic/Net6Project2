using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Entities.Models.Product>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Entities.Models.Product> builder)
        {
            builder.HasData
            (
            new Entities.Models.Product
            {
                Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                Name = "Samsung",
                Price = 26,
                IsActive = false,
                ProductCategoryId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
                TimeStamp = DateTime.UtcNow,
            },
            new Entities.Models.Product
            {
                Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                Name = "LG",
                Price = 30,
                IsActive = true,
                ProductCategoryId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
                TimeStamp = DateTime.UtcNow,
            },
            new Entities.Models.Product
            {
                Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                Name = "Traktor",
                Price = 35,
                IsActive = true,
                ProductCategoryId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
                TimeStamp = DateTime.UtcNow,
            }
            );
        }

        #endregion Methods
    }
}