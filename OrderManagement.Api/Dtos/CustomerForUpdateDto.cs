using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using OrderManagement.Domain;

namespace OrderManagement.Api.Dtos
{
    public class CustomerForUpdateDto
    {
        [JsonProperty(Required = Required.DisallowNull)]
        public string Name { get; set; } = null!;

        [JsonProperty(Required = Required.Always)]
        public int ZipCode { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string City { get; set; } = null!;

        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Rating Rating { get; set; }
    }
}
