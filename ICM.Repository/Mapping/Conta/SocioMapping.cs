using ICM.Domain.Conta;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICM.Repository.Mapping.Conta
{
    public class SocioMapping : IEntityTypeConfiguration<Socio>
    {
        public void Configure(EntityTypeBuilder<Socio> builder)
        {
            builder.ToTable("Tbl_ICM_Socio");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
            builder.Property(x => x.Nome).IsRequired().HasColumnName("Nome");

            // Mapeamento do ValueObject
            builder.OwnsOne(x => x.CPF, p =>
            {
                p.Property(f => f.Valor).HasColumnName("CPF");
            });

            builder.OwnsOne(x => x.CNPJ, p =>
            {
                p.Property(f => f.Valor).HasColumnName("CNPJ");
            });
        }
    }


}
