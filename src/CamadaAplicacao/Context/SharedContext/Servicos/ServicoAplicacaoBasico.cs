using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CamadaAplicacao.Context.SharedContext.Interfaces;
using CamadaCore.Context.SharedContext.Interfaces.Dapper;
using CamadaCore.Context.SharedContext.Interfaces.Notificacoes;
using CamadaCore.Context.SharedContext.Interfaces.Trasacoes;
using CamadaCore.Context.SharedContext.Models;
using CamadaCore.Context.SharedContext.Servicos.Basico;
using CamadaCore.Context.SharedContext.ViewModels.Inputs;
using CamadaCore.Context.SharedContext.ViewModels.Outputs;
using Microsoft.Extensions.Logging;

namespace CamadaAplicacao.Context.SharedContext.Servicos
{
    public abstract class ServicoAplicacaoBasico<T, In, Out, InFiltro> : IServicoAplicacaoBasico<T, In, Out, InFiltro> 
        where T : EntidadeBasica
        where In : InputBasico
        where Out : OutputBasico
        where InFiltro : FiltroBasicoInput
    {
        private IServicoBasico<T> _servicoBasico;
        private readonly ITransacao _transacao;
        private readonly IMapper _mapper;
        private readonly IRepositorioBaseLeitura<Out, InFiltro> _repositorioBaseLeitura;
        private readonly ILogger _logger;

        public ServicoAplicacaoBasico(IServicoBasico<T> servicoBasico, 
            ITransacao transacao, IMapper mapper,
            IRepositorioBaseLeitura<Out, InFiltro> repositorioBaseLeitura)
        {
            _servicoBasico = servicoBasico;
            _transacao = transacao;
            _mapper = mapper;
            _repositorioBaseLeitura = repositorioBaseLeitura;
        }

        public async Task<Out> RetornarPorIdAsync(int id)
        {
            var consulta = await _servicoBasico.RetornarPorIdAsync(id);
            
            T entidade = consulta.Match(
                some: retorno => retorno,
                none:() => {
                    _servicoBasico.RetornarNotificacao().Adicionar("Registro não encontrado.");
                    return default(T);
                }
            );
            return _mapper.Map<T, Out>(entidade);
        }

        public virtual async Task<IEnumerable<Out>> RetornarVariosAsync()
        {
            var consulta = await _servicoBasico.RetornarVariosAsync();

            IEnumerable<T> entidades = consulta.Match(
                some: retorno => retorno,
                none: () => {
                    _servicoBasico.RetornarNotificacao().Adicionar("Nenhum registro encontrado.");
                    return Enumerable.Empty<T>();
                }
            );
            return _mapper.Map<IEnumerable<T>, IEnumerable<Out>>(entidades);
        }

        public virtual async Task<IEnumerable<Out>> ListarAsync(InFiltro filtro)
        {
            var consulta = await _repositorioBaseLeitura.ListarAsync(filtro);

            return consulta.Match(
                some: retorno => retorno,
                none: () => {
                    _servicoBasico.RetornarNotificacao().Adicionar("Nenhum registro encontrado.");
                    return Enumerable.Empty<Out>();
                }
            );
        }

        public async Task ExcluirAsync(In input)
        {
            await TransacaoWrapper(() =>
            {
                T entidade = _mapper.Map<In, T>(input);
                _servicoBasico.ExcluirAsync(entidade);
            });
        }
        public async Task SalvarAsync(In input)
        {
            await TransacaoWrapper(() =>
            {
                T entidade = _mapper.Map<In, T>(input);
                _servicoBasico.SalvarAsync(entidade);
            });
        }

        public INotificacao RetornarNotificacao()
        {
            return _servicoBasico.RetornarNotificacao();
        }      
        
        public async Task TransacaoWrapper(Action acao)
        {
            try
            {
                await _transacao.BeginTransactionAsync();
                acao();
                await _transacao.SaveChangesAsync();
                _transacao.Commit();
            }
            catch (Exception ex)
            {
                _transacao.Rollback();
                _servicoBasico.RetornarNotificacao().Adicionar(ex.InnerException.Message);
                _logger.LogError(ex.InnerException.Message);
            }
        }
    }
}
