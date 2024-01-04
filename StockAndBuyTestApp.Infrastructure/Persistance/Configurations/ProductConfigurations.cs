using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockAndBuyTestApp.Domain.Product;
using StockAndBuyTestApp.Domain.Product.ValueObjects;

namespace StockAndBuyTestApp.Infrastructure.Persistance.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ProductId.Create(value));
        builder.Property(p => p.Name).HasMaxLength(100);
    }
}