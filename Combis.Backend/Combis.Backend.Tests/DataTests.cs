using Combis.Backend.Data;
using Combis.Backend.DTO;
using Combis.Backend.Models;
using Combis.Backend.Tests.Utilities;
using Combis.Backend.Utilities.Validations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Serilog;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Combis.Backend.Tests
{
    public class DataTests
    {
        private CombisContext _context;
        private Microsoft.Extensions.Logging.ILogger _logger;
        private PersonValidation _validator;
        public DataTests(ITestOutputHelper output)
        {
            var databaseName = Guid.NewGuid().ToString();
            _context = new MockData().SetupContext(databaseName);

            _logger = new NullLogger<dynamic>();

            _validator = new PersonValidation();
        }

        [Fact]
        public async Task WillAddPersonUsingHandler()
        {
            var handler = new PersonHandler(_context, _logger);

            var person = new PersonDTO()
            {
                City = "Zagreb",
                Name = "Joža",
                PhoneNumber = "+385910397123",
                Surname = "Jožić",
                ZipCode = 10000.ToString()
            };

            var validationData = _validator.Validate(person);

            var result = await handler.AddAsync(person);

            Assert.True(validationData.IsValid);
            Assert.Equal(1, result);
        }
    }
}
