using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoIA.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIA.Repository.Configuracion
{
    public class CatStatusConfig : IEntityTypeConfiguration<CatStatus>
    {
        public void Configure(EntityTypeBuilder<CatStatus> entity)
        {
            entity.HasKey(e => e.IdStatus);
            entity.Property(e => e.IdStatus).HasColumnName("IdStatus");
            entity.Property(e => e.status).HasColumnName("Status");
        }
    }
}
