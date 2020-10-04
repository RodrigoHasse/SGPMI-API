using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Maquinas;
using CamadaCore.Context.SharedContext.Interfaces.Dapper;

namespace CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Maquinas
{
    public interface IRepositorioMaquinaLeitura: IRepositorioBaseLeitura<MaquinaOutputModel, FiltroMaquinasInputModel>
    {
        
    }
}
