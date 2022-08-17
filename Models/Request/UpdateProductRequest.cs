using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIA.Models.Request
{
    public class UpdateProductRequest
    {    
        [Required(ErrorMessage = "El Id del producto es requerido")]
        public int id { get; set; }
        public string name { get; set; }
        public int stock { get; set; }
    }
}
