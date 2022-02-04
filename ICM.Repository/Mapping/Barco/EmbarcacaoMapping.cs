using ICM.Domain.Barco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Repository.Mapping.Barco
{
    public class EmbarcacaoMapping : IEntityTypeConfiguration<Embarcacao>
    {
        public void Configure(EntityTypeBuilder<Embarcacao> builder)
        {
            builder.ToTable("Tbl_ICM_Embarcacao");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
            builder.Property(x => x.Nome).IsRequired().HasColumnName("Nome");
            builder.Property(x => x.RegistroMarinha).IsRequired().HasColumnName("RegistroMarinha");
            builder.Property(x => x.Tamanho).IsRequired().HasColumnName("Tamanho");
            builder.Property(x => x.TipoMotor).IsRequired().HasColumnName("TipoMotor");
            builder.Property(x => x.TipoVaga).IsRequired().HasColumnName("TipoVaga");
            builder.Property(x => x.TipoCombustivel).IsRequired().HasColumnName("TipoCombustivel");
        }
    }
}
