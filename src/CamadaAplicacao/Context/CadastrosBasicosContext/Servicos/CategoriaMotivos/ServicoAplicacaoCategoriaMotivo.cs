using AutoMapper;
using CamadaAplicacao.Context.CadastrosBasicosContext.Interfaces.CategoriaMotivos;
using CamadaAplicacao.Context.SharedContext.Servicos;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.CategoriaMotivo;
using CamadaCore.Context.CadastrosBasicoContext.Models.CategoriaMotivos;
using CamadaCore.Context.CadastrosBasicoContext.Servicos.CategoriaMotivos;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.CategoriaMotivo;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.CategoriaMotivo;
using CamadaCore.Context.SharedContext.Interfaces.Trasacoes;
using CamadaCore.Context.SharedContext.ViewModels.Outputs;
using Optional.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamadaAplicacao.Context.CadastrosBasicosContext.Servicos.CategoriaMotivos
{
    public class ServicoAplicacaoCategoriaMotivo : ServicoAplicacaoBasico<CategoriaMotivo, CategoriaMotivoInputModel, CategoriaMotivoOutputModel, FiltroCategoriaMotivoInputModel>,
                                          IServicoAplicacaoCategoriaMotivo
    {
        private IServicoCategoriaMotivo _servicoCategoriaMotivo;
        private readonly ITransacao _transacao;
        private readonly IMapper _mapper;
        private readonly IRepositorioCategoriaMotivoLeitura _repositorioLeituraCategoriaMotivo;

        public ServicoAplicacaoCategoriaMotivo(IServicoCategoriaMotivo servicoCategoriaMotivo, ITransacao transacao, IRepositorioCategoriaMotivoLeitura repositorioLeituraCategoriaMotivo, IMapper mapper) : base(servicoCategoriaMotivo, transacao, mapper, repositorioLeituraCategoriaMotivo)
        {
            _servicoCategoriaMotivo = servicoCategoriaMotivo;
            _transacao = transacao;
            _mapper = mapper;
            _repositorioLeituraCategoriaMotivo = repositorioLeituraCategoriaMotivo;
        }

        public async Task<IEnumerable<ComboPadraoOutput>> RetornarComboAsync(FiltroCategoriaMotivoInputModel filtros)
        {
            var listaCombo = await _repositorioLeituraCategoriaMotivo.ListarAsync(filtros);


            IEnumerable<CategoriaMotivoOutputModel> entidade = listaCombo.Match(
                some: lista => lista,
                none: () =>
                {
                    _servicoCategoriaMotivo.RetornarNotificacao().Adicionar("Nenhum registro encontrado.");
                    return Enumerable.Empty<CategoriaMotivoOutputModel>();
                });

            return entidade.Select(x => new ComboPadraoOutput { id = x.Id, label = x.Nome });
        }
    }
}
