using System.Threading.Tasks;
using CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.Models.Motivos;
using CamadaCore.Context.SharedContext.Interfaces.Entity;
using Optional;

namespace CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.Motivos
{
    public interface IRepositorioMotivo : IRepositorio<Motivo>
    {
        Task<Option<Motivo>> RetornarPorNome(string nome);
    }
}
