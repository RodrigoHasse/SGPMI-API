using AutoMapper;
using CamadaAplicacao.Context.CadastrosBasicosContext.Interfaces.Paradas;
using CamadaAplicacao.Context.SharedContext.Servicos;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.Models.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.Servicos.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Paradas;
using CamadaCore.Context.SharedContext.Interfaces.Trasacoes;
using CamadaCore.Context.SharedContext.ViewModels.Outputs;
using Optional.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamadaAplicacao.Context.CadastrosBasicosContext.Servicos.Paradas
{
    public class ServicoAplicacaoParada : ServicoAplicacaoBasico<Parada, ParadaInputModel, ParadaOutputModel, FiltroParadasInputModel>,
                                          IServicoAplicacaoParada
    {
        private IServicoParada _servicoParada;
        private readonly ITransacao _transacao;
        private readonly IMapper _mapper;
        private readonly IRepositorioParadaLeitura _repositorioLeituraParada;

        public ServicoAplicacaoParada(IServicoParada servicoParada, ITransacao transacao, IRepositorioParadaLeitura repositorioLeituraParada, IMapper mapper) : base(servicoParada, transacao, mapper, repositorioLeituraParada)
        {
            _servicoParada = servicoParada;
            _transacao = transacao;
            _mapper = mapper;
            _repositorioLeituraParada = repositorioLeituraParada;
        }

        public async Task<decimal> RetornarTotalTempoParada(FiltroParadasInputModel filtro)
        {
            return await _repositorioLeituraParada.RetornarTotalTempoParada(filtro);
        }

        public async Task<IEnumerable<ParadaOutputModel>> RetornarParadas(FiltroParadasInputModel filtro)
        {
            var consulta = await _repositorioLeituraParada.ListarAsync(filtro);

            IEnumerable<ParadaOutputModel> paradas = consulta.Match(
                some: retorno => retorno,
                none: () =>
                {
                    _servicoParada.RetornarNotificacao().Adicionar("Nenhum registro encontrado.");
                    return Enumerable.Empty<ParadaOutputModel>();
                });
            var total = await _repositorioLeituraParada.RetornarTotalTempoParada(filtro);

            foreach (var item in paradas)
            {                
                if(item.TempoParada != null)
                    item.PercentualTempoParada = ( (decimal)item.TempoParada / total) * 100;
            };

            return paradas;
        }

        public async Task<IEnumerable<ParadasResumoMotivoInputModel>> RetornarResumoParadasPorMotivo(FiltroParadasInputModel filtro)
        {
            var consulta = await _repositorioLeituraParada.ResumoParadasPorMotivoAsync(filtro);

            IEnumerable<ParadasResumoMotivoInputModel> paradas = consulta.Match(
                some: retorno => retorno,
                none: () =>
                {
                    _servicoParada.RetornarNotificacao().Adicionar("Nenhum registro encontrado.");
                    return Enumerable.Empty<ParadasResumoMotivoInputModel>();
                });
            var total = await _repositorioLeituraParada.RetornarTotalTempoParada(filtro);

            foreach (var item in paradas)
            {
                if ((total > 0 ) && (item.Total > 0))
                    item.Percentual = (item.Total / total) * 100;
            };

            return paradas;
        }
    }
}
