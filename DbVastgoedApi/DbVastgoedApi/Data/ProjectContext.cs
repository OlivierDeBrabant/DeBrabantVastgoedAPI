using DbVastgoedApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DbVastgoedApi.Data
{
    public class ProjectContext : IdentityDbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Project>()
                .HasMany(p => p.Producten)
                .WithOne()
                .IsRequired()
                .HasForeignKey("ProjectID"); //Shadow property

            builder.Entity<Project>().Property(p => p.Naam).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(pr => pr.Titel).IsRequired().HasMaxLength(50);

            //builder.Entity<Administrator>().HasKey(a => a.AdministratorId);
            builder.Entity<Administrator>().Property(a => a.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Administrator>().Property(a => a.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Administrator>().Property(a => a.Email).IsRequired().HasMaxLength(100);


            //Another way to seed the database
            builder.Entity<Project>().HasData(
                 new Project { ProjectID = 1, Naam = "Residentie Vindevogel"},
                 new Project { ProjectID = 2, Naam = "Verkaveling Eikenveld"}
            );

            builder.Entity<Product>().HasData(
            //Shadow property can be used for the foreign key, in combination with anaonymous objects
                new { ProductID = 1, ProjectID = 1, Titel = "Ruim Appartement", Type = EnumType.Appartement, Kostprijs = 7.28, Straat = "", Huisnummer = 9, Postcode = 8720, Beschrijving = "", Gemeente = "", isVerkocht = false, Oppervlakte = 10},
                new { ProductID = 2, ProjectID = 1, Titel = "Zonnig Dakappartement", Type = EnumType.Loft, Kostprijs = 18.20, Straat = "", Huisnummer = 10, Postcode = 8720, Beschrijving = "", Gemeente = "", isVerkocht = false, Oppervlakte = 11 },
                new { ProductID = 3, ProjectID = 2, Titel = "Gezellige Woning", Type = EnumType.Halfopen, Kostprijs = 25.33, Straat = "", Huisnummer = 11, Postcode = 8720, Beschrijving = "", Gemeente = "", isVerkocht = false, Oppervlakte = 12 }
            );
        }

        public DbSet<Project> Projecten { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
    }
}
