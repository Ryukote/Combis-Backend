using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Combis.Backend.Models
{
    public class CombisContext : DbContext
    {
        public CombisContext(DbContextOptions<CombisContext> options) : base(options)
        {
            
        }

        public DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(x => x.Surname)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(x => x.ZipCode)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(x => x.PhoneNumber)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .HasIndex(x => x.PhoneNumber)
                .IsUnique();
        }
    }
}
