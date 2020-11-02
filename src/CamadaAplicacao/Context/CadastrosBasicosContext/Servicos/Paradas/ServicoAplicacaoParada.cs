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
    }
}
