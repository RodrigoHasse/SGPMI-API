using CamadaAplicacao.Context.SharedContext.Interfaces;
using CamadaCore.Context.CadastrosBasicoContext.Models.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Motivos;

namespace CamadaAplicacao.Context.CadastrosBasicosContext.Interfaces.Maquinas
{
    public interface IServicoAplicacaoMotivo : IServicoAplicacaoBasico<Motivo, MotivoInputModel, MotivoOutputModel, FiltroMotivosInputModel>
    {
    }
}
