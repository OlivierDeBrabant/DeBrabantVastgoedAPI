using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbVastgoedApi.DTOs
{
    public class ProjectDTO
    {
        public string Naam { get; set; }
        //public int ProjectID { get; set; }
        public string Beschrijving { get; set; }
        public string Adres { get; set; }
    }
}
