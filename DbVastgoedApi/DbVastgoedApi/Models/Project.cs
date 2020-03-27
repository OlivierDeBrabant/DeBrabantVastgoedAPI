using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbVastgoedApi.Models
{
    public class Project
    {
        [Required]
        public string Naam { get; set; }
        public int ProjectID { get; set; }
        public string Beschrijving { get; set; }
        public ICollection<Product> Producten { get; set; }


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
    }
}
