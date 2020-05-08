using DbVastgoedApi.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DbVastgoedApi.Data
{
    public class ProjectDataInitializer
    {
        private readonly ProjectContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        public ProjectDataInitializer(ProjectContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            //_dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Administrator admin = new Administrator { Email = "olivier@outlook.com", FirstName = "Olivier", LastName = "De Brabant" };
                _dbContext.Administrators.Add(admin);
                await CreateUser(admin.Email, "P@ssword1111");

                Administrator admin2 = new Administrator { Email = "db@db.com", FirstName = "Admin", LastName = "De Brabant" };
                _dbContext.Administrators.Add(admin2);
                await CreateUser(admin2.Email, "P@ssword1111");
                _dbContext.SaveChanges();
            }
        }
        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}
