using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockAndBuyTestApp.Domain.Bundle;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;
using StockAndBuyTestApp.Domain.Common.Entities;
using StockAndBuyTestApp.Domain.Common.ValueObjects;
using StockAndBuyTestApp.Domain.Product;
using StockAndBuyTestApp.Domain.Product.ValueObjects;

namespace StockAndBuyTestApp.Infrastructure.Persistance.Configurations;

public class BundleToProductConfiguration : IEntityTypeConfiguration<BundleToProductRelationship>
{
    public void Configure(EntityTypeBuilder<BundleToProductRelationship> builder)
    {
        builder.ToTable("BundleToProductRelationship");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => BundleToProductRelationshipId.Create(value));
        
        builder.HasOne<Bundle>()
            .WithMany()
            .HasForeignKey(btb => btb.BundleId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(btb => btb.BundleId)
            .HasConversion(
                id => id.Value,
                value => BundleId.Create(value)); 
        
        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(btb => btb.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(btb => btb.ProductId)
            .HasConversion(
                id => id.Value,
                value => ProductId.Create(value));
    }
}