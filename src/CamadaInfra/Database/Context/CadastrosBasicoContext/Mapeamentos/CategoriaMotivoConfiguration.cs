using CamadaCore.Context.CadastrosBasicoContext.Models.CategoriaMotivos;
using CamadaCore.Context.CadastrosBasicoContext.Models.Motivos;
using CamadaInfra.Database.SharedContext.MapeamentosBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CamadaInfra.Database.Context.CadastrosBasicoContext.Mapeamentos
{
    public sealed class CategoriaMotivoConfiguration : EntidadeBasicaConfiguration<CategoriaMotivo>
    {
        public override void Configure(EntityTypeBuilder<CategoriaMotivo> builder)
        {
            builder.ToTable("CategoriasMotivo");
            base.Configure(builder);
            builder.Property(x => x.Nome).IsRequired();
        }
    }
}