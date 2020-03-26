using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbVastgoedApi.Models
{
    public class Product
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
        //public List<int> FotoNummers { get; set; }
        public Boolean isVerkocht { get; set; }
        public int ID { get; set; }
        public int ProjectID { get; set; }

        public Product(string titel, string straat, int huisnummer, int postcode, string gemeente, int oppervlakte, string beschrijving, bool isVerkocht, EnumType type, double kostprijs)
        {
            Titel = titel;
            
            Straat = straat;
            Huisnummer = huisnummer;
            Postcode = postcode;
            Gemeente = gemeente;
            Oppervlakte = oppervlakte;
            Beschrijving = beschrijving;
            this.isVerkocht = isVerkocht;
            
            Type = type;
            Kostprijs = kostprijs;
        }
    }
}
