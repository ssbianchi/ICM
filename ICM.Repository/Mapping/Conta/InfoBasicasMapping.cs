using ICM.Domain.Conta;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Repository.Mapping.Conta
{
    public class InfoBasicasMapping : IEntityTypeConfiguration<InfoBasica>
    {
        public void Configure(EntityTypeBuilder<InfoBasica> builder)
        {
            builder.ToTable("Tbl_ICM_InfoBasica");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
            builder.Property(x => x.SocioId).IsRequired().HasColumnName("SocioId");
            builder.Property(x => x.NumTelefone).IsRequired().HasColumnName("NumTelefone");
            builder.Property(x => x.Email).HasColumnName("Email");

            builder.HasOne(x => x.Socio).WithMany(x => x.InfoBasica).HasForeignKey(x => x.SocioId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
