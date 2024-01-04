using StockAndBuyTestApp.Domain.Common.Models;

namespace StockAndBuyTestApp.Domain.Product.Events;

public record ProductCreated(Product Product) : IDomainEvent;