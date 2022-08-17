using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoIA.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIA.Repository.Configuracion
{
    public class OrdersConfig : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> entity)
        {
            entity.HasKey(e => e.IdOrder);
            entity.Property(e => e.IdOrder).HasColumnName("IdOrder");
            entity.Property(e => e.IdProduct).HasColumnName("IdProduct");
            entity.Property(e => e.IdStatus).HasColumnName("IdStatus");
            entity.Property(e => e.orderNumber).HasColumnName("OrderNumber");
            entity.Property(e => e.amount).HasColumnName("Amount");
        }
    }
}
