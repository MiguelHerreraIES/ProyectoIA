using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIA.Models.Entity
{
    public class CatStatus
    {
        [Key]
        [Column("IdStatus")]
        public int IdStatus { get; set; }
        public string status { get; set; }
    }
}
