using CamadaCore.Context.ConfiguracoesContext.Interfaces.Entity.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.Models.Usuarios;
using CamadaCore.Context.SharedContext.Interfaces.Notificacoes;
using CamadaCore.Context.SharedContext.Servicos.Basico;
using Microsoft.Extensions.Logging;
using Optional;
using System.Threading.Tasks;

namespace CamadaCore.Context.ConfiguracoesContext.Servicos.Usuarios
{
    public class ServicoUsuario : ServicoBasico<Usuario>, IServicoUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public ServicoUsuario(IRepositorioUsuario repositorioUsuario, INotificacao notificacao, ILogger<ServicoUsuario> logger) 
            : base(repositorioUsuario, notificacao, logger)
        {
            _repositorioUsuario = repositorioUsuario;
        }               

        public async Task<Option<Usuario>> RetornarPorLoginAsync(string login)
        {            
            return await _repositorioUsuario.RetornarPorExpressionAsync(x => x.Login == login); ;
        }

        public async Task<Option<Usuario>> RetornarPorUsuarioSenhaAsync(string login, string senha)
        {   
            return await _repositorioUsuario.RetornarPorExpressionAsync(x => x.Login == login);
        }

        public override async Task ValidarAsync(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Nome))
                _notificacao.Adicionar("Nome deve ser informado!");
        }       
    }
}
