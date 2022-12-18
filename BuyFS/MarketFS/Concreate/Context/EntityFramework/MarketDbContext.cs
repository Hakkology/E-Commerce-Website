using BuyFS.Entity.POCO;
using MerchantFS.DataAccessLayer.Concreate.Context.EntityFramework.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantFS.DataAccessLayer.Concreate.Context.EntityFramework
{
    // Template for project supports 3.1.22 for Entity Framework, hence that Nuget Package is installed.
    // Identity.EFCore provides us with User, Roles and modifier properties and a way for connection.
    public class MarketDbContext:IdentityDbContext<AppClient, AppRoles, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Actual method that provides connection to SQL server.
            //Server is SQL Server name, Database is DbContext name, MultipleActiveResultSets is essential for multiple architectural services.
            optionsBuilder.UseSqlServer("Server = HAKKO; Database = MarketDbContext; Trusted_Connection = True; MultipleActiveResultSets = true;");
            //Essential for migration, initial command shall be "add-migration <name>
            //next command to lift the database shall be "update-database"
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //This is where many-to-many relationships are brought to life on models before migration.
            //Note that the primary key for these relations are all Ids, as specified on migration.
            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.CategoryId, x.ProductId });
            //modelBuilder.Entity<AppClientRoles>().HasKey(x => new { x.AppClientId, x.AppRolesId });
            //First migration given here as "Merchant-1". Changing deleting behaviour with below code requires an update on migration, which is added as "Merchant-2".
            foreach (var DeleteBehaviour in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                DeleteBehaviour.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //Mappings are added as configuration with following section, requiring another migration which is provided as "Merchant-3".
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new ProductImageMapping());
            modelBuilder.Entity<AppRoles>().HasData
                (
                    new AppRoles { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                    new AppRoles { Id = 2, Name = "UserApp", NormalizedName = "USERAPP" });
            base.OnModelCreating(modelBuilder);
        }

        //Tables shall be specified on this page, which shall later then be associated with SQL tables and relations
        //User information tables as specified below
        //later Entity FrameWork Identity replaces the User Relations tables
        //public DbSet<AppClient> AppClient { get; set; }
        //public DbSet<AppRoles> AppRoles { get; set; }
        //public DbSet<AppClientRoles> AppClientRoles { get; set; }

        //Product Category Tables are as specified below
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Basket> Basket { get; set; }
    }
}
