using System;
using System.Threading.Tasks;
using AutoMapper;
using Combis.Backend.Contracts;
using Combis.Backend.DTO;
using Combis.Backend.Models;
using Microsoft.Extensions.Logging;

namespace Combis.Backend.Data
{
    public class PersonHandler : IHandler<PersonDTO>
    {
        private IMapper _mapper;
        private CombisContext _context;
        private readonly ILogger _logger;
        public PersonHandler(CombisContext context, ILogger logger)
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<PersonDTO, Person>();
            }).CreateMapper();

            _context = context;
            _logger = logger;
        }

        public async Task<int> AddAsync(PersonDTO dto)
        {
            var data = _mapper.Map<Person>(dto);

            await _context.AddAsync(data);

            try
            {
                if (await _context.SaveChangesAsync() == 1)
                {
                    _logger.LogInformation($"{data}");
                    return 1;
                }

                else
                {
                    _logger.LogDebug($"{data}");
                    return -1;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"{data}");
                _logger.LogError($"{ex.Message}");
                _logger.LogError($"{ex.StackTrace}");

                throw ex;
            }
        }
    }
}
