using Combis.Backend.Contracts;

namespace Combis.Backend.DTO
{
    public class PersonDTO : IDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
    }
}
