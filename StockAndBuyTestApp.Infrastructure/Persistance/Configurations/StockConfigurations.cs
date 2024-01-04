using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockAndBuyTestApp.Domain.Product;
using StockAndBuyTestApp.Domain.Product.ValueObjects;
using StockAndBuyTestApp.Domain.Stock;
using StockAndBuyTestApp.Domain.Stock.ValueObjects;

namespace StockAndBuyTestApp.Infrastructure.Persistance.Configurations;

public class StockConfigurations : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => StockId.Create(value));

        builder.HasOne<Product>()
            .WithOne()
            .HasForeignKey<Stock>(s => s.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(s => s.ProductId)
            .HasConversion(
                id => id.Value,
                value => ProductId.Create(value));
    }
}