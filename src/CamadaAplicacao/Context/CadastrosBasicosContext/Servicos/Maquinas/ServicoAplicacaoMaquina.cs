﻿using AutoMapper;
using CamadaAplicacao.Context.CadastrosBasicosContext.Interfaces.Maquinas;
using CamadaAplicacao.Context.SharedContext.Servicos;
using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Dapper.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.Models.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.Servicos.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.Servicos.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Maquinas;
using CamadaCore.Context.SharedContext.Interfaces.Trasacoes;
using CamadaCore.Context.SharedContext.ViewModels.Outputs;
using Optional.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamadaAplicacao.Context.CadastrosBasicosContext.Servicos.Maquinas
{
    public class ServicoAplicacaoMaquina : ServicoAplicacaoBasico<Maquina, MaquinaInputModel, MaquinaOutputModel, FiltroMaquinasInputModel>,
                                          IServicoAplicacaoMaquina
    {
        private IServicoMaquina _servicoMaquina;
        private IServicoParada _servicoParada;
        private readonly ITransacao _transacao;
        private readonly IMapper _mapper;
        private readonly IRepositorioMaquinaLeitura _repositorioLeituraMaquina;

        public ServicoAplicacaoMaquina(IServicoMaquina servicoMaquina, ITransacao transacao, IRepositorioMaquinaLeitura repositorioLeituraMaquina, IMapper mapper, IServicoParada servicoParada) : base(servicoMaquina, transacao, mapper, repositorioLeituraMaquina)
        {
            _servicoMaquina = servicoMaquina;
            _transacao = transacao;
            _mapper = mapper;
            _repositorioLeituraMaquina = repositorioLeituraMaquina;
            _servicoParada = servicoParada;
        }

        public async Task<IEnumerable<ComboPadraoOutput>> RetornarComboAsync(FiltroMaquinasInputModel filtro)
        {
            var listaCombo = await _repositorioLeituraMaquina.ListarAsync(filtro);


            IEnumerable<MaquinaOutputModel> entidade = listaCombo.Match(
                some: lista => lista,
                none: () =>
                {
                    _servicoMaquina.RetornarNotificacao().Adicionar("Nenhum registro encontrado.");
                    return Enumerable.Empty<MaquinaOutputModel>();
                });

            return entidade.Select(x => new ComboPadraoOutput { id = x.Id, label = x.Nome });
        }

        public async Task AlterarStatusMaquina(AlterarStatusMaquinaInputModel statusMaquina)
        {
            var retorno = await _servicoMaquina.RetornarPorIdAsync(statusMaquina.MaquinaId);

            Maquina maquina = retorno.Match(
                some: lista => lista,
                none: () =>
                {
                    _servicoMaquina.RetornarNotificacao().Adicionar("Registro não encontrado.");
                    return default;
                });

            maquina.Ligada = statusMaquina.Ligada;

            await TransacaoWrapper(() =>
            {
                _servicoMaquina.AlterarStatusMaquina(maquina);
            });

            if (!statusMaquina.Ligada)
            {
                await TransacaoWrapper(() =>
                {
                    _servicoParada.SalvarAsync(new Parada { Id = 0, MaquinaId = statusMaquina.MaquinaId });
                });
            }
        }
    }
}
