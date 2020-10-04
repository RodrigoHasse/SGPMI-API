using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Paradas;
using CamadaCore.Context.SharedContext.Interfaces.Dapper;

namespace CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Paradas
{
    public interface IRepositorioParadaLeitura: IRepositorioBaseLeitura<ParadaOutputModel, FiltroParadasInputModel>
    {
    }
}
