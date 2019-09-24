using Combis.Backend.Contracts;
using Combis.Backend.Data;
using Combis.Backend.DTO;
using Combis.Backend.Models;
using Combis.Backend.Utilities.Validations;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Combis.Backend.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase, IController
    {
        private PersonValidation _validator;
        private PersonHandler _handler;
        private ILogger<PersonController> _logger;
        public PersonController(CombisContext context, ILogger<PersonController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _validator = new PersonValidation();
            _handler = new PersonHandler(context, _logger);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JArray json)
        {
            var data = json.ToObject<ICollection<PersonDTO>>();

            var returnData = new List<PersonDTO>();

            foreach(var item in data)
            {
                if(_validator.Validate(item).IsValid 
                    && int.TryParse(item.ZipCode, out int n))
                {
                    var result = await _handler.AddAsync(item);

                    if(result == 1)
                    {
                        returnData.Add(item);
                    }
                }
            }

            return Ok(returnData);
        }
    }
}