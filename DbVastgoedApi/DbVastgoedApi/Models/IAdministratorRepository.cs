using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbVastgoedApi.Models
{
    public interface IAdministratorRepository
    {
        Administrator GetBy(string email);
        void Add(Administrator customer);
        void SaveChanges();
    }
}
