using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIA.Models.DTO
{
    public class ProductDTO
    {
        public int id { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public int stock { get; set; }

        public ProductDTO()
        {

        }
    }
}
