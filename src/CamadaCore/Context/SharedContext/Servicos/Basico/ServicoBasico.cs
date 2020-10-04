using CamadaCore.Context.SharedContext.Interfaces.Entity;
using CamadaCore.Context.SharedContext.Interfaces.Notificacoes;
using CamadaCore.Context.SharedContext.Models;
using Microsoft.Extensions.Logging;
using Optional;
using System.Linq;
using System.Threading.Tasks;

namespace CamadaCore.Context.SharedContext.Servicos.Basico
{
    public abstract class ServicoBasico<T> : IServicoBasico<T> where T : EntidadeBasica
    {
        private readonly IRepositorio<T> _repositorio;
        protected INotificacao Notificacao { get { return _notificacao; } }
        protected INotificacao _notificacao;
        private readonly ILogger _logger;
        public ServicoBasico(IRepositorio<T> repositorio, INotificacao notificacao, ILogger<ServicoBasico<T>> logger)
        {
            _repositorio = repositorio;
            _notificacao = notificacao;
            _logger = logger;
        }
        public async Task ExcluirAsync(T entidade)
        {
            _repositorio.Excluir(entidade);
            _logger.LogInformation(1001, "Exclusão {ID}", entidade.Id);
        }
        public INotificacao RetornarNotificacao()
        {
            return Notificacao;
        }
        public async Task<Option<T>> RetornarPorIdAsync(int id)
        {
            return await _repositorio.RetornarPorIdAsync(id);
        }
        public async Task<Option<IQueryable<T>>> RetornarVariosAsync()
        {
            return await _repositorio.RetornarVariosAsync();
        }
        public virtual async Task ValidarAsync(T entidade)
        {
            
        }
        public async Task SalvarAsync (T entidade)
        {
            await ValidarAsync(entidade);

            if (_notificacao.IsValid()) 
            { 
                _repositorio.Salvar(entidade);
                _logger.LogInformation(1002, "Salvar {ID}", entidade.Id);
            }
        }
    }
}