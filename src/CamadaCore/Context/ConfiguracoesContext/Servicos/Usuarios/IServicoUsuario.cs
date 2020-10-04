using CamadaCore.Context.ConfiguracoesContext.Models.Usuarios;
using CamadaCore.Context.SharedContext.Servicos.Basico;
using Optional;
using System.Threading.Tasks;

namespace CamadaCore.Context.ConfiguracoesContext.Servicos.Usuarios
{
    public interface IServicoUsuario : IServicoBasico<Usuario>
    {
        Task<Option<Usuario>> RetornarPorLoginAsync(string login);
        Task<Option<Usuario>> RetornarPorUsuarioSenhaAsync(string login, string senha);
    }
}
