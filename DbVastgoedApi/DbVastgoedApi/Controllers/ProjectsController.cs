using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbVastgoedApi.Data;
using DbVastgoedApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbVastgoedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectRepository _projectRepo;

        public ProjectsController(ProjectRepository repo)
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
            Project project = new Project() { ID = p.ID, Naam = p.Naam, Beschrijving = p.Beschrijving};
            foreach (var i in p.Producten)
                project.VoegProductToe(new Product(i.Titel, i.Straat, i.Huisnummer, i.Postcode, i.Gemeente, i.Oppervlakte, i.Beschrijving, i.isVerkocht, i.Type, i.Kostprijs));
            _projectRepo.Add(project);
            _projectRepo.SaveChanges();

            return CreatedAtAction(nameof(GetProject), new { id = project.ID }, project);
        }
        [HttpPut("{id}")]
        public IActionResult PutRecipe(int id, Project p)
        {
            if (id != p.ID)
            {
                return BadRequest();
            }
            _projectRepo.Update(p);
            _projectRepo.SaveChanges();
            return NoContent();
        }
    }
}