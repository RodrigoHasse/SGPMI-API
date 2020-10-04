using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamadaWebApi.Context.SharedContext.Models
{
    public class AppErrorHelper
    {
        public string mensagem { get; set; }
        public string detalheMsg { get; set; }
        public string detalheMsgTecnico { get; set; }
    }
}
