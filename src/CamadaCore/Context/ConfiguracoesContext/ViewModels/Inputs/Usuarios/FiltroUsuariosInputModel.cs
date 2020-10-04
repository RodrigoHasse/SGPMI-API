using CamadaCore.Context.SharedContext.ViewModels.Inputs;

namespace CamadaCore.Context.ConfiguracoesContext.ViewModels.Inputs.Usuarios
{
    public class FiltroUsuariosInputModel: FiltroBasicoInput
    {
        public FiltroListaInput Organizacoes { get; set; }
    }
}
