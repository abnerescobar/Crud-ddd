namespace Domain.ValueObjects
{
    public interface IPhoneNumber
    {
        string Value { get; init; }

        bool Equals(object? obj);
        bool Equals(PhoneNumber? other);
        int GetHashCode();
        string ToString();
    }
}