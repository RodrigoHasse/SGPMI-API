using AutoMapper;
using CamadaAplicacao.Context.CadastrosBasicosContext.Interfaces.Maquinas;
using CamadaAplicacao.Context.SharedContext.Servicos;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.Models.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.Servicos.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Motivos;
using CamadaCore.Context.SharedContext.Interfaces.Trasacoes;
using CamadaCore.Context.SharedContext.ViewModels.Outputs;
using Optional.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamadaAplicacao.Context.CadastrosBasicosContext.Servicos.Motivos
{
    public class ServicoAplicacaoMotivo : ServicoAplicacaoBasico<Motivo, MotivoInputModel, MotivoOutputModel, FiltroMotivosInputModel>,
                                          IServicoAplicacaoMotivo
    {
        private IServicoMotivo _servicoMotivo;
        private readonly ITransacao _transacao;
        private readonly IMapper _mapper;
        private readonly IRepositorioMotivoLeitura _repositorioLeituraMotivo;

        public ServicoAplicacaoMotivo(IServicoMotivo servicoMotivo, ITransacao transacao, IRepositorioMotivoLeitura repositorioLeituraMotivo, IMapper mapper) : base(servicoMotivo, transacao, mapper, repositorioLeituraMotivo)
        {
            _servicoMotivo = servicoMotivo;
            _transacao = transacao;
            _mapper = mapper;
            _repositorioLeituraMotivo = repositorioLeituraMotivo;
        }

        public async Task<IEnumerable<ComboPadraoOutput>> RetornarComboAsync(FiltroMotivosInputModel filtros)
        {
            var listaCombo = await _repositorioLeituraMotivo.ListarAsync(filtros);


            IEnumerable<MotivoOutputModel> entidade = listaCombo.Match(
                some: lista => lista,
                none: () =>
                {
                    _servicoMotivo.RetornarNotificacao().Adicionar("Nenhum registro encontrado.");
                    return Enumerable.Empty<MotivoOutputModel>();
                });

            return entidade.Select(x => new ComboPadraoOutput { id = x.Id, label = x.Nome });
        }
    }
}
