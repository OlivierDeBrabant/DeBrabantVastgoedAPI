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
        public ICollection<Project> _projects;
        
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
                .HasForeignKey("RecipeId"); //Shadow property
            builder.Entity<Project>().Property(p => p.Naam).IsRequired().HasMaxLength(50);

            builder.Entity<Product>().Property(pr => pr.Titel).IsRequired().HasMaxLength(50);
            

            //Another way to seed the database
            builder.Entity<Project>().HasData(
                 new Project { }
            );

            builder.Entity<Product>().HasData(
                    //Shadow property can be used for the foreign key, in combination with anaonymous objects
                    new { Id = 1, Name = "Tomatoes", Amount = (double?)0.75, Unit = "liter", RecipeId = 1 },
                    new { Id = 2, Name = "Minced Meat", Amount = (double?)500, Unit = "grams", RecipeId = 1 },
                    new { Id = 3, Name = "Onion", Amount = (double?)2, RecipeId = 1 }
                 );
        }

        public Microsoft.EntityFrameworkCore.DbSet<Project> Recipes { get; set; }
    }
}
