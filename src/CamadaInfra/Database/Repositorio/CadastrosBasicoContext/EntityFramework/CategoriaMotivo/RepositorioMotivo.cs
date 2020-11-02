using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.CategoriaMotivos;
using CamadaCore.Context.CadastrosBasicoContext.Models.CategoriaMotivos;
using CamadaInfra.Database.Context;
using CamadaInfra.Database.Repositorio.SharedContext.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Optional;
using System.Threading.Tasks;

namespace CamadaInfra.Database.Repositorio.CadastrosBasicoContext.EntityFramework.CategoriaMotivos
{
    public class RepositorioCategoriaMotivo : RepositorioBasico<CategoriaMotivo>, IRepositorioCategoriaMotivo
    {
        public RepositorioCategoriaMotivo(ContextoPrincipal contextoPrincipal) : base(contextoPrincipal){}

        public async Task<Option<CategoriaMotivo>> RetornarPorNome(string nome)
        {
            var consulta = await dbSet.FirstOrDefaultAsync(x => x.Nome == nome);

            return consulta != null ? Option.Some<CategoriaMotivo>(consulta) : Option.None<CategoriaMotivo>();
        }
    }
}
