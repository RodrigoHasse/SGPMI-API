using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Motivos;
using CamadaCore.Context.SharedContext.Interfaces.Dapper;

namespace CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Motivos
{
    public interface IRepositorioMotivoLeitura: IRepositorioBaseLeitura<MotivoOutputModel, FiltroMotivosInputModel>
    {
        
    }
}
