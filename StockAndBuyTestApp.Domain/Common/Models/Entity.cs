namespace StockAndBuyTestApp.Domain.Common.Models;

public class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId Id { get; }

    public Entity(TId id)
    {
        Id = id;
    }

    public override bool Equals(object? obj) => Equals(obj as Entity<TId>);

    public static bool operator ==(Entity<TId> obj1, Entity<TId> obj2) => Equals(obj1, obj2);

    public static bool operator !=(Entity<TId> obj1, Entity<TId> obj2) => !Equals(obj1, obj2);

    public bool Equals(Entity<TId>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<TId>.Default.GetHashCode(Id);
    }
}