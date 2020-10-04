using CamadaCore.Context.SharedContext.ViewModels.Outputs;
using System.Collections.Generic;

namespace CamadaCore.Context.ConfiguracoesContext.ViewModels.Outputs.Usuarios
{
    public class UsuarioOutputListaModel : OutputListaBasico
    {
        public List<UsuarioOutputModel> UsuarioRetornoListas { get; set; }
    }
}
