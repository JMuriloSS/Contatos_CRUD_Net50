using Microsoft.EntityFrameworkCore;
using Contacts.Models;
using Microsoft.Extensions.Configuration;
using System;

namespace Contacts.Data
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options)
            : base(options)
        {
        }

        public DbSet<Professional> Professionals { get; set; }
        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<ProfessionalEstablishment> ProfessionalEstablishments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder
                .UseSqlServer(configuration.GetConnectionString("ContactsContext"));
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProfessionalEstablishment>(entity =>
        //    {
        //        entity.HasKey(e => new { e.ProfessionalId, e.EstablishmentId });
        //    });
        //}

    }
}
