using DbVastgoedApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DbVastgoedApi.Data
{
    public class ProjectContext : Microsoft.EntityFrameworkCore.DbContext
    {
        /*
        public ProjectContext()
        {
            _projects = new List<Project>();

            Product p = new Product();
            p.Titel = "Landelijk Huis Oeselgem";
            p.Gemeente = "Oeselgem";
            p.Straat = "Vennebosstraat";

            Product p2 = new Product();
            p2.Titel = "Moderne Villa Aan De Leie";
            p2.Gemeente = "Wielsbeke";
            p2.Type = EnumType.Open;

            Project project = new Project();
            project.VoegProductToe(p);
            project.VoegProductToe(p2);

            _projects.Add(project);
        }
        */
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
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
            

            //Another way to seed the database
            builder.Entity<Project>().HasData(
                 new Project { ID = 1, Naam = "Residentie Vindevogel"},
                 new Project { ID = 2, Naam = "Verkaveling Eikenveld"}
            );

            builder.Entity<Product>().HasData(
            //Shadow property can be used for the foreign key, in combination with anaonymous objects
                new Product { ID = 1, ProjectID = 1, Titel = "Ruim Appartement", Type = EnumType.Appartement, Kostprijs = 7.28},
                new Product { ID = 2, ProjectID = 1, Titel = "Zonnig Dakappartement", Type = EnumType.Loft, Kostprijs = 18.20},
                new Product { ID = 3, ProjectID = 2, Titel = "Gezellige Woning", Type = EnumType.Halfopen, Kostprijs = 25.33}
            );
        }

        public Microsoft.EntityFrameworkCore.DbSet<Project> Projecten { get; set; }
    }
}
