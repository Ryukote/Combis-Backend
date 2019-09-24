using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Combis.Backend.Contracts
{
    public interface IController
    {
        [HttpPost]
        Task<IActionResult> Post([FromBody]JArray json);
    }
}
