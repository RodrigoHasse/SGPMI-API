using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CamadaWebApi.Context.SharedContext.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "ApiCustomAuthorizePolicy")]
    [ApiExplorerSettings(GroupName = "comum")]
    [ApiController]
    public abstract class BaseAbstractController : ControllerBase
    {
        protected bool CheckRole(string role)
        {
            return HttpContext.User.IsInRole(role);
        }

        protected int GetEmpresaID()
        {
            return int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "EMPRESA")?.Value);
        }

        protected int GetUsuarioID()
        {
            return int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "ID")?.Value);
        }

        protected int GetOrganizacaoID()
        {
            return int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "ORGANIZACAO")?.Value);
        }
    }
}