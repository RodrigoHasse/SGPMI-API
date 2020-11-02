using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.CategoriaMotivo;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.CategoriaMotivo;
using CamadaCore.Context.SharedContext.Interfaces.Dapper;

namespace CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.CategoriaMotivo
{
    public interface IRepositorioCategoriaMotivoLeitura: IRepositorioBaseLeitura<CategoriaMotivoOutputModel, FiltroCategoriaMotivoInputModel>
    {
        
    }
}
