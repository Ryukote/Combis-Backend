using Combis.Backend.Contracts;
using Newtonsoft.Json;

namespace Combis.Backend.DTO
{
    public class PersonDTO : IDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("surname")]
        public string Surname { get; set; }
        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
