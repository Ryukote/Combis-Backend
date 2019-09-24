using Combis.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Combis.Backend.Tests.Utilities
{
    public class MockData
    {
        public CombisContext SetupContext(string databaseName)
        {
            DbContextOptions<CombisContext> options;
            var builder = new DbContextOptionsBuilder<CombisContext>();
            builder.UseInMemoryDatabase(databaseName: databaseName);
            options = builder.Options;
            CombisContext context = new CombisContext(options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}
