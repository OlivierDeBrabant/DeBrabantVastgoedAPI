using DbVastgoedApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbVastgoedApi.Data
{
    public class ProjectDataInitializer
    {
        public class RecipeDataInitializer
        {
            private readonly ProjectContext _dbContext;

            public RecipeDataInitializer(ProjectContext dbContext)
            {
                _dbContext = dbContext;
            }

            public void InitializeData()
            {
                _dbContext.Database.EnsureDeleted();
                if (_dbContext.Database.EnsureCreated())
                {
                    //seeding the database with recipes, see DBContext               
                }
            }

        }
    }
}
