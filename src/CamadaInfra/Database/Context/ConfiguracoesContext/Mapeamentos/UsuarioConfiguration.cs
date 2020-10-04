using CamadaCore.Context.ConfiguracoesContext.Models.Usuarios;
using CamadaInfra.Database.SharedContext.MapeamentosBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CamadaInfra.Database.Context.ConfiguracoesContext.Mapeamentos
{
    public class UsuarioConfiguration : EntidadeBasicaConfiguration<Usuario>
    {
        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            base.Configure(builder);

            builder.Property(x => x.Login).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => new { x.Login }).IsUnique();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(100);
        }
    }
}