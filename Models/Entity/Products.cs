using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIA.Models.Entity
{
    public class Products
    {
        [Key]
        [Column("IdProduct")]
        public int IdProducto { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public int stock { get; set; }
    }
}
