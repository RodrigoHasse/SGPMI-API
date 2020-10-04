using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CamadaWebApi.Context.SharedContext.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CamadaWebApi.Context.CadastrosBasicoContext.Controllers
{
    [Route("api/configuracoes/[controller]")]
    [ApiExplorerSettings(GroupName = "configuracoes")]
    public abstract class ConfiguracaoBaseAbstractController : BaseAbstractController
    {
    }
}