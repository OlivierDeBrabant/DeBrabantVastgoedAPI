using DbVastgoedApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbVastgoedApi.Data.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly ProjectContext _context;
        private readonly DbSet<Administrator> _administrators;

        public AdministratorRepository(ProjectContext dbContext)
        {
            _context = dbContext;
            _administrators = dbContext.Administrators;
        }

        public Administrator GetBy(string email)
        {
            return _administrators.SingleOrDefault(c => c.Email == email);
        }

        public void Add(Administrator admin)
        {
            _administrators.Add(admin);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
