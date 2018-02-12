using IDisplay.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace IDisplay.DAL
{
    public class IDisplayContext : DbContext
    {
        public IDisplayContext()
            : base("IDisplayDb")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ProductCategory>().HasMany(x => x.Products).WithRequired(x => x.ProductCategory).HasForeignKey(x => x.ProductCategoryId).WillCascadeOnDelete(true);

            modelBuilder.Entity<Seller>().HasMany(x => x.Products).WithRequired(x => x.Seller).HasForeignKey(x => x.UserId).WillCascadeOnDelete(true);
        }
    }
}