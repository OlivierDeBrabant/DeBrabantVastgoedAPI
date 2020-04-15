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
        // GET: api/Projects
        /// <summary>
        /// Get all the Projects
        /// </summary>
        /// <returns>List of projects</returns>
        [HttpGet]
        public IEnumerable<Project> GetProjects()
        {
            return _projectRepo.GeefAlle();
        }
        
        //  GET: api/Projects/2
        /// <summary>
        /// Get the project with a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Project> GetProject(int id)
        {
            Project project = _projectRepo.geefProjectOpID(id);
            if (project == null) return NotFound();
            return project;
        }
        // GET: api/Projects/5/products/2
        /// <summary>
        /// Get a product from a project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productID"></param>
        /// <returns>Product</returns>
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

        //PUT: api/Projects/2
        /// <summary>
        /// Edit the project with given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="p"></param>
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
        
        //PUT: api/Projects/2/products/3
        /// <summary>
        /// Edit a product with given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productID"></param>
        /// <param name="p"></param>
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
        //POST: api/Projects/3/products
        /// <summary>
        /// Adds a product to a project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="p"></param>
        /// <returns>Product</returns>
        [HttpPost("{id}/products")]
        public ActionResult<Product> AddProduct(int id,  ProductDTO p)
        {
            if (!_projectRepo.TryGetProject(id, out var project))
            {
                return NotFound();
            }
            var productToCreate = new Product(p.Titel,p.Oppervlakte, p.Beschrijving, p.isVerkocht, p.Type, p.Kostprijs);
            project.VoegProductToe(productToCreate);
            _projectRepo.SaveChanges();
            return CreatedAtAction("GetProduct", new { id = project.ProjectID, productID = productToCreate.ProductID }, productToCreate);
        }

        //POST: api/Projects/AddProject
        /// <summary>
        /// Add a project
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Project</returns>
        [HttpPost("AddProject")]
        public ActionResult<Project> AddProject(ProjectDTO p)
        {
            Project project = new Project() { Naam = p.Naam, Beschrijving = p.Beschrijving, Adres = p.Adres};
            _projectRepo.Add(project);
            _projectRepo.SaveChanges();

            return CreatedAtAction(nameof(GetProject), new { id = project.ProjectID }, project);
        }
        #endregion

        #region HttpDelete

        //DELETE: api/Projects/2
        /// <summary>
        /// Delete a project with given id
        /// </summary>
        /// <param name="id"></param>
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

        //DELETE: api/Projects/2/products/5
        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productID"></param>
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
 