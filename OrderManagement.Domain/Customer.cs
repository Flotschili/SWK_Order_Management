using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace OrderManagement.Domain;

//[DataContract]
public class Customer
{
    public Customer(Guid id, string name, int zipCode, string city, Rating rating)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        ZipCode = zipCode;
        City = city ?? throw new ArgumentNullException(nameof(city));
        Rating = rating;
    }

    //[DataMember]
    public Guid Id { get; set; }

    //[DataMember]
    public string Name { get; set; }

    public int ZipCode { get; set; }

    public string City { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public Rating Rating { get; set; }

    public decimal TotalRevenue { get; set; }
}
