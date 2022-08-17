using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIA.Models.Entity
{
    public class Orders
    {
        [Key]
        [Column("IdOrder")]
        public int IdOrder { get; set; } 
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Products Products { get; set; }
        public int IdStatus { get; set; }
        [ForeignKey("IdStatus")]
        public virtual CatStatus CatStatus { get; set; }
        public int orderNumber { get; set; }
        public int amount { get; set; }

        public Orders()
        {

        }

    }
}
