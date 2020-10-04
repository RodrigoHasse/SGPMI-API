using CamadaCore.Context.CadastrosBasicoContext.Models.Paradas;
using CamadaInfra.Database.SharedContext.MapeamentosBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CamadaInfra.Database.Context.CadastrosBasicoContext.Mapeamentos
{
    public sealed class ParadaConfiguration : EntidadeBasicaConfiguration<Parada>
    {
        public override void Configure(EntityTypeBuilder<Parada> builder)
        {
            builder.ToTable("Paradas");
            base.Configure(builder);

            builder.HasOne(x => x.Motivo).WithMany().HasForeignKey(x => x.MotivoId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey(x => x.UsuarioId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Maquina).WithMany().HasForeignKey(x => x.MaquinaId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}