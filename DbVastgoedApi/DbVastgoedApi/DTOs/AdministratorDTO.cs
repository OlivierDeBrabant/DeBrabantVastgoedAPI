using DbVastgoedApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbVastgoedApi.DTOs
{
    public class AdministratorDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public AdministratorDTO() { }

        public AdministratorDTO(Administrator admin) : this()
        {
            FirstName = admin.FirstName;
            LastName = admin.LastName;
            Email = admin.Email;
        }
    }
}
