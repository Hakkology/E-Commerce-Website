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
    public class ProductImageMapping : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            //Product has One-to-Many relations with Product Image
            builder.HasOne(x => x.Product).WithMany(x => x.ProductImage).HasForeignKey(x => x.ProductId);
        }
    }
}
