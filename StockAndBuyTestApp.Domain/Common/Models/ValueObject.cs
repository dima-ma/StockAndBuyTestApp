using System.Text;

namespace StockAndBuyTestApp.Domain.Common.Models;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj) => Equals(obj as ValueObject);

    public override int GetHashCode()
        => GetEqualityComponents()
            .Select(x => x?.GetHashCode() ?? 0)
            .Aggregate((x, y) => x * y);

    public static bool operator ==(ValueObject obj1, ValueObject obj2) => Equals(obj1, obj2);

    public static bool operator !=(ValueObject obj1, ValueObject obj2) => !Equals(obj1, obj2);

    public bool Equals(ValueObject? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }
}