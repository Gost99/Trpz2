using System.Data.Entity;
using Trpz2.EntityFramework.Models;

namespace Trpz2.EntityFramework
{
    public class StoreContext: DbContext
    {
        public StoreContext() : base("MsSqlConnection")
        { }

        #region DbSets

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<SpecialOffer> SpecialOffers { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
              .HasMany<Order>(s => s.Orders)
              .WithMany(c => c.Products);

            modelBuilder.Entity<Product>().Property(o => o.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(o => o.Price).IsRequired();

            modelBuilder.Entity<Order>().Property(o => o.Key).IsRequired();

            modelBuilder.Entity<Tag>().Property(o => o.Title).IsRequired();

            modelBuilder.Entity<SpecialOffer>().Property(o => o.Name).IsRequired();
            modelBuilder.Entity<SpecialOffer>().Property(o => o.Price).IsRequired();

            modelBuilder.Entity<Administrator>().Property(o => o.Username).IsRequired();
            modelBuilder.Entity<Administrator>().Property(o => o.Password).IsRequired();

        }

    }
}
