using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIA.Models.Request
{
    public class AddOrderRequest
    {
        public List<AddOrderDTO> order { get; set; }

        public class AddOrderDTO
        {
            [Required(ErrorMessage = "Seleccione un producto.")]
            public int idProduct { get; set; }
            [Required(ErrorMessage = "Ingrese la cantidad.")]
            public int Amount { get; set; }

        }        
    }
}
