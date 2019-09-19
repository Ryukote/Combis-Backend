using System;
using System.Threading.Tasks;
using AutoMapper;
using Combis.Backend.Contracts;
using Combis.Backend.DTO;
using Combis.Backend.Models;
using Serilog;

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
                    _logger.Information($"{data}");
                    return 1;
                }

                else
                {
                    _logger.Debug($"{data}");
                    return -1;
                }
            }
            catch(Exception ex)
            {
                _logger.Error($"{data}");
                _logger.Error($"{ex.Message}");
                _logger.Error($"{ex.StackTrace}");

                throw ex;
            }
        }
    }
}
