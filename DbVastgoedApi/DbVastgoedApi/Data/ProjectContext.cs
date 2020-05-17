using DbVastgoedApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
                 new Project { ProjectID = 1, Naam = "Vindevogel", Beschrijving = "Grote verkaveling in het centrum van Oeselgem", Adres = "Volderstraat, Oeselgem" },
                 new Project { ProjectID = 2, Naam = "Eikenveld", Beschrijving = "Residentie met 10 ruime appartementen en 2 lofts, met uitzicht op het regenboogstadium", Adres = "Wakkenweg, Markegem" },
                 new Project { ProjectID = 3, Naam = "Zonnebloem", Beschrijving = "Residentie met 35 appartementen met elk een terras. Gelegen in het centrum van Waregem. ", Adres = "Stormestraat, Waregem" },
                 new Project { ProjectID = 4, Naam = "Waardamme", Beschrijving = "15 landelijke woningen in een nieuwe verkaveling omringd door natuur.", Adres = "Heerbaan, Tielt" }

            );

            builder.Entity<Product>().HasData(
            //Shadow property can be used for the foreign key, in combination with anaonymous objects
                new { ProductID = 1, ProjectID = 1, Titel = "Appartement 1", Type = "Appartement", Kostprijs = 275000.0, Beschrijving = "Appartement met groot terras en 2 slaapkamers.", isVerkocht = true, Oppervlakte = 80 },
                new { ProductID = 2, ProjectID = 1, Titel = "Appartement 2", Type = "Loft", Kostprijs = 325000.0, Beschrijving = "Ruime loft met 3 slaapkamers en een zonneterras.", isVerkocht = false, Oppervlakte = 125 },

                new { ProductID = 3, ProjectID = 2, Titel = "Appartement 1", Type = "Appartement", Kostprijs = 375000.0, Beschrijving = "", isVerkocht = false, Oppervlakte = 320 },

                new { ProductID = 4, ProjectID = 3, Titel = "Appartement 1", Type = "Appartement", Kostprijs = 175000.0, Beschrijving = "Appartement met terras en 1 slaapkamer.", isVerkocht = false, Oppervlakte = 85 },
                new { ProductID = 5, ProjectID = 3, Titel = "Appartement 2", Type = "Appartement", Kostprijs = 275000.0, Beschrijving = "Appartement met groot terras en 2 slaapkamers.", isVerkocht = false, Oppervlakte = 130 },

                new { ProductID = 6, ProjectID = 4, Titel = "Huis 1", Type = "Halfopen", Kostprijs = 275000.0, Beschrijving = "Halfopen huis met ruime woonkamer en 4 slaapkamers.", isVerkocht = true, Oppervlakte = 245 },
                new { ProductID = 7, ProjectID = 4, Titel = "Huis 2", Type = "Halfopen", Kostprijs = 280000.0, Beschrijving = "Halfopen huis met ruime woonkamer en 4 slaapkamers. Mogelijkheid voor een carpool naast het huis.", isVerkocht = false, Oppervlakte = 260 }
            );
        }

        public DbSet<Project> Projecten { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
    }
}
