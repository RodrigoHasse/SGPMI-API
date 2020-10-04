using CamadaCore.Context.CadastrosBasicoContext.Models.Motivos;
using CamadaInfra.Database.SharedContext.MapeamentosBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CamadaInfra.Database.Context.CadastrosBasicoContext.Mapeamentos
{
    public sealed class MotivoConfiguration : EntidadeBasicaConfiguration<Motivo>
    {
        public override void Configure(EntityTypeBuilder<Motivo> builder)
        {
            builder.ToTable("Motivos");
            base.Configure(builder);
            builder.Property(x => x.Nome).IsRequired();
        }
    }
}