using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ProyectoIA.Models.Request
{
    [ExcludeFromCodeCoverage]
    public class AddProductRequest
    {
        [Required(ErrorMessage ="SKU es requerido")]
        [DataMember]
        public string sku { get; set; }
        [Required(ErrorMessage = "Nombre de producto es requerido")]
        [DataMember]
        public string name { get; set; }
        [Required(ErrorMessage = "Cantidad a ingresar es requerida")]
        [DataMember]
        public int amount { get; set; }
    }
}
