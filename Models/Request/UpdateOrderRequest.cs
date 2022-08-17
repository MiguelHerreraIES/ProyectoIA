using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIA.Models.Request
{
    public class UpdateOrderRequest
    {
        [Required(ErrorMessage ="Estatus Requerido")]
        public int IdStatus { get; set; }
        [Required(ErrorMessage = "Número de orden Requerido")]
        public int OrderNumber { get; set; }
    }
}
