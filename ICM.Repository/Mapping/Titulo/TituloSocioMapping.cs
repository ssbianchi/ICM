using ICM.Domain.Titulo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Repository.Mapping.Titulo
{
    public class TituloSocioMapping : IEntityTypeConfiguration<TituloSocio>
    {
        public void Configure(EntityTypeBuilder<TituloSocio> builder)
        {
            builder.ToTable("Tbl_ICM_TituloSocio");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
            builder.Property(x => x.NumTituloSocio).IsRequired().HasColumnName("NumTituloSocio");
            builder.Property(x => x.SocioId).IsRequired().HasColumnName("SocioId");
            builder.Property(x => x.EmbarcacaoId).IsRequired().HasColumnName("EmbarcacaoId");

            builder.HasOne(x => x.Socio).WithOne().HasForeignKey<TituloSocio>(x => x.SocioId);
            builder.HasOne(x => x.Embarcacao).WithMany(x => x.TituloSocio).HasForeignKey(x => x.EmbarcacaoId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}