using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        #region Constructors

        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        #endregion Constructors

        #region Properties

        public DbSet<Entities.Models.Product>? Product { get; set; }

        public DbSet<ProductCategory>? ProductCategory { get; set; }

        public DbSet<ProductStatus>? ProductStatus { get; set; }

        #endregion Properties

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProductStatusConfiguration());
        }

        #endregion Methods
    }
}