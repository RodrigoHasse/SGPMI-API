using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamadaWebApi.Authorization
{
    public class APICustomAuthorizeAttribute : Attribute
    {
        public string Programa { get; }
        public string Permissao { get; }

        public APICustomAuthorizeAttribute(string programa, string permissao)
        {
            this.Programa = programa;
            this.Permissao = permissao;
        }
    }
}
