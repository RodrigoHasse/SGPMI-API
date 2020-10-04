using CamadaAplicacao.Context.CadastrosBasicosContext.Interfaces.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Paradas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Paradas;
using CamadaCore.Context.SharedContext.ViewModels.Inputs;
using CamadaWebApi.Context.SharedContext.Models;
using Microsoft.AspNetCore.Mvc;
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
            var Paradas = await _servicoAplicacaoParada.ListarAsync(filtro);

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
    }
}