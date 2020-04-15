using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbVastgoedApi.DTOs;
using DbVastgoedApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbVastgoedApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IAdministratorRepository _adminRepo;

        public AdministratorController(IAdministratorRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }

        /// <summary>
        /// Get the details of the authenticated customer
        /// </summary>
        /// <returns>the customer</returns>
        [HttpGet()]
        public ActionResult<AdministratorDTO> GetCustomer()
        {
            Administrator admin = _adminRepo.GetBy(User.Identity.Name);
            return new AdministratorDTO(admin);
        }
    }
}