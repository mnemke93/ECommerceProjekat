using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class SupplierConfiguration : EntityConfiguration<Supplier>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(x => x.SupplierName).IsRequired();
            builder.Property(x => x.SupplierContact).IsRequired();

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Supplier)
                .HasForeignKey(x => x.SupplierID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
