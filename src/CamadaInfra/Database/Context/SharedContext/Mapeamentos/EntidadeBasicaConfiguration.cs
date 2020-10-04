using CamadaCore.Context.SharedContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CamadaInfra.Database.SharedContext.MapeamentosBase
{
    public abstract class EntidadeBasicaConfiguration<T> : IEntityTypeConfiguration<T> where T : EntidadeBasica
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
