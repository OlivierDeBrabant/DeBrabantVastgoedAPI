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
        #region HttpGet
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
        [HttpGet("{id}/products/{productID}")]
        public ActionResult<Product> GetProduct(int id, int productID)
        {
            if (!_projectRepo.TryGetProject(id, out var project))
            {
                return NotFound();
            }
            Product p = project.GetProduct(productID);
            if (p == null)
                return NotFound();
            return p;
        }
        #endregion

        #region HttpPut
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
         [HttpPut("{id}/products/{productID}")]
         public IActionResult PutProduct(int id, int productID, Product p)
        {
            _projectRepo.TryGetProject(id, out var project);

            Product product = project.GetProduct(productID);
            product = p;

            _projectRepo.Update(project);
            _projectRepo.SaveChanges();

            return NoContent();
        }
        #endregion

        #region HttpPost
        //Adds a product to a project
        [HttpPost("{id}/products")]
        public ActionResult<Product> AddProduct(int id,  ProductDTO p)
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
        //Adds a new Project
        [HttpPost("AddProject")]
        public ActionResult<Project> AddProject(ProjectDTO p)
        {
            Project project = new Project() { Naam = p.Naam, Beschrijving = p.Beschrijving };
            _projectRepo.Add(project);
            _projectRepo.SaveChanges();

            return CreatedAtAction(nameof(GetProject), new { id = project.ProjectID }, project);
        }
        #endregion

        #region HttpDelete

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            Project project = _projectRepo.geefProjectOpID(id);
            if (project == null)
            {
                return NotFound();
            }
            _projectRepo.DeleteProject(project);
            _projectRepo.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}/products/{productID}")]
        public IActionResult DeleteProduct(int id, int productID)
        {
            //GEEN ERROR, MAAR WERKT NIET

            Project project = _projectRepo.geefProjectOpID(id);
            if(project == null)
            {
                return NotFound();
            }
            _projectRepo.DeleteProduct(project, productID);
            _projectRepo.SaveChanges();

            return NoContent();
        }
        #endregion
    }
}
 