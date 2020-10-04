using CamadaAplicacao.Context.SharedContext.Interfaces;
using CamadaCore.Context.ConfiguracoesContext.Models.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.ViewModels.Inputs.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.ViewModels.Outputs.Usuarios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CamadaAplicacao.Context.ConfiguracoesContext.Interfaces.Usuarios
{
    public interface IServicoAplicacaoUsuario : IServicoAplicacaoBasico<Usuario, UsuarioInputModel,
                                                        UsuarioOutputModel, FiltroUsuariosInputModel>
    {
        Task<UsuarioOutputModel> RetornarPorLoginAsync(string login);
        Task<UsuarioOutputModel> RetornarPorUsuarioSenhaAsync(string login, string senha);
    }
}
