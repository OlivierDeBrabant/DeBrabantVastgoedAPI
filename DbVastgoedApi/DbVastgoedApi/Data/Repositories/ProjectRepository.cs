using DbVastgoedApi.Data.Mapper;
using DbVastgoedApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbVastgoedApi.Data
{
    public class ProjectRepository
    {
        private ICollection<Project> _projecten;
        private ProjectContext _context;

        public ProjectRepository()
        {
            _context = new ProjectContext();
            _projecten = _context.geefProjecten();
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
