using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbVastgoedApi.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        [Required]
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public string Adres { get; set; }
        public ICollection<Product> Producten { get; set; }
        public string imgPath { get; set; }

        public Project()
        {
            Producten = new List<Product>();
        }

        public void VoegProductToe(Product p)
        {
            Producten.Add(p);
        }
        public Product GetProduct(int id)
        {
            return Producten.SingleOrDefault(p => p.ProductID == id);
        }
        public void DeleteProduct(int id)
        {
            Producten.Remove(Producten.SingleOrDefault(p => p.ProductID == id));
        }
        public void changeProduct(int productId, Product p)
        {
            Product prod = GetProduct(productId);

            prod.Titel = p.Titel;
            prod.Beschrijving = p.Beschrijving;
            prod.Oppervlakte = p.Oppervlakte;
            prod.Kostprijs = p.Kostprijs;
            prod.Type = p.Type;
            prod.isVerkocht = p.isVerkocht;
        }
    }
}
