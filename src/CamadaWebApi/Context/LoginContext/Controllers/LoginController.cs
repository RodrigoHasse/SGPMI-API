using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using CamadaAplicacao.Context.ConfiguracoesContext.Interfaces.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.Models.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.Servicos.Usuarios;
using CamadaCore.Context.ConfiguracoesContext.ViewModels.Outputs.Usuarios;
using CamadaCore.Context.SharedContext.ViewModels.Inputs;
using CamadaCore.Context.SharedContext.ViewModels.Outputs;
using CamadaWebApi.Context.SharedContext.Controllers;
using CamadaWebApi.Context.SharedContext.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CamadaWebApi.Context.LoginContext.Controllers
{
    public class LoginController : BaseAbstractController
    {
        private readonly TokenManagerHelper _tokenManager;
        private readonly IServicoAplicacaoUsuario _servicoAplicacaoUsuario;
        private UsuarioOutputModel _usuario;

        public LoginController(TokenManagerHelper tokenManager, IServicoAplicacaoUsuario servicoAplicacaoUsuario)
        {
            _tokenManager = tokenManager;
            _servicoAplicacaoUsuario = servicoAplicacaoUsuario;
        }

        [HttpGet("TestConnection")]
        public IActionResult TestConnection()
        {
            return Ok("usuario autenticado: empresa:" + GetEmpresaID());
        }

        [HttpGet("TestConnection2")]
        [AllowAnonymous]
        public IActionResult TestConnection2()
        {
            return Ok("teste ok");
        }

        
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(LoginAuthenticationInput model)
        {
            // verifica se login e password foram informados
            if (string.IsNullOrEmpty(model.Login) || string.IsNullOrEmpty(model.Password))
                return BadRequest("Login e password devem ser informados");

            // aqui deveria ser buscado usuario no banco - verificar se login e password existem, ativos, etc;
            _usuario = await _servicoAplicacaoUsuario.RetornarPorUsuarioSenhaAsync(model.Login, model.Password);

            if (_usuario == null)
                return BadRequest("Credenciais inválidas!");

            JwtSecurityToken token = _tokenManager.GetJwtSecurityToken(_usuario.Id, _usuario.Login, "PERFIL", _usuario.Nome);

            return Ok(new LoginAuthenticationOutput { Login = _usuario.Login, Token = token.RawData});
        }
    }
}