using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoIA.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIA.Repository.Configuracion
{
    public class ProductConfig : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> entity)
        {
            entity.HasKey(e => e.IdProducto);
            entity.Property(e => e.IdProducto).HasColumnName("IdProduct");
            entity.Property(e => e.sku).HasColumnName("SKU");
            entity.Property(e => e.name).HasColumnName("Name");
            entity.Property(e => e.stock).HasColumnName("Stock");
        }
    }
}
