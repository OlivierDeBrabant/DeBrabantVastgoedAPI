using DbVastgoedApi.Data;
using DbVastgoedApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbVastgoedApi.Data
{
    public class ProjectRepository
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
            return _projecten.ToList();
        }
        public void voegProjectenToe(Project p)
        {
            _projecten.Add(p);
        }
        public Project geefProjectOpID(int id)
        {
            return _projecten.SingleOrDefault(p => p.ID == id);
        }
    }
}
