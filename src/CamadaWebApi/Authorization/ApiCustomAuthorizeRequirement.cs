using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Controllers;
using CamadaAplicacao.Context.ConfiguracoesContext.Interfaces.Usuarios;

namespace CamadaWebApi.Authorization
{
    public class ApiCustomAuthorizeRequirement : IAuthorizationRequirement
    {
    }

    public class ApiCustomAuthorizeHandler: AuthorizationHandler<ApiCustomAuthorizeRequirement>
    {
        private IServicoAplicacaoUsuario _servicoAplicacaoUsuario;

        public ApiCustomAuthorizeHandler(IServicoAplicacaoUsuario servicoAplicacaoUsuario)
        {
            _servicoAplicacaoUsuario = servicoAplicacaoUsuario;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiCustomAuthorizeRequirement requirement)
        {
            if (context.Resource is AuthorizationFilterContext mvcContext)
            {
                if (mvcContext.ActionDescriptor is ControllerActionDescriptor actionDescriptor)
                {
                    var customAttribute = actionDescriptor
                            .MethodInfo
                            .GetCustomAttributes(true)
                            .OfType<APICustomAuthorizeAttribute>()
                            .FirstOrDefault();

                    if (customAttribute == null)
                    {
                        context.Succeed(requirement);
                    }
                    else
                    {
                        var usuarioId = Convert.ToInt32(context.User.Claims.FirstOrDefault(x => x.Type == "ID").Value);
                        context.Succeed(requirement);
                    }
                }
            }

            //return Task.CompletedTask;
        }
    }
}
