using CamadaAplicacao.Context.CadastrosBasicosContext.Interfaces.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Motivos;
using CamadaCore.Context.SharedContext.ViewModels.Inputs;
using CamadaWebApi.Context.SharedContext.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CamadaWebApi.Context.CadastrosBasicoContext.Controllers.Motivos
{
    public class MotivoController : CadastrosBaseAbstractController
    {
        private readonly IServicoAplicacaoMotivo _servicoAplicacaoMotivo;
        public MotivoController(IServicoAplicacaoMotivo servicoAplicacaoMotivo)
        {
            _servicoAplicacaoMotivo = servicoAplicacaoMotivo;
        }

        [HttpPost("Salvar")]
        public async Task<IActionResult> Salvar(MotivoInputModel model)
        {
            await _servicoAplicacaoMotivo.SalvarAsync(model);

            if (!_servicoAplicacaoMotivo.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoMotivo.RetornarNotificacao().RetornarErros()));

            return Ok();
        }

        [HttpPost("RetornarVarios")]
        [ProducesResponseType(typeof(MotivoOutputModel[]), 200)]
        public async Task<IActionResult> RetornarVarios([FromBody] FiltroMotivosInputModel filtro)
        {
            var Motivos = await _servicoAplicacaoMotivo.ListarAsync(filtro);

            if (!_servicoAplicacaoMotivo.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoMotivo.RetornarNotificacao().RetornarErros()));

            return Ok(Motivos);
        }

        [HttpPost("RetornarPorId")]
        [ProducesResponseType(typeof(MotivoOutputModel), 200)]
        public async Task<IActionResult> RetornarPorId(ParamIdInput param)
        {
            var Motivo = await _servicoAplicacaoMotivo.RetornarPorIdAsync(param.Id);

            if (!_servicoAplicacaoMotivo.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoMotivo.RetornarNotificacao().RetornarErros()));

            return Ok(Motivo);
        }

        [HttpDelete("Excluir")]
        public async Task<IActionResult> Excluir(MotivoInputModel model)
        {
            await _servicoAplicacaoMotivo.ExcluirAsync(model);

            if (!_servicoAplicacaoMotivo.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoMotivo.RetornarNotificacao().RetornarErros()));

            return Ok();
        }
    }
}