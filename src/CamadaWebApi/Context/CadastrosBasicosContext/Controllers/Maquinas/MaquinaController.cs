using CamadaAplicacao.Context.CadastrosBasicosContext.Interfaces.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Maquinas;
using CamadaCore.Context.SharedContext.ViewModels.Inputs;
using CamadaWebApi.Context.SharedContext.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CamadaWebApi.Context.CadastrosBasicoContext.Controllers.Maquinas
{
    public class MaquinaController : CadastrosBaseAbstractController
    {
        private readonly IServicoAplicacaoMaquina _servicoAplicacaoMaquina;
        public MaquinaController(IServicoAplicacaoMaquina servicoAplicacaoMaquina)
        {
            _servicoAplicacaoMaquina = servicoAplicacaoMaquina;
        }

        [HttpPost("Salvar")]
        public async Task<IActionResult> Salvar(MaquinaInputModel model)
        {
            await _servicoAplicacaoMaquina.SalvarAsync(model);

            if (!_servicoAplicacaoMaquina.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoMaquina.RetornarNotificacao().RetornarErros()));

            return Ok();
        } 

        [HttpPost("RetornarVarios")]
        [ProducesResponseType(typeof(MaquinaOutputModel[]), 200)]
        public async Task<IActionResult> RetornarVarios([FromBody] FiltroMaquinasInputModel filtro)
        {
            var maquinas = await _servicoAplicacaoMaquina.ListarAsync(filtro);

            if (!_servicoAplicacaoMaquina.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoMaquina.RetornarNotificacao().RetornarErros()));

            return Ok(maquinas);
        }

        [HttpPost("RetornarPorId")]
        [ProducesResponseType(typeof(MaquinaOutputModel), 200)]
        public async Task<IActionResult> RetornarPorId(ParamIdInput param)
        {
            var maquina = await _servicoAplicacaoMaquina.RetornarPorIdAsync(param.Id);

            if (!_servicoAplicacaoMaquina.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoMaquina.RetornarNotificacao().RetornarErros()));

            return Ok(maquina);
        }

        [HttpDelete("Excluir")]
        public async Task<IActionResult> Excluir(MaquinaInputModel model)
        {
            await _servicoAplicacaoMaquina.ExcluirAsync(model);

            if (!_servicoAplicacaoMaquina.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoMaquina.RetornarNotificacao().RetornarErros()));

            return Ok();
        }

        [HttpPost("AlterarStatusMaquina")]
        public async Task<IActionResult> AlterarStatusMaquina(AlterarStatusMaquinaInputModel model)
        {
            await _servicoAplicacaoMaquina.AlterarStatusMaquina(model);

            if (!_servicoAplicacaoMaquina.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoMaquina.RetornarNotificacao().RetornarErros()));

            return Ok();
        }

        [HttpPost("RetornaVariosAppAsync")]
        public async Task<IActionResult> RetornaVariosAppAsync()
        {
            var maquinas = await _servicoAplicacaoMaquina.RetornaVariosAppAsync();

            if (!_servicoAplicacaoMaquina.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoMaquina.RetornarNotificacao().RetornarErros()));

            return Ok(maquinas);
        }
    }
}