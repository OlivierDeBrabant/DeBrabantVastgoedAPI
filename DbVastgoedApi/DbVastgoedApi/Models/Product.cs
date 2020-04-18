using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbVastgoedApi.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Titel { get; set; }
        public int Oppervlakte { get; set; }
        public string Beschrijving { get; set; }
        public double Kostprijs { get; set; }
        public string Type { get; set; }
        public Boolean isVerkocht { get; set; }
        


        public Product(string titel, int oppervlakte, string beschrijving, bool isVerkocht, string type, double kostprijs)
        {
            Titel = titel;
            Oppervlakte = oppervlakte;
            Beschrijving = beschrijving;
            this.isVerkocht = isVerkocht;
            
            Type = type;
            Kostprijs = kostprijs;
        }
        public Product()
        {

        }
    }
}
