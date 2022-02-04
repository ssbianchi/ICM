using ICM.Domain.Responsavel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Repository.Mapping.Responsavel
{
    public class DependenteMapping : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente> builder)
        {
            builder.ToTable("Tbl_ICM_Dependente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
            builder.Property(x => x.SocioId).IsRequired().HasColumnName("SocioId");
            builder.Property(x => x.Nome).IsRequired().HasColumnName("Nome");
            builder.Property(x => x.CPF).HasColumnName("CPF");

            builder.HasOne(x => x.Socio).WithMany(x => x.Dependente).HasForeignKey(x => x.SocioId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}