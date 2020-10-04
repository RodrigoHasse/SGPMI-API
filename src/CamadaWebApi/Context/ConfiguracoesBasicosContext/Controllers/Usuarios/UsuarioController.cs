using CamadaAplicacao.Context.ConfiguracoesContext.Interfaces.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.ViewModels.Inputs.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.ViewModels.Outputs.Usuarios;
using CamadaCore.Context.SharedContext.ViewModels.Inputs;
using CamadaWebApi.Context.SharedContext.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CamadaWebApi.Context.CadastrosBasicoContext.Controllers.Usuarios
{
    public class UsuarioController : ConfiguracaoBaseAbstractController
    {
        private readonly IServicoAplicacaoUsuario _servicoAplicacaoUsuario;
        public UsuarioController(IServicoAplicacaoUsuario servicoAplicacaoUsuario)
        {
            _servicoAplicacaoUsuario = servicoAplicacaoUsuario;
        }

        [HttpPost("Salvar")]
        public async Task<IActionResult> Salvar(UsuarioInputModel model)
        {
            await _servicoAplicacaoUsuario.SalvarAsync(model);

            if (!_servicoAplicacaoUsuario.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoUsuario.RetornarNotificacao().RetornarErros()));

            return Ok();
        } 

        [HttpPost("RetornarVarios")]
        [ProducesResponseType(typeof(UsuarioOutputModel[]), 200)]
        public async Task<IActionResult> RetornarVarios([FromBody] FiltroUsuariosInputModel filtro)
        {
            var Usuarios = await _servicoAplicacaoUsuario.ListarAsync(filtro);

            if (!_servicoAplicacaoUsuario.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoUsuario.RetornarNotificacao().RetornarErros()));

            return Ok(Usuarios);
        }

        [HttpPost("RetornarPorId")]
        [ProducesResponseType(typeof(UsuarioOutputModel), 200)]
        public async Task<IActionResult> RetornarPorId(ParamIdInput param)
        {
            var Usuario = await _servicoAplicacaoUsuario.RetornarPorIdAsync(param.Id);

            if (!_servicoAplicacaoUsuario.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoUsuario.RetornarNotificacao().RetornarErros()));

            return Ok(Usuario);
        }

        [HttpDelete("Excluir")]
        public async Task<IActionResult> Excluir(UsuarioInputModel model)
        {
            await _servicoAplicacaoUsuario.ExcluirAsync(model);

            if (!_servicoAplicacaoUsuario.RetornarNotificacao().IsValid())
                return BadRequest(error: ErroSistemaHelper.retornarErroDetalhado(null, _servicoAplicacaoUsuario.RetornarNotificacao().RetornarErros()));

            return Ok();
        }
    }
}