using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbVastgoedApi.Data;
using DbVastgoedApi.DTOs;
using DbVastgoedApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbVastgoedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepo;

        public ProjectsController(IProjectRepository repo)
        {
            _projectRepo = repo;
        }

        [HttpGet]
        public IEnumerable<Project> GetProjects()
        {
            return _projectRepo.GeefAlle();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Project> GetProject(int id)
        {
            Project project = _projectRepo.geefProjectOpID(id);
            if (project == null) return NotFound();
            return project;
        }
        [HttpPost]
        public ActionResult<Project> AddProject(Project p)
        {
            Project project = new Project() { ProjectID = p.ProjectID, Naam = p.Naam, Beschrijving = p.Beschrijving};
            foreach (var i in p.Producten)
                project.VoegProductToe(new Product(i.Titel, i.Straat, i.Huisnummer, i.Postcode, i.Gemeente, i.Oppervlakte, i.Beschrijving, i.isVerkocht, i.Type, i.Kostprijs));
            _projectRepo.Add(project);
            _projectRepo.SaveChanges();

            return CreatedAtAction(nameof(GetProject), new { id = project.ProjectID }, project);
        }
        [HttpPut("{id}")]
        public IActionResult PutProject(int id, Project p)
        {
            if (id != p.ProjectID)
            {
                return BadRequest();
            }
            _projectRepo.Update(p);
            _projectRepo.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}/products/{productID}")]
        public ActionResult<Product> GetProduct(int id, int productID)
        {
            if (!_projectRepo.TryGetProject(id, out var recipe))
            {
                return NotFound();
            }
            Product p = recipe.GetProduct(productID);
            if (p == null)
                return NotFound();
            return p;
        }

        //Adds a product to a project
        [HttpPost("{id}/products")]
        public ActionResult<Product> PostIngredient(int id,  Product p)
        {
            if (!_projectRepo.TryGetProject(id, out var project))
            {
                return NotFound();
            }
            var productToCreate = new Product(p.Titel, p.Straat, p.Huisnummer, p.Postcode, p.Gemeente, p.Oppervlakte, p.Beschrijving, p.isVerkocht, p.Type, p.Kostprijs);
            project.VoegProductToe(productToCreate);
            _projectRepo.SaveChanges();
            return CreatedAtAction("GetProduct", new { id = project.ProjectID, productID = productToCreate.ProductID }, productToCreate);
        }
        
        [HttpPost]
        public ActionResult<Project> PostProject(ProjectDTO p)
        {
            Project projectToCreate = new Project() { Naam = p.Naam, Beschrijving = p.Beschrijving, ProjectID = p.ProjectID };
            _projectRepo.Add(projectToCreate);
            _projectRepo.SaveChanges();
            return CreatedAtAction(nameof(GetProject), new { id = p.ProjectID }, projectToCreate);


        }
        
    }
}
 