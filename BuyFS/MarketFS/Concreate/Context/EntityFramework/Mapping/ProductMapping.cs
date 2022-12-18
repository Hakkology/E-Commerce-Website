using BuyFS.Entity.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantFS.DataAccessLayer.Concreate.Context.EntityFramework.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Product Name is not null and nvarchar50;
            //Product has Many-to-One relations with Product Image
            builder.Property(p => p.Name).HasColumnName("Product Name").HasColumnType("nvarchar(50)").IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasMany(x=>x.ProductImage).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId);
        }
    }
}
