using DbVastgoedApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbVastgoedApi.Models
{
    public interface IProjectRepository
    {
        public IEnumerable<Project> GeefAlle();
        public void Add(Project p);
        public Project geefProjectOpID(int id);
        public void Update(Project p);
        public void DeleteProject(Project p);
        public void DeleteProduct(Project p, int productID);
        public void SaveChanges();
        public bool TryGetProject(int id, out Project p);
    }
}
