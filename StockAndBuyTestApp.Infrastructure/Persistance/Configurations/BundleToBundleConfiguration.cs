using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockAndBuyTestApp.Domain.Bundle;
using StockAndBuyTestApp.Domain.Bundle.Entites;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;

namespace StockAndBuyTestApp.Infrastructure.Persistance.Configurations;

public class BundleToBundleConfiguration : IEntityTypeConfiguration<BundleToBundleRelationship>
{
    public void Configure(EntityTypeBuilder<BundleToBundleRelationship> builder)
    {
        builder.ToTable("BundleToBundleRelationships");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => BundleToBundleRelationshipId.Create(value));

        builder.HasOne<Bundle>()
            .WithMany()
            .HasForeignKey(btb => btb.ParentBundleId)
            .HasConstraintName("FK_BundleToBundleRelationship_ParentBundle")
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(btb => btb.ParentBundleId)
            .HasConversion(
                id => id.Value,
                value => BundleId.Create(value));
        
        builder.HasOne<Bundle>() 
            .WithMany()
            .HasForeignKey(btb => btb.ChildBundleId)
            .HasConstraintName("FK_BundleToBundleRelationship_ChildBundle")
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(btb => btb.ChildBundleId)
            .HasConversion(
                id => id.Value,
                value => BundleId.Create(value));
    }
}