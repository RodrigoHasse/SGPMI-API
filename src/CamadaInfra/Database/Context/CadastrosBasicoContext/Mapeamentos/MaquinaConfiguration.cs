using CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas;
using CamadaInfra.Database.SharedContext.MapeamentosBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CamadaInfra.Database.Context.CadastrosBasicoContext.Mapeamentos
{
    public sealed class MaquinaConfiguration : EntidadeBasicaConfiguration<Maquina>
    {
        public override void Configure(EntityTypeBuilder<Maquina> builder)
        {
            builder.ToTable("Maquinas");
            base.Configure(builder);
            builder.Property(x => x.Nome).IsRequired();
        }
    }
}