using CamadaCore.Context.SharedContext.Interfaces.Notificacoes;
using CamadaCore.Context.SharedContext.Models;
using Optional;
using System.Linq;
using System.Threading.Tasks;

namespace CamadaCore.Context.SharedContext.Servicos.Basico
{
    public interface IServicoBasico<T> where T : EntidadeBasica
    {
        Task<Option<T>> RetornarPorIdAsync(int id);
        Task<Option<IQueryable<T>>> RetornarVariosAsync();
        Task SalvarAsync (T entidade);
        Task ExcluirAsync(T entidade);
        INotificacao RetornarNotificacao();
    }
}
