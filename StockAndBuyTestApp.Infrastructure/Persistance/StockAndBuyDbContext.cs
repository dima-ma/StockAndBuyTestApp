using Microsoft.EntityFrameworkCore;
using StockAndBuyTestApp.Domain.Bundle;
using StockAndBuyTestApp.Domain.Bundle.Entites;
using StockAndBuyTestApp.Domain.Common.Entities;
using StockAndBuyTestApp.Domain.Common.Models;
using StockAndBuyTestApp.Domain.Product;
using StockAndBuyTestApp.Domain.Stock;
using StockAndBuyTestApp.Infrastructure.Persistance.Configurations;
using StockAndBuyTestApp.Infrastructure.Persistance.Interceptors;

namespace StockAndBuyTestApp.Infrastructure.Persistance;

public class StockAndBuyDbContext : DbContext
{
    private readonly PublishDomainEventInterceptor _domainEventInterceptor;

    public StockAndBuyDbContext(DbContextOptions<StockAndBuyDbContext> options,
        PublishDomainEventInterceptor domainEventInterceptor)
        : base(options)
    {
        _domainEventInterceptor = domainEventInterceptor;
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        var editedEntities = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Modified).ToList();

        editedEntities.ForEach(e =>
        {
            e.Property("UpdatedDateTime").CurrentValue = DateTime.Now;
        });

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_domainEventInterceptor);
        
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfiguration(new ProductConfigurations())
            .ApplyConfiguration(new StockConfigurations())
            .ApplyConfiguration(new BundleConfigurations())
            .ApplyConfiguration(new BundleToBundleConfiguration())
            .ApplyConfiguration(new BundleToProductConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Stock> Stocks { get; set; } = null!;
    public DbSet<Bundle> Bundles { get; set; } = null!;
    public DbSet<BundleToBundleRelationship> BundleRelationships { get; set; } = null!;
    public DbSet<BundleToProductRelationship> BundleToProductRelationships { get; set; } = null!;
}