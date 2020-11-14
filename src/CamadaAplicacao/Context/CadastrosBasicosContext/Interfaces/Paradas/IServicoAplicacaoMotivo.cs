using CamadaAplicacao.Context.SharedContext.Interfaces;
using CamadaCore.Context.CadastrosBasicoContext.Models.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Paradas;
using System.Collections.Generic;
using System.Threading.Tasks;
    
namespace CamadaAplicacao.Context.CadastrosBasicosContext.Interfaces.Paradas
{
    public interface IServicoAplicacaoParada : IServicoAplicacaoBasico<Parada, ParadaInputModel, ParadaOutputModel, FiltroParadasInputModel>
    {
        Task<decimal> RetornarTotalTempoParada(FiltroParadasInputModel filtro);
        Task<IEnumerable<ParadaOutputModel>> RetornarParadas(FiltroParadasInputModel filtro);
    }
}
