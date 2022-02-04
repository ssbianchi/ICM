using ICM.Domain.Funcionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Repository.Mapping.Funcionario
{
    public class TripulanteMapping : IEntityTypeConfiguration<Tripulante>
    {
        public void Configure(EntityTypeBuilder<Tripulante> builder)
        {
            builder.ToTable("Tbl_ICM_Tripulante");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
            builder.Property(x => x.Nome).IsRequired().HasColumnName("Nome");
            builder.Property(x => x.CPF).HasColumnName("CPF");
            builder.Property(x => x.EmbarcacaoId).IsRequired().HasColumnName("EmbarcacaoId");

            builder.HasOne(x => x.Embarcacao).WithMany(x => x.Tripulante).HasForeignKey(x => x.EmbarcacaoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}