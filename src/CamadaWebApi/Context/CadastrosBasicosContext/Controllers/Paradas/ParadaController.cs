using CamadaAplicacao.Context.CadastrosBasicosContext.Interfaces.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Relatorios;
using CamadaCore.Context.SharedContext.ViewModels.Inputs;
using CamadaWebApi.Context.SharedContext.Helpers;
using CamadaWebApi.Context.SharedContext.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CamadaWebApi.Context.CadastrosBasicoContext.Controllers.Paradas
{
    public class ParadaController : CadastrosBaseAbstractController
    {
        private readonly IServicoAplicacaoParada _servicoAplicacaoParada;
        public ParadaController(IServicoAplicacaoParada servicoAplicacaoParada)
        {
            _servicoAplicacaoParada = servicoAplicacaoParada;
        }

        [HttpPost("Salvar")]
        public async Task<IActionResult> Salvar(ParadaInputModel model)
        {
            model.UsuarioId = GetUsuarioID();
            await _servicoAplicacaoParada.SalvarAsync(model);

            if (!_servicoAplicacaoParada.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoParada.RetornarNotificacao().RetornarErros()));

            return Ok();
        }

        [HttpPost("RetornarVarios")]
        [ProducesResponseType(typeof(ParadaOutputModel[]), 200)]
        public async Task<IActionResult> RetornarVarios(FiltroParadasInputModel filtro)
        {
            var Paradas = await _servicoAplicacaoParada.RetornarParadas(filtro);

            if (!_servicoAplicacaoParada.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoParada.RetornarNotificacao().RetornarErros()));

            return Ok(Paradas);
        }

        [HttpPost("RetornarPorId")]
        [ProducesResponseType(typeof(ParadaOutputModel), 200)]
        public async Task<IActionResult> RetornarPorId(ParamIdInput param)
        {
            var Parada = await _servicoAplicacaoParada.RetornarPorIdAsync(param.Id);

            if (!_servicoAplicacaoParada.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoParada.RetornarNotificacao().RetornarErros()));

            return Ok(Parada);
        }

        [HttpDelete("Excluir")]
        public async Task<IActionResult> Excluir(ParadaInputModel model)
        {
            await _servicoAplicacaoParada.ExcluirAsync(model);

            if (!_servicoAplicacaoParada.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoParada.RetornarNotificacao().RetornarErros()));

            return Ok();
        }
        [HttpPost("RetornarTotalTempoParada")]
        [ProducesResponseType(typeof(decimal), 200)]
        public async Task<IActionResult> RetornarTotalTempoParada(FiltroParadasInputModel filtro)
        {
            var Total = await _servicoAplicacaoParada.RetornarTotalTempoParada(filtro);

            if (!_servicoAplicacaoParada.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoParada.RetornarNotificacao().RetornarErros()));

            return Ok(Total);
        }
        [HttpPost("Relatorio")]
        [ProducesResponseType(typeof(RelatorioOutput), 200)]
        public async Task<IActionResult> Relatorio([FromBody] FiltroParadasInputModel filtros)
        {
            var retorno = await _servicoAplicacaoParada.RetornarParadas(filtros);

            var data1 = retorno.Select(x => new ParadaRelatorioOutputModel
            {
                MaquinaNome = x.MaquinaNome,
                TempoParada = x.TempoParada,
                MotivoNome = x.MotivoNome,
                UsuarioNome = x.UsuarioNome,
                PercentualTempoParada = x.PercentualTempoParada
            });

            var estados = data1;
            var retornoRel = new RelatorioOutput();

            var model = estados;
            var colunas = new String[] { "Máquina", "Tempo", "Motivo", "Usuário", "%" };
            var data = new dataRel { subTitulo = "", dados = model };
            var dados = new dataRel[] { data };
            var total = await _servicoAplicacaoParada.RetornarTotalTempoParada(filtros);

            

            retornoRel = RetornoRelatorioHelper.montarRetornoRelatorio("Relatório de Paradas", colunas, dados, total);
            return new JsonResult(retornoRel);
        }
            
    }
}
