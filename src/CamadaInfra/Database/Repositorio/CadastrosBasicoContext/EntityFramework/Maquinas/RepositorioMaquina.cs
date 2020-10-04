using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas;
using CamadaInfra.Database.Context;
using CamadaInfra.Database.Repositorio.SharedContext.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Optional;
using System.Threading.Tasks;

namespace CamadaInfra.Database.Repositorio.CadastrosBasicoContext.EntityFramework.Maquinas
{
    public class RepositorioMaquina : RepositorioBasico<Maquina>, IRepositorioMaquina
    {
        public RepositorioMaquina(ContextoPrincipal contextoPrincipal) : base(contextoPrincipal){}

        public async Task<Option<Maquina>> RetornarPorNome(string nome)
        {
            var consulta = await dbSet.FirstOrDefaultAsync(x => x.Nome == nome);

            return consulta == null ? Option.None<Maquina>() : Option.Some<Maquina>(consulta);
        }


    }
}
