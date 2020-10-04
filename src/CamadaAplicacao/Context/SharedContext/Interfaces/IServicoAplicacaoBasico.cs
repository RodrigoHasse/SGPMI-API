using CamadaCore.Context.SharedContext.Interfaces.Notificacoes;
using CamadaCore.Context.SharedContext.Models;
using CamadaCore.Context.SharedContext.ViewModels.Inputs;
using CamadaCore.Context.SharedContext.ViewModels.Outputs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamadaAplicacao.Context.SharedContext.Interfaces
{
    
    public interface IServicoAplicacaoBasico<T, In, Out, InFiltro> 
        where T : EntidadeBasica
        where In : InputBasico              
        where Out : OutputBasico
        where InFiltro : FiltroBasicoInput
    {
        Task<Out> RetornarPorIdAsync(int id);
        Task<IEnumerable<Out>> RetornarVariosAsync();        
        Task<IEnumerable<Out>> ListarAsync(InFiltro filtro);
        Task SalvarAsync(In input);
        Task ExcluirAsync(In input);
        INotificacao RetornarNotificacao();        
    }
}
