using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CamadaWebApi.Context.SharedContext.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CamadaWebApi.Context.CadastrosBasicoContext.Controllers
{
    [Route("api/cadastros/[controller]")]
    [ApiExplorerSettings(GroupName = "cadastros")]
    public abstract class CadastrosBaseAbstractController : BaseAbstractController
    {
    }
}