using CamadaAplicacao.Context.SharedContext.Interfaces;
using CamadaCore.Context.CadastrosBasicoContext.Models.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.CategoriaMotivo;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.CategoriaMotivo;

namespace CamadaAplicacao.Context.CadastrosBasicosContext.Interfaces.CategoriaMotivos
{
    public interface IServicoAplicacaoCategoriaMotivo : IServicoAplicacaoBasico<Motivo, CategoriaMotivoInputModel, CategoriaMotivoOutputModel, FiltroCategoriaMotivoInputModel>
    {
    }
}
