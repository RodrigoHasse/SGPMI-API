using System.Threading.Tasks;
using CamadaCore.Context.CadastrosBasicoContext.Models.CategoriaMotivos;
using CamadaCore.Context.SharedContext.Interfaces.Entity;
using Optional;

namespace CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.CategoriaMotivos
{
    public interface IRepositorioCategoriaMotivo : IRepositorio<CategoriaMotivo>
    {
        Task<Option<CategoriaMotivo>> RetornarPorNome(string nome);
    }
}
