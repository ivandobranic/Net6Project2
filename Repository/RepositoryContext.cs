using Entities.Models;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<Product>? Product { get; set; }
        public DbSet<ProductCategory>? ProductCategory { get; set; }

        #endregion Properties
    }
}