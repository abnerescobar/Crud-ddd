
namespace Domain.ValueObjects;

public record class Sku
{
    private const int DefaultLenght = 8;
    private Sku(string value) => Value = value;
    public string Value { get; init; }
    public static Sku? Create(string value) 
    {
        if (string.IsNullOrEmpty(value) ||value.Length !=DefaultLenght) { return null; }
        return new Sku(value);
    }

}
