using DbVastgoedApi.Data;
using DbVastgoedApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbVastgoedApi.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectContext _context;
        private readonly DbSet<Project> _projecten;

        public ProjectRepository(ProjectContext dbContext)
        {
            _context = dbContext;
            _projecten = dbContext.Projecten;
        }

        public IEnumerable<Project> GeefAlle()
        {
            return _projecten.Include(p => p.Producten).ToList();
        }
        public void Add(Project p)
        {
            _projecten.Add(p);
        }
        public Project geefProjectOpID(int id)
        {
            return _projecten.SingleOrDefault(p => p.ProjectID == id);
        }
        public void Update(Project p)
        {
            _context.Update(p);
        }
        public void DeleteProject(Project p)
        {
            _projecten.Remove(p);
        }
        public void DeleteProduct(Project p, int productID)
        {
            p.DeleteProduct(productID);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool TryGetProject(int id, out Project p)
        {
            p = _context.Projecten.Include(t => t.Producten).FirstOrDefault(t => t.ProjectID == id);
            return p != null;
        }
    }
}
