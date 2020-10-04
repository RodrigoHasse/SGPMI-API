using AutoMapper;
using CamadaAplicacao.Context.ConfiguracoesContext.Interfaces.Usuarios;
using CamadaAplicacao.Context.SharedContext.Servicos;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.Models.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.Servicos.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.ViewModels.Inputs.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.ViewModels.Outputs.Usuarios;
using CamadaCore.Context.SharedContext.Interfaces.Trasacoes;
using System.Threading.Tasks;

namespace CamadaAplicacao.Context.ConfiguracoesContext.Servicos.Usuarios
{
    public class ServicoAplicacaoUsuario :
        ServicoAplicacaoBasico<Usuario, UsuarioInputModel, UsuarioOutputModel, FiltroUsuariosInputModel>,
        IServicoAplicacaoUsuario
    {
        private IServicoUsuario _servicoUsuario;
        private readonly ITransacao _transacao;
        private readonly IMapper _mapper;
        private readonly IRepositorioUsuarioLeitura _repositorioLeituraUsuario;
        public ServicoAplicacaoUsuario(IServicoUsuario servicoUsuario, ITransacao transacao,
            IRepositorioUsuarioLeitura repositorioLeituraUsuario, IMapper mapper) :
            base(servicoUsuario, transacao, mapper, repositorioLeituraUsuario)
        {
            _servicoUsuario = servicoUsuario;
            _transacao = transacao;
            _mapper = mapper;
            _repositorioLeituraUsuario = repositorioLeituraUsuario;
        }

        public async Task<UsuarioOutputModel> RetornarPorLoginAsync(string login)
        {
            var consulta = await _servicoUsuario.RetornarPorLoginAsync(login);
            Usuario entidade = consulta.Match(
                some: retorno => retorno,
                none: () =>
                {
                    _servicoUsuario.RetornarNotificacao().Adicionar("Registro não encontrado.");
                    return default(Usuario);
                }
            );
            UsuarioOutputModel entidadeMapper = _mapper.Map<Usuario, UsuarioOutputModel>(entidade);
            return entidadeMapper;
        }

        public async Task<UsuarioOutputModel> RetornarPorUsuarioSenhaAsync(string login, string senha)
        {
            var consulta = await _servicoUsuario.RetornarPorUsuarioSenhaAsync(login, senha);
            Usuario entidade = consulta.Match(
                some: retorno => retorno,
                none: () =>
                {
                    _servicoUsuario.RetornarNotificacao().Adicionar("Registro não encontrado.");
                    return default(Usuario);
                }
            );
            UsuarioOutputModel entidadeMapper = _mapper.Map<Usuario, UsuarioOutputModel>(entidade);
            return entidadeMapper;
        }
    }
}
