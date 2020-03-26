using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbVastgoedApi.Models
{
    public class Product
    {
        [Required]
        public string Titel { get; set; }
        public string Straat { get; set; }
        public string Gemeente { get; set; }
        public int Postcode { get; set; }
        public int Huisnummer { get; set; }
        public int Oppervlakte { get; set; }
        public int OppervlakteTuin { get; set; }
        public string Status { get; set; }
        public double Kostprijs { get; set; }
        public EnumType Type { get; set; }
        //public List<int> FotoNummers { get; set; }
        public Boolean isVerkocht { get; set; }
        public int ID { get; set; }

        /*
        public Product()
        {
            FotoNummers = new List<int>();
        }
        */
    }
}
