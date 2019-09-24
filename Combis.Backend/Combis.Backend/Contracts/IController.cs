using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Combis.Backend.Contracts
{
    public interface IController
    {
        [HttpPost]
        Task<IActionResult> Post([FromBody]IDTO dto);
    }
}
