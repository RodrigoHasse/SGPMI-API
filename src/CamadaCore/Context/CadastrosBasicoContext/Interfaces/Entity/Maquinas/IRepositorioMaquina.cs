using System.Threading.Tasks;
using CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas;
using CamadaCore.Context.SharedContext.Interfaces.Entity;
using Optional;

namespace CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.Maquinas
{
    public interface IRepositorioMaquina : IRepositorio<Maquina>
    {
        Task<Option<Maquina>> RetornarPorNome(string nome);
    }
}
