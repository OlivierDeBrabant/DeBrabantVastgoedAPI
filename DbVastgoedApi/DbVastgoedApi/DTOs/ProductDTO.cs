using DbVastgoedApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbVastgoedApi.DTOs
{
    public class ProductDTO
    {
        public string Titel { get; set; }
        public string Straat { get; set; }
        public string Gemeente { get; set; }
        public int Postcode { get; set; }
        public int Huisnummer { get; set; }
        public int Oppervlakte { get; set; }
        public string Beschrijving { get; set; }
        public double Kostprijs { get; set; }
        public EnumType Type { get; set; }
        public Boolean isVerkocht { get; set; }
    }
}
