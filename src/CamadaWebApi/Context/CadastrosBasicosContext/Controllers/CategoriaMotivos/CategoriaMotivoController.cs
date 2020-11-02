using CamadaAplicacao.Context.CadastrosBasicosContext.Interfaces.CategoriaMotivos;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.CategoriaMotivo;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.CategoriaMotivo;
using CamadaCore.Context.SharedContext.ViewModels.Inputs;
using CamadaWebApi.Context.SharedContext.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CamadaWebApi.Context.CadastrosBasicoContext.Controllers.CategoriaMotivos
{
    public class CategoriaMotivoController : CadastrosBaseAbstractController
    {
        private readonly IServicoAplicacaoCategoriaMotivo _servicoAplicacaoCategoriaMotivo;
        public CategoriaMotivoController(IServicoAplicacaoCategoriaMotivo servicoAplicacaoCategoriaMotivo)
        {
            _servicoAplicacaoCategoriaMotivo = servicoAplicacaoCategoriaMotivo;
        }

        [HttpPost("Salvar")]
        public async Task<IActionResult> Salvar(CategoriaMotivoInputModel model)
        {
            await _servicoAplicacaoCategoriaMotivo.SalvarAsync(model);

            if (!_servicoAplicacaoCategoriaMotivo.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoCategoriaMotivo.RetornarNotificacao().RetornarErros()));

            return Ok();
        }

        [HttpPost("RetornarVarios")]
        [ProducesResponseType(typeof(CategoriaMotivoOutputModel[]), 200)]
        public async Task<IActionResult> RetornarVarios([FromBody] FiltroCategoriaMotivoInputModel filtro)
        {
            var Motivos = await _servicoAplicacaoCategoriaMotivo.ListarAsync(filtro);

            if (!_servicoAplicacaoCategoriaMotivo.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoCategoriaMotivo.RetornarNotificacao().RetornarErros()));

            return Ok(Motivos);
        }

        [HttpPost("RetornarPorId")]
        [ProducesResponseType(typeof(CategoriaMotivoOutputModel), 200)]
        public async Task<IActionResult> RetornarPorId(ParamIdInput param)
        {
            var categoriaMotivo = await _servicoAplicacaoCategoriaMotivo.RetornarPorIdAsync(param.Id);

            if (!_servicoAplicacaoCategoriaMotivo.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoCategoriaMotivo.RetornarNotificacao().RetornarErros()));

            return Ok(categoriaMotivo);
        }

        [HttpDelete("Excluir")]
        public async Task<IActionResult> Excluir(CategoriaMotivoInputModel model)
        {
            await _servicoAplicacaoCategoriaMotivo.ExcluirAsync(model);

            if (!_servicoAplicacaoCategoriaMotivo.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoCategoriaMotivo.RetornarNotificacao().RetornarErros()));

            return Ok();
        }
    }
}