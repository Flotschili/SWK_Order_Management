using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using OrderManagement.Domain;

namespace OrderManagement.Api.Dtos
{
    //[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class CustomerDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public int ZipCode { get; set; }

        //[JsonProperty(PropertyName = "location")]
        public string City { get; set; } = null!;

        [JsonConverter(typeof(StringEnumConverter))]
        public Rating Rating { get; set; }
    }
}
