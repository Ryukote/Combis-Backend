using Combis.Backend.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Combis.Backend.DTO
{
    public class PersonCollection : IDTO
    {
        [JsonProperty]
        public List<PersonDTO> Collection { get; set; }
    }
}
