

namespace Domain.ValueObjects;

public record Address
{
    public Address(string country, string line1, string line2, string city, string state, string zipcode) 
    {
        Country = country;
        Line1 = line1;
        Line2 = line2;
        City = city;
        State = state;
        Zipcode = zipcode;


    }
    public string Country { get; init; }
    public string Line1 { get; init; }
    public string Line2 { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Zipcode { get; init; }
    public static Address? Create(string country, string line1, string line2, string city, string state, string zipcode)
    {
        if(string.IsNullOrEmpty(country) || string.IsNullOrEmpty(line1) || 
            string.IsNullOrEmpty(line2) || string.IsNullOrEmpty(city) ||
            string.IsNullOrEmpty(state) || string.IsNullOrEmpty(zipcode)) 
        {
            return null;
        }
        return new Address(country, line1, line2, city, state, zipcode);
    }
}
