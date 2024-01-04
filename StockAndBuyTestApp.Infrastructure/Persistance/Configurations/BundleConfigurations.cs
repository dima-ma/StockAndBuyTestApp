using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockAndBuyTestApp.Domain.Bundle;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;
using StockAndBuyTestApp.Domain.Product;
using StockAndBuyTestApp.Domain.Product.ValueObjects;

namespace StockAndBuyTestApp.Infrastructure.Persistance.Configurations;

public class BundleConfigurations : IEntityTypeConfiguration<Bundle>
{
    public void Configure(EntityTypeBuilder<Bundle> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => BundleId.Create(value));
        
        builder.OwnsMany(p => p.BundleItemsIds, bid =>
        {
            bid.ToTable("BundleToBundleRelationshipIds");

            bid.WithOwner().HasForeignKey("BundleId");

            bid.HasKey("Id"); 

            bid.Property(d => d.Value)
                .HasColumnName("ChildBundleId")
                .ValueGeneratedNever();
        });
        
        builder.OwnsMany(p => p.ProductItemsIds, bid =>
        {
            bid.ToTable("BundleToProductRelationshipIds");

            bid.WithOwner().HasForeignKey("BundleId");

            bid.HasKey("Id"); 

            bid.Property(d => d.Value)
                .HasColumnName("ChildProductId")
                .ValueGeneratedNever();
        });
        
      
        builder.Metadata.FindNavigation(nameof(Bundle.BundleItemsIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        
        builder.Metadata.FindNavigation(nameof(Bundle.ProductItemsIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}