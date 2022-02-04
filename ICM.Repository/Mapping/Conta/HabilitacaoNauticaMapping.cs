using ICM.Domain.Conta;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICM.Repository.Mapping.Conta
{
    public class HabilitacaoNauticaMapping : IEntityTypeConfiguration<HabilitacaoNautica>
    {
        public void Configure(EntityTypeBuilder<HabilitacaoNautica> builder)
        {
            builder.ToTable("Tbl_ICM_HabilitacaoNautica");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
            builder.Property(x => x.SocioId).IsRequired().HasColumnName("SocioId");
            builder.Property(x => x.DataEmissao).IsRequired().HasColumnName("DataEmissao");
            builder.Property(x => x.DataValidade).IsRequired().HasColumnName("DataValidade");
            builder.Property(x => x.NumHabilitacao).IsRequired().HasColumnName("NumHabilitacao");

            builder.HasOne(x => x.Socio).WithMany(x => x.HabilitacaoNautica).HasForeignKey(x => x.SocioId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
