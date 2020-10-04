using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.Models.Motivos;
using CamadaInfra.Database.Context;
using CamadaInfra.Database.Repositorio.SharedContext.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Optional;
using System.Threading.Tasks;

namespace CamadaInfra.Database.Repositorio.CadastrosBasicoContext.EntityFramework.Motivos
{
    public class RepositorioMotivo : RepositorioBasico<Motivo>, IRepositorioMotivo
    {
        public RepositorioMotivo(ContextoPrincipal contextoPrincipal) : base(contextoPrincipal){}

        public async Task<Option<Motivo>> RetornarPorNome(string nome)
        {
            var consulta = await dbSet.FirstOrDefaultAsync(x => x.Nome == nome);

            return consulta == null ? Option.None<Motivo>() : Option.Some<Motivo>(consulta);
        }
    }
}
