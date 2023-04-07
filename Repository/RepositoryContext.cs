using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : DbContext
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

        #endregion Properties

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        #endregion Methods
    }
}